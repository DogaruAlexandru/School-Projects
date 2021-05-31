#include <iostream>
#include <fstream>
#include <utility>
#include <queue>
#include <iomanip>

void read(int**& mat, int& rows, int& cols, std::string filePath)
{
	std::ifstream myFile(filePath);
	if (myFile.is_open())
	{
		myFile >> rows >> cols;
		mat = new int*[rows];
		for (int index = 0; index < rows; ++index)
			mat[index] = new int[cols];
		for (int index1 = 0; index1 < rows; ++index1)
			for (int index2 = 0; index2 < cols; ++index2)
				myFile >> mat[index1][index2];
		myFile.close();
	}
	else
		std::cout << "File not open";
}
int** copy(int** mat, int rows, int cols)
{
	int** matCopy = new int*[rows];
	for (int index = 0; index < rows; ++index)
		matCopy[index] = new int[cols];
	for (int index1 = 0; index1 < rows; ++index1)
		for (int index2 = 0; index2 < cols; ++index2)
			matCopy[index1][index2] = mat[index1][index2];
	return matCopy;
}
bool find(int* arr, int size, int elem)
{
	for (int index = 0; index < size; ++index)
		if (arr[index] == elem)
			return 1;
	return 0;

}
void write(int** mat, int rows, int cols)
{
	for (int index1 = 0; index1 < rows; ++index1)
	{
		for (int index2 = 0; index2 < cols; ++index2)
			std::cout << std::setw(2) << mat[index1][index2] << ' ';
		std::cout << '\n';
	}
	std::cout << '\n';
}
void mark(int** mat, int rows, int cols, std::pair<int, int> aux, int& no, bool type)
{
	std::queue <std::pair <int, int>> queue;
	queue.push(aux);
	mat[aux.first][aux.second] = no;
	while (queue.empty() == 0)
	{
		if (mat[queue.front().first][queue.front().second + 1] == 0)
		{
			queue.push(std::make_pair(queue.front().first, queue.front().second + 1));
			if (type)
				++no;
			mat[queue.front().first][queue.front().second + 1] = no;
		}
		if (mat[queue.front().first][queue.front().second - 1] == 0)
		{
			queue.push(std::make_pair(queue.front().first, queue.front().second - 1));
			if (type)
				++no;
			mat[queue.front().first][queue.front().second - 1] = no;
		}
		if (mat[queue.front().first + 1][queue.front().second] == 0)
		{
			queue.push(std::make_pair(queue.front().first + 1, queue.front().second));
			if (type)
				++no;
			mat[queue.front().first + 1][queue.front().second] = no;
		}
		if (mat[queue.front().first - 1][queue.front().second] == 0)
		{
			queue.push(std::make_pair(queue.front().first - 1, queue.front().second));
			if (type)
				++no;
			mat[queue.front().first - 1][queue.front().second] = no;
		}
		queue.pop();
	}
}
void rooms(int** mat, int rows, int cols, int& no, int& max, bool type)
{
	int room = 0;
	no = max = 0;
	for (int index1 = 1; index1 < rows - 1; ++index1)
		for (int index2 = 1; index2 < cols - 1; ++index2)
			if (mat[index1][index2] == 0)
			{
				++room;
				if (type)
					no = 1;
				else
					no = room;
				mark(mat, rows, cols, std::make_pair(index1, index2), no, type);
				if (no > max)
					max = no;
			}
	no = room;
}
void fill(int** mat, int rows, int cols, std::pair<int, int> aux, int no)
{
	std::queue <std::pair <int, int>> queue;
	queue.push(aux);
	mat[aux.first][aux.second] = no;
	while (queue.empty() == 0)
	{
		if (mat[queue.front().first][queue.front().second + 1] != -1 && mat[queue.front().first][queue.front().second + 1] != no)
		{
			queue.push(std::make_pair(queue.front().first, queue.front().second + 1));
			mat[queue.front().first][queue.front().second + 1] = no;
		}
		if (mat[queue.front().first][queue.front().second - 1] != -1 && mat[queue.front().first][queue.front().second - 1] != no)
		{
			queue.push(std::make_pair(queue.front().first, queue.front().second - 1));
			mat[queue.front().first][queue.front().second - 1] = no;
		}
		if (mat[queue.front().first + 1][queue.front().second] != -1 && mat[queue.front().first + 1][queue.front().second] != no)
		{
			queue.push(std::make_pair(queue.front().first + 1, queue.front().second));
			mat[queue.front().first + 1][queue.front().second] = no;
		}
		if (mat[queue.front().first - 1][queue.front().second] != -1 && mat[queue.front().first - 1][queue.front().second] != no)
		{
			queue.push(std::make_pair(queue.front().first - 1, queue.front().second));
			mat[queue.front().first - 1][queue.front().second] = no;
		}
		queue.pop();
	}
}
void maxRoom(int** mat, int rows, int cols)
{
	int** copyMat = copy(mat, rows, cols);
	int** copyMat1 = copy(mat, rows, cols);
	int a, b;
	rooms(copyMat1, rows, cols, a, b, 0);
	for (int index1 = 1; index1 < rows - 1; ++index1)
		for (int index2 = 1; index2 < cols - 1; ++index2)
			if (copyMat[index1][index2] == 0)
			{
				int no = 1;
				mark(copyMat, rows, cols, std::make_pair(index1, index2), no, 1);
				fill(copyMat, rows, cols, std::make_pair(index1, index2), no);
			}
	int max = 0;
	std::pair<int, int> aux;
	for (int index1 = 1; index1 < rows - 1; ++index1)
		for (int index2 = 1; index2 < cols - 1; ++index2)
			if (copyMat[index1][index2] == -1)
			{
				int *arr = new int[3], k = 0;
				int sum = 0;
				if (copyMat[index1 - 1][index2] != -1 && find(arr, k, copyMat1[index1 - 1][index2]) == 0)
				{
					arr[k++] = copyMat1[index1 - 1][index2];
					sum += copyMat[index1 - 1][index2];
				}
				if (copyMat[index1 + 1][index2] != -1 && find(arr, k, copyMat1[index1 + 1][index2]) == 0)
				{
					arr[k++] = copyMat1[index1 + 1][index2];
					sum += copyMat[index1 + 1][index2];
				}
				if (copyMat[index1][index2 - 1] != -1 && find(arr, k, copyMat1[index1][index2 - 1]) == 0)
				{
					arr[k++] = copyMat1[index1][index2 - 1];
					sum += copyMat[index1][index2 - 1];
				}
				if (copyMat[index1][index2 + 1] != -1 && find(arr, k, copyMat1[index1][index2 + 1]) == 0)
				{
					arr[k++] = copyMat1[index1][index2 + 1];
					sum += copyMat[index1][index2 + 1];
				}
				delete[] arr;
				if (max < sum)
				{
					max = sum;
					aux.first = index1;
					aux.second = index2;
				}
			}
	std::cout <<"pentru a avea o camera maxima se sparge peretele "<< aux.first << ' ' << aux.second << '\n';
	mat[aux.first][aux.second] = 0;
	write(mat, rows, cols);
	for (int index = 0; index < rows; index++)
		delete[] copyMat[index];
	delete[] copyMat;
	for (int index = 0; index < rows; index++)
		delete[] copyMat1[index];
	delete[] copyMat1;
}

void main()
{
	int **mat, cols, rows, no, max;
	read(mat, rows, cols, "in.txt");
	int **copyMat = copy(mat, rows, cols);
	rooms(copyMat, rows, cols, no, max, 1);
	write(mat, rows, cols);
	std::cout << "Numarul de camere este: " << no << '\n';
	std::cout << "Suprafata maxima este: " << max << '\n';
	for (int index = 0; index < rows; index++)
		delete[] copyMat[index];
	delete[] copyMat;
	maxRoom(mat, rows, cols);
	for (int index = 0; index < rows; index++)
		delete[] mat[index];
	delete[] mat;
}