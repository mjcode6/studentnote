using System;

namespace studentnote
{
    class Grade
    {
        public string Course { get; set; }

        private double grade;

        public double GetGrade()
        {
            return grade;
        }

        public void SetGrade(double value)
        {
            grade = value;
        }

        public string Comment { get; set; }

        public Grade(string course, double grade, string comment)
        {
            Course = course;
            SetGrade(grade);
            Comment = comment;
        }
    }
}
