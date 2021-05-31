#include "Nod.h"

Nod::Nod(char info)
{
	this->info = info;
	frequency = 0;
	left = right = parent = nullptr;
}