using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableImplementation
{
    class Program
    {
        private static void Main(string[] args)
        {
            for (var i = 0; i < 1000; i++)
            {
                Console.WriteLine("Writing #" + i + "...");
                WriteLog("Iteration number #" + i);
            }

            Console.WriteLine("Finished");
            Console.ReadKey();
        }

        private static void WriteLog(string str)
        {
            using (var logger = new MemoryStreamLogger())
                logger.Log(str);
        }
    }
}
