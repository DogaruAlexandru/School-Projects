#include <iostream>
#include <fstream>
#include <iomanip>
#include <queue>
#include <utility>
#include <windows.h>
#include "conio.h"

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
		myFile.close();
	}
	else
		std::cout << "File not open";
}
void read(std::pair <int, int>& mouse, std::pair <int, int>& cheese, bool& anim)
{
	std::cout << "Introduceti coordonatele soricelului: ";
	std::cin >> mouse.first >> mouse.second;
	std::cout << "Introduceti coordonatele branzei: ";
	std::cin >> cheese.first >> cheese.second;
	std::cout << "Pentru animatie apasati 1 altfel 0";
	anim = _getch() - '0';
}
void write(int** mat, int rows, int cols)
{
	Sleep(250);
	system("cls");
	for (int index1 = 0; index1 < rows; ++index1)
	{
		for (int index2 = 0; index2 < cols; ++index2)
			if (mat[index1][index2] == -2)
				std::cout << " x";
			else if (mat[index1][index2] == -1)
				std::cout << std::setw(2) << (char)254;
			else
				std::cout << "  ";
		std::cout << '\n';
	}
	std::cout << '\n';
}
void boarding(int**& mat, int rows, int cols)
{
	for (int index = 0; index < rows; ++index)
		mat[index][0] = mat[index][cols - 1] = -1;
	for (int index = 1; index < cols - 1; ++index)
		mat[0][index] = mat[rows - 1][index] = -1;
}
void find(int**& mat, int rows, int cols, std::pair <int, int> mouse, std::pair <int, int> cheese, bool anim)
{
	std::queue <std::pair <int, int>> queue;
	queue.push(cheese);
	int no = 1;
	mat[cheese.first][cheese.second] = no;
	while (queue.empty() == 0)
	{
		no = mat[queue.front().first][queue.front().second] + 1;
		if (mat[queue.front().first][queue.front().second + 1] == 0)
		{
			queue.push(std::make_pair(queue.front().first, queue.front().second + 1));
			mat[queue.front().first][queue.front().second + 1] = no;
		}
		if (mat[queue.front().first][queue.front().second - 1] == 0)
		{
			queue.push(std::make_pair(queue.front().first, queue.front().second - 1));
			mat[queue.front().first][queue.front().second - 1] = no;
		}
		if (mat[queue.front().first + 1][queue.front().second] == 0)
		{
			queue.push(std::make_pair(queue.front().first + 1, queue.front().second));
			mat[queue.front().first + 1][queue.front().second] = no;
		}
		if (mat[queue.front().first - 1][queue.front().second] == 0)
		{
			queue.push(std::make_pair(queue.front().first - 1, queue.front().second));
			mat[queue.front().first - 1][queue.front().second] = no;
		}
		queue.pop();
	}
	if (mat[mouse.first][mouse.second] == 0)
	{
		std::cout << "Nu exista drum de la soricel la branza";
		return;
	}
	while (cheese != mouse)
	{
		if (anim == 1)
			write(mat, rows, cols);
		if (mat[mouse.first + 1][mouse.second] + 1 == mat[mouse.first][mouse.second])
		{
			mat[mouse.first][mouse.second] = -2;
			++mouse.first;
		}
		else if (mat[mouse.first - 1][mouse.second] + 1 == mat[mouse.first][mouse.second])
		{
			mat[mouse.first][mouse.second] = -2;
			--mouse.first;
		}
		else if (mat[mouse.first][mouse.second + 1] + 1 == mat[mouse.first][mouse.second])
		{
			mat[mouse.first][mouse.second] = -2;
			++mouse.second;
		}
		else
		{
			mat[mouse.first][mouse.second] = -2;
			--mouse.second;
		}
	}
	if (anim == 1)
		write(mat, rows, cols);
	mat[cheese.first][cheese.second] = -2;
	write(mat, rows, cols);
}

void main()
{
	int **mat, cols, rows;
	bool anim;
	std::pair <int, int> mouse, cheese;
	readMaze(mat, rows, cols, "in.txt");
	read(mouse, cheese, anim);
	boarding(mat, rows, cols);
	find(mat, rows, cols, mouse, cheese, anim);
	for (int index = 0; index < rows; index++)
		delete[] mat[index];
	delete[] mat;
}