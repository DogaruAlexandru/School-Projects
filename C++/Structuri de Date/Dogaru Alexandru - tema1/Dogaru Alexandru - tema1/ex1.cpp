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

void triples(int* array, int size)
{
	for (int index = 2; index < size; index++)
		if (array[index - 2] < array[index - 1] && array[index - 1] < array[index])
			std::cout << array[index - 2] << ' ' << array[index - 1] << ' ' << array[index] << '\n';
}

void main()
{
	int *array, size;
	read(array, size, "in.txt");
	triples(array, size);
	delete[] array;
}