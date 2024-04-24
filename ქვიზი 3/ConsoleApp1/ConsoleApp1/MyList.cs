using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] items;
        private int count;

        public int Count => count;

        public MyList()
        {
            items = new T[4]; 
            count = 0;
        }

        public T this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }


        public void Add(T item)
        {
            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2); 
            }
            items[count++] = item;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            while (items.Length < collection.Count() || count == items.Length)
            {
                    Array.Resize(ref items, items.Length * 2);
            }
            foreach(T item in collection)
            {
                items[count++] = item;
            }
        }

        public void Remove(T item)
        {
            if (items.Contains(item))
            {
                for(int i = 0; i < items.Length; i++)
                {
                    if (item.Equals(items[i]))
                    {
                        for (int j = i; j < items.Length; j++)
                        {
                            if(j + 1 < items.Length)
                            {
                                items[j] = items[j + 1];
                            }
                        }
                    }
                }
                count--;
            }
        }

        public void RemoveRange(int start, int quantyty)
        {
            if (count > (start + quantyty))
            {
                for (int i = start; i <= quantyty+1; i++)
                {
                    items[i] = items[start + quantyty];
                    items[start + quantyty] = default;
                }
                count -= quantyty;
            }
            else
                throw new Exception("ArgumentOutOfRangeException");
        }
        public void RemoveAt(int index)
        {
            if(items.Length < index)
            {
                throw new Exception("ArgumentOutOfRangeException");
            }
            for(int i = index; i < items.Length; i++)
            {
                if(i + 1 < items.Length)
                    items[i] = items[i + 1];
                if (i + 1 >= items.Length)
                    items[i] = default;
            }
        }

        public bool Contains(T item)
        {
            for( int i = 0; i <  items.Length; i++)
            {
                if (item.Equals(items[i]))
                {
                    return true;
                }

            }
            return false;
        }

        public T First(Func<T, bool> predicate)
        {
            for(int i = 0; i < items.Length; i++)
            {
                if (predicate(items[i]))
                {
                    return items[i];
                }
            }
            throw new OperationException("InvalidOperationException"); 

        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (predicate(items[i]))
                {
                    return items[i];
                }
            }
            return default;

        }

        public MyList<T> Where(Func<T, bool> predicate)
        {
            MyList<T> list = new MyList<T>();
            for (int i = 0; i < items.Length; i++)
            {
                if (predicate(items[i]))
                {
                    list.Add(items[i]);
                }
            }
            return list;
        }

        public MyList<T> Distinct()
        {
            MyList<T> list = new MyList<T>();
            list.AddRange(items);
            for (int i = 0; i < list.count; i++)
            {
                for (int j = 0; j < list.count; j++)
                {
                    if (list[j].Equals(list[i]) && i != j)
                    {
                        if (j + 1 < list.count)
                        {
                            list[j] = list[j + 1];
                        }
                        if (j + 1 == list.Count)
                            list[j] = default;
                    }
                }
            }
            return list;
        }

        public MyList<T> OrderBy(Func<T, bool> func)
        {
            for(int i = 0; i < items.Length; i++)
            {
                for(int j = 0; j < items.Length; j++)
                {
                    if (func(items[j]))
                    {

                    }
                }
            }
            return default;

        }

        public IEnumerator<T> GetEnumerator()
        {
            return default;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
