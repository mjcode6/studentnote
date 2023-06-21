using System;

namespace studentnote
{
    class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Grade> Grades { get; set; }

        public Student(int id, string firstName, string lastName, DateTime dateOfBirth)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Grades = new List<Grade>();
        }

        public double CalculateAverageGrade()
        {
            if (Grades.Count == 0)
            {
                return 0;
            }

            double totalGrade = 0;
            foreach (var grade in Grades)
            {
                totalGrade += grade.GetGrade();
            }

            return totalGrade / Grades.Count;
        }
    }

}
