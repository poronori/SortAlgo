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

            mf.Run(TestFunc);
            mf.Run(TestFunc);
            mf.Run(TestFunc);
            mf.Run(TestFunc);
            mf.Run(TestFunc);

            foreach (long elapsedTime in mf.ElapsedTimes)
            {
                Console.WriteLine("ElapsedTime is " + elapsedTime);
            }

            Console.Read();
        }

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
        public List<long> ElapsedTimes { get; private set; } = new List<long>();

        public void Run(Action func)
        {
            System.Diagnostics.Stopwatch sw
                = new System.Diagnostics.Stopwatch();
            sw.Start();

            func();

            sw.Stop();
            ElapsedTimes.Add(sw.ElapsedMilliseconds);
        }
    }
}
