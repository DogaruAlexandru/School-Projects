#include <iostream>
#include <fstream>
#include "AFD.h"

void ReadFile(AFD& myAFD, const std::string& filePath)
{
	std::ifstream file(filePath);
	if (file.is_open())
	{
		file >> myAFD;
		file.close();
	}
	else
		throw "File not open!";
}

void WriteFile(const AFD& myAFD, const std::string& filePath)
{
	std::ofstream file(filePath);
	if (file.is_open())
	{
		file << myAFD;
		file.close();
	}
	else
		throw "File not open!";
}

void verifyWords(const AFD& myAFD)
{
	char ver; std::string word;
	std::cout << "For word verifying use 1: ";
	std::cin >> ver;
	while (ver == '1')
	{
		std::cout << "Enter the word:\n";
		std::cin >> word;
		myAFD.WordVerification(word);
		std::cout << '\n';
		std::cout << "For close use 1 else continue: ";
		std::cin >> ver;
	}
}

int main()
{
	AFD myAFD;
	ReadFile(myAFD, "in.txt");
	if (!myAFD.AFDVerification())
		std::cout << "Invalid AFD!";
	else
	{
		std::cout << myAFD << "\n\n\n";
		myAFD.Minimize();
		WriteFile(myAFD, "out.txt");
		std::cout << myAFD << '\n';
		verifyWords(myAFD);
	}
	return 0;
}