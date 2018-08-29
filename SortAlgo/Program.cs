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
            // Difinition of test functions
            Dictionary<string, Action> funcMap =
                new Dictionary<string, Action>()
                {
                    { "Babble 500", Bind(SortAlgos.BabbleSort, 500) },
                    { "Babble 5000", Bind(SortAlgos.BabbleSort, 5000) }
                };

            // Test following the above difinition.
            MeasureFunction mf = new MeasureFunction();
            foreach(KeyValuePair<string, Action> pair in funcMap)
            {
                mf.Run(pair.Value);

                Console.WriteLine($"Target = {pair.Key}:");
                foreach (int elapsedTime in mf.ElapsedTimes)
                {
                    Console.WriteLine($"ElapsedTime is {elapsedTime} [ms]");
                }
                Console.WriteLine($"Average is {mf.ElapsedTimeAve} [ms]");

                mf.Reset();
                Console.WriteLine("----------");
            }

            Console.Read();
        }

        private static Action Bind(Action<int> action, int param)
        {
            return () => action(param);
        }

        /// <summary>
        /// It takes about 500ms.
        /// </summary>
        private static void TestFunc()
        {
            Random random = new Random();
            for (int i=0; i<10; i++)
            {
                System.Threading.Thread.Sleep(random.Next(0, 100));
            }
        }
    }

    class MeasureFunction
    {
        public int Repeat { get; set; } = 5;

        public List<long> ElapsedTimes
        {
            get;
            private set;
        } = new List<long>();

        public double ElapsedTimeAve
        {
            get { return ElapsedTimes.Average(); }
        }

        public void Run(Action func)
        {
            System.Diagnostics.Stopwatch sw
                = new System.Diagnostics.Stopwatch();

            for (int i = 0; i < Repeat; i++)
            {
                sw.Start();
                func();
                sw.Stop();
                ElapsedTimes.Add(sw.ElapsedMilliseconds);
                sw.Reset();
            }
        }

        public void Reset()
        {
            ElapsedTimes = new List<long>();
        }
    }
}
