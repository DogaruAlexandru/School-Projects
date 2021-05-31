#include <iostream>

class Queue
{
	const int MAX_SIZE = 3;
	int* data, begin, end;
public:
	Queue()
	{
		begin = end = 0;
		data = new int[MAX_SIZE];
	}
	~Queue()
	{
		delete[] data;
	}
	bool isEmpty()
	{
		return	end == begin;
	}
	bool isFull()
	{
		return (end + 1) % MAX_SIZE == begin;
	}
	void push(int elem)
	{
		if (isFull() == 0)
		{
			data[end % MAX_SIZE] = elem;
			++end;
		}
		else
			std::cout << "Coada este plina.\n";
	}
	void pop()
	{
		if (isEmpty() == 0)
			begin = (begin + 1) % SIZE_MAX;
		else
			std::cout << "Nu exista nici un element de sters.\n";
	}
	int front()
	{
		return data[begin];
	}
};

void main()
{
	int no;
	Queue queue;
	std::cout << "Introduceti numarul de elemente din coada: ";
	std::cin >> no;
	std::cout << "Introduceti elementele cozii:\n";
	for (int index = 0; index < no; ++index)
	{
		int elem;
		std::cin >> elem;
		queue.push(elem);
	}
	for (int index = 0; index < no; ++index)
	{
		std::cout << queue.front() << ' ';
		queue.pop();
	}
	std::cout << queue.front();
}