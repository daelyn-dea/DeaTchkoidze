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

                    for (int j = array.Length-1; j > i; j--)
                    {
                        if (array[i] == array[j] )
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
                for(int i = 0; i < count; i++)
                {
                    resultArray[i] = array[i];
                }

                return resultArray;
            }
        }
        public static string FindNumber(this int[] array, int num)
        {
            string result = "";
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == num)
                {
                    result = $"Array containt {i}";
                    return result;
                }
                result = $"Array does not containt {i}";
                return result;
            }
        }
}
