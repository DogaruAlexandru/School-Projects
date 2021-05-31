#include <iostream>
#include <fstream>
#include <string>

void read(int**& mat, int& size, std::string filePath)
{
	std::ifstream myFile(filePath);
	if (myFile.is_open())
	{
		myFile >> size;
		mat = new int*[size];
		for (int index = 0; index < size; index++)
			mat[index] = new int[size];
		for (int index1 = 0; index1 < size; index1++)
			for (int index2 = 0; index2 < size; index2++)
				myFile >> mat[index1][index2];
		myFile.close();
	}
	else
		std::cout << "File not open";
}

void sum(int** mat, int size)
{
	for (int index1 = 0; index1 < size / 2; index1++)
	{
		int Sum = 0;
		for (int index = index1; index < size - index1 - 1; ++index)
			Sum += mat[index1][index];
		for (int index = index1; index < size - index1 - 1; ++index)
			Sum += mat[index][size - index1 - 1];
		for (int index = index1; index < size - index1 - 1; ++index)
			Sum += mat[size - index1 - 1][size - index - 1];
		for (int index = index1; index < size - index1 - 1; ++index)
			Sum += mat[size - index - 1][index1];
		std::cout << "Suma " << index1 + 1 << ": " << Sum << '\n';
	}
	if (size % 2 == 1)
		std::cout << "Suma " << size / 2 + 1 << ": " << mat[size / 2][size / 2];
}

void main()
{
	int **mat, size;
	read(mat, size, "in.txt");
	sum(mat, size);
	for (int index = 0; index < size; index++)
		delete[] mat[index];
	delete[] mat;
}