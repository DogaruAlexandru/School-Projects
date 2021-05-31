#pragma once

#include <queue>
#include <vector>
#include "Nod.h"

template <typename T>
class AVL
{
private:
	Nod<T>* root;
	int fb(Nod<T>* p);
	int findHeight(Nod<T>* p);
	void fixInsert(Nod<T>* p);
	void spinLeft(Nod<T>* p);
	void spinRight(Nod<T>* p);
	void rsd(Nod<T>* p);
	void srd(Nod<T>* p);
	void sdr(Nod<T>* p);
	void layer(Nod<T>* p);
	void fixRemove(Nod<T>* p);
	Nod<T>* copy(Nod<T>* p);

	void build(const AVL<T>& treeBase, const AVL<T>& treeAdd);
	Nod<T>* getLeaf();
	void fixMerge(Nod<T>* p);

public:
	AVL();
	AVL(const AVL & avl);
	AVL(const std::vector<T> & vect);
	~AVL();
	AVL<T>& operator=(const AVL<T>& tree);
	void insert(T info);
	Nod<T>* getMin(Nod<T>* p);
	Nod<T>* getMax(Nod<T>* p);
	Nod<T>* getSuccesor(Nod<T>* p);
	Nod<T>* getPredecesor(Nod<T>* p);
	Nod<T>* search(T info);
	void print(int option);
	void empty();
	void remove(Nod<T>* p);
	void construct(const std::vector<T> & vect);
	void merge(const AVL<T>& tree1, const AVL<T>& tree2);

	Nod<T>* getRoot();
};

template<typename T>
inline AVL<T>::AVL()
{
	root = nullptr;
}

template<typename T>
inline AVL<T>::AVL(const AVL & avl2)
{
	*this = avl2;
}

template<typename T>
inline AVL<T>::AVL(const std::vector<T> & vect)
{
	root = nullptr;
	construct(vect);
}

template<typename T>
inline AVL<T>::~AVL()
{
	empty();
}

template<typename T>
inline AVL<T>& AVL<T>::operator=(const AVL<T>& tree)
{
	this->empty();
	this->root = copy(tree.root);
	return *this;
}

template<typename T>
inline void AVL<T>::insert(T info)
{
	Nod<T> *aux;
	aux = new Nod<T>(info);
	if (root != nullptr)
	{
		Nod<T>* p;
		p = root;
		while (p->left != nullptr || p->right != nullptr)
			if (p->info > info)
			{
				if (p->left == nullptr)
					break;
				p = p->left;
			}
			else
			{
				if (p->right == nullptr)
					break;
				p = p->right;
			}
		aux->parent = p;
		if (p->info > info)
			p->left = aux;
		else
			p->right = aux;
		fixInsert(p);
	}
	else
		root = aux;
}

template<typename T>
inline Nod<T>* AVL<T>::getMin(Nod<T>* p)
{
	while (p->left)
		p = p->left;
	return p;
}

template<typename T>
inline Nod<T>* AVL<T>::getMax(Nod<T>* p)
{
	while (p->right)
		p = p->right;
	return p;
}

template<typename T>
inline Nod<T>* AVL<T>::getSuccesor(Nod<T>* p)
{
	if (p->right)
	{
		p = p->right;
		return getMin(p);
	}
	while (p->parent)
		if (p->parent->right == p)
			p = p->parent;
		else
			return p->parent;
	return nullptr;
}

template<typename T>
inline Nod<T>* AVL<T>::getPredecesor(Nod<T>* p)
{
	if (p->left)
	{
		p = p->left;
		return getMax(p);
	}
	while (p->parent)
		if (p->parent->left == p)
			p = p->parent;
		else
			return p->parent;
	return nullptr;
}

template<typename T>
inline Nod<T>* AVL<T>::search(T info)
{
	Nod<T>* p = root;
	while (p)
		if (p->info < info)
			p = p->right;
		else if (p->info > info)
			p = p->left;
		else
			return p;
	return nullptr;
}

template<typename T>
inline void AVL<T>::print(int opt)
{
	if (root == nullptr)
	{
		std::cout << "Nu exista noduriin arbore.";
		return;
	}
	switch (opt)
	{
	case 1:
		rsd(root);
		break;
	case 2:
		srd(root);
		break;
	case 3:
		sdr(root);
		break;
	case 4:
		layer(root);
		break;
	default:
		break;
	}
}

template<typename T>
inline void AVL<T>::empty()
{
	std::queue<Nod<T>*> q;
	if (root)
		q.push(root);
	root = nullptr;
	while (q.empty() == 0)
	{
		if (q.front()->left)
			q.push(q.front()->left);
		if (q.front()->right)
			q.push(q.front()->right);
		delete q.front();
		q.pop();
	}
}

