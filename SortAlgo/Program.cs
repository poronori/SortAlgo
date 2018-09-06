using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgo
{
    using FuncType = Dictionary<string, Action>;

    class Defs
    {
        public const int Repeat = 5;
        public const bool ShowLog = true;
    }

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
                { "Shell 100", BindChecking(SortAlgos.ShellSort, 100) },
                { "Shell 1000", BindChecking(SortAlgos.ShellSort, 1000) },
                { "Shell 10000", BindChecking(SortAlgos.ShellSort, 10000) },
                { "Shell2 100", BindChecking(SortAlgos.ShellSort2, 100) },
                { "Shell2 1000", BindChecking(SortAlgos.ShellSort2, 1000) },
                { "Shell2 10000", BindChecking(SortAlgos.ShellSort2, 10000) },
                { "Merge 100", BindChecking(SortAlgos.MergeSort, 100) },
                { "Merge 1000", BindChecking(SortAlgos.MergeSort, 1000) },
                { "Merge 10000", BindChecking(SortAlgos.MergeSort, 10000) },
            };

            MeasureFuncs(funcMap, out List<Tuple<double, long>> results);
            ShowResult(funcMap, results);

            // Wait for a user input.
            Console.Read();
        }

        /// <summary>
        /// Measure times of running each function
        /// </summary>
        /// <param name="funcMap">functions map</param>
        /// <param name="results">result list including average and max time</param>
        private static void MeasureFuncs(FuncType funcMap, out List<Tuple<double, long>> results)
        {
            MeasureFunction mf = new MeasureFunction();
            mf.Repeat = Defs.Repeat;

            results = new List<Tuple<double, long>>();
            foreach (var pair in funcMap)
            {
                mf.Run(pair.Value);

                Test.Log($"Target = {pair.Key}:");
                foreach (int elapsedTime in mf.ElapsedTimes)
                {
                    Test.Log($"ElapsedTime is {elapsedTime} [ms]");
                }
                Test.Log($"Average is {mf.ElapsedTimeAve} [ms]");
                results.Add(new Tuple<double, long>(mf.ElapsedTimeAve, mf.ElapsedTimeMax));

                mf.Reset();
                Test.Log("----------");
            }
        }

        /// <summary>
        /// Show result with good format
        /// </summary>
        /// <param name="results">list for showing</param>
        private static void ShowResult(FuncType funcMap, List<Tuple<double, long>> results)
        {
            for (int i = 0; i < results.Count; i++)
            {
                int maxKeyLen = funcMap.Keys.Max((key) => key.Count());
                string result
                    = ($"{funcMap.Keys.ToArray()[i]}").PadRight(maxKeyLen)
                    + " :"
                    + ($"{results[i].Item1:F1} [ms]").PadLeft(13);
                Console.Write(result + " |");

                int ave = Math.Max((int)Math.Log(results[i].Item1, 1.2), 0);
                int max = Math.Max((int)Math.Log(results[i].Item2, 1.2), 0);
                Console.WriteLine(("").PadRight(ave, '#').PadRight(max) + "|");
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
            = (message) => { if (Defs.ShowLog) Console.WriteLine(message); };

        public static void DubugLog(string logString)
        {
            if (Defs.ShowLog)
                Console.WriteLine(logString);
        }

        /// <summary>
        /// Write debug log into Console with color (for internal)
        /// </summary>
        /// <param name="logData">log data with color info</param>
        private static void DubugLog(List<Tuple<String, ConsoleColor>> logData)
        {
            if (Defs.ShowLog)
            {
                logData.ForEach(pair =>
                {
                    ConsoleColor prevColor = Console.ForegroundColor;
                    Console.ForegroundColor = pair.Item2;
                    Console.Write(pair.Item1);
                    Console.ForegroundColor = prevColor;
                });
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Show elements as one line.
        /// </summary>
        /// <param name="list">target list</param>
        public static void ShowListElements(List<int> list, Func<int, bool> enhanceCondition, string prefix = "")
        {
            List<Tuple<String, ConsoleColor>> debugData
                = new List<Tuple<string, ConsoleColor>>();

            List<Tuple<string, ConsoleColor>> newList = list.Select((elem, index) =>
            {
                string text = $"{elem} ";
                ConsoleColor color = ConsoleColor.Gray;
                if (enhanceCondition(index))
                {
                    color = ConsoleColor.Red;
                }
                if ((index + 1) % 20 == 0) text += Environment.NewLine + ("").PadLeft(prefix.Length);
                return new Tuple<string, ConsoleColor>(text, color);
            }).ToList();

            newList.Insert(0, new Tuple<string, ConsoleColor>(prefix, ConsoleColor.White));
            Test.DubugLog(newList);
        }

        public static bool AlwaysFalse(int elem) { return false; }

        /// <summary>
        /// It takes about 500ms.
        /// </summary>
        public static void TestFunc()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(random.Next(0, 100));
            }
        }
    }
}
