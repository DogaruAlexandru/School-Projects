#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <random>
#include <cctype>
#include <cstdlib>

void Read(const std::string& filePath, std::vector<std::string>& words)
{
	std::ifstream file(filePath);
	std::string word;
	if (file.is_open())
	{
		while (file >> word)
			words.push_back(word);
		file.close();
	}
	else
		throw "File not open";
}

int PickRandomNumber(int begin, int end)
{
	std::random_device r;
	std::default_random_engine e1(r());
	std::uniform_int_distribution<int> uniform_dist(begin, end);
	return uniform_dist(e1);
}

void WriteWord(const std::string& word)
{
	for (char letter : word)
		std::cout << letter << ' ';
	std::cout << "\n\n";
}

void WriteInfo(const bool alphabet[26], const int attemptsLeft)
{
	std::cout << "Litere incercate:";
	for (unsigned int index = 0; index < 26; ++index)
		if (alphabet[index] == true)
			std::cout << ' ' << char(index + 'A');
	std::cout << '\n' << "Litere neincercate:";
	for (unsigned int index = 0; index < 26; ++index)
		if (alphabet[index] == false)
			std::cout << ' ' << char(index + 'A');
	std::cout << '\n' << "Incercari ramase: " << attemptsLeft << "\n\n";
}

void GameRun(const std::string& word)
{
	int attemptsLeft = 6;
	bool alphabet[26] = {};
	std::string copyWord(word);
	int aux;
	char letter;
	std::string displayedWord(copyWord.size(), '_');
	while (attemptsLeft != 0 && displayedWord.find('_') != std::string::npos)
	{
		WriteInfo(alphabet, attemptsLeft);
		WriteWord(displayedWord);

		std::cout << "Introduceti litera de cautat: ";
		std::cin >> letter;
		letter = toupper(letter);

		if (letter >= 'A' && letter < +'Z')
			alphabet[letter - 'A'] = true;
		aux = copyWord.find(letter);
		if (aux != std::string::npos)
			do
			{
				copyWord[aux] = '#';
				displayedWord[aux] = letter;
				aux = copyWord.find(letter);
			} while (aux != std::string::npos);
		else
			--attemptsLeft;
		system("cls");
	}
	WriteInfo(alphabet, attemptsLeft);
	WriteWord(displayedWord);
	if (attemptsLeft == 0)
		std::cout << "Ai pierdut!\n\n" << "Cuvantul era: " << word << "\n";
	else
		std::cout << "Ai castigat!\n";
}

int main()
{
	std::vector<std::string> words;
	Read("in.txt", words);
	while (true)
	{
		system("cls");
		GameRun(words[PickRandomNumber(0, words.size() - 1)]);
		std::cin.get();
	}
	return 0;
}