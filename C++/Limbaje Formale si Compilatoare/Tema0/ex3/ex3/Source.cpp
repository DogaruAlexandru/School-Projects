#include <iostream>
#include <string>

void Invert(std::string& text)
{
	std::reverse(text.begin(), text.end());
}

void Replace(std::string& text, std::string& remove, std::string& replacer)
{
	int aux = text.find(remove);
	while (aux != std::string::npos)
	{
		text.replace(aux, remove.size(), replacer);
		aux = text.find(remove);
	}
}

int main()
{
	std::string text = "Mihai a mers la magazin sa cumpere mandarine.";
	std::string remove = "am";
	std::string replacer = "#####";
	std::cout << text << '\n';
	Invert(text);
	std::cout << text << '\n';
	Replace(text, remove, replacer);
	std::cout << text << '\n';
	return 0;
}