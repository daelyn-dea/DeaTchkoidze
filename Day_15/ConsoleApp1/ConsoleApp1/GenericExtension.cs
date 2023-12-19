using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class ExtentionClass
    {
        public static void SwapElements<T>(this T[] array, T element1, T element2)  
        {
            int index1 = Array.IndexOf(array, element1);
            int index2 = Array.IndexOf(array, element2);
            if (index1 == -1 || index2 == -1)
            {
                Console.WriteLine("One or both elements not found in the array. Cannot swap.");
                return;
            }
            T swapping = array[index1];
            array[index1] = array[index2];
            array[index2] = swapping;
        }

        public static T FindMaximum<T>(this T[] array) where T : IComparable<T>
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Array is null or empty");
            }

            T maximum = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(maximum) > 0)
                {
                    maximum = array[i];
                }
            }

            return maximum;
        }
    }
}
