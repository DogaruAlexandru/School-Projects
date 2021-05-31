#include "PriortyQueueMin.h"
#include <algorithm>
#include <iostream>

PriortyQueueMin::PriortyQueueMin()
{
	size = 0;
}

void PriortyQueueMin::constr()
{
	for (int index = size / 2 - 1; index >= 0; --index)
		siftDown(index);
}

void PriortyQueueMin::siftDown(int index)
{
	int left = 2 * index + 1;
	int right = 2 * index + 2;
	int min = index;
	if (left < size && data[left]->frequency < data[index]->frequency)
		min = left;
	if (right < size && data[right]->frequency < data[min]->frequency)
		min = right;
	if (min != index)
	{
		std::swap(data[index], data[min]);
		siftDown(min);
	}
}

void PriortyQueueMin::siftUp(int index, Nod* p)
{
	if (p->frequency < data[index]->frequency)
	{
		data[index]->frequency = p->frequency;
		int aux = (index - 1) / 2;
		while (index > 0 && data[aux]->frequency > p->frequency)
		{
			data[index] = data[aux];
			index = aux;
			aux = (index - 1) / 2;
		}
		data[index] = p;
	}
	else
		std::cout << 'x';
}

void PriortyQueueMin::write()
{
	int index = 0;
	for (; index < size; index++)
		std::cout << '(' << data[index]->info << ", " << data[index]->frequency << ") ";
}

void PriortyQueueMin::addVect(std::vector<Nod*> vect)
{
	data = vect;
	constr();
}

void PriortyQueueMin::insert(Nod* p)
{
	Nod* aux = new Nod;
	aux->frequency = INT_MAX;
	data.push_back(aux);
	++size;
	siftUp(size - 1, p);
}

Nod* PriortyQueueMin::getMin()
{
	return data[0];
}

int PriortyQueueMin::getSize()
{
	return size;
}

void PriortyQueueMin::pop()
{
	if (size > 0)
	{
		data[0] = data[size - 1];
		--size;
		data.resize(size);
		siftDown(0);
	}
}