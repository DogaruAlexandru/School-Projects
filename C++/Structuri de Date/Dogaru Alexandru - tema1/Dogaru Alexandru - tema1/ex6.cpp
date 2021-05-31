#include <iostream>
#include <fstream>
#include <string>

void read(int*& array, int& size, int& digits, std::string filePath)
{
	std::ifstream myFile(filePath);
	if (myFile.is_open())
	{
		myFile >> size >> digits;
		array = new int[size];
		for (int index = 0; index < size; ++index)
			myFile >> array[index];
		myFile.close();
	}
	else
		std::cout << "File not open";
}

void write(int* array, int size)
{
	for (int index = 0; index < size; index++)
		std::cout << array[index];
}

void elim(int*& array, int& size, int digits)
{
	int* auxArray = new int[size - digits];
	for (int index = size - 1, no = size-digits-1; no >= 0; --index)
		if (array[index] != -1)
			auxArray[no--] = array[index];
	size -= digits;
	delete[] array;
	array = auxArray;
}

void biggest(int*& array, int& size, int digits)
{
	int no = 0;
	for (int index1 = 0, index2 = 1; index2 < size && no < digits;)
	{
		if (array[index1] < array[index2])
		{
			array[index1] = -1;
			no++;
			while (array[index1] == -1 && index1 >= 0)
				--index1;
			if (index1 == -1)
				index1 = index2++;
		}
		else
			index1 = index2++;
	}
	for (int index = size - 1; no < digits; --index)
		if (array[index] != -1)
		{
			array[index] = -1;
			no++;
		}
	elim(array, size, digits);
}

void main()
{
	int *array, size, digits;
	read(array, size, digits, "in.txt");
	biggest(array, size, digits);
	write(array, size);
	delete[] array;
}