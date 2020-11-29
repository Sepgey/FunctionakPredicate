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
            var _string = Console.ReadLine();

            Func<int[], int> summator = ints =>
            {
                int sum = 0;
                for (var i = 0; i < ints.Length; i++)
                {
                    sum += ints[i];
                }

                return sum;
            };

            Console.WriteLine(summator(lineParser(_string.Split(' '))));
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
