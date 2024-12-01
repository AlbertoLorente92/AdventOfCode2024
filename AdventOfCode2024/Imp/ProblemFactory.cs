using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2024.Interfaces;

namespace AdventOfCode2024.Imp
{
    internal class ProblemFactory : IProblemFactory
    {
        private readonly Dictionary<int, Type> _problemType;
        public ProblemFactory() 
        {
            _problemType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(IProblem).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                .Select(type => new
                {
                    Type = type,
                    DayNumber = (int?)type.GetProperty("DayNumber", BindingFlags.Public | BindingFlags.Static)?.GetValue(null)
                })
                .Where(x => x.DayNumber.HasValue)
                .ToDictionary(x => x.DayNumber.Value, x => x.Type);
        }
        public IProblem GetProblem(int dayNumber)
        {
            if (!_problemType.TryGetValue(dayNumber, out Type value))
            {
                throw new Exception();
            }
            return (IProblem)Activator.CreateInstance(value);
        }
    }
}
