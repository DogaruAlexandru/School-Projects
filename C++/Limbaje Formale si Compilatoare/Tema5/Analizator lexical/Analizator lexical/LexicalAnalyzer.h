#pragma once

#include <cstdint>
#include <string>
#include <fstream>
#include <iostream>
#include <vector>
#include <utility>
#include <unordered_set>
#include "DFA.h"

class LexicalAnalyzer
{
public:
	enum class TokenType : uint8_t
	{
		Undefined,
		Identifier,
		Number,
		Keyword,
		ArithmeticOperator,
		RelationalOperator,
		Bracket,
		AssignmentOperator,
		Separator
	};
	using Tokens = std::vector<std::pair<LexicalAnalyzer::TokenType, std::string>>;
	using Errors = std::vector<std::tuple<uint32_t, TokenType, std::string>>;

public:
	LexicalAnalyzer();
	LexicalAnalyzer(LexicalAnalyzer const&) = default;
	LexicalAnalyzer& operator=(LexicalAnalyzer const&) = default;
	LexicalAnalyzer(LexicalAnalyzer&&) = default;
	LexicalAnalyzer& operator=(LexicalAnalyzer&&) = default;
	~LexicalAnalyzer() = default;

	const std::tuple<Tokens, std::unordered_set<std::string>, Errors> ParseFile(const std::string&) const;
	static const std::string toString(const TokenType& tokenType);

private:
	void Load(DFA& dfa, const std::string&);
	const std::string IsKeyword(const std::string&, const uint32_t) const;
	bool UseDFA(const DFA&, TokenType, const uint32_t, const std::string&, uint32_t&, Tokens&, Errors&) const;

	DFA m_dfaNumber;
	DFA m_dfaIdentifier;
	DFA m_dfaArithmeticOperator;
	DFA m_dfaRelationalOperator;
	DFA m_dfaBracket;
	DFA m_dfaAssignmentOperator;
	DFA m_dfaSeparator;
	std::unordered_set<std::string> m_keywords;
};

