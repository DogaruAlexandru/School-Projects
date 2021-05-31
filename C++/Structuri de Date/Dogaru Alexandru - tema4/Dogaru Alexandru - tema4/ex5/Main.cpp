#include <iostream>
#include <queue>
#include <vector>
#include <fstream>
#include <cmath>
#include <iomanip>
#include <stack>
#include <utility>

const std::vector<int> i = { -1, 0, 1, 1, 1, 0, -1, -1 };
const std::vector<int> j = { -1, -1, -1, 0, 1, 1, 1, 0 };

struct Data
{
	int x, y;
	int distStart;
	int distFinish;
	int sum;
	Data()
	{
	}
	Data(int x, int y, Data cheese, Data mouse)
	{
		this->x = x;
		this->y = y;
		distStart = abs(mouse.x - x) + abs(mouse.y - y);
		distFinish = abs(cheese.x - x) + abs(cheese.y - y);
		sum = distStart + distFinish;
	}
};
struct myComparator
{
	bool operator() (const Data& d1, const Data& d2) const
	{
		return (d1.sum > d2.sum || (d1.sum == d2.sum && d1.distFinish > d2.distFinish));
	}
};

void boarding(int**& mat, int rows, int cols)
{
	for (int index = 0; index < rows; ++index)
		mat[index][0] = mat[index][cols - 1] = -1;
	for (int index = 1; index < cols - 1; ++index)
		mat[0][index] = mat[rows - 1][index] = -1;
}
void readMaze(int**& mat, int& rows, int& cols, std::string filePath)
{
	std::ifstream myFile(filePath);
	if (myFile.is_open())
	{
		myFile >> rows >> cols;
		rows += 2;
		cols += 2;
		mat = new int*[rows];
		for (int index = 0; index < rows; ++index)
			mat[index] = new int[cols];
		for (int index1 = 1; index1 < rows - 1; ++index1)
			for (int index2 = 1; index2 < cols - 1; ++index2)
				myFile >> mat[index1][index2];
		boarding(mat, rows, cols);
		myFile.close();
	}
	else
		std::cout << "File not open";
}
void read(Data& mouse, Data& cheese)
{
	std::cout << "Introduceti coordonatele soricelului: ";
	std::cin >> mouse.x >> mouse.y;
	std::cout << "Introduceti coordonatele branzei: ";
	std::cin >> cheese.x >> cheese.y;
}
void write(int** mat, int rows, int cols)
{
	for (int index1 = 0; index1 < rows; ++index1)
	{
		for (int index2 = 0; index2 < cols; ++index2)
			std::cout << std::setw(2) << mat[index1][index2] << "  ";
		std::cout << '\n';
	}
	std::cout << '\n';
}

void way(int** mat, int rows, int cols, Data mouse, Data cheese)
{
	std::stack <std::pair<int, int>> path;
	path.push(std::make_pair(cheese.x, cheese.y));
	while (path.empty() == 0 && (path.top().first != mouse.x || path.top().second != mouse.y))
	{
		std::pair<int, int> aux = path.top();
		bool ok = 0;
		for (int index = 0; index < 8; ++index)
		{
			if (mat[aux.first + i[index]][aux.second + j[index]] == mat[aux.first][aux.second] - 1)
			{
				path.push(std::make_pair(aux.first + i[index], aux.second + j[index]));
				ok = 1;
				break;
			}
		}
		if (ok == 0)
		{
			mat[path.top().first][path.top().second] = -1;
			path.pop();
		}
	}
	while (path.empty() == 0)
	{
		std::cout << '(' << path.top().first << ", " << path.top().second << ") ";
		path.pop();
	}
}
void find(int**& mat, int rows, int cols, Data mouse, Data cheese)
{
	std::priority_queue <Data, std::vector<Data>, myComparator > pq;
	pq.push(mouse);
	while (pq.empty() != 1 && mat[cheese.x][cheese.y] == 0)
	{
		Data aux = pq.top();
		pq.pop();
		for (int index = 0; index < 8 && mat[cheese.x][cheese.y] == 0; ++index)
			if (mat[aux.x + i[index]][aux.y + j[index]] == 0 || mat[aux.x + i[index]][aux.y + j[index]] > mat[aux.x][aux.y] + 1)
			{
				mat[aux.x + i[index]][aux.y + j[index]] = mat[aux.x][aux.y] + 1;
				Data d(aux.x + i[index], aux.y + j[index], cheese, mouse);
				pq.push(d);
			}
	}
	write(mat, rows, cols);
	if (mat[cheese.x][cheese.y])
	{
		std::cout << "Exista Drum:\n";
		way(mat, rows, cols, mouse, cheese);
	}
	else
		std::cout << "Nu exista Drum!\n";
}

void main()
{
	int **mat, cols, rows;
	Data cheese, mouse;

	readMaze(mat, rows, cols, "in.txt");
	write(mat, rows, cols);

	read(mouse, cheese);
	mouse.distStart = 0;
	mouse.distFinish = mouse.sum = abs(cheese.x - mouse.x) + abs(cheese.y - mouse.y);
	cheese.distFinish = 0;
	cheese.distStart = cheese.sum = mouse.sum;

	mat[mouse.x][mouse.y] = 1;

	find(mat, rows, cols, mouse, cheese);

	for (int index = 0; index < rows; index++)
		delete[] mat[index];
	delete[] mat;
}