﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Stack<T>
    {
        protected Node<T> first;
        protected int count;

        // Public property to tell if the stack is empty or not.
        public bool isEmpty()
        {
            return first == null;
        }

        // Public property to get the size of the stack.
        public int size()
        {
            return count;
        }

        // Adds a new node to the front of the linked list. 
        public void push(T data)
        {
            Node<T> oldFirst = first;
            first = new Node<T>();
            first.Data = data;
            first.Next = oldFirst;
            count++;
        }

        // Removes a node from the front of the linked list. 
        public T pop()
        {
            T data = first.Data;
            first = first.Next;
            count--;
            return data;
        }
    }
}
