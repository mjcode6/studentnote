using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace studentnote
{
    class Program
    {
        private const string DataFilePath = "data.json";
        private const string LogFilePath = "log.txt";

        private static Logger logger;

        static void Main(string[] args)
        {
            // Initialize the logger
            logger = new Logger(LogFilePath);

           
            // Load data from the JSON file
            List<Student> students = LoadData();

            // Display the main menu
            bool exit = false;
            while (!exit)
            {
                 logger.LogAction("Menu Principal:");
                 Console.WriteLine("");
                Console.WriteLine("1. Elèves");
                Console.WriteLine("");
                Console.WriteLine("2. Cours");
                Console.WriteLine("");
                Console.WriteLine("0. Quitter");
                Console.WriteLine("");
                Console.Write("Choisissez une option : ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                    logger.LogAction("Option 1 sélectionnée : Manager les élèves");
                    Console.Clear();
                        ManageStudents(students);
                        break;
                    case "2":
                    logger.LogAction("Option 2 sélectionnée : Manager les Cours");
                     Console.Clear();
                        ManageCourses(students);
                        break;
                    case "0":
                    logger.LogAction("Option 0 sélectionnée : Quitter L'application");
                     Console.Clear();
                      Console.WriteLine("Au revoir!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }

                Console.WriteLine();
            }

            // Save data to the JSON file
            SaveData(students);
        }

        static void ManageStudents(List<Student> students)
        {
            bool backToMainMenu = false;
            while (!backToMainMenu)
            {
                
                logger.LogAction("Menu Elèves:");
                Console.WriteLine("");
                Console.WriteLine("1. Lister les élèves");
                Console.WriteLine("");
                Console.WriteLine("2. Créer un nouvel élève");
                Console.WriteLine("");
                Console.WriteLine("3. Consulter un élève existant");
                Console.WriteLine("");
                Console.WriteLine("4. Ajouter une note et une appréciation pour un cours sur un élève existant");
                Console.WriteLine("");
                Console.WriteLine("5. Supprimer un eléves par son identifiant");
                Console.WriteLine("");
                Console.WriteLine("0. Revenir au menu principal");
                Console.WriteLine("");
            
                Console.Write("Choisissez une option :  ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                    logger.LogAction("Option 1 sélectionnée : Lister les élèves");
                     Console.Clear();
                        ListStudents(students);
                        break;
                    case "2":
                    logger.LogAction("Option 2 sélectionnée : Ajouter les élèves");
                     Console.Clear();
                        AddStudent(students);
                        break;
                    case "3":
                    logger.LogAction("Option 3 sélectionnée : Voir les élèves");
                     Console.Clear();
                        ViewStudent(students);
                        break;
                    case "4":
                    logger.LogAction("Option 4 sélectionnée : Ajouter les Note et commentaire aux les éleves");
                     Console.Clear();
                        AddNoteAndComment(students);
                        break;
                        case "5":
                        logger.LogAction("Option 5 sélectionnée : Effecer les élèves");
                         Console.Clear();
                        DeleteStudent(students);
                        break;
                    case "0":
                    logger.LogAction("Option 0 sélectionnée : Retour au menu principal");
                    Console.Clear();
                        backToMainMenu = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }

                Console.WriteLine();
            }
        }
static void DeleteStudent(List<Student> students)
{
    Console.WriteLine("Supprimer l'élève");
    Console.WriteLine("");
    Console.Write("Entrez l'identifiant de l'étudiant : ");
    int id = Convert.ToInt32(Console.ReadLine());

    Student studentToDelete = students.Find(s => s.Id == id);

    if (studentToDelete != null)
    {
        students.Remove(studentToDelete);
        Console.WriteLine("Étudiant supprimé avec succès !");
    }
    else
    {
        Console.WriteLine("");
        Console.WriteLine("Aucun étudiant avec cette pièce d'identité n'a été trouvé.");
    }
}

        static void ManageCourses(List<Student> students)
        {
            bool backToMainMenu = false;
            while (!backToMainMenu)
            {
                logger.LogAction("Menu Cours : ");
                Console.WriteLine("");
                Console.WriteLine("1. Lister les cours existants");
                Console.WriteLine("");
                Console.WriteLine("2. Ajouter un nouveau cours au programme");
                Console.WriteLine("");
                Console.WriteLine("3. Supprimer un cours par son Nom");
                Console.WriteLine("");
                Console.WriteLine("0. Revenir au menu principal");
                Console.WriteLine("");
                Console.Write("Choisissez une option :  ");
                Console.WriteLine("");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                    logger.LogAction("Option 1 sélectionnée : Lister les coures");
                     Console.Clear();
                        ListCourses(students);
                        break;
                    case "2":
                    logger.LogAction("Option 2 sélectionnée : Ajouter les coures");
                    Console.Clear();
                        AddCourse(students);
                        break;
                         case "3":
                         logger.LogAction("Option 3 sélectionnée : Effecer les courses");
                         Console.Clear();
                        DeleteCourse(students);
                        break;
                    case "0":
                    logger.LogAction("Option 0 sélectionnée : Retour au menu principal");
                    Console.Clear();
                        backToMainMenu = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ListStudents(List<Student> students)
        {
            Console.WriteLine("Liste des étudiants");
            foreach (var student in students)
            {
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------");

                Console.WriteLine("");
                Console.WriteLine($"ID : {student.Id},             Nom : {student.FirstName} {student.LastName}");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------");
           
            }
        }

        static void AddStudent(List<Student> students)
        {
            Console.WriteLine("Ajouter un étudiant");
            Console.WriteLine("");
            // Console.Write("Enter student ID: ");
            // int id = Convert.ToInt32(Console.ReadLine());

             int id = students.Count + 1;
            
            Console.Write("Entrez le prénom de l'étudiant : ");
            string firstName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Entrez le nom de famille de l'élève : ");
            string lastName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Entrez la date de naissance de l'étudiant (AAAA-MM-JJ) : ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Student newStudent = new Student(id, firstName, lastName, dateOfBirth);
            students.Add(newStudent);
            Console.WriteLine("");
            Console.WriteLine("Étudiant ajouté avec succès.");
        }

        static void ViewStudent(List<Student> students)
        {
            Console.WriteLine("Voir l'étudiant");
            Console.WriteLine("");
            Console.Write("Entrez l'identifiant de l'étudiant : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine($"ID:                    {student.Id}");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine($"Nom:                         {student.FirstName} {student.LastName}");
                Console.WriteLine("");
                Console.WriteLine($"Date de naissance :          {student.DateOfBirth.ToShortDateString()}");
               Console.WriteLine("");
                Console.WriteLine("Notes :");
                

                foreach (var grade in student.Grades)
                {
                     Console.WriteLine("");
                    Console.WriteLine($"Course :                      {grade.Course}");
                    Console.WriteLine("");
                    Console.WriteLine($"Notes :                       {grade.GetGrade()} / 20");
                    Console.WriteLine("");
                    Console.WriteLine($"Commentaire :                 {grade.Comment}");
                }
                Console.WriteLine("");
                Console.WriteLine($"La note moyenne :             {student.CalculateAverageGrade()}%  / 100 %");

                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Étudiant introuvable.");
            }
        }

        static void AddNoteAndComment(List<Student> students)
        {
            Console.WriteLine("Ajouter une note et un commentaire");
            Console.WriteLine("");
            Console.Write("Entrez l'identifiant de l'étudiant : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine($"Étudiant: {student.FirstName} {student.LastName}");
                Console.Write("Entrez le nom du cours : ");
                string course = Console.ReadLine();
                Console.WriteLine("");
                Console.Write("Entrez la note : ");
                double grade = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("");
                Console.Write("Entrez un commentaire : ");
                string comment = Console.ReadLine();

                Grade newGrade = new Grade(course, grade, comment);
                student.Grades.Add(newGrade);
                Console.WriteLine("");
                Console.WriteLine("Note et commentaire ajoutés avec succès.");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Étudiant introuvable.");
            }
        }

        static void ListCourses(List<Student> students)
        {
            Console.WriteLine("Liste des cours");
            Console.WriteLine("");
            HashSet<string> courses = new HashSet<string>();
            foreach (var student in students)
            {
                foreach (var grade in student.Grades)
                {
                    courses.Add(grade.Course);
                }
            }

            foreach (var course in courses)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("");
                Console.WriteLine(course);
                Console.WriteLine("");
                Console.WriteLine("--------------------------------");

            }
        }

        static void AddCourse(List<Student> students)
        {
            Console.WriteLine("Ajouter un cours");
            Console.WriteLine("");
            Console.Write("Entrez le nom du cours : ");
            string course = Console.ReadLine();

            foreach (var student in students)
            {
                Grade newGrade = new Grade(course, 0, "");
                student.Grades.Add(newGrade);
            }
            Console.WriteLine("");
            Console.WriteLine("Cours ajouté avec succès.");
        }

        static void DeleteCourse(List<Student> students)
        {
            Console.WriteLine("Supprimer le cours");
            Console.WriteLine("");
            Console.Write("Entrez le nom du cours : ");
            string course = Console.ReadLine();

           Console.WriteLine("");
            Console.WriteLine("Êtes-vous sûr de vouloir supprimer ce cours ? (O/N)");
            string confirmation = Console.ReadLine();

            if (confirmation.ToUpper() == "O")
            {
                foreach (var student in students)
                {
                    student.Grades.RemoveAll(g => g.Course == course);
                }
                Console.WriteLine("");
                Console.WriteLine("Cours supprimé avec succès.");
            }
        }

        static List<Student> LoadData()
        {
            if (File.Exists(DataFilePath))
            {
                string jsonData = File.ReadAllText(DataFilePath);
                return JsonConvert.DeserializeObject<List<Student>>(jsonData);
            }
            else
            {
                return new List<Student>();
            }
        }

        static void SaveData(List<Student> students)
        {
            string jsonData = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(DataFilePath, jsonData);
        }
    }

    
    
}
