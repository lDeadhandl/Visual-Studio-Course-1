using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    //Inheritance
    public class ThrowAwayGradebook : Gradebook
    {
        public ThrowAwayGradebook(string name)
            :base(name)
        {
            Console.WriteLine("throwaway ctor");
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Throwaway compute");
            float lowest = float.MaxValue;
            foreach(float grade in grades)
            {
                lowest = Math.Min(lowest, grade);
            }
            grades.Remove(lowest);
            return base.ComputeStatistics();
        }
    }
}
