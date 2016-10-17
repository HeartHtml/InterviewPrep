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
            for (int i = 0; i < array.Length; i ++)
            {
                for (int j = i; j < array.Length; j ++)
                {
                    if (j < 0)
                    {
                        break;
                    }

                    if (array[i] > array[j])
                    {
                        int holder = array[i];

                        array[i] = array[j];

                        array[j] = holder;

                        j --;
                    }
                }
            }
        }
    }
}
