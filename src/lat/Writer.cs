using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lat
{
    public static class Writer
    {
        
        public static void appendString(string message)
        {
                System.IO.File.AppendAllText("log.txt", message + "\n");
        }

        public static void appendString(string message, string fileName)
        {
            System.IO.File.AppendAllText(fileName, message + "\n");
        }

        public static void appendBenchMark(List<Tuple<string, double>> times)
        {
            using (StreamWriter sw = System.IO.File.AppendText("benchmark.txt"))
            {
                foreach (Tuple<string, double> time in times)
                {
                    sw.Write(time + "\n");
                }
            }
            
        }

        public static void clearFile(string filePath)
        {
            System.IO.File.WriteAllText(filePath, "");
        }

    }
}
