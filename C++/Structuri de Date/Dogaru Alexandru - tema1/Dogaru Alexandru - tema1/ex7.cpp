#include <iostream>

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
	std::cout << "Introduceti dimensiunea matricei: ";
	std::cin >> size;
	mat = new int*[size];
	for (int index = 0; index < size; index++)
		mat[index] = new int[size];

	int no = size % 2 * (size*size + 1);
	for (int index1 = 0; index1 < size / 2; index1++)
	{
		for (int index = index1; index < size - index1 - 1; ++index)
		{
			no = no + 1 - size % 2 * 2;
			mat[index1][index] = no;
		}
		for (int index = index1; index < size - index1 - 1; ++index)
		{
			no = no + 1 - size % 2 * 2;
			mat[index][size - index1 - 1] = no;
		}
		for (int index = index1; index < size - index1 - 1; ++index)
		{
			no = no + 1 - size % 2 * 2;
			mat[size - index1 - 1][size - index - 1] = no;
		}
		for (int index = index1; index < size - index1 - 1; ++index)
		{
			no = no + 1 - size % 2 * 2;
			mat[size - index - 1][index1] = no;
		}
	}
	if (size % 2 == 1)
		mat[size / 2][size / 2] = --no;

	//int no = size % 2 * (size*size + 1);
	//for (int index1 = 0; index1 < size / 2; index1++)
	//{
	//	for (int index = index1; index < size - index1 - 1; ++index)
	//	{
	//		no = no + 1 - size % 2 * 2;
	//		mat[index1][index] = no;
	//		mat[index][size - index1 - 1] = no + (size - (index1 + 1) * 2 + 1)*(-1 + (size + 1) % 2 * 2);
	//		mat[size - index1 - 1][size - index - 1] = no + ((size - (index1 + 1) * 2 + 1) * 2)*(-1 + (size + 1) % 2 * 2);
	//		mat[size - index - 1][index1] = no + ((size - (index1 + 1) * 2 + 1) * 3)*(-1 + (size + 1) % 2 * 2);
	//	}
	//	no = no + ((size - index1 * 2 - 1) * 3)*(-1 + (size + 1) % 2 * 2);
	//}
	//if (size % 2 == 1)
	//	mat[size / 2][size / 2] = --no;
}

void main()
{
	int **mat;
	int size;
	create(mat, size);
	write(mat, size);
	for (int index = 0; index < size; index++)
		delete[] mat[index];
	delete[] mat;
}