using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GenericStack<T>
    {
        private T[] array { get; set; }
        private int indexOfArray { get; set; }
        public GenericStack()
        {
            array = new T[0];
            indexOfArray = 0;
        }

        public T Push(T element)
        {
            indexOfArray++;
            T[] newArray = new T[array.Length+1];
            if (newArray.Length > 1)
            {
                for (int i = 1; i < newArray.Length; i++)
                {
                    newArray[i] = array[i - 1];
                }
            }
            array = newArray;
            array[0] = element;
            Console.WriteLine($"Push: {element}");
            return array[0];
        }
        public T Peek()
        {
            if (indexOfArray > 0)
            {
                T lastAdded = array[array.Length - 1];
                Console.WriteLine($"Peeked: {lastAdded}");
                return lastAdded;
            }
            Console.WriteLine("Queue is empty. Cannot peek.");
            return default(T);
        }
        public T Pop()
        {
            if (indexOfArray > 0)
            {
                T lastAdded = array[array.Length - 1];
                T[] newArray = new T[array.Length - 1];
                for (int i = 0; i < newArray.Length; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
                Console.WriteLine($"poped: {lastAdded}");
                indexOfArray--;
                return lastAdded;
            }
            Console.WriteLine("Queue is empty. Cannot poped.");
            return default (T);
        }
    }
}