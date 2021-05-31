#include <iostream>
#include <fstream>
#include "Graph.h"

void ReadFile(Graph& graph, const std::string& filePath)
{
	std::ifstream file(filePath);
	if (file.is_open())
	{
		file >> graph;
		file.close();
	}
	else
		throw "File not open!";
}

int main()
{
	Graph graph1;
	ReadFile(graph1, "in.txt");
	Graph graph2 = graph1;
	std::cout << graph1 << '\n';
	std::cout << "Prim:\nValue: " << graph1.Prim() << '\n' << graph1 << "\n";
	std::cout << "Kruskal:\nValue: " << graph2.Kruskal() << '\n' << graph2;
	return 0;
}
