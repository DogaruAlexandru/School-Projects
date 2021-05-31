#pragma once

#include <vector>
#include "Nod.h"

class PriortyQueueMin
{
	int size;
	std::vector<Nod*> data;

	void constr();
	void siftDown(int index);
	void siftUp(int index, Nod* p);

public:
	PriortyQueueMin();

	void write();
	void addVect(std::vector<Nod*> vect);

	void insert(Nod* p);
	Nod* getMin();
	int getSize();
	void pop();
};