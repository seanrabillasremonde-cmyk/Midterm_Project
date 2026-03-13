using Student_Management;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;



class Program
{
    static void Main()
    {

        string mainFolder = Path.Combine(
       Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
       "SchoolSyst" // The name of the folder  


   );

        {
            string studentSubjectFile = /*This one is use to combine mainfolder and its name of it -->*/Path.Combine(mainFolder, "StudentSubject.txt"); // <--- The name of the file EnterGradesvariable


            string gradeFile = /*This one is use to combine mainfolder and its name of it -->*/ Path.Combine(mainFolder, "Grades.txt"); // <--- The name of the file EnterGradesvariable

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
                            RegisterStudent(studentSubjectFile); // <-- use as a string to connect with mainfolder 
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
                            EnrollSubject(studentSubjectFile); // <-- use as a string to connect with mainfolder 
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
                            EnterGrades(gradeFile);// <-- use as a string to connect with mainfolder 
                        }
                        break;


                    case "4":
                        ShowGrades(gradeFile); // <-- use as a string to connect with mainfolder 
                        break;

                    case "5":
                        CreateFolder(mainFolder);
                        break;

                    case "6":
                        running = false;
                       
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
                Console.Clear();
            }
        }
    }

    // =========================
    // 1 REGISTER STUDENT
    // =========================

    static void RegisterStudent(string file) // the string variable file is use for connecting to EnrollSubject  
    {
        List<student> students; // list of the empty file 
        if (File.Exists(file))
        {
            string oldJson = File.ReadAllText(file); // print all of the old input
            students = JsonSerializer.Deserialize<List<student>>(oldJson); // record of all of the old input 
            if (students == null) // this is for if the json is equal to blank becuase of streamwriter or 0 then it will create a new list 
            {
                students = new List<student>();
            }
        }
        else
        {
            students = new List<student>(); // if file not be found then it automatically create another one 
        }



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

        students.Add(s);

           var options = new JsonSerializerOptions
           {
              WriteIndented = true      
           };
         
          string json = JsonSerializer.Serialize(students, options);// And this file will be use to connect in students
         using (StreamWriter writer = new StreamWriter(file))
         {
            writer.Write(json);
         }



        Console.WriteLine("Student Registered Successfully!");
        System.Threading.Thread.Sleep(800); // timer 
        Console.SetCursorPosition(0, 0);// this to prevent the position of ansi to change 
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

    static void EnterGrades(string grad) // the grad variable file is use for connecting to  ShowGrades
    {
        List<grade> grades = new List<grade>(); // list of the empty file 


        string oldJson1 = File.ReadAllText(grad); // print all of the old input
        grades = JsonSerializer.Deserialize<List<grade>>(oldJson1); // record of all of the old input 

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
            System.Threading.Thread.Sleep(800);
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            return;
        }

        Console.Write("2nd Semester Grade: ");
        if (!double.TryParse(Console.ReadLine(), out double second))
        {
            Console.WriteLine("Error please try again");
            System.Threading.Thread.Sleep(800);
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            return;
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
        
        grades.Add(g);

        string json = JsonSerializer.Serialize(grades, new JsonSerializerOptions { WriteIndented = true });// The file is use to connect to enter grades 
            {

              File.WriteAllText(grad, json);
             }



        Console.WriteLine("Grades Saved!");
        System.Threading.Thread.Sleep(800);
        Console.SetCursorPosition(0, 0);
        Console.Clear();

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
        bool found = false;
        
        
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
                if (!found)
                {
                    Console.WriteLine("Student not found.");
                }

            }

        }
       
    }

    // =========================
    // 5 CREATE FOLDER
    // =========================

    static void CreateFolder(string mainFolder) // The string is use to conect to path combine and so it would be name as the file and will be going to the desktop and become a folder
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

