#include "PriortyQueueMin.h"
#include "Nod.h"
#include <fstream>
#include <iostream>
#include <string>
#include <utility>

std::string read(std::vector<Nod*>& vect, std::string filePath)
{
	std::ifstream myFile(filePath);
	if (myFile.is_open())
	{
		std::string str;
		std::getline(myFile, str);

		vect.resize(128);
		for (int index = 0; index < 128; ++index)
			vect[index] = new Nod(index);

		for (int index = 0; index < str.size(); ++index)
			++(vect[str[index]]->frequency);

		myFile.close();

		return str;
	}
	else
		std::cout << "File not open";
	return "";
}

void createPQ(PriortyQueueMin& pq, std::vector<Nod*> vect)
{
	for (int index = 0; index < 128; ++index)
		if (vect[index]->frequency > 0)
			pq.insert(vect[index]);
}

Nod* createTree(PriortyQueueMin pq)
{
	Nod* p = nullptr;
	while (pq.getSize() > 1)
	{
		p = new Nod;
		p->left = pq.getMin();
		pq.pop();
		p->right = pq.getMin();
		pq.pop();
		p->frequency = p->left->frequency + p->right->frequency;
		pq.insert(p);
	}
	return p;
}

void rsd(Nod* x, std::vector<std::pair<char, std::string>>& vect, std::string str)
{
	if (x)
	{
		if (x->info >= 0 && x->info < 128)
			vect[x->info].second = str;
		rsd(x->left, vect, str + '0');
		rsd(x->right, vect, str + '1');
	}
}

std::vector<std::pair<char, std::string>> createCode(Nod* root)
{
	std::vector<std::pair<char, std::string>> vect;
	vect.resize(128);
	for (int index = 0; index < 128; ++index)
		vect[index].first = index;
	rsd(root, vect, "");
	return vect;
}

void coding(std::vector<std::pair<char, std::string>> code, std::string str)
{
	for (int index = 0; index < str.size(); ++index)
		std::cout << code[str[index]].second << ' ';
}

void writeTable(std::vector<std::pair<char, std::string>> code)
{
	for (int index = 0; index < code.size(); ++index)
		if (code[index].second != "")
			std::cout << code[index].first << ' ' << code[index].second << '\n';
}

void main()
{
	PriortyQueueMin pq;
	std::vector<Nod*> vect;
	std::vector<std::pair<char, std::string>> code;
	std::string str;

	str = read(vect, "in.txt");

	createPQ(pq, vect);
	Nod* root = createTree(pq);

	code = createCode(root);

	writeTable(code);
	std::cout << '\n';
	std::cout << str << '\n';
	coding(code, str);
}