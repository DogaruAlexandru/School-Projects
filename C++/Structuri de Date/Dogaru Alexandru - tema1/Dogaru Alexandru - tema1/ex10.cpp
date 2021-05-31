#include <iostream>
#include <fstream>
#include <string>
#include <cmath>

void read(int**& mat, int& size, std::string filePath)
{
	std::ifstream myFile(filePath);
	if (myFile.is_open())
	{
		myFile >> size;
		mat = new int*[size];
		for (int index = 0; index < size; ++index)
			mat[index] = new int[size];
		for (int index1 = 0; index1 < size; ++index1)
			for (int index2 = 0; index2 < size; ++index2)
				myFile >> mat[index1][index2];
		myFile.close();
	}
	else
		std::cout << "File not open";
}

void write(int* array, int size)
{
	for (int index = 0; index < size; ++index)
		std::cout << array[index] << ' ';
}

void create(int*& array, int& size, std::string filePath)
{
	int** mat, sizeMat, index = 0;
	read(mat, sizeMat, filePath);
	size = sizeMat * (sizeMat + 1) / 2;
	array = new int[size];
	for (int index1 = 0; index1 < sizeMat; ++index1)
		for (int index2 = 0; index2 <= index1; ++index2)
			array[index++] = mat[index1][index2];

	for (int index = 0; index < sizeMat; index++)
		delete[] mat[index];
	delete[] mat;
}

void product(int* array1, int size1, int* array2, int size2, int*& array, int& size)
{
	int sizeMat = int(sqrt(size1 * 2)), index;
	size = size1;
	array = new int[size];
	for (int index = 0; index < size; index++)
		array[index] = 0;
	for (int index1 = 0; index1 < sizeMat; ++index1)
		for (int index2 = 0; index2 <= index1; ++index2)
			for (int index3 = index2; index2 <= index1; ++index2)
				array[((index1 + 1)*index1) / 2 + index2] += array1[((index1 + 1)*index1) / 2 + index2 + index3] * array2[((index3 + 1)*index3) / 2 + index2];
}

void main()
{
	int* array1, size1, *array2, size2, *array, size;
	create(array1, size1, "in1.txt");
	create(array2, size2, "in2.txt");
	product(array1, size1, array2, size2, array, size);
	write(array, size);
	delete[] array1;
	delete[] array2;
	delete[] array;
}