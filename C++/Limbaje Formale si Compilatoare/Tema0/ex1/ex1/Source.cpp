#include <iostream>
#include <string>

int Count(const std::string& text, const char character)
{
	int contor = 0;
	for (char c : text)
		if (c == character)
			++contor;
	return contor;
}

int main()
{
	std::string text = "Mihai a mers la magazin.";
	char character = 'i';
	std::cout << character << " apare de " << Count(text, character) << " ori";
	return 0;
}