#include "Graph.h"

std::ostream& operator<<(std::ostream& stream, const Graph& object)
{
	stream << object.m_numberNodes << '\n';
	for (auto& v : object.m_vertices)
		stream << v.node1 << ' ' << v.node2 << ' ' << v.value << '\n';
	return stream;
}

std::istream& operator>>(std::istream& stream, Graph& object)
{
	stream >> object.m_numberNodes;
	stream.get();
	Graph::Vertice vertice;
	while (stream.peek() != EOF && stream.peek() != '\n')
	{
		stream >> vertice.node1 >> vertice.node2 >> vertice.value;
		object.m_vertices.push_back(vertice);
		stream.get();
	}
	return stream;
}

uint32_t Graph::Kruskal()
{
	std::sort(m_vertices.begin(), m_vertices.end(), Vertice());

	uint32_t totalValue = 0;
	std::vector<Vertice> vertices;
	std::vector<std::pair<uint16_t, std::list<uint16_t>>> components;
	components.resize(m_numberNodes);

	for (uint16_t index = 0; index < components.size(); ++index)
	{
		components[index].first = index;
		components[index].second.push_back(index + 1);
	}
	for (auto& v : m_vertices)
		if (components[v.node1 - 1].first != components[v.node2 - 1].first)
		{
			uint16_t indexNode1 = components[v.node1 - 1].first;
			uint16_t indexNode2 = components[v.node2 - 1].first;
			if (components[indexNode1].second.size() < components[indexNode2].second.size())
				std::swap(indexNode1, indexNode2);

			for (auto& n : components[indexNode2].second)
				components[n - 1].first = indexNode1;
			components[indexNode1].second.insert(components[indexNode1].second.end(),
				components[indexNode2].second.begin(), components[indexNode2].second.end());
			components[indexNode2].second.clear();

			vertices.push_back(v);
			totalValue += v.value;
			if (vertices.size() == m_numberNodes - 1)
				break;
		}

	m_vertices = vertices;
	return totalValue;
}

uint32_t Graph::Prim()
{
	uint32_t totalValue = 0;
	std::vector<Vertice> vertices;
	std::vector<bool> visited;
	visited.resize(m_numberNodes);

	visited[0] = true;

	for (uint16_t index1 = 1; index1 < m_numberNodes; ++index1)
	{
		uint16_t minimumIndex = -1;
		uint16_t minimum = UINT16_MAX;
		for (uint16_t index2 = 0; index2 < m_vertices.size(); ++index2)
		{
			if (visited[m_vertices[index2].node1 - 1] != visited[m_vertices[index2].node2 - 1] && minimum > m_vertices[index2].value)
			{
				minimumIndex = index2;
				minimum = m_vertices[index2].value;
			}
		}
		totalValue += minimum;
		vertices.push_back(m_vertices[minimumIndex]);
		if (visited[m_vertices[minimumIndex].node1 - 1])
			visited[m_vertices[minimumIndex].node2 - 1] = true;
		else
			visited[m_vertices[minimumIndex].node1 - 1] = true;
	}

	m_vertices = vertices;
	return totalValue;
}