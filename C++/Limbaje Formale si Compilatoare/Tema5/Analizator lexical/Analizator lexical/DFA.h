#pragma once

#include <vector>
#include <string>
#include <utility>
#include <unordered_map>
#include <unordered_set>

class DFA
{
private:
	struct hash_pair {
		template <class T1, class T2>
		size_t operator()(const std::pair<T1, T2>&) const;
	};

public:
	DFA() = default;
	DFA(DFA const& other) = default;
	DFA& operator=(DFA const& other) = default;
	DFA(DFA&& other) = default;
	DFA& operator=(DFA&& other) = default;
	~DFA() = default;

	const void WordVerification(const std::string&) const;
	std::pair<bool, std::string> Run(const std::string&, uint32_t const) const;
	bool AFDVerification() const;

	friend std::istream& operator>>(std::istream&, DFA&);

private:
	bool IsUsableTransition(const std::string&, const char) const;
	bool VerifyStateInFinaleStates(const std::string&) const;
	bool VerifyBeginStateInStates() const;
	bool VerifyLetterUsedInSigma() const;
	bool VerifyEndStateInStates() const;
	bool VerifyDelta() const;
	bool VerifyInitialStateInStates() const;
	bool VerifyFinaleStatesInStates() const;

	std::unordered_set<std::string> m_states;
	std::unordered_set<char> m_sigma;
	std::unordered_map<std::pair<std::string, char>, std::string, hash_pair> m_delta;
	std::string m_initialState;
	std::unordered_set<std::string> m_finaleStates;
};

template<class T1, class T2>
inline size_t DFA::hash_pair::operator()(const std::pair<T1, T2>& p) const
{
	return std::hash<T1>{}(p.first) ^ std::hash<T2>{}(p.second);
}
