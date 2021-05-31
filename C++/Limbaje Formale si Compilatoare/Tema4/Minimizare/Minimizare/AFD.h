#pragma once

#include <vector>
#include <string>
#include <unordered_map>
#include <unordered_set>
#include <queue>
#include <vector>

class AFD
{
private:
	struct hash_pair {
		template <class T1, class T2>
		size_t operator()(const std::pair<T1, T2>&) const;
	};

public:
	AFD() = default;
	AFD(AFD const&) = default;
	AFD(AFD&&) = default;
	~AFD() = default;
	AFD& operator=(AFD const&) = default;
	AFD& operator=(AFD&&) = default;

	const void WordVerification(const std::string&) const;
	bool AFDVerification() const;
	void Minimize();

	friend std::ostream& operator<<(std::ostream&, const AFD&);
	friend std::istream& operator>>(std::istream&, AFD&);

private:
	bool IsUsableTransition(const std::string&, const char) const;
	bool VerifyStateInFinaleStates(const std::string&) const;
	bool VerifyBeginStateInStates() const;
	bool VerifyLetterUsedInSigma() const;
	bool VerifyEndStateInStates() const;
	bool VerifyDelta() const;
	bool VerifyInitialStateInStates() const;
	bool VerifyFinaleStatesInStates() const;

	void EliminateInaccessibleStates();
	void Separte(std::vector<std::unordered_set<std::string >>&);
	void Merge(const std::vector<std::unordered_set<std::string >>&);

	void Marking(std::unordered_set<std::pair<std::string, std::string>, hash_pair>&);

	std::unordered_set<std::string> m_states;
	std::unordered_set<char> m_sigma;
	std::unordered_map<std::pair<std::string, char>, std::string, hash_pair> m_delta;
	std::string m_initialState;
	std::unordered_set<std::string> m_finaleStates;
};

template<class T1, class T2>
inline size_t AFD::hash_pair::operator()(const std::pair<T1, T2>& p) const
{
	return std::hash<T1>{}(p.first) ^ std::hash<T2>{}(p.second);
}
