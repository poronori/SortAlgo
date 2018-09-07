using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgo
{
    public class SortAlgos
    {
        /// <summary>
        /// Check given sort algorithm is correct.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="numOfElem"></param>
        public static void CheckSortAlgo(Func<List<int>, List<int>> func, int numOfElem)
        {
            var list = GetRandomList(numOfElem);
            list = func(list);
        }

        #region sort algorithm

        /// <summary>
        /// Linq Sort
        /// </summary>
        /// <param name="list">sort target list</param>
        /// <returns>sorted list</returns>
        public static List<int> LinqSort(List<int> list)
        {
            // Sort elements
            list.Sort();
            return list;
        }

        /// <summary>
        /// Bubble sort O(n^2)
        /// - Compare sequentially each index to the index + 1 and swap them if needed.
        /// - Repeat the all above until nothing is swapped.
        /// </summary>
        /// <param name="list">sort target list</param>
        /// <returns>sorted list</returns>
        public static List<int> BabbleSort(List<int> list)
        {
            int numOfElem = list.Count;
            int count = 0;
            while (true)
            {
                bool isFinished = true;

                // Swap if needed
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
                if (isFinished) break;
            }
            return list;
        }

        /// <summary>
        /// Shaker sort O(n^2)
        /// - Compare an index to the index + 1 and swap them if needed.
        /// - Do again oppositely.
        /// - Repeat sequentially the all above until nothing is swapped.
        /// </summary>
        /// <param name="list">sort target list</param>
        /// <returns>sorted list</returns>
        public static List<int> ShakerSort(List<int> list)
        {
            int numOfElem = list.Count;
            for (int i = 0; i < numOfElem; i++)
            {
                bool isFinished = true;

                // Swap1 if needed
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
                // Check if it finished
                if (isFinished) break;

                // Swap2 if needed
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
                if (isFinished) break;
            }
            return list;
        }

        /// <summary>
        /// Comb sort O(n^2)
        /// - The first h is floor(n/1.3).
        /// - Compare sequentially each index to the index + h and swap them if needed.
        /// - Renew h; new h is current h/1.3 unless h is 1.
        /// - Repeat the all above with new h until nothing is swapped.
        /// </summary>
        /// <param name="list">sort target list</param>
        /// <returns>sorted list</returns>
        public static List<int> CombSort(List<int> list)
        {
            int numOfElem = list.Count;

            // first h is n/1.3
            int h = numOfElem * 10 / 13;
            while (true)
            {
                bool isFinished = true;

                // swap index:i and index:i+h if needed
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
            return list;
        }

        /// <summary>
        /// Selection sort O(n^2)
        /// - Select max number from rest of items (First rest of items is all)
        /// - Swap The max number and max index item of rest of items.
        /// - Remove max index item from rest of items and the result is new rest of item.
        /// - Repeat the all above until the next target is min item.
        /// </summary>
        /// <param name="list">sort target list</param>
        /// <returns>sorted list</returns>
        public static List<int> SelectionSort(List<int> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                // Search max number and its index
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

                // Swap maximun number and maximun index item not swapped
                SwapListElements(ref list, i, maxIndex);
            }
            return list;
        }

        /// <summary>
        /// Insertion sort O(n^2)
        /// - Check sequentially each index and insert it into its appropreate position of already checked items.
        /// - Repeat the all above until the last item is checked.
        /// </summary>
        /// <param name="list">sort target list</param>
        /// <returns>sorted list</returns>
        public static List<int> InsertionSort(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                // Insert the current item into its appropreate position of already checked items
                int currentItem = list[i];
                for (int j = i; j >= 0; j--)
                {
                    if (j != 0 && currentItem < list[j - 1])
                    {
                        list[j] = list[j - 1];
                    }
                    else
                    {
                        list[j] = currentItem;
                        break;
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Gnome sort O(n^2)
        /// </summary>
        /// <param name="list">sort target list</param>
        /// <returns>sorted list</returns>
        public static List<int> GnomeSort(List<int> list)
        {
            int i = 1;
            while (i < list.Count)
            {
                // Insert the current item into its appropreate position of already checked items
                if (i > 0 && list[i] < list[i - 1])
                {
                    SwapListElements(ref list, i, i - 1);
                    i--;
                }
                else
                {
                    i++;
                }
            }
            return list;
        }

        /// <summary>
        /// Shell sort O(n*log(n)^2)
        /// - Define h; average is O(n^1.25) when you choose the max number of (3^i - 1)/2 where h is less than n/9.
        /// - Apply the insertion sort to picked up items at intervals of h.
        /// - Update h; h /= 2
        /// - Repeat the all above until 
        /// </summary>
        /// <param name="list">sort target list</param>
        /// <returns>sorted list</returns>
        public static List<int> ShellSort(List<int> list)
        {
            // h = the max number of (3^i - 1)/2 where h < n/9
            // => i < log3(2/9 * n + 1)
            int i = (int)Math.Log(2 * list.Count / 9 + 1, 3);
            int h = (int)(Math.Pow(3, i) - 1) / 2;
            while(h >= 1)
            {
                // The iterator of this loop is the first item of each picked up items.
                // e.g. when an element whose index is k is A_k and h = 4
                // Gorups of picked up items are:
                // {A_0, A_4, A_8, ...}
                // {A_1, A_5, A_9, ...}
                // {A_2, A_6, A_10, ...}
                // {A_3, A_7, A_11, ...}
                // And this loop iterator indicates A_0, A_1, A_2, A_3.
                for (int j = 0; j < h; j++)
                {
                    //Test.ShowListElements(list, (index) => index % h == j, $"{j}".PadRight(4));
                    // Apply the insertion sort each groups
                    for (int k = j + h; k < list.Count; k += h)
                    {
                        int currentItem = list[k];
                        int l = k;
                        for (; l >= h; l -= h)
                        {
                            if (list[l - h] > currentItem)
                            {
                                list[l] = list[l - h];
                            }
                            else
                            {
                                break;
                            }
                        }
                        list[l] = currentItem;
                    }
                    //Test.ShowListElements(list, (index) => index % h == j, $"=>".PadRight(4));
                }

                // Update h
                h = (h - 1) / 3;
            }
            return list;
        }

        /// <summary>
        /// Shell sort 2
        /// </summary>
        /// <param name="list">sort target list</param>
        /// <returns>sorted list</returns>
        public static List<int> ShellSort2(List<int> list)
        {
            // h = the max number of (3^i - 1)/2 where h < n/9
            // => i < log3(2/9 * n + 1)
            int i = (int)Math.Log(2 * list.Count / 9 + 1, 3);
            int h = (int)(Math.Pow(3, i) - 1) / 2;
            while (h > 0)
            {
                for (int j = h; j < list.Count; j++)
                {
                    //Test.ShowListElements(list, (index) => index <= j && index % h == j % h, $"{j})".PadRight(4));
                    // Apply the insertion sort each groups
                    int currentItem = list[j];
                    int l = j;
                    for (; l >= h; l -= h)
                    {
                        if (list[l - h] > currentItem)
                        {
                            list[l] = list[l - h];
                        }
                        else
                        {
                            break;
                        }
                    }
                    list[l] = currentItem;
                    //Test.ShowListElements(list, (index) => index <= j && index % h == j % h, $"=>".PadRight(4));
                }

                // Update h
                h = (h - 1) / 3;
            }
            return list;
        }

        /// <summary>
        /// Merge sort O(n*log(n))
        /// - Devide given list into two lists.
        /// - If the devided list size is 2 or 1, sort it.
        /// - Otherwise, do the same operation recursively and merge returned list.
        /// - 'Merge' means comparing two min index items and set less one into result list sequentially.
        /// </summary>
        /// <param name="list">sort target list</param>
        /// <returns>sorted list</returns>
        public static List<int> MergeSort(List<int> list)
        {
            list = new List<int>(MergeSortInternal(list.ToArray()));
            return list;
        }

        private static int[] MergeSortInternal(int[] list)
        {
            int lastIndex = list.Length;

            if (lastIndex > 2)
            {
                int middleIndex = list.Count() / 2;

                int[] firstList = new int[middleIndex];
                int[] secondList = new int[lastIndex - middleIndex];
                for (int i = 0; i < middleIndex ; i++)
                {
                    firstList[i] = list[i];
                    secondList[i] = list[i + middleIndex];
                }
                if (lastIndex % 2 == 1)
                    secondList[middleIndex] = list[lastIndex - 1];

                // recursive call => sort them
                firstList = MergeSortInternal(firstList);
                secondList = MergeSortInternal(secondList);

                int currentFirstIndex = 0;
                int currentSecondIndex = 0;
                for (int i = 0; i < lastIndex; i++)
                {
                    if (currentSecondIndex == secondList.Length || currentFirstIndex < firstList.Length && firstList[currentFirstIndex] < secondList[currentSecondIndex])
                    {
                        list[i] = firstList[currentFirstIndex++];
                    }
                    else
                    {
                        list[i] = secondList[currentSecondIndex++];
                    }
                }
                return list;
            }
            else if (lastIndex == 2)
            {
                if (list[0] > list[1])
                    Swap(ref list[0], ref list[1]);
                return list;
            }
            else // lastIndex == 1
            {
                return list;
            }
        }

        /// <summary>
        /// Merge sort 2
        /// If the number of list elements becomes less than 100,
        /// sort them by insertion sort.
        /// </summary>
        /// <param name="list">sort target list</param>
        /// <returns>sorted list</returns>
        public static List<int> MergeSort2(List<int> list)
        {
            list = new List<int>(MergeSort2Internal(list.ToArray()));
            return list;
        }

        private static int[] MergeSort2Internal(int[] list)
        {
            int lastIndex = list.Length;

            if (lastIndex >= 100)
            {
                int middleIndex = list.Count() / 2;

                int[] firstList = new int[middleIndex];
                int[] secondList = new int[lastIndex - middleIndex];
                for (int i = 0; i < middleIndex; i++)
                {
                    firstList[i] = list[i];
                    secondList[i] = list[i + middleIndex];
                }
                if (lastIndex % 2 == 1)
                    secondList[middleIndex] = list[lastIndex - 1];

                // recursive call => sort them
                firstList = MergeSort2Internal(firstList);
                secondList = MergeSort2Internal(secondList);

                int currentFirstIndex = 0;
                int currentSecondIndex = 0;
                for (int i = 0; i < lastIndex; i++)
                {
                    if (currentSecondIndex == secondList.Length || currentFirstIndex < firstList.Length && firstList[currentFirstIndex] < secondList[currentSecondIndex])
                    {
                        list[i] = firstList[currentFirstIndex++];
                    }
                    else
                    {
                        list[i] = secondList[currentSecondIndex++];
                    }
                }
                return list;
            }
            else // lastIndex == 1
            {
                return InsertionSort(new List<int>(list)).ToArray();
            }
        }

        /// <summary>
        /// Quick sort O(n*log(n))
        /// - Define P by using some picked up elements.
        /// - Look for less number than P from left side.
        /// - Look for not less number than P from right side.
        /// - If both are found then swap them.
        /// - If both searching cross without finding both then this session is finished.
        /// - Do the same operation recursively with new range, less than P and not less than P, until new range is one.
        /// </summary>
        /// <param name="list">sort target list</param>
        /// <returns>sorted list</returns>
        public static List<int> QuickSort(List<int> list)
        {
            QuickSortInternal(ref list, 0, list.Count - 1);
            return list;
        }

        private static void QuickSortInternal(ref List<int> list, int first, int last)
        {
            int count = last - first + 1;
            if (count > 2)
            {
                int middle = first + (last - first) / 2;
                int pickUpSum = list[first] + list[middle] + list[last];
                int P = pickUpSum / 3;

                bool leftIsDefined = false;
                bool rightIsDefined = false;
                int leftIndex = first;
                int rightIndex = last;
                for (int i = 0; i <= last; i++)
                {
                    // Search index
                    if (!leftIsDefined && P <= list[leftIndex++])
                    {
                        leftIsDefined = true;
                    }
                    if (!rightIsDefined && P > list[rightIndex--])
                    {
                        rightIsDefined = true;
                    }

                    // Swap condition
                    if (leftIsDefined && rightIsDefined)
                    {
                        SwapListElements(ref list, leftIndex - 1, rightIndex + 1);
                        leftIsDefined = rightIsDefined = false;
                    }

                    // Finish condition
                    if (leftIndex > rightIndex)
                    {
                        break;
                    }
                }

                int nextFirst1 = first;
                int nextLast2 = last;
                int nextLast1 = -1;
                int nextFirst2 = -1;
                for (int i = first; i <= last; i++)
                {
                    if (list[i] >= P)
                    {
                        nextLast1 = i - 1;
                        nextFirst2 = i;
                        break;
                    }
                }
                QuickSortInternal(ref list, nextFirst1, nextLast1);
                QuickSortInternal(ref list, nextFirst2, nextLast2);
            }
            else if (count == 2)
            {
                if (list[first] > list[last])
                    SwapListElements(ref list, first, last);
            }
            else
            {
                /* do nothing */
            }
        }

        #endregion 

        #region Utils

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
        /// Check if elements is sorted correctly.
        /// </summary>
        /// <param name="list">target list</param>
        private static void CheckListElements(List<int> list)
        {
            bool result = true;
            for(int i=1; i<list.Count; i++)
            {
                if (list[i - 1] > list[i] || list[i - 1] == list[i])
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

        /// <summary>
        /// Swap 2 items.
        /// </summary>
        /// <param name="item1">one item</param>
        /// <param name="item2">another item</param>
        private static void Swap(ref int item1, ref int item2)
        {
            int temp = item1;
            item1 = item2;
            item2 = temp;
        }

        #endregion
    }
}
