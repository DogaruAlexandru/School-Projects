#include <iostream>
#include <fstream>
#include <string>
#include <queue>

struct Nod
{
	int info;
	Nod* left, *right;
	Nod(int aux)
	{
		info = aux;
		left = right = NULL;
	}
};

int* readArr(int& size, std::string filePath)
{
	std::ifstream myFile(filePath);
	if (myFile.is_open())
	{
		myFile >> size;
		int* arr = new int[size];
		for (int index = 0; index < size; ++index)
			myFile >> arr[index];
		myFile.close();
		return arr;
	}
	else
		std::cout << "File not open";
}

struct BinaryTree
{
	Nod* root = NULL;
	~BinaryTree()
	{
		std::queue <Nod*> tree;
		tree.push(root);
		while (tree.empty() == 0)
		{
			if (tree.front()->left != NULL)
				tree.push(tree.front()->left);
			if (tree.front()->right != NULL)
				tree.push(tree.front()->right);
			delete tree.front();
			tree.pop();
		}
	}
	int find(int* arr, int inf, int sup, int no)	//nu verifica sup
	{
		for (; inf < sup; ++inf)
			if (arr[inf] == no)
				return inf;
	}
	void create(int* rsd, int infRSD, int supRSD, int* srd, int infSRD, int supSRD, Nod*& p)
	{
		if (supRSD > infRSD && supSRD > infSRD)
		{
			int indexCurrent;
			indexCurrent = find(srd, infSRD, supSRD, rsd[infRSD]);
			p = new Nod(rsd[infRSD]);
			if (root == NULL)
				root = p;
			int sizeLeft = indexCurrent - infSRD;
			int sizeRight = supSRD- indexCurrent ;
			create(rsd, infRSD + 1, (sizeLeft + 1) + infRSD, srd, infSRD, indexCurrent, p->left);
			create(rsd, infRSD + sizeLeft + 1, infRSD + sizeLeft + sizeRight + 1, srd, indexCurrent + 1, supSRD, p->right);
		}
	}
	void buildTree()
	{
		int* rsd, *srd, size;
		rsd = readArr(size, "RSD.txt");
		srd = readArr(size, "SRD.txt");
		create(rsd, 0, size, srd, 0, size, root);
		delete[] rsd;
		delete[] srd;
	}
	void rsd(Nod* x)
	{
		if (x)
		{
			std::cout << x->info << " ";
			rsd(x->left);
			rsd(x->right);
		}
	}
	void srd(Nod* x)
	{
		if (x)
		{
			srd(x->left);
			std::cout << x->info << " ";
			srd(x->right);
		}
	}
	void sdr(Nod* x)
	{
		if (x)
		{
			sdr(x->left);
			sdr(x->right);
			std::cout << x->info << " ";
		}
	}
};

void main()
{
	BinaryTree tree;
	tree.buildTree();
	tree.rsd(tree.root);
	std::cout << '\n';
	tree.srd(tree.root);
	std::cout << '\n';
	tree.sdr(tree.root);
}
