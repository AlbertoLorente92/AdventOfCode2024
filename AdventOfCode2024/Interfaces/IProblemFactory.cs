namespace AdventOfCode2024.Interfaces
{
    internal interface IProblemFactory
    {
        public IProblem GetProblem(int dayNumber);
    }
}