template<typename T>
inline void AVL<T>::remove(Nod<T>* p)
{
	if (p->left && p->right)
	{
		Nod<T>* aux;
		aux = getPredecesor(p);

		p->info = aux->info;
		if (aux->left)
			aux->left->parent = aux->parent;
		if (aux->parent->left == aux)
			aux->parent->left = aux->left;
		else
			aux->parent->right = aux->right;
		fixRemove(aux->parent);
		delete aux;
	}
	else
	{
		Nod<T>* aux = nullptr;
		if (p->left)
			aux = p->left;
		else if (p->right)
			aux = p->right;
		if (p->parent)
			if (p->parent->left == p)
				p->parent->left = aux;
			else
				p->parent->right = aux;
		if (aux)
			aux->parent = p->parent;
		if (p->parent)
			fixRemove(p->parent);
		else
			root = aux;
		delete p;
	}
}

template<typename T>
inline void AVL<T>::construct(const std::vector<T>& vect)
{
	this->empty();
	for (int index = 0; index < vect.size(); ++index)
		insert(vect[index]);
}

template<typename T>
inline void AVL<T>::merge(const AVL<T>& tree1, const AVL<T>& tree2)
{
	if (tree1.root && tree2.root)
		if (tree1.root->height > tree2.root->height)
			build(tree1, tree2);
		else
			build(tree2, tree1);
	else if (tree1.root)
		*this = tree1;
	else
		*this = tree2;
}

template<typename T>
inline void AVL<T>::fixInsert(Nod<T>* p)
{
	while (p && fb(p) != 0)
	{
		p->height = findHeight(p);
		if (fb(p) == -2)
		{
			if (fb(p->left) == -1)
				spinRight(p);
			else if (fb(p->left) == 1)
			{
				spinLeft(p->left);
				spinRight(p);
				if (p->parent->left)
					p->parent->left->height = findHeight(p->parent->left);
			}
			p->height = findHeight(p);
		}
		else if (fb(p) == 2)
		{
			if (fb(p->right) == -1)
			{
				spinRight(p->right);
				spinLeft(p);
				if (p->parent->right)
					p->parent->right->height = findHeight(p->parent->right);
			}
			else if (fb(p->right) == 1)
				spinLeft(p);
			p->height = findHeight(p);
		}
		p = p->parent;
	}
}

template<typename T>
inline void AVL<T>::spinLeft(Nod<T>* p)
{
	if (p->parent)
		if (p->parent->left == p)
			p->parent->left = p->right;
		else
			p->parent->right = p->right;

	Nod<T>* aux;
	aux = p->right;

	aux->parent = p->parent;
	p->parent = aux;

	p->right = aux->left;
	if (aux->left)
		aux->left->parent = p;
	aux->left = p;

	if (p == root)
		root = aux;
}

template<typename T>
inline void AVL<T>::spinRight(Nod<T>* p)
{
	if (p->parent)
		if (p->parent->left == p)
			p->parent->left = p->left;
		else
			p->parent->right = p->left;

	Nod<T>* aux;
	aux = p->left;

	aux->parent = p->parent;
	p->parent = aux;

	p->left = aux->right;
	if (aux->right)
		aux->right->parent = p;
	aux->right = p;

	if (p == root)
		root = aux;
}

template<typename T>
inline int AVL<T>::fb(Nod<T>* p)
{
	if (p->left == nullptr && p->right == nullptr)
		return 0;
	if (p->right == nullptr)
		return -p->left->height - 1;
	if (p->left == nullptr)
		return p->right->height + 1;
	return p->right->height - p->left->height;
}

template<typename T>
inline int AVL<T>::findHeight(Nod<T>* p)
{
	if (p->left == nullptr && p->right == nullptr)
		return 0;
	if (p->right == nullptr)
		return p->left->height + 1;
	if (p->left == nullptr)
		return p->right->height + 1;
	return (p->right->height > p->left->height) ? p->right->height + 1 : p->left->height + 1;
}

template<typename T>
inline Nod<T>* AVL<T>::getRoot()
{
	return root;
}

template<typename T>
inline void AVL<T>::rsd(Nod<T>* p)
{
	if (p)
	{
		std::cout << "Cheie:" << p->info << " Factor de balansare:" << fb(p) << '\n';
		rsd(p->left);
		rsd(p->right);
	}
}

template<typename T>
inline void AVL<T>::srd(Nod<T>* p)
{
	if (p)
	{
		srd(p->left);
		std::cout << "Cheie:" << p->info << " Factor de balansare:" << fb(p) << '\n';
		srd(p->right);
	}
}

template<typename T>
inline void AVL<T>::sdr(Nod<T>* p)
{
	if (p)
	{
		sdr(p->left);
		sdr(p->right);
		std::cout << "Cheie:" << p->info << " Factor de balansare:" << fb(p) << '\n';
	}
}

