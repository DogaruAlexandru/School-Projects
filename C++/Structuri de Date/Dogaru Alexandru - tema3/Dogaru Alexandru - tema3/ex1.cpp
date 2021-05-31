#include <iostream>
#include <fstream>
#include <string>
#include <queue>

struct Nod
{
	int info;
	Nod* next;
};

struct Graf
{
	Nod** lists;
	int nods;
	~Graf()
	{
		for (int index = 0; index < nods; ++index)
		{
			while (lists[index] != NULL)
			{
				Nod* p = lists[index];
				lists[index] = lists[index]->next;
				delete p;
			}
		}
		delete[] lists;
	}
	void add(int no, int index)
	{
		if (lists[index] != NULL)
		{
			Nod* p = lists[index];
			while (p->next != NULL)
				p = p->next;
			Nod* aux = new Nod;
			aux->next = NULL;
			aux->info = no;
			p->next = aux;
		}
		else
		{
			lists[index] = new Nod;
			lists[index]->info = no;
			lists[index]->next = NULL;
		}
	}
	void read(std::string filePath)
	{
		std::ifstream myFile(filePath);
		if (myFile.is_open())
		{
			myFile >> nods;
			lists = new Nod*[nods];
			for (int index = 0; index < nods; ++index)
			{
				lists[index] = NULL;
			}
			int no;
			for (int index = 0; index < nods; ++index)
			{
				myFile.get();
				while (myFile.peek() != '\n' && myFile.peek() != EOF)
				{
					myFile >> no;
					add(no, index);
				}
			}
			myFile.close();
		}
		else
			std::cout << "File not open";
	}

	bool drum(int begin, int end)
	{
		bool* mark = new bool[nods];
		for (int index = 0; index < nods; ++index)
			mark[index] = 0;
		std::queue <int> queue;
		queue.push(begin);
		mark[queue.front()] = 1;
		while (queue.empty() == 0 && mark[end] == 0)
		{
			Nod* p = lists[queue.front()]->next;
			while (p)
			{
				if (mark[(p->info) - 1] == 0 && mark[end] == 0)
				{
					queue.push((p->info) - 1);
					mark[(p->info) - 1] = 1;
				}
				p = p->next;
			}
			queue.pop();
		}
		bool aux = 0;
		if (mark[end] == 1)
			aux = 1;
		delete[] mark;
		return aux;
	}

	int find(int* mark, int begin, int no)
	{
		Nod* p;
		for (int index = begin; index < nods; ++index)
		{
			if (index == no)
				continue;
			p = lists[index]->next;
			while (p)
			{
				if (p->info - 1 == no && mark[index] == 0)
					return index;
				p = p->next;
			}
		}
		return -1;
	}
	bool lant(int begin, int end)
	{
		int* mark = new int[nods];
		for (int index = 0; index < nods; ++index)
			mark[index] = 0;
		std::queue <int> queue;
		queue.push(begin);
		mark[queue.front()] = 1;
		while (queue.empty() == 0 && mark[end] == 0)
		{
			Nod* p = lists[queue.front()]->next;
			while (p && mark[end] == 0)
			{
				if (mark[(p->info) - 1] == 0)
				{
					queue.push((p->info) - 1);
					mark[(p->info) - 1] = 1;
				}
				p = p->next;
			}
			int index = find(mark, 0, (lists[queue.front()]->info) - 1);
			while (index != -1 && mark[end] == 0)
			{
				queue.push(index);
				mark[index] = 1;
				index = find(mark, index + 1, (lists[queue.front()]->info) - 1);
			}
			queue.pop();
		}
		bool aux = 0;
		if (mark[end] == 1)
			aux = 1;
		delete[] mark;
		return aux;
	}
};

void main()
{
	Graf graf;
	graf.read("in.txt");
	std::cout << graf.drum(3, 0) << ' ' << graf.lant(3, 0);

}