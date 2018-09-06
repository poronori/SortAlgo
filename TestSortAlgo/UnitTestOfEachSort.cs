using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSortAlgo
{
    [TestClass]
    public class UnitTestOfEachSort
    {
        private void Test_SortAlgo(Func<List<int>, List<int>> SortFunc)
        {
            int count = 123;

            List<int> expect = new List<int>();
            for (int i = 1; i <= count; i++)
            {
                expect.Add(i);
            }

            int[] sourceArray = new int[expect.Count];
            expect.CopyTo(sourceArray);
            for (int i = 1; i < sourceArray.Length; i++)
            {
                int tmp = sourceArray[i];
                sourceArray[i] = sourceArray[i - 1];
                sourceArray[i - 1] = tmp;
            }
            List<int> source = new List<int>(sourceArray);

            List<int> actual = SortFunc(source);

            CollectionAssert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Test_Babble()
        {
            Test_SortAlgo(SortAlgo.SortAlgos.BabbleSort);
        }

        [TestMethod]
        public void Test_Shaker()
        {
            Test_SortAlgo(SortAlgo.SortAlgos.ShakerSort);
        }

        [TestMethod]
        public void Test_Comb()
        {
            Test_SortAlgo(SortAlgo.SortAlgos.CombSort);
        }

        [TestMethod]
        public void Test_Selection()
        {
            Test_SortAlgo(SortAlgo.SortAlgos.SelectionSort);
        }

        [TestMethod]
        public void Test_Insertion()
        {
            Test_SortAlgo(SortAlgo.SortAlgos.InsertionSort);
        }

        [TestMethod]
        public void Test_Shell()
        {
            Test_SortAlgo(SortAlgo.SortAlgos.ShellSort);
            Test_SortAlgo(SortAlgo.SortAlgos.ShellSort2);
        }

        [TestMethod]
        public void Test_Merge()
        {
            Test_SortAlgo(SortAlgo.SortAlgos.MergeSort);
        }
    }
}
