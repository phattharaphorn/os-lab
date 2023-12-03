// Version 1
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Collections.Concurrent;

#pragma warning disable SYSLIB0011

namespace Problem01
{
    class Program
    {
        static byte[] Data_Global = new byte[1000000000];
        static long Sum_Global = 0;

        static void ReadData()
        {
            FileStream fs = new FileStream("Problem01.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {

                Data_Global = (byte[])bf.Deserialize(fs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Read Failed: " + ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        static long Sum(int startIndex, int endIndex)
        {
            long localSum = 0;

            for (int i = startIndex; i < endIndex; i++)
            {
                byte value = Data_Global[i];

                if (value % 2 == 0)
                {
                    localSum -= value;
                }
                else if (value % 3 == 0)
                {
                    localSum += value * 2;
                }
                else if (value % 5 == 0)
                {
                    localSum += value / 2;
                }
                else if (value % 7 == 0)
                {
                    localSum += value / 3;
                }

                Data_Global[i] = 0;
            }

            return localSum;
        }

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            /* Read data from file */
            Console.Write("Data read...");
            ReadData();
            Console.WriteLine("Complete.");

            /* Start */
            Console.Write("\n\nWorking...");
            sw.Start();

            Sum_Global = Sum(0, Data_Global.Length);

            sw.Stop();
            Console.WriteLine("Done.");

            /* Result */
            Console.WriteLine("Summation result: {0}", Sum_Global);
            Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}