

using System;

namespace studentnote
{
    public class Course
    {
         public int Id { get; set; }
    public string Name { get; set; }

    public Course(int id, string name)
    {
        Id = id;
        Name = name;
    }

    }
}
