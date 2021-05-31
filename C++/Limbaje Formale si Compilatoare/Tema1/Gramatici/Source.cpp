#include <iostream>
#include <fstream>
#include "GenerativeGrammar.h"

void ReadFile(GenerativeGrammar& generativeGrammar, const std::string& filePath)
{
	std::ifstream file(filePath);
	if (file.is_open())
	{
		file >> generativeGrammar;
		file.close();
	}
	else
		throw "File not open";
}

void GenerateWords(GenerativeGrammar& generativeGrammar)
{
	int number;
	bool option;
	std::cout << "Introducti cate cuvinte sa generati: ";
	std::cin >> number;
	std::cout << "Introducti 0 pentru a afisa doar cuvintele sau 1 pentru pasii intrermediari: ";
	std::cin >> option;
	for (int index = 0; index < number; ++index)
	{
		std::cout << '\n' << index + 1 << ")  ";
		generativeGrammar.Generate(option);
	}
	std::cout << '\n';
}

int main()
{
	GenerativeGrammar generativeGrammar;
	ReadFile(generativeGrammar, "in.txt");
	if (generativeGrammar.Verification()==false)
		std::cout << "Gramatica nu este corecta!";
	else
	{
		std::cout << generativeGrammar;
		GenerateWords(generativeGrammar);
	}
	return 0;
}