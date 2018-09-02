using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgo
{
    using FuncType = Dictionary<string, Action>;

    class Program
    {
        static void Main(string[] args)
        {
            // Difinition of test functions
            var funcMap = new FuncType() {
                { "Linq 100", BindChecking(SortAlgos.BabbleSort, 100) },
                { "Linq 1000", BindChecking(SortAlgos.BabbleSort, 1000) },
                { "Linq 10000", BindChecking(SortAlgos.BabbleSort, 10000) },
                { "Babble 100", BindChecking(SortAlgos.BabbleSort, 100) },
                { "Babble 1000", BindChecking(SortAlgos.BabbleSort, 1000) },
                { "Babble 10000", BindChecking(SortAlgos.BabbleSort, 10000) },
                { "Shaker 100", BindChecking(SortAlgos.ShakerSort, 100) },
                { "Shaker 1000", BindChecking(SortAlgos.ShakerSort, 1000) },
                { "Shaker 10000", BindChecking(SortAlgos.ShakerSort, 10000) },
                { "Comb 100", BindChecking(SortAlgos.CombSort, 100) },
                { "Comb 1000", BindChecking(SortAlgos.CombSort, 1000) },
                { "Comb 10000", BindChecking(SortAlgos.CombSort, 10000) },
                { "Selection 100", BindChecking(SortAlgos.SelectionSort, 100) },
                { "Selection 1000", BindChecking(SortAlgos.SelectionSort, 1000) },
                { "Selection 10000", BindChecking(SortAlgos.SelectionSort, 10000) },
                { "Insertion 100", BindChecking(SortAlgos.InsertionSort, 100) },
                { "Insertion 1000", BindChecking(SortAlgos.InsertionSort, 1000) },
                { "Insertion 10000", BindChecking(SortAlgos.InsertionSort, 10000) },
            };

            MeasureFuncs(funcMap, out List<double> results);
            ShowResult(funcMap, results);

            // Wait for a user input.
            Console.Read();
        }

        /// <summary>
        /// Measure times of running each function
        /// </summary>
        /// <returns></returns>
        private static void MeasureFuncs(FuncType funcMap, out List<double> results)
        {
            MeasureFunction mf = new MeasureFunction();

            results = new List<double>();
            foreach (var pair in funcMap)
            {
                mf.Run(pair.Value);

                Test.Log($"Target = {pair.Key}:");
                foreach (int elapsedTime in mf.ElapsedTimes)
                {
                    Test.Log($"ElapsedTime is {elapsedTime} [ms]");
                }
                Test.Log($"Average is {mf.ElapsedTimeAve} [ms]");
                results.Add(mf.ElapsedTimeAve);

                mf.Reset();
                Test.Log("----------");
            }
        }

        /// <summary>
        /// Show result with good format
        /// </summary>
        /// <param name="results">list for showing</param>
        private static void ShowResult(FuncType funcMap, List<double> results)
        {
            for (int i = 0; i < results.Count; i++)
            {
                int maxKeyLen = funcMap.Keys.Max((key) => key.Count());
                string result
                    = ($"{funcMap.Keys.ToArray()[i]}").PadRight(maxKeyLen)
                    + " :"
                    + ($"{results[i]:F1} [ms]").PadLeft(13);
                Console.Write(result + " |");

                int count = Math.Max((int)Math.Log(results[i], 1.2), 0);
                Console.WriteLine(("").PadLeft(count, '#'));
            }
        }
        
        // Bind action and parameter
        // CheckFunc, SortFunc, numOfElem
        private static Func<Func<List<int>, List<int>>, int, Action> BindChecking
            = (list, param) => (() => SortAlgos.CheckSortAlgo(list, param));
    }

    // class for testing
    class Test
    {
        public static Action<string> Log
            = (message) => { if (true) Console.WriteLine(message); };

        /// <summary>
        /// It takes about 500ms.
        /// </summary>
        private static void TestFunc()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(random.Next(0, 100));
            }
        }
    }
}
