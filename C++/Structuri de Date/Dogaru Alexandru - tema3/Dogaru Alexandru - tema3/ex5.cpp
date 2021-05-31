#include <iostream>
#include <fstream>
#include <queue>

struct Nod
{
	Nod(char add = 'x')
	{
		info = add;
		left = right = NULL;
	}
	char info;
	Nod* left, *right;
};

struct BinaryTree
{
	Nod* root = new Nod;
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
	void read(std::string filePath)
	{
		std::ifstream myFile(filePath);
		if (myFile.is_open())
		{
			int leaves;
			char way, info;
			myFile >> leaves;
			for (int index = 0; index < leaves; ++index)
			{
				myFile >> info;
				Nod* p = root;
				while (myFile.peek() != '\n' && myFile.peek() != EOF)
				{
					myFile >> way;
					if (way - '0' == 0)
					{
						if (p->left == NULL)
						{
							Nod* aux = new Nod;
							p->left = aux;
						}
						p = p->left;
					}
					else
					{
						if (p->right == NULL)
						{
							Nod* aux = new Nod;
							p->right = aux;
						}
						p = p->right;
					}
				}
				p->info = info;
				myFile.get();
			}
			myFile.close();
		}
		else
			std::cout << "File not open";
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
};

void main()
{
	BinaryTree tree;
	tree.read("in.txt");
	tree.rsd(tree.root);
}