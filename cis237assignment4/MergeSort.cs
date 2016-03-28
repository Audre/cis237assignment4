using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class MergeSort
    {
        private IComparable[] aux;

        public void Sort(IComparable[] array)
        {
            aux = new IComparable[array.Length];
            Sort(array, 0, array.Length - 1);
        }

        public void Merge(IComparable[] array, int low, int mid, int high)
        {
            
            int i = low;
            int j = mid + 1;
            
            for (int k = low; k <= high; k++)
            {
                aux[k] = array[k];
            }

            for (int k = low; k <= high; k++)
            {
                if (i > mid)
                {
                    array[k] = aux[j++];
                }

                else if (j > high)
                {
                    array[k] = aux[i++];
                }

                else if ((aux[j].CompareTo(aux[i])) > 0)
                {
                    array[k] = aux[j++];
                }

                else
                {
                    array[k] = aux[i++];
                }
            }

        }

        private void Sort(IComparable[] array, int low, int high)
        {
            if (high <= low)
            {
                return;
            }

            int mid = low + (high - low) / 2;
            Sort(array, low, mid);
            Sort(array, mid + 1, high);
            Merge(array, low, mid, high);
        }
    }
}
