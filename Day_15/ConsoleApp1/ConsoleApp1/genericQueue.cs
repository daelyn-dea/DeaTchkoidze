using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class GenericQueue<T>
    {
        private T[] array { get; set; }
        private int indexOfArray {get; set;}
        public GenericQueue()
        {
             array  = new T[4];
             indexOfArray = 0;
        }
 
        public void Enqueue(T element)
        {
            if(indexOfArray < array.Length)
            {
                array[indexOfArray] = element;
                Console.WriteLine($"Enqueued: {element}");
                indexOfArray++;
            }
            else
            {
                T[] newArray  = new T[indexOfArray * 2];
                for(int i = 0; i < array.Length; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
                array[indexOfArray] = element;
                Console.WriteLine($"Enqueued: {element}");
                indexOfArray++;
            }
        }
        public T Peek()
        {
            if (indexOfArray > 0)
            {
                Console.WriteLine($"Peeked: {array[0]}");
                return array[0];
            }
            Console.WriteLine("Queue is empty. Cannot peek.");
            return array[0];

        }
        public T Dequeue()
        {
            if(indexOfArray > 0)
            {
                T index0 = array[0];
                for (int i = 0; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                indexOfArray--;
                Console.WriteLine($"Dequeued: {index0}");
                return index0;
            }
                Console.WriteLine("Queue is empty. Cannot dequeue.");
                return array[0];
        }
    }
}
