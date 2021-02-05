using System;
using System.Linq;

namespace HaromKancso
{
    class Program
    {
        static int[] max;
        static int[] allapot;
        static void Main(string[] args)
        {
            max = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            allapot = new int[] { 0, 0, max[2] };
        }
        static void Pour(int from, int to)
        {
            if (allapot[0] > 0 && allapot[to] < max[to])
            {
                int attoltheto = Math.Min(allapot[from], max[to] - allapot[to]);
            }
        }
        static bool IsDone()
        {
            return allapot.Any(x => x == 4);
        }
    }
}
