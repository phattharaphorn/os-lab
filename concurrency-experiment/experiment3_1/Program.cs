// test pause #2
using System;
using System.Threading;

namespace Lab_OS_Concurrency01
{
    class Program
    {
        static int resource = 10000;
        static void TestThread1()
        {
            int i;
            for (i = 0; i < 45555; i++)
            {
                resource++;
                Console.Write(".");
            }
        }

        static void Main(string[] args)
        {
            Thread th1 = new Thread(TestThread1);
            th1.Start();
            Thread.Sleep(100000);
            Console.WriteLine("Resource = {0}", resource);
        }
    }

}