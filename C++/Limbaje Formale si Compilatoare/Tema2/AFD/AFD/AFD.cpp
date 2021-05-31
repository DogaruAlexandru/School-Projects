#include "AFD.h"
#include <iostream>
#include <cstdint>
#include <iomanip>

AFD::AFD()
{
}

AFD::AFD(const AFD& other)
{
	*this = other;
}

AFD::~AFD()
{
}

AFD& AFD::operator=(const AFD& other)
{
	m_states = other.m_states;
	m_sigma = other.m_sigma;
	m_delta = other.m_delta;
	m_initialState = other.m_initialState;
	m_finaleStates = other.m_finaleStates;
	return *this;
}

const void AFD::WordVerification(const std::string& word) const
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

bool AFD::IsUsableTransition(const std::string& state, const char letter) const
{
	if (m_delta.find({ state, letter }) == m_delta.end())
		return false;
	return true;
}

bool AFD::VerifyStateInFinaleStates(const std::string& searched) const
{
	for (auto& finaleState : m_finaleStates)
		if (searched == finaleState)
			return true;
	return false;
}

bool AFD::VerifyBeginStateInStates() const
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

bool AFD::VerifyLetterUsedInSigma() const
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

bool AFD::VerifyEndStateInStates() const
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

bool AFD::VerifyDelta() const
{
	return VerifyBeginStateInStates() && VerifyLetterUsedInSigma() && VerifyEndStateInStates();
}

bool AFD::VerifyInitialStateInStates() const
{
	for (auto& state : m_states)
		if (state == m_initialState)
			return true;
	return false;
}

bool AFD::VerifyFinaleStatesInStates() const
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

bool AFD::AFDVerification() const
{
	return VerifyInitialStateInStates() && VerifyFinaleStatesInStates() && VerifyDelta();
}

std::ostream& operator<<(std::ostream& stream, const AFD& object)
{
	stream << "AFD: M={States, Imput Alphabet, Transitions, Initial State, Finale States}\n";

	stream << "States = { ";
	for (uint8_t index = 0; index < object.m_states.size() - 1; ++index)
		stream << object.m_states[index] << ", ";
	stream << object.m_states[object.m_states.size() - 1] << " }\n";

	stream << "Imput Alphabet = { ";
	for (uint8_t index = 0; index < object.m_sigma.size() - 1; ++index)
		stream << object.m_sigma[index] << ", ";
	stream << object.m_sigma[object.m_sigma.size() - 1] << " }\n";

	stream << "Transitions:\n" << std::setw(3) << ' ';
	for (auto& letter : object.m_sigma)
		stream << std::setw(3) << letter << ' ';
	stream << '\n';
	for (auto& state : object.m_states)
	{
		stream << std::setw(3) << state << ' ';
		for (auto& letter : object.m_sigma)
			if (object.m_delta.find({ state,letter }) != object.m_delta.end())
				stream << std::setw(3) << object.m_delta.at({ state,letter }) << ' ';
				//stream << std::setw(3) << object.m_delta[{ state,letter }] << ' ';
			else
				stream << "    ";
		stream << '\n';
	}

	stream << "Initial State = { " << object.m_initialState << " }\n";

	stream << "Finale States = { ";
	for (uint8_t index = 0; index < object.m_finaleStates.size() - 1; ++index)
		stream << object.m_finaleStates[index] << ", ";
	stream << object.m_finaleStates[object.m_finaleStates.size() - 1] << " }\n";

	return stream;
}

std::istream& operator>>(std::istream& stream, AFD& object)
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
		object.m_delta[std::make_pair(beginState, letterUsed)] = nextState;
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
