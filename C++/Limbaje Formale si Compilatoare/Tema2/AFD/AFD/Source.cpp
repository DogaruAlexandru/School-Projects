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

void verifyWords(const AFD& myAFD)
{
	//uint16_t numberWords;
	//std::string word;
	//std::cout << "Enter the number of words to check: ";
	//std::cin >> numberWords;
	//std::cout << "Enter the words:\n";
	//for (uint16_t index = 0; index < numberWords; ++index)
	//{
	//	std::cout << index + 1 << ". ";
	//	std::cin >> word;
	//	myAFD.WordVerification(word);
	//	std::cout << '\n';
	//}

	char ver; std::string word;
	std::cout << "For word verifying use 1: ";
	std::cin >> ver;
	while (ver == '1')
	{
		std::cout << "Enter the words:\n";
		std::cin >> word;
		myAFD.WordVerification(word);
		std::cout << '\n';
		std::cout << "For word verifying use 1: ";
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
		std::cout << myAFD << '\n';
		verifyWords(myAFD);
	}
	return 0;
}