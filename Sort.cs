using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Sort
    {
        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static List<int> ShellSort(List<int> data)
        {
            for (int gap = data.Count / 2; gap > 0; gap = gap / 2)
            {
                for (var i = gap; i < data.Count; i++)
                {
                    var j = i;
                    var current = data[i];
                    while (j - gap >= 0 && current < data[j - gap])
                    {
                        data[j] = data[j - gap];
                        j = j - gap;
                    }
                    data[j] = current;
                }
            }
            return data;
        }


        /// <summary>
        /// 快拍
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QuickSort(int[] array, int left, int right)
        {
            if (array.Length <=1)
            {
                return;
            }
            int baseNum = array[left];
            int i = left, j = right;
            int temp = 0;
            while (i != j)
            {
                while(array[i]<baseNum && i < j)
                {
                    i++;
                }
                while(array[j]<baseNum && i < j)
                {
                    j--;
                }
                if (1 < j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            array[i] = array[j];
            array[j] = baseNum;
            QuickSort(array, left, i-1);
            QuickSort(array, i-1, right);

        }
    }
}
