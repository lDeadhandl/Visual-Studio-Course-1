using System;
using System.Collections.Generic;


namespace Grades
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrade = 0f;
            LowestGrade = float.MaxValue;
        }
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;
    }
}
