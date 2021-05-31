#include <iostream>
#include <fstream>
#include <string>
#include <cmath>

void read(bool**& mat, int& rows, int& cols, std::string filePath)
{
	std::ifstream myFile(filePath);
	if (myFile.is_open())
	{
		myFile >> rows >> cols;
		mat = new bool*[rows];
		for (int index = 0; index < rows; index++)
			mat[index] = new bool[cols];
		for (int index1 = 0; index1 < rows; index1++)
			for (int index2 = 0; index2 < cols; index2++)
				myFile >> mat[index1][index2];
		myFile.close();
	}
	else
		std::cout << "File not open";
}

void dec(bool**& mat, int& rows, int& cols)
{
	for (int index1 = 0; index1 < rows; index1++)
	{
		int no = 0;
		for (int index2 = 0; index2 < cols; index2++)
			no += mat[index1][index2] * pow(2, cols - index2 - 1);
		std::cout << no << '\n';
	}
}

void main()
{
	bool **mat;
	int rows, cols;
	read(mat, rows, cols, "in.txt");
	dec(mat, rows, cols);
	for (int index = 0; index < rows; index++)
		delete[] mat[index];
	delete[] mat;
}