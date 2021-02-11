using System;
using System.Text;

namespace HanoiTornya
{
    class Program
    {
        static int height;
        static StringBuilder sb;
        static void Main(string[] args)
        {
            height = int.Parse(Console.ReadLine());
            sb = new StringBuilder();
            Move(1, 3, height);
            Console.WriteLine(sb.ToString());
        }
        static void Move(int from, int to, int howMany)
        {
            if(howMany == 1)
            {
                sb.Append(from);
                sb.Append('-');
                sb.Append(to);
                sb.Append('\n');
                return;
            }
            int helper = 6 - from - to;
            Move(from, helper, howMany - 1);
            Move(from, to, 1);
            Move(helper, to, howMany - 1);
        }
    }
}
