using System;
using System.Text;
using System.Linq;

namespace Feladat3
{
    class Program
    {
        static int[,] board;

        static void Main(string[] args)
        {
            int[] pos = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            board = new int[8, 8];
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 8; x++)
                    board[x, y] = 10;
            Jump(pos[1] - 1, pos[0] - 1, 0);
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    sb.Append(board[x, y]);
                    sb.Append(' ');
                }
                sb.Append(board[7, y]);
                sb.Append('\n');
            }
            Console.Write(sb.ToString());
        }
        static void Jump(int fromX, int fromY, int fromDistance)
        {
            if (fromX >= 0 && fromX < 8 && fromY >= 0 && fromY < 8)
            {
                if (fromDistance < board[fromX, fromY])
                {
                    board[fromX, fromY] = fromDistance;
                    Jump(fromX + 2, fromY + 1, fromDistance + 1);
                    Jump(fromX + 2, fromY - 1, fromDistance + 1);
                    Jump(fromX - 2, fromY + 1, fromDistance + 1);
                    Jump(fromX - 2, fromY - 1, fromDistance + 1);
                    Jump(fromX + 1, fromY + 2, fromDistance + 1);
                    Jump(fromX + 1, fromY - 2, fromDistance + 1);
                    Jump(fromX - 1, fromY + 2, fromDistance + 1);
                    Jump(fromX - 1, fromY - 2, fromDistance + 1);
                }
            }
        }
    }
}
