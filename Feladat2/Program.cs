using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Feladat2
{
    class Program
    {
        static int N, M;
        static char[,] colors;
        static StringBuilder sb;

        static void Main(string[] args)
        {
            int[] resolution = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            N = resolution[0];
            M = resolution[1];
            colors = new char[M, N];
            sb = new StringBuilder();
            sb.Append(N);
            sb.Append(' ');
            sb.Append(M);
            sb.Append('\n');
            FirstLine();
            for (int y = 1; y < N; y++)
            {
                NextLine(y);
            }
            Console.WriteLine(sb.ToString());
        }
        static void FirstLine()
        {
            IEnumerable<char> line = Console.ReadLine().Split(' ').Select(x => x[0]);
            int x = 0;
            int from = 0;
            char current = '\0';
            foreach (char color in line)
            {
                colors[x, 0] = color;
                if (x == 0)
                {
                    current = color;
                }
                else if (current != color)
                {
                    WriteChange(1, from + 1, x, current);
                    current = color;
                    from = x;
                }
                x++;
            }
            WriteChange(1, from + 1, x, current);
        }
        static void NextLine(int y)
        {
            IEnumerable<char> line = Console.ReadLine().Split(' ').Select(x => x[0]);
            int x = 0;
            int from = 0;
            char current = '\0';
            bool same = true;
            foreach (char color in line)
            {
                colors[x, y] = color;
                char prev = colors[x, y - 1];
                if (x == 0)
                {
                    current = color;
                    if (prev != color)
                    {
                        from = 1;
                        same = false;
                    }
                }
                else if (prev == color && current != color)
                {
                    if (!same)
                    {
                        same = true;
                        WriteChange(y + 1, from, x, current);
                    }
                    current = color;
                    from = x + 1;
                }
                else if (prev != color && current != color)
                {
                    if (same)
                    {
                        same = false;
                    }
                    else
                    {
                        WriteChange(y + 1, from, x, current);
                    }
                    from = x + 1;
                    current = color;
                }
                else if (prev != color && current == color && same)
                {
                    same = false;
                    from = x + 1;
                }
                else if (prev == color && current == color && colors[x - 1, y - 1] != current)
                {
                    same = true;
                    WriteChange(y + 1, from, x, current);
                }
                x++;
            }
            if (!same)
            {
                WriteChange(y + 1, from, x, current);
            }
        }
        static void WriteChange(int column, int from, int to, char color)
        {
            sb.Append(column);
            sb.Append(' ');
            sb.Append(from);
            sb.Append(' ');
            sb.Append(to);
            sb.Append(' ');
            sb.Append(color);
            sb.Append('\n');
        }
    }
}
