namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            
            public Node(T value)
            {
                this.Value = value;
                this.Previous = null;
            }
            public T Value { get; set; }
            public Node Previous { get; set; }
        }

        private Node top;

        public int Count { get; set; }

        public void Push(T item)
        {
            Node newNode = new Node(item);

            if (this.Count == 0)
            {
                this.top = newNode;
            }
            else
            {
                newNode.Previous = this.top;
                this.top = newNode;
            }
            this.Count++;
        }

        public T Pop()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T value = this.top.Value;
            this.top = this.top.Previous;
            this.Count--;
            return value;
        }

        public T Peek()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T value = this.top.Value;
            return value;
        }

        public bool Contains(T item)
        {
            Node node = this.top;
            while(node != null)
            {
                if(node.Value.Equals(item))
                {
                    return true;
                }
                node = node.Previous;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = this.top;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}