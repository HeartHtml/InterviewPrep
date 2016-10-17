using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.Entities
{
    public class InsertionSort
    {
        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    if (array[j - 1] > array[j])
                    { 
                        int temp = array[j - 1];

                        array[j - 1] = array[j];

                        array[j] = temp;
                    }

                    j--;
                }
            }
        }
    }
}
