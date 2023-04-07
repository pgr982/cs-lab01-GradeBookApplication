using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name,bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("You need at least 5 students to do ranked grading");
            }

            var n = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= grades[n - 1])
            {
                return 'A';
            }
            if (averageGrade >= grades[(n * 2) - 1])
            {
                return 'B';
            }
            if (averageGrade >= grades[(n * 3) - 1])
            {
                return 'C';
            }
            if (averageGrade >= grades[(n * 4) - 1])
            {
                return 'D';
            }

            return 'F';

        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

    }
}