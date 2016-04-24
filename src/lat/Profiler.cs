using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lat
{
    public static class Profiler
    {
        private static Stopwatch sw = new Stopwatch();
        private static List<Tuple<String, double>> times = new List<Tuple<String, double>>();
        private static string lastTask;
     
        public static void start(string task)
        {
            lastTask = task;
            sw.Start();
        }
        public static void newTask(string task)
        {
            stop();
            start(task);
        }

        public static void stop()
        {
            sw.Stop();
            //times.Add(new Tuple<string, double>(lastTask, sw.Elapsed.TotalSeconds));
            Writer.appendString("" + lastTask + ", " + sw.Elapsed.TotalSeconds, "benchmark.txt");
            sw.Reset();
        }

        public static void write()
        {
            Writer.appendBenchMark(times);
        }

        public static void clear()
        {
            Writer.clearFile("benchmark.txt");
        }
    }

}
