using System;
using System.Threading;

namespace OS_Sync_Ex_04
{
    class Program
    {
        private static string x ="";
        private static int exitflag = 0;
        private static Semaphore s;

        static void ThReadX()
        {
            while(exitflag == 0)
            {
                s.WaitOne();
                if(exitflag == 0)
                    Console.Write("X = {0}", x);
                s.Release();
            }
        }
        static void ThWriteX()
        {
            string xx;
            while(exitflag == 0)
            {
                s.WaitOne();
                Console.Write("Input: ");
                xx = Console.ReadLine();
                if(xx == "exit")
                {
                    exitflag = 1;
                }
                else
                {
                    x = xx;
                }
                s.Release();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Start!");
            s = new Semaphore(1, 1);

            Thread A = new Thread(ThReadX);
            Thread B = new Thread(ThWriteX);

            A.Start();
            B.Start();
        }
    }
}