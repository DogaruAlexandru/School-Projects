#include "LexicalAnalyzer.h"

LexicalAnalyzer::LexicalAnalyzer()
{
	Load(m_dfaNumber, "DFA_Number.txt");
	Load(m_dfaIdentifier, "DFA_Identifier.txt");
	Load(m_dfaArithmeticOperator, "DFA_ArithmeticOperator.txt");
	Load(m_dfaRelationalOperator, "DFA_RelationalOperator.txt");
	Load(m_dfaAssignmentOperator, "DFA_AssignmentOperator.txt");
	Load(m_dfaBracket, "DFA_Bracket.txt");
	Load(m_dfaSeparator, "DFA_Separator.txt");

	std::ifstream file("keywords.txt");
	if (file.is_open())
	{
		std::string keyword;
		while (getline(file, keyword))
		{
			m_keywords.insert(keyword);
		}
	}
	else
		std::cout << "keywords.txt did not open!";
}

const std::tuple<LexicalAnalyzer::Tokens, std::unordered_set<std::string>,
	LexicalAnalyzer::Errors> LexicalAnalyzer::ParseFile(const std::string& path) const
{
	std::ifstream file(path);
	if (!file.is_open())
	{
		std::cout << path << " did not open!";
		return {};
	}

	Tokens tokens;
	std::unordered_set<std::string> identifiers;
	Errors errors;

	std::string line;

	uint32_t lineNumber = 0;
	while (getline(file, line))
	{
		for (uint32_t index = 0; index < line.size(); ++index)
		{
			while (line[index] == ' ' || line[index] == 9 || line[index] == 46)
				++index;
			if (index == line.size())
				break;

			if (line.size() - index > 2 && line[index] == '/' && line[index + 1] == '/')
				break;

			std::string keyword = IsKeyword(line, index);

			auto [accepted, identifier] = m_dfaIdentifier.Run(line, index);

			if (!identifier.empty())
			{
				if (keyword == identifier)
					tokens.push_back({ TokenType::Keyword, keyword });
				else if (accepted)
				{
					tokens.push_back({ TokenType::Identifier, identifier });
					if (identifiers.find(identifier) == identifiers.end())
						identifiers.insert(identifier);
				}
				else
					errors.push_back({ lineNumber, TokenType::Identifier, identifier });
				index += identifier.size() - 1;
				continue;
			}
			else
			{
				if (UseDFA(m_dfaArithmeticOperator, TokenType::ArithmeticOperator, lineNumber, line, index, tokens, errors))
					continue;
				else if (UseDFA(m_dfaNumber, TokenType::Number, lineNumber, line, index, tokens, errors))
					continue;
				else if (UseDFA(m_dfaAssignmentOperator, TokenType::AssignmentOperator, lineNumber, line, index, tokens, errors))
					continue;
				else if (UseDFA(m_dfaRelationalOperator, TokenType::RelationalOperator, lineNumber, line, index, tokens, errors))
					continue;
				else if (UseDFA(m_dfaBracket, TokenType::Bracket, lineNumber, line, index, tokens, errors))
					continue;
				else if (UseDFA(m_dfaSeparator, TokenType::Separator, lineNumber, line, index, tokens, errors))
					continue;
			}

			errors.push_back({ lineNumber, TokenType::Undefined,std::string(1, line[index]) });
		}
		++lineNumber;
	}

	file.close();
	return { tokens, identifiers, errors };
}

const std::string LexicalAnalyzer::toString(const TokenType& tokenType)
{
	switch (tokenType)
	{
	case TokenType::Undefined: return "Undefined";
	case TokenType::ArithmeticOperator: return "ArithmeticOperator";
	case TokenType::AssignmentOperator: return "AssignmentOperator";
	case TokenType::RelationalOperator: return "RelationalOperator";
	case TokenType::Bracket: return "Bracket";
	case TokenType::Identifier: return "Identifier";
	case TokenType::Number: return "Number";
	case TokenType::Keyword: return "Keyword";
	case TokenType::Separator: return "Separator";
	default:
		return {};
	}
}

void LexicalAnalyzer::Load(DFA& dfa, const std::string& path)
{
	std::ifstream file(path);
	if (!file.is_open())
	{
		std::cout << path << " did not open!";
		return;
	}
	file >> dfa;
	file.close();
	dfa.AFDVerification();
}

const std::string LexicalAnalyzer::IsKeyword(const std::string& line, const uint32_t lineIndex) const
{
	for (auto& word : m_keywords)
	{
		if (line.find(word, lineIndex) == lineIndex)
			return word;
	}
	return std::string{ "" };
}

bool LexicalAnalyzer::UseDFA(const DFA& dfa, TokenType token, const uint32_t lineNumber,
	const std::string& line, uint32_t& lineIndex, Tokens& tokens, Errors& errors) const
{
	auto [accepted, string] = dfa.Run(line, lineIndex);
	if (!string.empty())
	{
		if (accepted)
			tokens.push_back({ token, string });
		else
			errors.push_back({ lineNumber, token, string });
		lineIndex += string.size() - 1;
		return true;
	}
	return false;
}

