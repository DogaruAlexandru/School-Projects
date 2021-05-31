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

int verSort(int* array, int size)
{
	int index;
	for (index = 1; index < size; index++)
		if (array[index - 1] < array[index])
			break;
	if (index == size)
		return -1;
	for (index = 1; index < size; index++)
		if (array[index - 1] > array[index])
			break;
	if (index == size)
		return 1;
	return 0;
}

void main()
{
	int *array, size;
	read(array, size, "in.txt");
	int aux = verSort(array, size);
	if (aux == -1)
		std::cout << "Vector sortat descrescator";
	else if (aux == 1)
		std::cout << "Vector sortat crescator";
	else
		std::cout << "Vector nesortat";
	delete[] array;
}