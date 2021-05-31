#include <iostream>
#include <fstream>
#include "AFN.h"

void ReadFile(AFN& myAFN, const std::string& filePath)
{
	std::ifstream file(filePath);
	if (file.is_open())
	{
		file >> myAFN;
		file.close();
	}
	else
		throw "File not open!";
}

void verifyWords(const AFN& myAFN)
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
	//	myAFN.WordVerification(word);
	//	std::cout << '\n';
	//}

	char ver; std::string word;
	std::cout << "For word verifying use 1: ";
	std::cin >> ver;
	while (ver == '1')
	{
		std::cout << "Enter the words:\n";
		std::cin >> word;
		myAFN.WordVerification(word);
		std::cout << '\n';
		std::cout << "For word verifying use 1: ";
		std::cin >> ver;
	}
}

int main()
{
	AFN myAFN;
	ReadFile(myAFN, "in.txt");
	if (!myAFN.AFNVerification())
		std::cout << "Invalid AFN!";
	else
	{
		std::cout << myAFN << '\n';
		verifyWords(myAFN);
	}
	return 0;
}