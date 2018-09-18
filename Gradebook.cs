using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class Gradebook : GradeTracker
    {
        ////Default constructor that calls other constructor
        //public Gradebook()
        //    : this("No name")
        //{

        //}

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }
        public override void WriteGrade(TextWriter textwriter)
        {
            Console.WriteLine("Swag");
        }
        public Gradebook(string name = "There is no name")
        {
            Console.WriteLine("gradebook ctor");
            Name = name;
            grades = new List<float>();
        }
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Gradebook compute");
            GradeStatistics stats = new GradeStatistics();

            float sum = 0f;

            foreach (float grade in grades)
            {
                // Math.Max/Min compares two variables and returns min or max 
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        //Field
        private string _name;

        //Property
        public string Name
        {
            get
            {
                return _name;
            }
          
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be Null or empty");
                }
                if (_name != value)
                {

                    string oldValue = _name;
                    _name = value;

                    if(NameChanged != null)
                    {
                        var args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = value;

                    NameChanged(this, args);
                    }
                }
            }
        }

        //Delegate field
        public event NameChangedDelegate NameChanged;
        //protected allows derived classes to use variable
        protected List<float> grades;
    
    }

}
