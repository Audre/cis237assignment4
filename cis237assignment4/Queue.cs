using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;
        private int count;

        public bool isEmpty()
        {
            return first == null;
        }

        public int size()
        {
            return count;
        }

        // Adds a new node to the end of the linked list.
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
