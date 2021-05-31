#include "AFD.h"
#include <iostream>
#include <cstdint>
#include <iomanip>

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
		if (m_states.find(transition.first.first) == m_states.end())
			return false;
	return true;
}

bool AFD::VerifyLetterUsedInSigma() const
{
	for (auto& transition : m_delta)
		if (m_sigma.find(transition.first.second) == m_sigma.end())
			return false;
	return true;
}

bool AFD::VerifyEndStateInStates() const
{
	for (auto& transition : m_delta)
		if (m_states.find(transition.second) == m_states.end())
			return false;
	return true;
}

bool AFD::VerifyDelta() const
{
	return VerifyBeginStateInStates() && VerifyLetterUsedInSigma() && VerifyEndStateInStates();
}

bool AFD::VerifyInitialStateInStates() const
{
	return m_states.find(m_initialState) != m_states.end();
}

bool AFD::VerifyFinaleStatesInStates() const
{
	for (auto& state : m_finaleStates)
		if (m_states.find(state) == m_states.end())
			return false;
	return true;
}

void AFD::EliminateInaccessibleStates()
{
	std::unordered_set<std::string> visitedStates;
	std::unordered_set<char> usedLetters;
	std::unordered_map<std::pair<std::string, char>, std::string, hash_pair> usedTransitions;
	std::unordered_set<std::string> visitedFinaleStates;
	std::queue<std::string> currentStates;

	visitedStates.insert(m_initialState);
	if (m_finaleStates.find(m_initialState) != m_finaleStates.end())
		visitedFinaleStates.insert(m_initialState);
	currentStates.push(m_initialState);
	while (!currentStates.empty())
	{
		for (auto& letter : m_sigma)
			if (m_delta.find({ currentStates.front(),letter }) != m_delta.end())
			{
				if (visitedStates.find(m_delta[{ currentStates.front(), letter }]) == visitedStates.end())
				{
					currentStates.push(m_delta[{ currentStates.front(), letter }]);
					visitedStates.insert(m_delta[{ currentStates.front(), letter }]);
				}
				if (usedLetters.find(letter) == usedLetters.end())
					usedLetters.insert(letter);
				if (usedTransitions.find({ currentStates.front(), letter }) == usedTransitions.end())
					usedTransitions[{currentStates.front(), letter }] = m_delta[{ currentStates.front(), letter }];
				if (m_finaleStates.find(m_delta[{ currentStates.front(), letter }]) != m_finaleStates.end() &&
					visitedFinaleStates.find(m_delta[{ currentStates.front(), letter }]) == visitedFinaleStates.end())
					visitedFinaleStates.insert(m_delta[{ currentStates.front(), letter }]);
			}
		currentStates.pop();
	}

	m_states = visitedStates;
	m_sigma = usedLetters;
	m_delta = usedTransitions;
	m_finaleStates = visitedFinaleStates;
}

void AFD::Separte(std::vector<std::unordered_set<std::string>>& statesGroups)
{
	statesGroups.reserve(m_states.size());
	statesGroups.push_back({});
	statesGroups.push_back({});
	uint16_t index = 1;
	std::unordered_map<std::string, uint16_t> stateGroupIndex;
	for (auto& state : m_states)
		if (m_finaleStates.find(state) == m_finaleStates.end())
		{
			statesGroups.front().insert(state);
			stateGroupIndex[state] = 0;
		}
		else
		{
			statesGroups.back().insert(state);
			stateGroupIndex[state] = 1;
		}

	std::pair<std::string, std::string>nextElementsPair;
	bool wasChanged, ok;
	do
	{
		std::vector<std::vector<std::string>> out;

		wasChanged = false;
		for (auto stateIterator = statesGroups.begin(); stateIterator != statesGroups.end(); ++stateIterator)
		{
			out.push_back({});
			if (stateIterator->size() > 1)
			{
				ok = true;
				for (auto iterator = std::next(stateIterator->begin()); iterator != stateIterator->end();)
				{
					auto auxIterator = iterator;
					++iterator;

					for (auto& letter : m_sigma)
						if (m_delta.find({ *stateIterator->begin(), letter }) != m_delta.end() &&
							m_delta.find({ *auxIterator, letter }) != m_delta.end())
						{
							nextElementsPair.first = m_delta[{*stateIterator->begin(), letter}];
							nextElementsPair.second = m_delta[{*auxIterator, letter}];
							if (stateGroupIndex[nextElementsPair.first] != stateGroupIndex[nextElementsPair.second])
							{
								if (ok)
								{
									ok = false;
									wasChanged = true;
								}
								out[out.size() - 1].push_back(*auxIterator);
								break;
							}
						}
				}
			}

		}

		for (int index1 = 0; index1 < out.size(); ++index1)
		{
			if (out[index1].size())
			{
				++index;
				statesGroups.push_back({});
				for (int index2 = 0; index2 < out[index1].size(); ++index2)
				{
					statesGroups[statesGroups.size() - 1].insert(out[index1][index2]);
					stateGroupIndex[out[index1][index2]] = index;
					statesGroups[index1].erase(out[index1][index2]);
				}	
			}
		}

	} while (wasChanged);
}

