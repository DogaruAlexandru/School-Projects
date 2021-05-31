#pragma once

#include <vector>
#include "Production.h"

class GenerativeGrammar
{
public:
	GenerativeGrammar();
	GenerativeGrammar(const std::vector<char>&, const std::vector<char>&, const char, const std::vector<Production>&);
	GenerativeGrammar(const GenerativeGrammar&);
	~GenerativeGrammar();
	GenerativeGrammar& operator=(const GenerativeGrammar&);
	bool Verification();
	void Generate(bool);
	friend std::ostream& operator<<(std::ostream&, const GenerativeGrammar&);
	friend std::istream& operator>>(std::istream&, GenerativeGrammar&);

private:
	bool VerificationIntersectionVNAndVT();
	bool VerificationStartInVN();
	bool VerificationLeftMemberHasNonterminal();
	bool VerificationProductionWithStartOnly();
	bool VerificationVNAndVTAnd$ElementsOnly();
	void FindApplicableProductions(const std::string&, std::vector<uint8_t>&);
	void UseProduction(const uint8_t, std::string&);
	bool VerificationTerminalsOnly(const std::string&);

	std::vector<char> m_VN;
	std::vector<char> m_VT;
	char m_start;
	std::vector<Production> m_productions;
};

