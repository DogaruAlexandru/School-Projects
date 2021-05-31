#include <iostream>

struct Nod
{
	int info;
	Nod* next;
};

class Queue
{
	Nod* Front;
	Nod* Back;
public:
	Queue()
	{
		Front = NULL;
	}
	~Queue()
	{
		while (Front != NULL)
		{
			Nod* p = Front;
			Front = Front->next;
			delete p;
		}
	}
	bool isEmpty()
	{
		return (Front == NULL);
	}
	void push(int elem)
	{
		Nod* x = new Nod;
		x->info = elem;
		x->next = NULL;
		if (isEmpty() == 1)
			Front = Back = x;
		else
		{
			Back->next = x;
			Back = x;
		}
	}
	void pop()
	{
		if (isEmpty() == 0)
		{
			Nod* p = Front;
			Front = Front->next;
			delete p;
		}
		else
			std::cout << "Coada nu are nici un element de sters\n";
	}
	int front()
	{
		return Front->info;
	}
};

class Stack
{
	Nod* Top;
public:
	Stack()
	{
		Top = NULL;
	}
	~Stack()
	{
		while (Top != NULL)
		{
			Nod* p = Top;
			Top = Top->next;
			delete p;
		}
	}
	void push(int elem)
	{
		Nod* x = new Nod;
		x->info = elem;
		if (isEmpty() == 0)
			x->next = Top;
		else
			x->next = NULL;
		Top = x;
	}
	bool isEmpty()
	{
		return (Top == NULL);
	}
	void pop()
	{
		if (isEmpty() == 0)
		{
			Nod* p = Top;
			Top = Top->next;
			delete p;
		}
		else
			std::cout << "Stiva nu are nici un element de sters\n";
	}
	int top()
	{
		return Top->info;
	}
};

void main()
{
	Stack s;
	int n;
	std::cout << "introduceti numarul de elemente din stiva: ";
	std::cin >> n;
	std::cout << "itroduceti elementele stivei:\n";
	for (int index = 0; index < n; index++)
	{
		int x;
		std::cin >> x;
		s.push(x);
	}
	std::cout << "elementele din stiva sunt:\n";
	while (s.isEmpty() == 0)
	{
		std::cout << s.top() << ' ';
		s.pop();
	}
	std::cout << "\n\n\n";

	Queue q;
	std::cout << "Introduceti numarul de elemente din coada: ";
	std::cin >> n;
	std::cout << "Itroduceti elementele cozii:\n";
	for (int index = 0; index < n; index++)
	{
		int x;
		std::cin >> x;
		q.push(x);
	}
	std::cout << "Elementele din coada sunt:\n";
	while (q.isEmpty() == 0)
	{
		std::cout << q.front() << ' ';
		q.pop();
	}
}
