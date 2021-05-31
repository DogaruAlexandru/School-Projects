#include <iostream>
#include "LexicalAnalyzer.h"

int main()
{
	LexicalAnalyzer lexer;
	auto [tokens, identifiers, errors] = lexer.ParseFile("in.txt");

	std::cout << "Tokens:\n";
	for (auto& token : tokens)
		std::cout << "< " << LexicalAnalyzer::toString(token.first) << ", " << token.second << " >" << std::endl;

	std::cout << "\nIdentifiers:\n";
	for (auto& identifier : identifiers)
		std::cout << identifier << '\n';

	std::cout << "\nErrors:\n";
	for (auto& error : errors)
	{
		auto& [lineNumber, tokenType, string] = error;
		std::cout << "Line: " << lineNumber << " - Token: " << LexicalAnalyzer::toString(tokenType) << " - " << string << '\n';
	}

	return 0;
}