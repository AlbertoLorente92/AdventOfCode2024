using AdventOfCode2024.Imp;
using AdventOfCode2024.Interfaces;

namespace AdventOfCode2024
{
    public class Program
    {
        public static void Main()
        {
            int day = 1;
            IProblemFactory factory = new ProblemFactory();
            IProblem problem = factory.GetProblem(day);
            problem.FirstPart();
            problem.SecondPart();
        }
    }
}