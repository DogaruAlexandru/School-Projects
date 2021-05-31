#include <iostream>
#include <fstream>
#include <string>
#include <cmath>

void read(bool**& mat, int& size, std::string filePath)
{
	std::ifstream myFile(filePath);
	if (myFile.is_open())
	{
		myFile >> size;
		mat = new bool*[size];
		for (int index = 0; index < size; index++)
			mat[index] = new bool[size];
		for (int index1 = 0; index1 < size; index1++)
			for (int index2 = 0; index2 < size; index2++)
				myFile >> mat[index1][index2];
		myFile.close();
	}
	else
		std::cout << "File not open";
}

void a(bool** mat, int size)
{
	std::cout << "Elevii care se agreeaz reciproc sunt:\n";
	for (int index1 = 0; index1 < size - 1; index1++)
		for (int index2 = index1 + 1; index2 < size; index2++)
			if (mat[index1][index2] + mat[index2][index1] == 2)
				std::cout << index1 + 1 << ' ' << index2 + 1 << '\n';
	std::cout << '\n';
}

void b(bool** mat, int size)
{
	std::cout << "Elevii care nu agreeaza pe nimeni sunt: ";
	for (int index1 = 0; index1 < size; index1++)
	{
		int index2;
		for (index2 = 0; index2 < size; index2++)
			if (mat[index1][index2] == 1 && index1 != index2)
				break;
		if (index2 == size)
			std::cout << index1 + 1 << ' ';
	}
	std::cout << "\n\n";
}

void c(bool** mat, int size)
{
	std::cout << "Elevii care nu sunt agreati de nimeni sunt: ";
	for (int index1 = 0; index1 < size; index1++)
	{
		int index2;
		for (index2 = 0; index2 < size; index2++)
			if (mat[index2][index1] == 1 && index1 != index2)
				break;
		if (index2 == size)
			std::cout << index1 + 1 << ' ';
	}
	std::cout << '\n';
}

void main()
{
	bool **mat;
	int size;
	read(mat, size, "in.txt");
	a(mat, size);
	b(mat, size);
	c(mat, size);
	for (int index = 0; index < size; index++)
		delete[] mat[index];
	delete[] mat;
}