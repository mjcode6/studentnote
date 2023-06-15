using System;

namespace studentnote
{
    public class Student
    {
        public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Dictionary<string, Tuple<double, string>> Grades { get; set; } 


public Student(int id, string lastName, string firstName, DateTime dateOfBirth)
    {
        Id = id;
        LastName = lastName;
        FirstName = firstName;
        DateOfBirth = dateOfBirth;
        Grades = new Dictionary<string, Tuple<double, string>>();
    }


public double CalculateAverageGrade()
    {
        if (Grades.Count == 0)
            return 0;

        double total = 0;
        foreach (var grade in Grades)
        {
            total += grade.Value.Item1;
        }

        return total / Grades.Count;
    }


    }

    
}
