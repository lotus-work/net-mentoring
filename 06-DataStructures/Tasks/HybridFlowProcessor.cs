using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private readonly IDoublyLinkedList<T> storage = new DoublyLinkedList<T>();

        public void Enqueue(T item)
        {
            storage.Add(item);
        }

        public void Push(T item)
        {
            storage.AddAt(0, item);
        }

        public T Dequeue()
        {
            if (storage.Length == 0)
                throw new InvalidOperationException("Queue is empty.");
            return storage.RemoveAt(0);
        }

        public T Pop()
        {
            if (storage.Length == 0)
                throw new InvalidOperationException("Stack is empty.");
            return storage.RemoveAt(0);
        }
    }
}