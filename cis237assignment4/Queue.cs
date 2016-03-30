using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Queue<T>
    {
        // Backing fields.
        protected Node<T> first;
        protected Node<T> last;
        protected int count;

        // Public property to know if the queue is empty or not. 
        public bool isEmpty()
        {
            return first == null;
        }

        // Public property to know the size of the queue. 
        public int size()
        {
            return count;
        }

        // Adds a new node to the end of the linked list. If isEmpty() is true,
        // then the new node added is the first and last node. 
        public void Enqueue(T data)
        {
            Node<T> oldLast = last;
            last = new Node<T>();
            last.Data = data;
            last.Next = null;
            if (isEmpty())
            {
                first = last;
            }

            else
            {
                oldLast.Next = last;
            }

            count++;
        }

        // Removes a node from the front of the linked list. 
        public T Dequeue()
        {
            T data = first.Data;
            first = first.Next;
            if (isEmpty())
            {
                last = null;
            }

            count--;
            return data;
        }
    }
}
