using System;
using System.Linq;
using System.Text;

namespace FunctionakPredicate
{
    class Program
    {
        static void Main(string[] args)
        {
            Task4();
        }

        private static void Task1()
        {
            var line = Console.ReadLine();

            Action<string> action = (word) => { Console.WriteLine(word); };

            foreach (var word in line.Split(' '))
            {
                action(word);
            }
        }

        private static void Task2()
        {
            var line = Console.ReadLine();

            Action<string> action = (word) => { Console.WriteLine($"{word} (нет в наличии)"); };

            foreach (var word in line.Split(' '))
            {
                action(word);
            }
        }

        static Func<string[], int[]> lineParser = strings =>
        {
            int[] ints = new int[strings.Length];
            for (var i = 0; i < strings.Length; i++)
            {
                ints[i] = int.Parse(strings[i]);
            }

            return ints;
        };

        private static void Task3()
        {
            string input = Console.ReadLine();
            Func<string, int> parser = n => int.Parse(n);
            int[] nums = input.Split(new string[] { " " },
                StringSplitOptions.RemoveEmptyEntries).Select(parser).ToArray();

            int min = Int32.MaxValue;

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < min)
                    min = nums[i];
            }
            Console.WriteLine(min);
        }

        private static void Task4()
        {
            string[] diapason = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string typeToDisplay = Console.ReadLine();

            Console.WriteLine(
                printOddOrEven(
                    Convert.ToInt32(diapason[0]),
                    Convert.ToInt32(diapason[1]),
                    typeToDisplay));
        }

        static Func<int, int, string, string> printOddOrEven = (minEdge, maxEdge, typeToDisplay) =>
        {
            StringBuilder output = new StringBuilder();
            if (typeToDisplay == "odd")
            {
                for (int i = minEdge; i <= maxEdge; i++)
                {
                    if (i % 2 != 0)
                    {
                        output.Append(i + " ");
                    }
                }
            }
            else if (typeToDisplay == "even")
            {
                for (int i = minEdge; i <= maxEdge; i++)
                {
                    if (i % 2 == 0)
                    {
                        output.Append(i + " ");
                    }
                }
            }
            return output.ToString().TrimEnd();
        };
    }
}
