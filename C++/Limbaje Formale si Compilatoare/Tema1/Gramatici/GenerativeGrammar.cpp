#include "GenerativeGrammar.h"
#include <iostream>
#include <cstdint>
#include <cstdio>
#include <algorithm>
#include <cstdlib>
#include <ctime>

GenerativeGrammar::GenerativeGrammar()
{
	srand(time(NULL));
}

GenerativeGrammar::GenerativeGrammar(const std::vector<char>& VN, const std::vector<char>& VT,
	const char start, const std::vector<Production>& productions)
{
	srand(time(NULL));
	m_VN = VN;
	m_VT = VT;
	m_start = start;
	m_productions = productions;
}

GenerativeGrammar::GenerativeGrammar(const GenerativeGrammar& other)
{
	*this = other;
}

GenerativeGrammar::~GenerativeGrammar()
{
}

GenerativeGrammar& GenerativeGrammar::operator=(const GenerativeGrammar& other)
{
	m_VN = other.m_VN;
	m_VT = other.m_VT;
	m_start = other.m_start;
	m_productions = other.m_productions;
	return *this;
}

bool GenerativeGrammar::Verification()
{
	if (!VerificationIntersectionVNAndVT() && VerificationStartInVN() && VerificationLeftMemberHasNonterminal() &&
		VerificationProductionWithStartOnly() && VerificationVNAndVTAnd$ElementsOnly())
		return true;
	return false;
}

void GenerativeGrammar::Generate(bool option = 0)
{
	std::vector<uint8_t> applicable;
	uint8_t apply;
	int aux;
	applicable.reserve(m_productions.size());
	std::string word;
	word.push_back(m_start);
	if (option == 1)
		std::cout << m_start;
	while (true)
	{
		FindApplicableProductions(word, applicable);
		if (applicable.size() == 0)
			break;
		apply = rand() % applicable.size();
		if (option == 1)
			std::cout << " (" << applicable[apply] + 1 << ")=> ";
		UseProduction(applicable[apply], word);
		if (option == 1)
		{
			aux = word.find('$');
			std::cout << word;
			if (word.size() != 1 && aux != std::string::npos)
			{
				word.erase(aux, 1);
				std::cout << " => " << word;
			}
		}
		applicable.clear();
	}
	if (option == 0)
		std::cout << word;
	//if (VerificationTerminalsOnly(word))
	//	std::cout << " (Nu contine terminale)";
	//else
	//	std::cout << " (Contine terminale)";
}

bool GenerativeGrammar::VerificationIntersectionVNAndVT()
{
	uint8_t index1, index2;
	for (index1 = 0; index1 < m_VN.size(); ++index1)
		for (index2 = 0; index2 < m_VT.size(); ++index2)
			if (m_VN[index1] == m_VT[index2])
				return true;
	return false;
}

bool GenerativeGrammar::VerificationStartInVN()
{
	for (uint8_t index = 0; index < m_VN.size(); ++index)
		if (m_VN[index] == m_start)
			return true;
	return false;
}

bool GenerativeGrammar::VerificationLeftMemberHasNonterminal()
{
	uint8_t index1, index2;
	bool ok;
	for (index1 = 0; index1 < m_productions.size(); ++index1)
	{
		ok = false;
		for (index2 = 0; index2 < m_VN.size() && ok == false; ++index2)
			if (m_productions[index1].leftMember.find(m_VN[index2]) != std::string::npos)
				ok = true;
		if (ok == false)
			return false;
	}
	return true;
}

bool GenerativeGrammar::VerificationProductionWithStartOnly()
{
	for (uint8_t index1 = 0; index1 < m_productions.size(); ++index1)
		if (m_productions[index1].leftMember.size() == 1 && m_productions[index1].leftMember[0] == m_start)
			return true;
	return false;
}

bool GenerativeGrammar::VerificationVNAndVTAnd$ElementsOnly()
{
	uint8_t index1, index2;
	for (index1 = 0; index1 < m_productions.size(); ++index1)
	{
		for (index2 = 0; index2 < m_productions[index1].leftMember.size(); ++index2)
			if (std::find(m_VN.begin(), m_VN.end(), m_productions[index1].leftMember[index2]) == m_VN.end() &&
				std::find(m_VT.begin(), m_VT.end(), m_productions[index1].leftMember[index2]) == m_VT.end() &&
				m_productions[index1].leftMember[index2] != '$')
				return false;
		for (index2 = 0; index2 < m_productions[index1].rightMember.size(); ++index2)
			if (std::find(m_VN.begin(), m_VN.end(), m_productions[index1].rightMember[index2]) == m_VN.end() &&
				std::find(m_VT.begin(), m_VT.end(), m_productions[index1].rightMember[index2]) == m_VT.end() &&
				m_productions[index1].rightMember[index2] != '$')
				return false;
	}
	return true;
}

void GenerativeGrammar::FindApplicableProductions(const std::string& word, std::vector<uint8_t>& applicable)
{
	for (uint8_t index = 0; index < m_productions.size(); ++index)
		if (word.find(m_productions[index].leftMember) != std::string::npos)
			applicable.push_back(index);
}

void GenerativeGrammar::UseProduction(const uint8_t productionNumber, std::string& word)
{
	uint8_t aux = word.find(m_productions[productionNumber].leftMember);
	word.replace(aux, m_productions[productionNumber].leftMember.size(), m_productions[productionNumber].rightMember);
}

bool GenerativeGrammar::VerificationTerminalsOnly(const std::string& word)
{
	for (uint8_t index = 0; index < m_VN.size(); ++index)
		if (word.find(m_VN[index]) != std::string::npos)
			return false;
	return true;
}

std::ostream& operator<<(std::ostream& stream, const GenerativeGrammar& object)
{
	stream << "(VN, VT, " << object.m_start << ", P)\n";
	stream << "VN = {";
	for (uint8_t index = 0; index < object.m_VN.size() - 1; ++index)
		stream << object.m_VN[index] << ", ";
	stream << object.m_VN[object.m_VN.size() - 1];
	stream << "}\n";
	stream << "VT = {";
	for (uint8_t index = 0; index < object.m_VT.size() - 1; ++index)
		stream << object.m_VT[index] << ", ";
	stream << object.m_VT[object.m_VT.size() - 1];
	stream << "}\n";
	stream << "P:\n";
	for (uint8_t index = 0; index < object.m_productions.size(); ++index)
		stream << index + 1 << ")  " << object.m_productions[index].leftMember
		<< " -> " << object.m_productions[index].rightMember << '\n';
	return stream;
}

std::istream& operator>>(std::istream& stream, GenerativeGrammar& object)
{
	char aux;
	do
	{
		stream >> aux;
		if (aux != ' ')
			object.m_VN.push_back(aux);

	} while (stream.peek() != '\n');
	stream.get();
	do
	{
		stream >> aux;
		if (aux != ' ')
			object.m_VT.push_back(aux);

	} while (stream.peek() != '\n');
	stream.get();
	stream >> object.m_start;
	unsigned int size;
	stream >> size;
	object.m_productions.resize(size);
	std::string string;
	for (uint8_t index = 0; index < size; ++index)
	{
		stream >> string;
		object.m_productions[index].leftMember = string;
		stream >> string;
		object.m_productions[index].rightMember = string;
	}
	return stream;
}
