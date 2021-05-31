#pragma once

template <typename T>
struct Nod
{
	T info;
	int height;
	Nod* left, *right, *parent;
	Nod(T info);
};

template <typename T>
inline Nod<T>::Nod(T info)
{
	this->info = info;
	height = 0;
	left = right = parent = nullptr;
}
