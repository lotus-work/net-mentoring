using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private class Node
        {
            public T Data;
            public Node? Next;
            public Node? Prev;

            public Node(T data)
            {
                Data = data;
            }
        }

        private Node? head;
        private Node? tail;
        private int count;

        public int Length => count;

        public void Add(T e)
        {
            var newNode = new Node(e);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            count++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException();

            if (index == count)
            {
                Add(e);
                return;
            }

            var newNode = new Node(e);
            if (index == 0)
            {
                newNode.Next = head;
                head!.Prev = newNode;
                head = newNode;
            }
            else
            {
                var current = GetNodeAt(index);
                var previous = current!.Prev;

                previous!.Next = newNode;
                newNode.Prev = previous;
                newNode.Next = current;
                current.Prev = newNode;
            }
            count++;
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException($"Index {index} is out of range.");

            return GetNodeAt(index).Data!;
        }

        public void Remove(T item)
        {
            var current = head;
            while (current != null)
            {
                if (Equals(current.Data, item))
                {
                    RemoveNode(current);
                    return;
                }
                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException($"Index {index} is out of range.");

            var node = GetNodeAt(index);
            var data = node.Data;
            RemoveNode(node);
            return data;
        }

        private Node GetNodeAt(int index)
        {
            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }

            return current!;
        }


        private void RemoveNode(Node node)
        {
            if (node.Prev != null)
                node.Prev.Next = node.Next;
            else
                head = node.Next;

            if (node.Next != null)
                node.Next.Prev = node.Prev;
            else
                tail = node.Prev;

            count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class DoublyLinkedListEnumerator : IEnumerator<T>
        {
            private Node? current;
            private readonly DoublyLinkedList<T> list;

            public DoublyLinkedListEnumerator(DoublyLinkedList<T> list)
            {
                this.list = list;
                current = null;
            }

            public T Current => current!.Data;

            object IEnumerator.Current => Current!;

            public bool MoveNext()
            {
                if (current == null)
                    current = list.head;
                else
                    current = current.Next;

                return current != null;
            }

            public void Reset() => current = null;

            public void Dispose() { }
        }
    }
}
