#include <iostream>
#include "conio.h"

struct Nod
{
	int info;
	Nod* next;
};

class List
{
	Nod* head;
	Nod* searchPrev(Nod* nod)
	{
		Nod* aux = head;
		while (aux->next != NULL)
		{
			if (aux->next == nod)
				return aux;
			aux = aux->next;
		}
		return NULL;
	}
public:
	List()
	{
		head = NULL;
	}
	~List()
	{
		while (head != NULL)
		{
			Nod* p = head;
			head = head->next;
			delete p;
		}
	}
	bool isEmpty()
	{
		return head == NULL;
	}
	void insert(int elem)
	{
		Nod* aux = new Nod;
		aux->info = elem;
		if (isEmpty() == 1)
			aux->next = NULL;
		else
			aux->next = head;
		head = aux;
	}
	Nod* search(int elem)
	{
		Nod* aux = head;
		while (aux != NULL)
		{
			if (aux->info == elem)
				return aux;
			aux = aux->next;
		}
		return NULL;
	}
	void remove(int elem)
	{
		if (isEmpty() == 1)
		{
			std::cout << "Nu exista nodul cu cheia k=" << elem << '\n';
			return;
		}
		Nod* aux = head;
		if (aux->info == elem)
		{
			head = head->next;
			delete aux;
		}
		else
		{
			while (aux->next != NULL)
			{
				if (aux->next->info == elem)
					break;
				aux = aux->next;
			}
			if (aux->next != NULL)
			{
				Nod* p = aux->next;
				aux->next = aux->next->next;
				delete p;
			}
		}
	}
	void swap(Nod* nod1, Nod* nod2)
	{
		insert(0);
		Nod* aux1 = searchPrev(nod1);
		Nod* aux2 = searchPrev(nod2);
		if (aux1 == NULL || aux2 == NULL || aux1 == aux2)
		{
			std::cout << "Nu se poate executa interschimbarea.\n";
			Nod* aux = head;
			head = head->next;
			delete aux;
			return;
		}
		Nod* aux = nod2;
		if (nod2->next != nod1)
			aux = aux->next;
		aux1->next = nod2;
		aux2->next = nod1;
		nod2->next = nod1->next;
		nod1->next = aux;
		aux = head;
		head = head->next;
		delete aux;
	}
	void sort()
	{
		if (head == NULL || head->next == NULL)
		{
			std::cout << "Nu se poate executa sortarea.\n";
			return;
		}
		Nod* index1, *index2;
		for (index1 = head; index1->next != NULL; index1 = index1->next)
			for (index2 = index1->next; index2 != NULL; index2 = index2->next)
				if (index1->info > index2->info)
				{
					int aux = index1->info;
					index1->info = index2->info;
					index2->info = aux;
				}
	}
	void insertBefore(int pos, int elem)
	{
		Nod* aux = head;
		if (aux == NULL || aux->info == pos)
		{
			insert(elem);
		}
		else
		{
			while (aux->next != NULL)
			{
				if (aux->next->info == pos)
					break;
				aux = aux->next;
			}
			Nod* p = new Nod;
			p->info = elem;
			if (aux->next != NULL)
				p->next = aux->next;

			else
				p->next = NULL;
			aux->next = p;
		}

	}
	void printList()
	{
		Nod* aux = head;
		while (aux != NULL)
		{
			std::cout << aux->info << ' ';
			aux = aux->next;
		}
		std::cout << '\n';
	}
};

void main()
{
	List list;
	char no = 0;
	std::cout << "Pentru a introduce un element in capatul listei apasati 1\n";
	std::cout << "Pentru a cauta un element in lista apasati 2\n";
	std::cout << "Pentru a sterge un element din lista apasati 3\n";
	std::cout << "Pentru a verifica daca lista este vida apasati 4\n";
	std::cout << "Pentru a schimba ordinea a 2 noduri din lista apasati 5\n";
	std::cout << "Pentru a sorta crescator elementele listei apasati 6\n";
	std::cout << "Pentru a introduce un element inaintea unui alt element apasati 7\n";
	std::cout << "Pentru a afisa lista apasati 8\n";
	std::cout << "Pentru a iesi din mediu apasati esc\n";
	no = _getch();
	while (no != 27)
	{
		no -= '0';
		switch (no)
		{
		case 1:
			int elem;
			std::cout << "Introduceti elementul: ";
			std::cin >> elem;
			list.insert(elem);
			break;
		case 2:
			std::cout << "Introduceti elementul: ";
			std::cin >> elem;
			list.search(elem);
			break;
		case 3:
			std::cout << "Introduceti elementul: ";
			std::cin >> elem;
			break;
		case 4:
			if (list.isEmpty() == 1)
				std::cout << "Lista vida.";
			else
				std::cout << "Lista nu e vida.";
			break;
		case 5:
			int elem1, elem2;
			std::cout << "Introduceti valorile din nodurile pe care vreti sa le interschimbati din lista: ";
			std::cin >> elem1 >> elem2;
			list.swap(list.search(elem1), list.search(elem2));
			break;
		case 6:
			list.sort();
			break;
		case 7:
			std::cout << "Introduceti valoarea elemntului in fata careia se adauga apoi valoa noului elemnet: ";
			std::cin >> elem1 >> elem2;
			list.insertBefore(elem1, elem2);
			break;
		case 8:
			list.printList();
			break;
		default:
			break;
		}
		no = _getch();
		std::cout << '\n';
	}
}