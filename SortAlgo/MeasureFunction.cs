using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgo
{
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
