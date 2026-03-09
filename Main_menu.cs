using Student_Management;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

class Program
{
    static void Main()
    {

        string mainFolder = Path.Combine(
       Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
       "SchoolSyst" // The name of the folder  EnterGradesvariable


   );             
                                             
            {                                  
                string studentSubjectFile = Path.Combine(mainFolder, $"StudentSubject.txt"); // <--- The name of the file EnterGradesvariable


                string gradeFile = Path.Combine(mainFolder, $"Grades.txt"); // <--- The name of the file EnterGradesvariable

                bool running = true;
                string Menu;
                Console.Clear();
                while (running)
                {
                    Console.WriteLine("\n+===== Main   Menu ======+");
                    Console.WriteLine("│1.Register Student      │");
                    Console.WriteLine("│2.Enroll student subject│");
                    Console.WriteLine("│3.Enter Grades          │");
                    Console.WriteLine("│4.Show Grade by student │");
                    Console.WriteLine("│5.Create folder         │");
                    Console.WriteLine("│6.Exit                  │");
                    Console.WriteLine("│════════════════════════│");
                    Console.WriteLine("│Pick a number 1 to 6    │");
                    Console.WriteLine("│Choose:                 │");
                    Console.WriteLine("+========================+");

                    Console.SetCursorPosition(8, 10);
                    Menu = Console.ReadLine();

                    Console.Clear();


                    switch (Menu)
                    {
                        case "1":
                            if (!Directory.Exists(mainFolder))
                            {
                                Console.WriteLine("Please create the folder first (Option 5).");
                                System.Threading.Thread.Sleep(800);
                                Console.SetCursorPosition(0, 0);
                                Console.Clear();
                            }

                            else
                            {
                                RegisterStudent(studentSubjectFile);
                            }
                            break;
                        case "2":
                            if (!Directory.Exists(mainFolder))
                            {
                                Console.WriteLine("Please create the folder first (Option 5).");
                                System.Threading.Thread.Sleep(800);
                                Console.SetCursorPosition(0, 0);
                                Console.Clear();

                            }
                            else
                            {
                                EnrollSubject(studentSubjectFile);
                            }
                            break;

                        case "3":
                            if (!Directory.Exists(mainFolder))
                            {
                                Console.WriteLine("Please create the folder first (Option 5).");
                                System.Threading.Thread.Sleep(800);
                                Console.SetCursorPosition(0, 0);
                                Console.Clear();


                            }
                            else
                            {
                                EnterGrades(gradeFile);
                            }
                            break;


                        case "4":
                            ShowGrades(gradeFile);
                            break;

                        case "5":
                            CreateFolder(mainFolder);
                            break;

                        case "6":
                            running = false;
                            return;
                            break;

                        default:
                            Console.WriteLine("Invalid choice!");
                            System.Threading.Thread.Sleep(800);
                            Console.SetCursorPosition(0, 0);
                            Console.Clear();
                            break;
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.SetCursorPosition(0, 0);
                    Console.ReadKey();
                }
            }
    }

    // =========================
    // 1 REGISTER STUDENT
    // =========================

    static void RegisterStudent(string file) // the string variable file is use for connecting to EnrollSubject  
    {
        List<student> students = new List<student>();
        Console.Clear();
        Console.WriteLine("=== REGISTER STUDENT ===");

        Console.Write("First Name: ");
        string fname = Console.ReadLine();

        Console.Write("Middle Name: ");
        string mname = Console.ReadLine();

        Console.Write("Last Name: ");
        string lname = Console.ReadLine();

        Console.Write("Birthdate: ");
        string birth = Console.ReadLine();

        Console.Write("Age: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Error not number please try again");
            System.Threading.Thread.Sleep(800);
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            return;
        }

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("Contact Number: ");
        if (!int.TryParse(Console.ReadLine(), out int contact))
        {
            Console.WriteLine("Error not number please try again");
            System.Threading.Thread.Sleep(800);
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            return;
        }


        Console.Write("Course Year: ");
        string course = Console.ReadLine();

        student s = new student
        {
            first_name = fname,
            middle_name = mname,
            last_name = lname,
            year_birth = birth,
            age_old = age,
            loaction_adress = address,
            contact_number = contact,
            COURSE = course

        };
        students.Clear();
        students.Add(s);


        using (StreamWriter writer = new StreamWriter(file, true)) // And this file will be use to connect in RegisterStudent
        {
            foreach (var connect in students)
            {
                writer.WriteLine("===== STUDENT =====");
                writer.WriteLine($"\rName:{(connect.first_name) + ""} {(connect.middle_name) + ""}  {(connect.last_name)}");
                writer.WriteLine("Birthdate: " + connect.year_birth);
                writer.WriteLine("Age: " + connect.age_old);
                writer.WriteLine("Address: " + connect.loaction_adress);
                writer.WriteLine("Contact: " + connect.contact_number);
                writer.WriteLine("Course/Year: " + connect.COURSE);
                writer.WriteLine("------------------------");
                System.Threading.Thread.Sleep(800);
                Console.SetCursorPosition(0, 0);
                Console.Clear();

            }


        }
        Console.WriteLine("Student Registered Successfully!");
        System.Threading.Thread.Sleep(800);
        Console.SetCursorPosition(0, 0);
        Console.Clear();
    }