template<typename T>
inline void AVL<T>::layer(Nod<T>* p)
{
	std::queue<Nod<T>*> q;
	if (p)
		q.push(p);
	while (q.empty() == 0)
	{
		std::cout << "Cheie:" << q.front()->info << " Factor de balansare:" << fb(q.front()) << '\n';
		if (q.front()->left)
			q.push(q.front()->left);
		if (q.front()->right)
			q.push(q.front()->right);
		q.pop();
	}
}

template<typename T>
inline void AVL<T>::fixRemove(Nod<T>* p)
{
	while (p)
	{
		p->height = findHeight(p);
		if (fb(p) == -2)
		{
			if (fb(p->left) == -1 || fb(p->left) == 0)
				spinRight(p);
			else if (fb(p->left) == 1)
			{
				spinLeft(p->left);
				spinRight(p);
				if (p->parent->left)
					p->parent->left->height = findHeight(p->parent->left);
			}
			p->height = findHeight(p);
		}
		else if (fb(p) == 2)
		{
			if (fb(p->right) == -1)
			{
				spinRight(p->right);
				spinLeft(p);
				if (p->parent->right)
					p->parent->right->height = findHeight(p->parent->right);
			}
			else if (fb(p->right) == 1 || fb(p->right) == 0)
				spinLeft(p);
			p->height = findHeight(p);
		}
		p = p->parent;
	}
}

template<typename T>
inline Nod<T>* AVL<T>::copy(Nod<T>* p)
{
	Nod<T>* pCopy = nullptr;
	if (p)
	{
		pCopy = new Nod<T>(p->info);
		pCopy->height = p->height;
		if (p->left)
		{
			pCopy->left = copy(p->left);
			pCopy->left->parent = pCopy;
		}
		if (p->right)
		{
			pCopy->right = copy(p->right);
			pCopy->right->parent = pCopy;
		}
	}
	return pCopy;
}

template<typename T>
inline void AVL<T>::build(const AVL<T>& treeBase, const AVL<T>& treeAdd)
{
	*this = treeBase;
	AVL<T> add(treeAdd);
	while (add.root)
	{
		Nod<T>* aux = add.getLeaf();
		Nod<T>* p = root;
		while (p->left != nullptr || p->right != nullptr)
			if (p->info > aux->info)
			{
				if (p->left == nullptr)
					break;
				p = p->left;
			}
			else
			{
				if (p->right == nullptr)
					break;
				p = p->right;
			}

		if (p->info > aux->info)
		{
			while (aux->parent)
			{
				if (getPredecesor(p))
					if (getPredecesor(p)->info > getMin(aux->parent)->info)
						break;
				if (p->info < getMax(aux->parent)->info)
					break;
				aux = aux->parent;
			}
			if (aux->parent)
				if (aux->parent->left == aux)
					aux->parent->left = nullptr;
				else
					aux->parent->right = nullptr;
			p->left = aux;
			aux->parent = p;
		}
		else
		{
			while (aux->parent)
			{
				if (p->info > getMin(aux->parent)->info)
					break;
				if (getSuccesor(p))
					if (getSuccesor(p)->info < getMax(aux->parent)->info)
						break;
				aux = aux->parent;
			}
			if (aux->parent)
				if (aux->parent->left == aux)
					aux->parent->left = nullptr;
				else
					aux->parent->right = nullptr;
			p->right = aux;
			aux->parent = p;
		}
		if (aux == add.root)
			add.root = nullptr;
		fixMerge(aux);
	}
}

template<typename T>
inline Nod<T>* AVL<T>::getLeaf()
{
	Nod<T>* p = root;
	while (p->left || p->right)
	{
		if (p->left && p->right)
			if (p->left->height > p->right->height)
				p = p->left;
			else
				p = p->right;
		else if (p->left)
			p = p->left;
		else
			p = p->right;
	}
	return p;
}

template<typename T>
inline void AVL<T>::fixMerge(Nod<T>* p)
{
	while (p)
	{
		p->height = findHeight(p);
		if (fb(p) <= -2)
		{
			if (fb(p->left) == -1 || fb(p->left) == 0)
				spinRight(p);
			else if (fb(p->left) == 1)
			{
				spinLeft(p->left);
				spinRight(p);
				if (p->parent->left)
					p->parent->left->height = findHeight(p->parent->left);
				continue;
			}
			p->height = findHeight(p);
		}
		else if (fb(p) >= 2)
		{
			if (fb(p->right) == -1)
			{
				spinRight(p->right);
				spinLeft(p);
				if (p->parent->right)
					p->parent->right->height = findHeight(p->parent->right);
				continue;
			}
			else if (fb(p->right) == 1 || fb(p->right) == 0)
				spinLeft(p);
			p->height = findHeight(p);
		}
		p = p->parent;
	}
}