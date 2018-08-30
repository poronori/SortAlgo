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
                    { "Linq 500", Bind(SortAlgos.BabbleSort, 500) },
                    { "Linq 5000", Bind(SortAlgos.BabbleSort, 5000) },
                    { "Babble 500", Bind(SortAlgos.BabbleSort, 500) },
                    { "Babble 5000", Bind(SortAlgos.BabbleSort, 5000) },
                    { "Babble2 500", Bind(SortAlgos.BabbleSort2, 500) },
                    { "Babble2 5000", Bind(SortAlgos.BabbleSort2, 5000) },
                };

            // Test following the above difinition.
            List<double> results = new List<double>();
            foreach(KeyValuePair<string, Action> pair in funcMap)
            {
                mf.Run(pair.Value);

                Console.WriteLine($"Target = {pair.Key}:");
                foreach (int elapsedTime in mf.ElapsedTimes)
                {
                    Console.WriteLine($"ElapsedTime is {elapsedTime} [ms]");
                }
                Console.WriteLine($"Average is {mf.ElapsedTimeAve} [ms]");
                results.Add(mf.ElapsedTimeAve);

                mf.Reset();
                Console.WriteLine("----------");
            }

            for(int i=0; i< results.Count; i++)
            {
                Console.WriteLine($"{funcMap.Keys.ToArray()[i]} : {results[i]} [ms]");
            }

            Console.Read();
        }

        private static Action Bind(Action<int> action, int param)
        {
            return () => action(param);
        }
    }

    class Test
    {
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
