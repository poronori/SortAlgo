using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgo
{
    class SortAlgos
    {
        public static void LinqSort(int numOfElem)
        {
            var list = GetRandomList(numOfElem);

            // Sort elements
            list.Sort();

            CheckListElements(list);
        }

        /// <summary>
        /// Bubble sort O(n^2)
        /// </summary>
        /// <param name="numOfElem"></param>
        public static void BabbleSort(int numOfElem)
        {
            var list = GetRandomList(numOfElem);

            // Sort elements
            while (true)
            {
                bool isFinished = true;

                // Swap if it needed
                for (int i = 1; i < numOfElem; i++)
                {
                    if (list[i - 1] > list[i])
                    {
                        SwapListElements(ref list, i - 1, i);
                        isFinished = false;
                    }
                }

                // Check if it finished
                if (isFinished)
                {
                    break;
                }
            }
            CheckListElements(list);
        }

        /// <summary>
        /// Bubble sort (loop end is shrinked gradually) O(n^2)
        /// </summary>
        /// <param name="numOfElem"></param>
        public static void BabbleSort2(int numOfElem)
        {
            var list = GetRandomList(numOfElem);

            // Sort elements
            int count = 0;
            while (true)
            {
                bool isFinished = true;

                // Swap if it needed
                for (int i = 1; i < numOfElem - count; i++)
                {
                    if (list[i - 1] > list[i])
                    {
                        SwapListElements(ref list, i - 1, i);
                        isFinished = false;
                    }
                }
                count++;

                // Check if it finished
                if (isFinished)
                {
                    break;
                }
            }
            CheckListElements(list);
        }

        /// <summary>
        /// Selection sort O(n^2)
        /// </summary>
        /// <param name="numOfElem"></param>
        public static void SelectionSort(int numOfElem)
        {
            var list = GetRandomList(numOfElem);

            // Sort elements

            CheckListElements(list);
        }

        private static List<int> GetRandomList(int numOfElem)
        {
            Random rand = new Random();

            // Create elements
            List<int> list = new List<int>();
            for (int i = 1; i <= numOfElem; i++)
            {
                list.Add(i);
            }

            // Mix elements
            for (int i = 0; i < numOfElem; i++)
            {
                int index = rand.Next(numOfElem);
                SwapListElements(ref list, i, index);
            }

            return list;
        }

        private static void ShowListElements(List<int> list)
        {
            string output = list.Aggregate("", (str, elem) => $"{str}, {elem}");
            output = output.Remove(0, 2);
            Console.WriteLine($"result = {output}");
        }

        private static void CheckListElements(List<int> list)
        {
            bool result = true;
            for(int i=1; i<list.Count; i++)
            {
                if(list[i - 1] > list[i])
                {
                    result = false;
                    break;
                }
            }
            Console.WriteLine(result ? "OK" : "NG");
        }

        private static void SwapListElements(ref List<int> list, int index1, int index2)
        {
            int temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
