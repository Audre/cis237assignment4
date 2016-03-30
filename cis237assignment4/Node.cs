using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    // This class is used as a "node" in linked lists. 
    class Node<T>
    {
        // Public properties
        public Node<T> Next
        {
            get;
            set;
        }

        public T Data
        {
            get;
            set;
        }
    }
}
