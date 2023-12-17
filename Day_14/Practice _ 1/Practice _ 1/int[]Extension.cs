using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_01
{
    public static class int__extension
    {
        public static int[] RemovesDublicate(this int[] array)
        {
            {
                int count = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    bool isDuplicate = false;

                    for (int j = array.Length - 1; j > i; j--)
                    {
                        if (array[i] == array[j])
                        {
                            isDuplicate = true;
                        }
                    }

                    if (!isDuplicate)
                    {
                        array[count++] = array[i];
                    }
                }

                int[] resultArray = new int[count];
                for (int i = 0; i < count; i++)
                {
                    resultArray[i] = array[i];
                }

                return resultArray;
            }
        }
        public static string FindNumber(this int[] array, int num)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == num)
                {
                    result = $"Array containt {num}";
                    return result;
                }
            }
            result = $"Array does not containt {num}";
            return result;
        }
        public static int ReturneMaxElement(this int[] array)
        {
            int result = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > result)
                {
                    result = array[i];
                }
            }
            return result;
        }
        public static int[] MergeTwoArray(this int[] array, int[] array2)
        {
            int[] array3 = new int[array.Length + array2.Length];
            for (int i = 0, j = 0; i < array3.Length; i++)
            {
                if (i < array.Length)
                {
                    array3[i] = array[i];
                }
                if (i >= array.Length)
                {
                    array3[i] = array2[j];
                    j++;
                }
            }
            return array3;
        }
        public static string arrayToString(this int[] array, char separator)
        {
            string arrayString = "";
            for(int i = 0; i < array.Length; i++)
            {
                if (i < array.Length - 1)
                {
                    arrayString += $"{array[i]}{separator}";
                }
                else
                {
                    arrayString += $"{array[i]}";
                }
            }
            return arrayString;
        }
    }
}