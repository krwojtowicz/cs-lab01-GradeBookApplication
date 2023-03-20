using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(base.Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            double N = Students.Count / 5;

            if (averageGrade >= Students[(int)N].AverageGrade) return 'A';
            else if (averageGrade >= Students[(int)N * 2].AverageGrade) return 'B';
            else if (averageGrade >= Students[(int)N * 3].AverageGrade) return 'C';
            else if (averageGrade >= Students[(int)N * 4].AverageGrade) return 'D';
            else  return 'F';




            return base.GetLetterGrade(averageGrade);
        }

        public override void CalculateStatistics()
        {
            if (base.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics(); ;
            }         
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(base.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
