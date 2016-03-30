using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class MergeSort
    {
        // New array to hold the sorted array
        private static IComparable[] aux;

        // Public method that creates a new array that is set to the size of the 
        // array being passed in. Calls the private Sort method that does all 
        // the sorting. LengthOfCollection is the length of the array being passed
        // in, minus 1. 
        public static void Sort(IComparable[] array, int lengthOfCollection)
        {
            aux = new IComparable[array.Length];
            Sort(array, 0, lengthOfCollection);
        }

        // Private method that recursively calls itself. The array is split in
        // half. The left half is then split in half recursively until it is of size
        // 1. After having 2 arrays of size 1, those arrays are passed into merge to sort
        // and merge the arrays. This repeats until there is no more to split on the left side
        // and then the right side is done.  
        private static void Sort(IComparable[] array, int low, int high)
        {
            if (high <= low)
            {
                return;
            }

            int mid = low + ((high - low) / 2);
            Sort(array, low, mid);
            Sort(array, mid + 1, high);
            Merge(array, low, mid, high);
        }

        // Public method that compares the 2 arrays and sorts and merges in 
        // ascending order.
        public static void Merge(IComparable[] array, int low, int mid, int high)
        {
            
            int i = low;
            int j = mid + 1;
            
            // Makes a new copy (aux) of the passed in array
            for (int k = low; k <= high; k++)
            {
                aux[k] = array[k];
            }

            // Goes from low to high comparing the first half of the passed in
            // array with the second half of the passed in array. 
            for (int k = low; k <= high; k++)
            {
                // At the end of the first half of the array, so add
                // aux[j] to the array and increment j.
                if (i > mid)
                {
                    array[k] = aux[j++];
                }

                // At the end of the second half of the array, so add
                // aux[i] to the array and increment i. 
                else if (j > high)
                {
                    array[k] = aux[i++];
                }

                // If true, aux[i] is greater than aux[j], so add
                // aux[j] (the smaller value) to the array and increment j.
                else if (aux[j].CompareTo(aux[i]) < 0)
                {
                    array[k] = aux[j++];
                }

                // Else aux[j] is greater than aux[i], so add
                // aux[i] (the smaller value) to the array and increment i.
                else
                {
                    array[k] = aux[i++];
                }
            }

        }
    }
}
