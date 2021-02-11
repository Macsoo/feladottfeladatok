using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace OKTV_2008_II_Feladatok
{
    class Program
    {
        static int year;
        static bool isLeapYear;
        static List<int> adminCounts;
        static int[] months = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        static List<int> safe;
        static List<int> dangerous;

        static void Main(string[] args)
        {
            year = Convert.ToInt32(Console.ReadLine());
            isLeapYear = DateTime.IsLeapYear(year);
            adminCounts = Enumerable.Repeat(2, 365).ToList();
            if (isLeapYear)
            {
                months[1]++;
                adminCounts.Add(2);
            }
            RemoveDates(Convert.ToInt32(Console.ReadLine()));
            RemoveDates(Convert.ToInt32(Console.ReadLine()));
            safe = new List<int>();
            dangerous = new List<int>();
            CalculateSafeAndDangerous();
            Console.WriteLine(WriteIntervals(safe));
            Console.WriteLine(WriteIntervals(dangerous));
        }

        private static string WriteIntervals(List<int> intervals)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(intervals.Count / 4);
            sb.Append('\n');
            for (int i = 0; i < intervals.Count / 4; i++)
            {
                sb.Append(intervals[i * 4 + 0]);
                sb.Append(' ');
                sb.Append(intervals[i * 4 + 1]);
                sb.Append(' ');
                sb.Append(intervals[i * 4 + 2]);
                sb.Append(' ');
                sb.Append(intervals[i * 4 + 3]);
                if (i < intervals.Count / 4 - 1) sb.Append('\n');
            }
            return sb.ToString();
        }

        static void CalculateSafeAndDangerous()
        {
            if (adminCounts[0] == 2)
            {
                safe.Add(1);
                safe.Add(1);
            }
            else if (adminCounts[0] == 0)
            {
                dangerous.Add(1);
                dangerous.Add(1);
            }
            for (int i = 1; i < adminCounts.Count - 1; i++)
            {
                if (adminCounts[i] == 2 && adminCounts[i - 1] < 2)
                {
                    int[] date = IntToDate(i + 1);
                    safe.Add(date[0]);
                    safe.Add(date[1]);
                }
                if (adminCounts[i] == 2 && adminCounts[i + 1] < 2)
                {
                    int[] date = IntToDate(i);
                    safe.Add(date[0]);
                    safe.Add(date[1]);
                }
                if (adminCounts[i] == 0 && adminCounts[i - 1] > 0)
                {
                    int[] date = IntToDate(i);
                    dangerous.Add(date[0]);
                    dangerous.Add(date[1]);
                }
                if (adminCounts[i] == 0 && adminCounts[i + 1] > 0)
                {
                    int[] date = IntToDate(i + 1);
                    dangerous.Add(date[0]);
                    dangerous.Add(date[1]);
                }
            }
            if (adminCounts[adminCounts.Count - 1] == 2)
            {
                safe.Add(12);
                safe.Add(31);
            }
            else if (adminCounts[adminCounts.Count - 1] == 0)
            {
                dangerous.Add(12);
                dangerous.Add(31);
            }
        }

        static void RemoveDates(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                int[] dates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                RemoveAdmin(dates[0], dates[1], dates[2], dates[3]);
            }
        }

        static void RemoveAdmin(int fromMonth, int fromDay, int toMonth, int toDay)
        {
            int fromIndex = DateToInt(fromMonth, fromDay);
            int toIndex = DateToInt(toMonth, toDay);
            for (int i = fromIndex; i < toIndex; i++)
            {
                adminCounts[i]--;
            }
        }

        static int[] IntToDate(int dayIndex)
        {
            int month;
            for(month = 0; dayIndex > 0; month++)
            {
                dayIndex -= months[month];
            }
            int day = dayIndex + months[month - 1];
            return new int[] { month, day };
        }

        static int DateToInt(int month, int day)
        {
            for(int i = 1; i < month; i++)
            {
                day += months[i - 1];
            }
            return day;
        }
    }
}
