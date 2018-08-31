using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            MeasureFunction mf = new MeasureFunction();

            // Difinition of test functions
            Dictionary<string, Action> funcMap =
                new Dictionary<string, Action>()
                {
                    // ##### TODO: try to run these parallelly
                    { "Linq 100", Bind(SortAlgos.BabbleSort, 100) },
                    { "Linq 1000", Bind(SortAlgos.BabbleSort, 1000) },
                    { "Linq 10000", Bind(SortAlgos.BabbleSort, 10000) },
                    { "Babble 100", Bind(SortAlgos.BabbleSort, 100) },
                    { "Babble 1000", Bind(SortAlgos.BabbleSort, 1000) },
                    { "Babble 10000", Bind(SortAlgos.BabbleSort, 10000) },
                    { "Babble2 100", Bind(SortAlgos.BabbleSort2, 100) },
                    { "Babble2 1000", Bind(SortAlgos.BabbleSort2, 1000) },
                    { "Babble2 10000", Bind(SortAlgos.BabbleSort2, 10000) },
                    { "Selection 100", Bind(SortAlgos.SelectionSort, 100) },
                    { "Selection 1000", Bind(SortAlgos.SelectionSort, 1000) },
                    { "Selection 10000", Bind(SortAlgos.SelectionSort, 10000) },
                };

            // Test following the above difinition.
            List<double> results = new List<double>();
            foreach(KeyValuePair<string, Action> pair in funcMap)
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

            // Show results
            for(int i=0; i< results.Count; i++)
            {
                Console.WriteLine($"{funcMap.Keys.ToArray()[i]} : {results[i]} [ms]");
            }

            // Wait for a user input.
            Console.Read();
        }

        // Bind action and parameter
        private static Func<Action<int>, int, Action> Bind
            = (action, param) => (() => action(param));
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
