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

        public long ElapsedTimeMax
        {
            get { return ElapsedTimes.Max(); }
        }

        public void Run(Action func)
        {
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < Repeat; i++)
            {
                tasks.Add(new Task(
                () => {
                    System.Diagnostics.Stopwatch sw
                        = new System.Diagnostics.Stopwatch();

                    sw.Start();
                    func();
                    sw.Stop();
                    lock (ElapsedTimes)
                    {
                        ElapsedTimes.Add(sw.ElapsedMilliseconds);
                    }
                }));
                tasks.Last().Start();
            }

            tasks.ForEach(task => task.Wait());
        }

        public void Reset()
        {
            ElapsedTimes = new List<long>();
        }
    }
}
