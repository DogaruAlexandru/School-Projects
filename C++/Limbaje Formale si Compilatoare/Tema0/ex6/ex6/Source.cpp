#include <iostream>
#include <string>
#include <vector>

void Read(std::string& word)
{
	std::cout << "Introduceti un cuvant: ";
	std::cin >> word;
}

void CreatePrefix(const std::string& word, std::vector<std::string>& prefixes)
{
	prefixes.reserve(word.size() - 1);
	for (int index = 1; index < word.size(); ++index)
		prefixes.push_back(word.substr(0, index));
}

void Write(const std::vector<std::string>& words)
{
	for (std::string word : words)
		std::cout << word << '\n';
}

int main()
{
	std::string word;
	Read(word);
	std::vector<std::string> prefixes;
	CreatePrefix(word, prefixes);
	Write(prefixes);
	return 0;
}