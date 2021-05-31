#include <iostream>
#include <string>
#include <fstream>
#include <vector>

void Read(const std::string& filePath, std::vector<std::string>& words)
{
	std::ifstream file(filePath);
	std::string word;
	if (file.is_open())
	{
		while (file >> word)
			words.push_back(word);
		file.close();
	}
	else
		throw "File not open";
}

void FindWordsWithSubString(const std::vector<std::string>& words, const std::string& subString, std::vector<std::string>& wordsWithSubString)
{
	for (std::string word : words)
		if (word.find(subString) != std::string::npos)
			wordsWithSubString.push_back(word);
}

void Write(const std::vector<std::string>& words)
{
	for (std::string word : words)
		std::cout << word << '\n';
}

int main()
{
	std::vector<std::string> words;
	Read("in.txt", words);
	std::string subString("qwe");
	std::vector<std::string> wordsWithSubString;
	FindWordsWithSubString(words, subString, wordsWithSubString);
	Write(words);
	std::cout << '\n';
	Write(wordsWithSubString);
	return 0;
}