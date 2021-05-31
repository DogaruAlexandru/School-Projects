#include <iostream>
#include <queue>
#include <string>
#include <fstream>
#include <utility>

struct nod
{
	int info;
	nod* st, *dr, *p;
	nod(int k = 0)
	{
		info = k;
		st = dr = p = nullptr;
	}
};

struct arbore
{
	nod* rad;
	arbore()
	{
		rad = nullptr;
	}
	~arbore()
	{
		std::queue <nod*> C;
		C.push(rad);
		while (C.empty() == 0)
		{
			if (C.front()->st != NULL)
				C.push(C.front()->st);
			if (C.front()->dr != NULL)
				C.push(C.front()->dr);
			delete C.front();
			C.pop();
		}
	}

	void citeste(std::string filename)
	{
		std::ifstream f;
		f.open(filename);
		int info;
		int copii;
		nod* nod_curent;
		std::queue<std::pair<nod*, int>> C;
		std::pair<nod*, int> curent;
		f >> info;
		f >> copii;
		rad = new nod(info);
		C.push(std::pair<nod*, int>(rad, copii));
		while (!C.empty())
		{
			nod* stanga = nullptr, *dreapta = nullptr;
			curent = C.front();
			C.pop();

			nod_curent = curent.first;

			if (curent.second == -1 || curent.second == 2)
			{
				f >> info;
				f >> copii;
				stanga = new nod(info);
				stanga->p = nod_curent;
				C.push(std::pair<nod*, int>(stanga, copii));
			}
			if (curent.second == 1 || curent.second == 2)
			{
				f >> info;
				f >> copii;
				dreapta = new nod(info);
				dreapta->p = nod_curent;
				C.push(std::pair<nod*, int>(dreapta, copii));
			}
			nod_curent->st = stanga;
			nod_curent->dr = dreapta;
		}
		f.close();
	}
	int inaltime(nod* nod)
	{
		if (nod == NULL)
			return 0;
		else
		{
			int stanga = inaltime(nod->st);
			int dreapta = inaltime(nod->dr);
			if (stanga > dreapta)
				return(stanga + 1);
			else return(dreapta + 1);
		}
	}
};

int main()
{
	arbore A;
	A.citeste("in.txt");
	std::cout << A.inaltime(A.rad);
}
