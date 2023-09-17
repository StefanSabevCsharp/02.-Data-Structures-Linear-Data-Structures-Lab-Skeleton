namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List(int capacity)
        {
            this.items = new T[capacity];
        }

        public List()
            : this(DEFAULT_CAPACITY)
        {

        }


        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < this.Count)
                {
                    return this.items[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < this.Count)
                {
                    this.items[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if(this.Count == this.items.Length)
            {
                this.Grow();
            }
            this.items[this.Count] = item;
            this.Count++;
        }

        

        public bool Contains(T item)
        {
            for(int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }

            }
            return false;
        }


        public int IndexOf(T item)
        {
           int indexOfSearchedItem = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    indexOfSearchedItem = i;
                    break;
                }
            }
            return indexOfSearchedItem;
        }

        public void Insert(int index, T item)
        {
            if (CheckValidIndex(index))
            {
                if (this.Count == this.items.Length)
                {
                    this.Grow();
                }
               
                //for (int i = this.Count + 1; i > index; i--)
                //{
                //    items[i] = items[i - 1];
                //}
                //items[index] = item;
                //this.Count++;

                for (int i = this.Count - 1; i >= index; i--)
                {
                    items[i + 1] = items[i];
                }
                items[index] = item;
                this.Count++;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                RemoveAt(IndexOf(item));
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (CheckValidIndex(index))
            {
                for (int i = index; i < this.Count - 1; i++)
                {
                    items[i] = items[i + 1];
                }
                Count--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
           
        }


        public IEnumerator<T> GetEnumerator()
        {
           for (int i = 0; i< this.Count; i++)
            {
                yield return this.items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

        private void Grow()
        {
            T[] newArray = new T[this.items.Length * 2];

            for(int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.items[i];
            }
            this.items = newArray;
        }
        private bool CheckValidIndex(int index)
        {
            if(index < 0 || index >= this.Count)   // Check >= if tests not passing
            {
               return false;
            }
            return true;
        }
    }
}