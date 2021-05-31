#include <iostream>
#include <cstdlib>
#include <conio.h>
#include "AVL.h"

void main()
{
	AVL<float> avl, avlSup, avlJoin;
	std::vector<float> vect;
	int option = 0, size;
	float x;
	Nod<float>* p;
	while (option != 13)
	{
		system("cls");
		std::cout << "Meniu arbore AVL:\n";
		std::cout << "Introduceti:  1 pentru insertie\n";
		std::cout << "              2 pentru cautare\n";
		std::cout << "              3 pentru stergere\n";
		std::cout << "              4 pentru minim\n";
		std::cout << "              5 pentru maxim\n";
		std::cout << "              6 pentru predecesor\n";
		std::cout << "              7 pentru succesor\n";
		std::cout << "              8 pentru afisare in preordine\n";
		std::cout << "              9 pentru afisare in inordine\n";
		std::cout << "             10 pentru afisare in postordine\n";
		std::cout << "             11 pentru afisare pe niveluri\n";
		std::cout << "             12 pentru reuniune\n";
		std::cout << "             13 pentru iesire\n";
		std::cin >> option;

		system("cls");
		switch (option)
		{
		case 1:
			std::cout << "Introduceti valoare pe care doriti sa o adaugati: ";
			std::cin >> x;
			avl.insert(x);
			break;
		case 2:
			std::cout << "Introduceti valoare pe care doriti sa o cautati: ";
			std::cin >> x;
			if (avl.search(x) == nullptr)
				std::cout << "Nu exista aceasta valoare in arbore.";
			else
				std::cout << "Exista aceasta valoare in arbore.";
			_getch();
			break;
		case 3:
			std::cout << "Introduceti valoare pe care doriti sa o stergeti: ";
			std::cin >> x;
			if (avl.search(x) == nullptr)
			{
				std::cout << "Nu exista aceasta valoare in arbore.";
				_getch();
			}
			else
				avl.remove(avl.search(x));
			break;
		case 4:
			if (avl.getRoot() == nullptr)
				std::cout << "Arbore este gol,";
			else
				std::cout << "Valoarea maxima din arbore este: " << avl.getMax(avl.getRoot())->info;
			_getch();
			break;
		case 5:
			if (avl.getRoot() == nullptr)
				std::cout << "Arbore este gol.";
			else
				std::cout << "Valoarea mminima din arbore este: " << avl.getMin(avl.getRoot())->info;
			_getch();
			break;
		case 6:
			std::cout << "Introduceti valoarea careia ii cautati predecesorul: ";
			std::cin >> x;
			p = avl.search(x);
			if (p == nullptr)
				std::cout << "Nu exista aceasta valoare in arbore.";
			else
			{
				p = avl.getPredecesor(p);
				if (p == nullptr)
					std::cout << "Nu exista predecesor in arbore pentru valoare aleasa.";
				else
					std::cout << "Predecesorul valorii alese este: " << p->info;
			}
			_getch();
			break;
		case 7:
			std::cout << "Introduceti valoarea careia ii cautati succesor: ";
			std::cin >> x;
			p = avl.search(x);
			if (p == nullptr)
				std::cout << "Nu exista aceasta valoare in arbore.";
			else
			{
				p = avl.getSuccesor(p);
				if (p == nullptr)
					std::cout << "Nu exista succesor in arbore pentru valoare aleasa.";
				else
					std::cout << "Succesorul valorii alese este: " << p->info;
			}
			_getch();
			break;
		case 8:
			avl.print(1);
			_getch();
			break;
		case 9:
			avl.print(2);
			_getch();
			break;
		case 10:
			avl.print(3);
			_getch();
			break;
		case 11:
			avl.print(4);
			_getch();
			break;
		case 12:
			std::cout << "Introduceti cate valori vreti sa aveti in al doilea arbore: ";
			std::cin >> size;
			vect.resize(size);
			if (size)
			{
				std::cout << "Introduceti valorile din al doilea arbore:\n";
				for (int index = 0; index < size; ++index)
				{
					std::cin >> x;
					vect[index] = x;
				}
				avlSup.construct(vect);
				avlJoin.merge(avl, avlSup);
			}
			avlJoin.print(1);
			_getch();
			break;
		default:
			break;
		}
	}
}