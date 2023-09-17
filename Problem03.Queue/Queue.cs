namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Next = null;
            }
            public T Value { get; set; }
            public Node Next { get; set; }
            
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            Node newNode = new Node(item);
            if(this.Count == 0)
            {
                this.head = newNode;
            }
            else
            {
                Node current = this.head;
                while(current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            this.Count++;
        }

        public T Dequeue()
        {

            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                T value = this.head.Value;
                this.head = this.head.Next;
                this.Count--;
                return value;
            }

        }

        public T Peek()
        {
            if(this.head == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                T value = this.head.Value;
                return value;
            }
        }

        public bool Contains(T item)
        {
            Node node = this.head;
            while(node != null)
            {
                if(node.Value.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = this.head;
            while(node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}