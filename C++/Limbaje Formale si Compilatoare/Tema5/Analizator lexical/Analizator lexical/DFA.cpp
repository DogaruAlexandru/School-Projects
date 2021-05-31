#include "DFA.h"
#include <iostream>
#include <cstdint>
#include <iomanip>

const void DFA::WordVerification(const std::string& word) const
{
	std::string currentState = m_initialState;
	for (uint8_t index = 0; index < word.size(); ++index)
	{
		if (IsUsableTransition(currentState, word[index]))
			currentState = m_delta.at({ currentState, word[index] });
		else
		{
			std::cout << "Blocked!\n";
			return;
		}
	}
	if (VerifyStateInFinaleStates(currentState))
		std::cout << "Accepted!\n";
	else
		std::cout << "Unaccepted!\n";
}

std::pair<bool, std::string> DFA::Run(const std::string& line, const uint32_t lineIndex) const
{
	std::string currentState = m_initialState;
	for (uint8_t index = lineIndex; index < line.size(); ++index)
	{
		if (IsUsableTransition(currentState, line[index]))
			currentState = m_delta.at({ currentState, line[index] });
		else
			return { VerifyStateInFinaleStates(currentState), line.substr(lineIndex, index - lineIndex) };
	}
	return { VerifyStateInFinaleStates(currentState),	line.substr(lineIndex) };
}

bool DFA::IsUsableTransition(const std::string& state, const char letter) const
{
	if (m_delta.find({ state, letter }) == m_delta.end())
		return false;
	return true;
}

bool DFA::VerifyStateInFinaleStates(const std::string& searched) const
{
	for (auto& finaleState : m_finaleStates)
		if (searched == finaleState)
			return true;
	return false;
}

bool DFA::VerifyBeginStateInStates() const
{
	for (auto& transition : m_delta)
		if (m_states.find(transition.first.first) == m_states.end())
			return false;
	return true;
}

bool DFA::VerifyLetterUsedInSigma() const
{
	for (auto& transition : m_delta)
		if (m_sigma.find(transition.first.second) == m_sigma.end())
			return false;
	return true;
}

bool DFA::VerifyEndStateInStates() const
{
	for (auto& transition : m_delta)
		if (m_states.find(transition.second) == m_states.end())
			return false;
	return true;
}

bool DFA::VerifyDelta() const
{
	return VerifyBeginStateInStates() && VerifyLetterUsedInSigma() && VerifyEndStateInStates();
}

bool DFA::VerifyInitialStateInStates() const
{
	for (auto& state : m_states)
		if (state == m_initialState)
			return true;
	return false;
}

bool DFA::VerifyFinaleStatesInStates() const
{
	for (auto& finalState : m_finaleStates)
		if (m_finaleStates.find(finalState) == m_finaleStates.end())
			return false;
	return true;
}

bool DFA::AFDVerification() const
{
	return VerifyInitialStateInStates() && VerifyFinaleStatesInStates() && VerifyDelta();
}

std::istream& operator>>(std::istream& stream, DFA& object)
{
	std::string auxString;
	char auxChar;

	while (stream.peek() != '\n')
	{
		stream >> auxString;
		object.m_states.insert(auxString);
	}
	stream.get();

	while (stream.peek() != '\n')
	{
		stream >> auxChar;
		object.m_sigma.insert(auxChar);
	}
	stream.get();

	std::uint16_t numberTransitions;
	stream >> numberTransitions;
	std::string beginState, nextState;
	char letterUsed;
	for (uint8_t index = 0; index < numberTransitions; ++index)
	{
		stream >> beginState >> letterUsed >> nextState;
		object.m_delta[std::make_pair(beginState, letterUsed)] = nextState;
	}

	stream >> object.m_initialState;

	stream.get();
	while (stream.peek() != EOF && stream.peek() != '\n')
	{
		stream >> auxString;
		object.m_finaleStates.insert(auxString);
	}
	stream.get();

	return stream;
}
