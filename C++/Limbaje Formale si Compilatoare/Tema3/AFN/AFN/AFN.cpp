#include "AFN.h"
#include <iostream>
#include <cstdint>
#include <iomanip>

AFN::AFN()
{
}

AFN::AFN(const AFN& other)
{
	*this = other;
}

AFN::~AFN()
{
}

AFN& AFN::operator=(const AFN& other)
{
	m_states = other.m_states;
	m_sigma = other.m_sigma;
	m_delta = other.m_delta;
	m_initialState = other.m_initialState;
	m_finaleStates = other.m_finaleStates;
	return *this;
}

const void AFN::WordVerification(const std::string& word) const
{
	std::queue<std::string> currentStates;
	currentStates.push(m_initialState);
	for (uint8_t wordIndex = 0; wordIndex < word.size(); ++wordIndex)
	{
		for (size_t queueIndex = currentStates.size(); queueIndex > 0; --queueIndex)
		{
			UseTransitions(currentStates, word[wordIndex]);
			currentStates.pop();
		}
		if (!currentStates.size())
		{
			std::cout << "Blocked!\n";
			return;
		}
	}
	if (VerifyStateInFinaleStates(currentStates))
		std::cout << "Accepted!\n";
	else
		std::cout << "Unaccepted!\n";
}

void AFN::UseTransitions(std::queue<std::string>& currentStates, const char letter) const
{
	auto range = m_delta.equal_range({ currentStates.front(),letter });
	for (auto it = range.first; it != range.second; ++it)
		currentStates.push(it->second);
}

bool AFN::VerifyStateInFinaleStates(std::queue<std::string>& searched) const
{
	while (searched.size())
	{
		for (auto& finaleState : m_finaleStates)
			if (searched.front() == finaleState)
				return true;
		searched.pop();
	}
	return false;
}

bool AFN::VerifyBeginStateInStates() const
{
	for (auto& transition : m_delta)
		for (std::uint8_t index = 0; index < m_states.size(); ++index)
		{
			if (transition.first.first == m_states[index])
				break;
			if (index == m_states.size() - 1)
				return false;
		}
	return true;
}

bool AFN::VerifyLetterUsedInSigma() const
{
	for (auto& transition : m_delta)
		for (std::uint8_t index = 0; index < m_sigma.size(); ++index)
		{
			if (transition.first.second == m_sigma[index])
				break;
			if (index == m_sigma.size() - 1)
				return false;
		}
	return true;
}

bool AFN::VerifyEndStateInStates() const
{
	for (auto& transition : m_delta)
		for (std::uint8_t index = 0; index < m_states.size(); ++index)
		{
			if (transition.second == m_states[index])
				break;
			if (index == m_states.size() - 1)
				return false;
		}
	return true;
}

bool AFN::VerifyDelta() const
{
	return VerifyBeginStateInStates() && VerifyLetterUsedInSigma() && VerifyEndStateInStates();
}

bool AFN::VerifyInitialStateInStates() const
{
	for (auto& state : m_states)
		if (state == m_initialState)
			return true;
	return false;
}

bool AFN::VerifyFinaleStatesInStates() const
{
	for (auto& finalState : m_finaleStates)
		for (std::uint8_t index = 0; index < m_states.size(); ++index)
		{
			if (finalState == m_states[index])
				break;
			if (index == m_states.size() - 1)
				return false;
		}
	return true;
}

bool AFN::AFNVerification() const
{
	return VerifyInitialStateInStates() && VerifyFinaleStatesInStates() && VerifyDelta();
}

std::ostream& operator<<(std::ostream& stream, const AFN& object)
{
	stream << "AFN: M={States, Imput Alphabet, Transitions, Initial State, Finale States}\n";

	stream << "States = { ";
	for (uint8_t index = 0; index < object.m_states.size() - 1; ++index)
		stream << object.m_states[index] << ", ";
	stream << object.m_states[object.m_states.size() - 1] << " }\n";

	stream << "Imput Alphabet = { ";
	for (uint8_t index = 0; index < object.m_sigma.size() - 1; ++index)
		stream << object.m_sigma[index] << ", ";
	stream << object.m_sigma[object.m_sigma.size() - 1] << " }\n";

	stream << "Transitions:\n{\n";
	for (auto it = object.m_delta.begin(); it != object.m_delta.end();)
	{
		auto range = object.m_delta.equal_range(it->first);
		stream << "    (" << it->first.first << ", " << it->first.second << ") = { ";
		for (; it != range.second; ++it)
			stream << it->second << ", ";
		stream << "\b\b }\n";
	}
	stream << "}\n";

	stream << "Finale States = { ";
	for (uint8_t index = 0; index < object.m_finaleStates.size() - 1; ++index)
		stream << object.m_finaleStates[index] << ", ";
	stream << object.m_finaleStates[object.m_finaleStates.size() - 1] << " }\n";

	return stream;
}

std::istream& operator>>(std::istream& stream, AFN& object)
{
	while (stream.peek() != '\n')
	{
		object.m_states.push_back("");
		stream >> object.m_states[object.m_states.size() - 1];
	}
	stream.get();

	while (stream.peek() != '\n')
	{
		object.m_sigma.push_back(0);
		stream >> object.m_sigma[object.m_sigma.size() - 1];
	}
	stream.get();

	std::uint16_t numberTransitions;
	stream >> numberTransitions;
	std::string beginState, nextState;
	char letterUsed;
	for (uint8_t index = 0; index < numberTransitions; ++index)
	{
		stream >> beginState >> letterUsed >> nextState;
		object.m_delta.insert({ { beginState,letterUsed }, nextState });
	}

	stream >> object.m_initialState;

	stream.get();
	while (stream.peek() != EOF && stream.peek() != '\n')
	{
		object.m_finaleStates.push_back("");
		stream >> object.m_finaleStates[object.m_finaleStates.size() - 1];
	}

	return stream;
}
