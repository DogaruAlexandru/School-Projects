#pragma once

struct Nod
{
	char info;
	int frequency;
	Nod* left, *right, *parent;
	Nod(char info = 254);
};