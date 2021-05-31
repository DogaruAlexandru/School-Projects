#include <iostream>
#include <string>
#include <vector>

//void GetWords(const std::string& text, std::vector<std::string>& words)
//{
//	const std::string delimiters = " ,.;:?!";
//	unsigned int begin, end;
//	for (begin = 0; begin < text.size(); ++begin)
//		if (delimiters.find(text[begin]) == std::string::npos)
//			for (end = begin + 1; end < text.size(); ++end)
//				if (delimiters.find(text[end]) != std::string::npos)
//				{
//					words.push_back(text.substr(begin, end - begin));
//					begin = end;
//					break;
//				}
//}

void GetWords(char str[], std::vector<std::string>& words)
{
	char* token, * nextToken = nullptr;
	char delimiters[] = " ,.;:?!";
	token = strtok_s(str, delimiters, &nextToken);
	while (token != nullptr)
	{
		words.push_back(token);
		token = strtok_s(nullptr, delimiters, &nextToken);
	}
}

void Write(std::vector<std::string>& words)
{
	for (unsigned int index = 0; index < words.size(); ++index)
		std::cout << index + 1 << ". " << words[index] << '\n';
}

int main()
{
	//std::string text = "Ce cuvinte sunt in fraza? Determina!!";
	char text[] = "Ce cuvinte sunt in fraza? Determina!!";
	std::vector<std::string> words;
	GetWords(text, words);
	Write(words);
	return 0;
}