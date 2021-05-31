#pragma once

#include <cstdint>
#include <iostream>
#include <vector>
#include <queue>
#include <list>

class Graph
{
public:
	struct Vertice
	{
		uint16_t node1;
		uint16_t node2;
		uint16_t value;

		bool operator()(Vertice a, Vertice b)
		{
			return a.value < b.value;
		}
	};

public:
	Graph() = default;
	Graph(Graph const&) = default;
	Graph& operator=(Graph const&) = default;
	Graph(Graph&&) = default;
	Graph& operator=(Graph&&) = default;
	~Graph() = default;

	uint32_t Kruskal();
	uint32_t Prim();

	friend std::ostream& operator<<(std::ostream&, const Graph&);
	friend std::istream& operator>>(std::istream&, Graph&);

private:
	uint16_t m_numberNodes = 0;
	std::vector<Vertice> m_vertices;
};

