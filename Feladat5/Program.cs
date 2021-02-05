using System;
using System.Linq;
using System.Collections.Generic;

namespace Feladat5
{
    class Program
    {
        static int N;
        static int[] jobs;
        static List<int> firstMachine;
        static List<int> secondMachine;
        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            jobs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            firstMachine = new List<int>();
            secondMachine = new List<int>();
            firstMachine.Add(0);
            FillMachines(ref firstMachine, ref secondMachine, 1);
            Console.WriteLine(Math.Max(SumOfMachine(firstMachine), SumOfMachine(secondMachine)));
            Console.WriteLine(string.Join(" ", firstMachine.Select(x => x + 1)));
            Console.WriteLine(string.Join(" ", secondMachine.Select(x => x + 1)));
        }
        static int FillMachines(ref List<int> firstMachine, ref List<int> secondMachine, int index)
        {
            if(index == N)
            {
                return Math.Max(SumOfMachine(firstMachine), SumOfMachine(secondMachine));
            }
            List<int> tempFirst = new List<int>(firstMachine);
            List<int> tempSecond = new List<int>(secondMachine);
            tempFirst.Add(index);
            tempSecond.Add(index);
            int firstResult = FillMachines(ref tempFirst, ref secondMachine, index + 1);
            int secondResult = FillMachines(ref firstMachine, ref tempSecond, index + 1);
            if (firstResult < secondResult)
            {
                firstMachine = tempFirst;
            }
            else
            {
                secondMachine = tempSecond;
            }
            return Math.Max(SumOfMachine(firstMachine), SumOfMachine(secondMachine));
        }
        static int SumOfMachine(List<int> machine)
        {
            return machine.Sum(x => jobs[x]);
        }
    }
}
