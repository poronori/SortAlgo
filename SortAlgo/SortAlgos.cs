using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgo
{
    class SortAlgos
    {
        /// <summary>
        /// Linq Sort
        /// </summary>
        /// <param name="numOfElem"></param>
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
        /// Shaker sort O(n^2)
        /// </summary>
        /// <param name="numOfElem"></param>
        public static void ShakerSort(int numOfElem)
        {
            var list = GetRandomList(numOfElem);

            // Sort elements
            for(int i=0; i<numOfElem; i++)
            {
                bool isFinished = true;

                // Swap if it 
                int min = 1 + i;
                int max = numOfElem - i;
                for (int j = min; j < max; j++)
                {
                    if (list[j - 1] > list[j])
                    {
                        SwapListElements(ref list, j - 1, j);
                        isFinished = false;
                    }
                }
                min = i;
                max = numOfElem - 2 - i;
                for (int j = max; j >= min; j--)
                {
                    if (list[j + 1] < list[j])
                    {
                        SwapListElements(ref list, j + 1, j);
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

        public static void CombSort(int numOfElem)
        {
            var list = GetRandomList(numOfElem);

            // Sort elements
            int h = numOfElem * 10 / 13;   // first h is n/1.3
            while (true)
            {
                bool isFinished = true;

                for (int i = 0; i < numOfElem - h; i++)
                {
                    if (list[i] > list[i + h])
                    {
                        SwapListElements(ref list, i, i + h);
                        isFinished = false;
                    }
                }

                if (h != 1)
                {
                    // h /= 1.3 unless h == 1
                    h = h * 10 / 13;
                }
                else if (isFinished)
                {
                    // finishing sorting
                    break;
                }
            }
            CheckListElements(list);
        }

        /// <summary>
        /// Comb sort O(n^2)
        /// </summary>
        /// <param name="numOfElem"></param>
        public static void CombSort(int numOfElem)
        {
            var list = GetRandomList(numOfElem);

            // Sort elements
            int h = numOfElem * 10 / 13;   // first h is n/1.3
            while (true)
            {
                bool isFinished = true;

                for (int i = 0; i < numOfElem - h; i++)
                {
                    if (list[i] > list[i + h])
                    {
                        SwapListElements(ref list, i, i + h);
                        isFinished = false;
                    }
                }

                if (h != 1)
                {
                    // h /= 1.3 unless h == 1
                    h = h * 10 / 13;
                }
                else if (isFinished)
                {
                    // finishing sorting
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
            for (int i = list.Count - 1; i >= 0; i--)
            {
                int maxIndex = -1;
                int max = Int32.MinValue;
                for (int j = 0; j <= i; j++)
                {
                    if (list[j] > max)
                    {
                        max = list[j];
                        maxIndex = j;
                    }
                }
                SwapListElements(ref list, i, maxIndex);
            }

            CheckListElements(list);
        }

        /// <summary>
        /// Create random element list and return it.
        /// </summary>
        /// <param name="numOfElem">the number of elements</param>
        /// <returns>created list</returns>
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

        /// <summary>
        /// Show elements as one line.
        /// </summary>
        /// <param name="list">target list</param>
        private static void ShowListElements(List<int> list)
        {
            string output = list.Aggregate("", (str, elem) => $"{str}, {elem}");
            output = output.Remove(0, 2);
            Console.WriteLine($"result = {output}");
        }

        /// <summary>
        /// Check if elements is sorted correctly.
        /// </summary>
        /// <param name="list">target list</param>
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
            Test.Log(result ? "OK" : "NG");
        }

        /// <summary>
        /// Swap elements of the given list.
        /// </summary>
        /// <param name="list">target list</param>
        /// <param name="index1">index</param>
        /// <param name="index2">another index</param>
        private static void SwapListElements(ref List<int> list, int index1, int index2)
        {
            int temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
