using System;
using System.Linq;
using System.Collections.Generic;

namespace Feladat4
{
    class Program
    {
        static int K, N;
        static List<int[]> runners;
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            K = data[0];
            N = data[1];
            runners = new List<int[]>();
            for (int i = 0; i < N; i++)
                runners.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            int min = N;
            List<int> bestRunners = null;
            for (int i = 0; i < N; i++)
            {
                if (runners[i][0] == 0)
                {
                    List<int> passedRunners = new List<int>();
                    Race(i, passedRunners);
                    if(passedRunners.Count < min)
                    {
                        min = passedRunners.Count;
                        bestRunners = passedRunners;
                    }
                }
            }
            Console.WriteLine(bestRunners?.Count);
            Console.WriteLine(string.Join(" ", bestRunners));
        }
        static void Race(int runnerIndex, List<int> passedRunners)
        {
            passedRunners.Add(runnerIndex + 1);
            int[] runner = runners[runnerIndex];
            if (runner[1] == K)
                return;
            int min = N;
            List<int> bestRunners = null;
            foreach(int[] otherRunner in runners
                .Where(x => x[0] <= runner[1] && runner[1] < x[1]))
            {
                List<int> otherRunners = new List<int>();
                int index = runners.FindIndex(x => x == otherRunner);
                Race(index, otherRunners);
                if(otherRunners.Count < min)
                {
                    min = otherRunners.Count;
                    bestRunners = otherRunners;
                }
            }
            if (bestRunners != null)
                passedRunners.AddRange(bestRunners);
        }
    }
}
