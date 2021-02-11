using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Feladat5
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            //List<int> jobs = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> jobs = Enumerable.Range(1, N).ToList();
            FillMachines(jobs);
        }
        static void FillMachines(List<int> jobs)
        {
            int jobsSum = jobs.Sum();
            int bestSplit = jobsSum / 2;
            int[] res = null;
            int i;
            for (i = bestSplit; res == null; i--)
            {
                Dictionary<int, int[]> memo = new Dictionary<int, int[]>();
                res = HowSum(i, jobs, ref memo);
            }
            HashSet<int> result = res.ToHashSet();
            StringBuilder sb = new StringBuilder();
            sb.Append(jobsSum - i - 1).AppendLine();
            List<int> firstMachine = new List<int>();
            List<int> secondMachine = new List<int>();
            for(i = 0; i < jobs.Count; i++)
            {
                if(result.Contains(jobs[i]))
                {
                    firstMachine.Add(i + 1);
                    result.Remove(jobs[i]);
                }
                else
                {
                    secondMachine.Add(i + 1);
                }
            }
            sb.AppendJoin(' ', firstMachine).AppendLine();
            sb.AppendJoin(' ', secondMachine);
            Console.WriteLine(sb.ToString());
        }
        static int[] HowSum(int targetSum, List<int> numbers, ref Dictionary<int, int[]> memo)
        {
            if (memo.ContainsKey(targetSum)) return memo[targetSum];
            if (targetSum == 0) return new int[] { };
            if (targetSum < 0) return null;
            
            foreach (int number in numbers)
            {
                int remainder = targetSum - number;
                List<int> passingNumbers = new List<int>(numbers);
                passingNumbers.Remove(number);
                int[] remainderResult = HowSum(remainder, passingNumbers, ref memo);
                if(remainderResult != null)
                {
                    int[] result = new int[remainderResult.Length + 1];
                    Array.Copy(remainderResult, result, remainderResult.Length);
                    result[result.Length - 1] = number;
                    memo[targetSum] = result;
                    return result;
                }
            }

            memo[targetSum] = null;
            return null;
        }
    }
}