void AFD::Merge(const std::vector<std::unordered_set<std::string>>& statesGroups)
{
	std::string statesString;
	std::unordered_map<char, std::string> transitions;
	bool finalState, initialState;

	for (auto& group : statesGroups)
	{
		initialState = false;
		finalState = m_finaleStates.find(*group.begin()) != m_finaleStates.end();

		if (group.size() > 1)
		{
			for (auto& state : group)
			{
				statesString += state;
				m_states.erase(state);

				for (auto& letter : m_sigma)
					if (m_delta.find({ state, letter }) != m_delta.end())
					{
						if (group.find(m_delta[{ state, letter }]) == group.end())
							transitions[letter] = m_delta[{ state, letter }];
						else
							transitions[letter] = state;
						m_delta.erase({ state, letter });
					}

				if (m_initialState == state)
					initialState = true;

				if (finalState)
					m_finaleStates.erase(state);
			}

			m_states.insert(statesString);

			for (auto& transition : m_delta)
				if (m_states.find(transition.second) == m_states.end())
					transition.second = statesString;
			for (auto& pair : transitions)
				if (m_states.find(pair.second) != m_states.end())
					m_delta[{statesString, pair.first}] = pair.second;
				else
					m_delta[{statesString, pair.first}] = statesString;

			if (initialState)
				m_initialState = statesString;

			if (finalState)
				m_finaleStates.insert(statesString);

			statesString.clear();
			transitions.clear();
		}
	}
}

void AFD::Marking(std::unordered_set<std::pair<std::string, std::string>, hash_pair>& pairsLeft)
{
	for (auto iterator1 = m_states.begin(); iterator1 != m_states.end(); ++iterator1)
		for (auto iterator2 = std::next(iterator1); iterator2 != m_states.end(); ++iterator2)
		{
			if (!(m_finaleStates.find(*iterator1) != m_finaleStates.end() ^
				m_finaleStates.find(*iterator2) != m_finaleStates.end()))
				pairsLeft.insert({ *iterator1, *iterator2 });
		}
	std::cout << '\n';

	bool wasChanged;
	std::pair<std::string, std::string> nextElementsPair;
	do
	{
		wasChanged = false;
		for (auto iterator = pairsLeft.begin(); iterator != pairsLeft.end();)
		{
			auto auxIterator = iterator;
			++iterator;
			for (auto& letter : m_sigma)
				if (m_delta.find({ auxIterator->first, letter }) != m_delta.end() &&
					m_delta.find({ auxIterator->second, letter }) != m_delta.end())
				{
					nextElementsPair.first = m_delta[{auxIterator->first, letter}];
					nextElementsPair.second = m_delta[{auxIterator->second, letter}];
					if (pairsLeft.find({ nextElementsPair.second,nextElementsPair.first }) == pairsLeft.end() &&
						pairsLeft.find(nextElementsPair) == pairsLeft.end() && nextElementsPair.first != nextElementsPair.second)
					{
						pairsLeft.erase(auxIterator);
						wasChanged = true;
						break;
					}
				}
		}
	} while (wasChanged);
}

bool AFD::AFDVerification() const
{
	return VerifyInitialStateInStates() && VerifyFinaleStatesInStates() && VerifyDelta();
}

void AFD::Minimize()
{
	EliminateInaccessibleStates();
	std::vector<std::unordered_set<std::string>> statesGroups;
	Separte(statesGroups);
	Merge(statesGroups);
}

std::ostream& operator<<(std::ostream& stream, const AFD& object)
{
	stream << "AFD: M = { States, Imput Alphabet, Transitions, Initial State, Finale States }\n";

	stream << "States = { ";
	for (auto iterator = object.m_states.begin(); iterator != std::prev(object.m_states.end()); ++iterator)
		stream << *iterator << ", ";
	stream << *std::prev(object.m_states.end()) << " }\n";

	stream << "Imput Alphabet = { ";
	for (auto iterator = object.m_sigma.begin(); iterator != std::prev(object.m_sigma.end()); ++iterator)
		stream << *iterator << ", ";
	stream << *std::prev(object.m_sigma.end()) << " }\n";

	stream << "Transitions:\n" << std::setw(10) << ' ';
	for (auto& letter : object.m_sigma)
		stream << std::setw(10) << letter << ' ';
	stream << '\n';
	for (auto& state : object.m_states)
	{
		stream << std::setw(10) << state << ' ';
		for (auto& letter : object.m_sigma)
			if (object.m_delta.find({ state,letter }) != object.m_delta.end())
				stream << std::setw(10) << object.m_delta.at({ state,letter }) << ' ';
			else
				stream << "           ";
		stream << '\n';
	}

	stream << "Initial State = { " << object.m_initialState << " }\n";

	stream << "Finale States = { ";
	for (auto iterator = object.m_finaleStates.begin(); iterator != std::prev(object.m_finaleStates.end()); ++iterator)
		stream << *iterator << ", ";
	stream << *std::prev(object.m_finaleStates.end()) << " }\n";

	return stream;
}

std::istream& operator>>(std::istream& stream, AFD& object)
{
	std::string auxString1;
	char auxChar;
	while (stream.peek() != '\n')
	{
		stream >> auxString1;
		object.m_states.insert(auxString1);
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

	std::string  auxString2;
	for (uint8_t index = 0; index < numberTransitions; ++index)
	{
		stream >> auxString1 >> auxChar >> auxString2;
		object.m_delta[std::make_pair(auxString1, auxChar)] = auxString2;
	}

	stream >> object.m_initialState;
	stream.get();

	while (stream.peek() != EOF && stream.peek() != '\n')
	{
		stream >> auxString1;
		object.m_finaleStates.insert(auxString1);
	}

	return stream;
}
