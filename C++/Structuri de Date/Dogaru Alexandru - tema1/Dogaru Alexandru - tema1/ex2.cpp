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

void frequency(int* array, int size)
{
	int* array1 = new int[101];
	for (int index = 0; index < 101; index++)
		array1[index] = 0;
	for (int index = 0; index < size; index++)
		array1[array[index]]++;
	for (int index = 0; index < 101; index++)
		if (array1[index] > 1)
			std::cout << index << " apare de " << array1[index] << " ori\n";
	delete[] array1;
}

void main()
{
	int *array, size;
	read(array, size, "in.txt");
	frequency(array, size);
	delete[] array;
}