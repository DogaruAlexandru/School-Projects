#include <iostream>
#include <fstream>
#include <string>
#include <queue>

struct Graf
{
	int nods;
	bool** graf;
	~Graf()
	{
		for (int index = 0; index < nods; ++index)
			delete[] graf[index];
		delete[] graf;
	}
	void alocMat()
	{
		graf = new bool*[nods];
		for (int index = 0; index < nods; ++index)
			graf[index] = new bool[nods];
	}
	void readGraf(std::string filePath)
	{
		std::ifstream myFile(filePath);
		if (myFile.is_open())
		{
			myFile >> nods;
			alocMat();
			for (int index1 = 0; index1 < nods; ++index1)
				for (int index2 = 0; index2 < nods; ++index2)
					myFile >> graf[index1][index2];
			myFile.close();
		}
		else
			std::cout << "File not open";
	}

	void writeConex()
	{
		std::queue<int> queue;
		int* mark = new int[nods];
		for (int index = 0; index < nods; ++index)
			mark[index] = 0;
		int no = 0;
		for (int index1 = 0; index1 < nods; ++index1)
			if (mark[index1] == 0)
			{
				queue.push(index1);
				mark[index1] = ++no;
				while (queue.empty() == 0)
				{
					for (int index2 = 0; index2 < nods; ++index2)
						if ((graf[queue.front()][index2] == 1 || graf[index2][queue.front()] == 1) && mark[index2] == 0)
						{
							queue.push(index2);
							mark[index2] = no;
						}
					queue.pop();
				}
			}

		std::cout << "Numarul componentelor conexe este " << no << " si acestea sunt:\n";
		while (no)
		{
			for (int index = 0; index < nods; index++)
				if (mark[index] == no)
					std::cout << index << ' ';
			std::cout << '\n';
			--no;
		}
		delete[] mark;
	}
};

void main()
{
	Graf graf;
	graf.readGraf("in.txt");
	graf.writeConex();
}