    // =========================
    // 2 ENROLL SUBJECT
    // =========================

    static void EnrollSubject(string file) // the string variable file is use for recording RegisterStudent   
    {
        Console.Clear();
        Console.WriteLine("=== ENROLL SUBJECT ===");

        Console.Write("Student Name: ");
        string studentName = Console.ReadLine();

        Console.Write("Subject ID: ");
        string studID = Console.ReadLine();

        Console.Write("Subject Name: ");
        string subName = Console.ReadLine();

        Console.Write("Grade: ");
        string grade = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(file, true))
        {
            writer.WriteLine("===== SUBJECT =====");
            writer.WriteLine("Student: " + studentName);
            writer.WriteLine("Student ID: " + studID);
            writer.WriteLine("Subject Name: " + subName);
            writer.WriteLine("Grade: " + grade);
            writer.WriteLine("------------------------");
        }

        Console.WriteLine("Subject Enrolled!");
    }

    // =========================
    // 3 ENTER GRADES
    // =========================

    static void EnterGrades(string grad) // the string variable file is use for connecting to EnrollSubject  
    {

        List<grade> grades = new List<grade>();
        Console.Clear();
        Console.WriteLine("=== ENTER GRADES ===");

        Console.Write("Student Name: ");
        string student = Console.ReadLine();

        Console.Write("Student ID:");
        string studeID = Console.ReadLine();

        Console.Write("1st Semester Grade: ");
        if (!double.TryParse(Console.ReadLine(), out double first))
        {
            Console.WriteLine("Error please try again");
        }

        Console.Write("2nd Semester Grade: ");
        if (!double.TryParse(Console.ReadLine(), out double second))
        {
            Console.WriteLine("Error please try again");
        }
        double average = (first + second) / 2;

        grade g = new grade
        {
            student_1 = student,
            stude_ID = studeID,
            first_1 = first,
            second_2 = second,
            average_1 = average,
        };
        grades.Clear();
        grades.Add(g);

        using (StreamWriter writer = new StreamWriter(grad, true)) // The file is use to connect to enter grades 
            foreach (var score in grades)
            {
                writer.WriteLine("===== GRADES =====");
                writer.WriteLine("Student: " + score.student_1);
                writer.WriteLine("Student_ID: " + score.stude_ID);
                writer.WriteLine("1st Sem: " + score.first_1);
                writer.WriteLine("2nd Sem: " + score.second_2);
                writer.WriteLine("Average: " + score.average_1);
                writer.WriteLine("------------------------");
            }

        Console.WriteLine("Grades Saved!");
    }

    // =========================
    // 4 SHOW GRADES
    // =========================

    static void ShowGrades(string grad) //  The string is use to connect to enter grades
    {
        Console.Clear();
        Console.WriteLine("=== SHOW STUDENT GRADES ===");

        Console.Write("Enter Student Name: ");
        string search = Console.ReadLine();

        if (File.Exists(grad))
        {
            using (StreamReader reader = new StreamReader(grad)) // is use to connect EnterGrades
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(search))
                    {
                        Console.WriteLine("\nStudent Found:");
                        Console.WriteLine(line);
                        Console.WriteLine(reader.ReadLine());
                        Console.WriteLine(reader.ReadLine());
                        Console.WriteLine(reader.ReadLine());// when you keep pressing showgrade it will stop the input of the line to go down  
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("No grade file found.");
        }
    }

    // =========================
    // 5 CREATE FOLDER
    // =========================

    static void CreateFolder(string mainFolder)
    {
        Console.Clear();

        if (!Directory.Exists(mainFolder))
        {
            Directory.CreateDirectory(mainFolder);
            Console.WriteLine("Main Folder Created!");
        }
        else
        {
            Console.WriteLine("Folder already exists.");
        }
    }
}
