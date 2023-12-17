using ConsoleApp1;
//1.
int[] array = { 1, 2, 3, 4, 5 };
array.SwapElements(3, 1);
for (int i = 0; i < array.Length; i++)
{
    Console.WriteLine(array[i]);
}



//2.
Console.WriteLine($"Max element is: {array.FindMaximum()}");

//3.
GenericQueue<int> intQueue = new GenericQueue<int>();
intQueue.Enqueue(10);
intQueue.Peek();
intQueue.Dequeue();
intQueue.Dequeue();

GenericQueue<string> stringQueue = new GenericQueue<string>();
stringQueue.Enqueue("pepp");
stringQueue.Peek();
stringQueue.Dequeue();
stringQueue.Dequeue();

//4
GenericStack<int> intStack = new GenericStack<int>();
intStack.Push(1);
intStack.Push(2);
intStack.Push(3);
intStack.Push(4);
intStack.Push(5);
intStack.Peek();
intStack.Pop();
intStack.Pop();
intStack.Pop();
intStack.Pop();
intStack.Pop();
intStack.Pop();
intStack.Peek();

GenericStack<string> stringStack = new GenericStack<string>();
stringStack.Push("pop");
stringStack.Peek();
stringStack.Pop();
stringStack.Pop();
