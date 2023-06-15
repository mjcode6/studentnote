


namespace studentnote;

class Program
{
 //Les eleves et cours. Ces listes sont utilisées pour stocker les données
     public static List<Student> students = new List<Student>();
      public static List<Course> courses = new List<Course>();
    static void Main(string[] args)
    {
        DisplayMainMenu();
        //  DisplayStudentMenu();
        //   DisplayCourseMenu();
    }

#region section main menu
public static void DisplayMainMenu()
    {
        Console.WriteLine("Menu Principal:");
        Console.WriteLine("1. Elèves");
        Console.WriteLine("2. Cours");
        Console.WriteLine("0. Quitter");
        Console.WriteLine("Choisissez une option :");


        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                DisplayStudentMenu();
                break;
            case 2:
                DisplayCourseMenu();
                break;
            case 0:
                Console.WriteLine("Au revoir!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Option invalide. Veuillez choisir une option valide.");
                DisplayMainMenu();
                break;
        }
    }

#endregion




#region section student

// for display students menu
 public static void DisplayStudentMenu()
    {
        Console.WriteLine("Menu Elèves:");
        Console.WriteLine("1. Lister les élèves");
        Console.WriteLine("2. Créer un nouvel élève");
        Console.WriteLine("3. Consulter un élève existant");
        Console.WriteLine("4. Ajouter une note et une appréciation pour un cours sur un élève existant");
        Console.WriteLine("0. Revenir au menu principal");
        Console.WriteLine("Choisissez une option :");

          int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                ListStudents();
                break;
            case 2:
                CreateStudent();
                break;
            case 3:
                ViewStudent();
                break;
            case 4:
                AddGradeToStudent();
                break;
            case 0:
                DisplayMainMenu();
                break;
            default:
                Console.WriteLine("Option invalide. Veuillez choisir une option valide.");
                DisplayStudentMenu();
                break;
        }
        


        // for listing students and for  futhuer interaction
    static void ListStudents()
    {
        Console.WriteLine("Liste des élèves :");

        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Id}, Prénom: {student.LastName}, Nom: {student.FirstName}");
        }

        Console.WriteLine();
        DisplayStudentMenu();
    }
// function for create new student
  static void CreateStudent()
    {
        Console.WriteLine("Création d'un nouvel élève :");

        Console.WriteLine("Entrez l'identifiant :");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Entrez le nom :");
        string lastName = Console.ReadLine();

        Console.WriteLine("Entrez le prénom :");
        string firstName = Console.ReadLine();

        Console.WriteLine("Entrez la date de naissance (au format JJ/MM/AAAA) :");
        DateTime dateOfBirth = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Student newStudent = new Student(id, lastName, firstName, dateOfBirth);
        students.Add(newStudent);

        Console.WriteLine("Nouvel élève créé avec succès !");
        Console.WriteLine();
        DisplayStudentMenu();
    }


// displaing the information from the lists about student
 static void ViewStudent()
    {
        Console.WriteLine("Consultation d'un élève :");
        Console.WriteLine("Entrez l'identifiant de l'élève :");
        int id = Convert.ToInt32(Console.ReadLine());

        Student student = students.Find(s => s.Id == id);

        if (student != null)
        {
            Console.WriteLine($"ID: {student.Id}, Prénom: {student.LastName}, Nom: {student.FirstName},  Date de naissance: {student.DateOfBirth}");

            Console.WriteLine("Notes par cours :");
            foreach (var grade in student.Grades)
            {
                Console.WriteLine($"Course: {grade.Key}, Notes: {grade.Value.Item1}, Appréciation: {grade.Value.Item2}");
            }

            double averageGrade = student.CalculateAverageGrade();
            Console.WriteLine($"Moyenne Notes: {averageGrade}");
        }
        else
        {
            Console.WriteLine("Aucun élève avec cet identifiant n'a été trouvé.");
        }

        Console.WriteLine();
        DisplayStudentMenu();
    }




// for adding grade for student
  static void AddGradeToStudent()
    {
        Console.WriteLine("Ajout d'une note et d'une appréciation pour un cours sur un élève existant :");
        Console.WriteLine("Entrez l'identifiant de l'élève :");
        int id = Convert.ToInt32(Console.ReadLine());

        Student student = students.Find(s => s.Id == id);

        if (student != null)
        {
            Console.WriteLine($"ID: {student.Id}, Prénom: {student.LastName}, Nom: {student.FirstName}");

            Console.WriteLine("Entrez le nom du cours :");
            string courseName = Console.ReadLine();

            Console.WriteLine("Entrez la note :");
            double grade = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Entrez l'appréciation :");
            string feedback = Console.ReadLine();

            student.Grades[courseName] = new Tuple<double, string>(grade, feedback);

            Console.WriteLine("Note et appréciation ajoutées avec succès !");
        }
        else
        {
            Console.WriteLine("Aucun élève avec cet identifiant n'a été trouvé.");
        }

        Console.WriteLine();
        DisplayStudentMenu();
    }





    }
#endregion





#region section Courses

 public static void DisplayCourseMenu()
    {
        Console.WriteLine("Menu Cours:");
        Console.WriteLine("1. Lister les cours existants");
        Console.WriteLine("2. Ajouter un nouveau cours au programme");
        Console.WriteLine("3. Supprimer un cours par son identifiant");
        Console.WriteLine("0. Revenir au menu principal");
        Console.WriteLine("Choisissez une option :");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                ListCourses();
                break;
            case 2:
                AddCourse();
                break;
            case 3:
                DeleteCourse();
                break;
            case 0:
               DisplayMainMenu();
                break;
            default:
                Console.WriteLine("Option invalide. Veuillez choisir une option valide.");
                DisplayCourseMenu();
                break;
        }
    }

// function for listing corses
 public static void ListCourses()
    {
        Console.WriteLine("List of courses:");

        foreach (var course in courses)
        {
            Console.WriteLine($"ID: {course.Id}, Name: {course.Name}");
        }

        Console.WriteLine();
        DisplayCourseMenu();
    }


// function for adding a courses
public static void AddCourse()
    {
        Console.WriteLine("Add a new course to the program:");

        Console.WriteLine("Enter the ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the name:");
        string name = Console.ReadLine();

        Course newCourse = new Course(id, name);
        courses.Add(newCourse);

        Console.WriteLine("New course added successfully!");
        Console.WriteLine();
        DisplayCourseMenu();
    }


// function for delete a course
 public static void DeleteCourse()
    {
        Console.WriteLine("Delete a course by its ID:");
        Console.WriteLine("Enter the course ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        Course courseToDelete = courses.Find(c => c.Id == id);

        if (courseToDelete != null)
        {
            courses.Remove(courseToDelete);
            Console.WriteLine("Course deleted successfully!");
        }
        else
        {
            Console.WriteLine("No course found with this ID.");
        }

        Console.WriteLine();
        DisplayCourseMenu();
    }
#endregion





}
