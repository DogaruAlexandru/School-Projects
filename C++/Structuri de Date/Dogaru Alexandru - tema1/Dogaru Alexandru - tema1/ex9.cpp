#include <iostream>
#include <fstream>
#include <string>

void read(int*& array, int& size, std::string filePath)
{
	std::ifstream myFile(filePath);
	if (myFile.is_open())
	{
		myFile >> size;
		array = new int[size];
		for (int index = 0; index < size; index++)
			myFile >> array[index];
		myFile.close();
	}
	else
		std::cout << "File not open";
}

void write(int** mat, int size)
{
	for (int index1 = 0; index1 < size; ++index1)
	{
		for (int index2 = 0; index2 < size; ++index2)
			std::cout << mat[index1][index2] << ' ';
		std::cout << '\n';
	}
}
void create(int**& mat, int& size)
{
	int* array;
	read(array, size, "in.txt");
	mat = new int*[size];
	for (int index = 0; index < size; index++)
		mat[index] = new int[size];
	for (int index1 = 0; index1 < size; index1++)
		for (int index2 = 0; index2 < size; index2++)
			mat[index1][index2] = array[(index1 + index2) % size];
	delete[] array;
}

void main()
{
	int **mat, size;
	create(mat, size);
	write(mat, size);
	for (int index = 0; index < size; index++)
		delete[] mat[index];
	delete[] mat;
}