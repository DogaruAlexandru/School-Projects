#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

void Read(std::vector<std::string>& words)
{
	int size;
	std::string word;
	std::cout << "Introduceti numarul de cuvinte: ";
	std::cin >> size;
	words.reserve(size);
	std::cout << "Introduceti cuvintele:\n";;
	for (int index = 0; index < size; ++index)
	{
		std::cin >> word;
		words.push_back(word);
	}
}

void Write(const std::vector<std::string>& words)
{
	std::cout << '\n';
	for (std::string word : words)
		std::cout << word << '\n';
}

int main()
{
	std::vector<std::string> words;
	Read(words);
	std::sort(words.begin(), words.end());
	Write(words);
	return 0;
}