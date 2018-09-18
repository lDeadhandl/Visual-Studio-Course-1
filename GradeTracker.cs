using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public interface IGradeTracker : IEnumerable
    {
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrade(TextWriter textwriter);
        string Name { get; set; }
        event NameChangedDelegate NameChanged;
        

    }
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrade(TextWriter textwriter);
        public abstract IEnumerator GetEnumerator();
        public event NameChangedDelegate NameChanged;
        private string _name;
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

                    if (NameChanged != null)
                    {
                        var args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = value;

                        NameChanged(this, args);
                    }
                }
            }
        }
    }
}
