using AdventOfCode2024.Interfaces;

namespace AdventOfCode2024.Imp
{
    internal class Day01 : IProblem
    {
        public static int DayNumber => 1;
        public void FirstPart()
        {
            Console.WriteLine("First Part");
            ReadProblem(out List<int> firstColumn, out List<int> secondColumn);

            firstColumn.Sort();
            secondColumn.Sort();
            int solution = 0;
            for (int i = 0; i < firstColumn.Count; i++)
            {
                solution += Math.Abs(firstColumn[i] - secondColumn[i]);
            }
            Console.WriteLine($"Solution = {solution}");
        }

        public void SecondPart()
        {
            Console.WriteLine("Second Part");
            ReadProblem(out List<int> firstColumn, out List<int> secondColumn);

            int solution = 0;
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            foreach(var number in firstColumn)
            {
                if (keyValuePairs.TryGetValue(number, out int value))
                {
                    solution += number * value;
                }
                else
                {
                    var count = secondColumn.Count(x => x == number);
                    keyValuePairs.Add(number, count);
                    solution += number * count;
                }
            }
            
            Console.WriteLine($"Solution = {solution}");
        }

        private static void ReadProblem(out List<int> firstColumn, out List<int> secondColumn)
        {
            var day = string.Concat("0", DayNumber.ToString())[^2..];
            var path = Environment.CurrentDirectory + @$"\Problems\Problem{day}.txt";
            var lines = File.ReadLines(path);
            firstColumn = new List<int>();
            secondColumn = new List<int>();
            foreach (var line in lines)
            {
                var aux = line.Split("   ");
                firstColumn.Add(int.Parse(aux[0]));
                secondColumn.Add(int.Parse(aux[1]));
            }
        }
    }
}
