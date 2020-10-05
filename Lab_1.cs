using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Class1
    {
        class Date
        {
            public int Day;
            public int Month;
            public int Year;
            public string ToRead;
            public Date(int day, int month, int year)
            {
                Day = day;
                Month = month;
                Year = year;
                ToRead = String.Format("{0}-{1}-{2}", day, month, year);
            }
        }
        class Student
        {
            public string Name;
            public string Surname;
            public Date BirthDate;
            public long Tele;
            public Student(string name, string surname, Date birthDate, long tele)
            {
                Name = name;
                Surname = surname;
                BirthDate = birthDate;
                Tele = tele;
            }
            public static void WriteData(Student a)
            {
                Console.WriteLine("What do you want to know :...");
                Console.WriteLine("Press 1 for Name.\nPress 2 for BirthDate." +
                    "\nPress 3 for Telephone number.\nPress 4 to know Vso." +
                    "\nPress 0 if you finished\n----------------------------");

                while (true)
                {

                    string x = (Console.ReadLine());
                    if (x == "1") { Console.WriteLine(a.Name + " " + a.Surname); }
                    else if (x == "2") { Console.WriteLine(a.BirthDate.ToRead + "\n"); }
                    else if (x == "3") { Console.WriteLine(a.Tele + "\n"); }
                    else if (x == "4") { Console.WriteLine($"{a.Name} \n{a.BirthDate.ToRead} \n{a.Tele}" + "\n"); }
                    else if (x == "0") { break; }
                    else { Console.WriteLine("Please read instructions ;)"); }
                }

            }
            public static void WriteData_Vso(Student a)
            {
                Console.WriteLine($"{a.Name} {a.Surname} \n{a.BirthDate.ToRead} \n{a.Tele}" + "\n");
            }
        }
        static Student[] RemoveAt(Student[] a, int index)
        {
            Student[] b = new Student[a.Length - 1];
            for (int i = 0; i < index; i++) { b[i] = a[i]; }
            for (int i = index; i < a.Length - 1; i++) { b[i] = a[i + 1]; }
            a = b;
            return a;
        }
        class StGroup
        {
            public string NameGroup;
            public int NumStud;
            public Student[] Students;

            public StGroup(string name, int numStud, Student[] students)
            {
                NameGroup = name;
                NumStud = numStud;
                Students = students;

            }

                public static StGroup AddStudent(StGroup a, int num)
                {
                    Student[] y = new Student[a.NumStud + num];

                    for (int i = 0; i < a.NumStud; i++)
                    {
                        y[i] = a.Students[i];
                    }
                    for (int i = 0; i < num; i++)
                    {
                        Console.WriteLine("Name of new student:...");
                        string z = Console.ReadLine();

                        Console.WriteLine("Sername of new student:...");
                        string x = Console.ReadLine();

                        Console.WriteLine("Day of birth of the new student:...");
                        int day = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("month of birth of the new student:...");
                        int month = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Year of birth of the new student:...");
                        int year = Convert.ToInt32(Console.ReadLine());

                        Date j = new Date(day, month, year);

                        Console.WriteLine("Tele phone number:...");
                        long k = long.Parse(Console.ReadLine());

                        y[a.NumStud + i] = new Student(z, x, j, k);
                        Console.WriteLine("\n");

                    }

                    StGroup a1 = new StGroup(a.NameGroup, num + a.NumStud, y);
                    return a1;
                }
                public static Student[] SearchByName(StGroup a)
                {
                    Console.WriteLine("THe name of the student :..."); string x = Console.ReadLine();

                    Console.WriteLine("----------------------------");
                    int i = 0; int j = 0;
                    Student[] y = new Student[a.NumStud];
                    while (i < a.NumStud)
                    {
                        if (a.Students[i].Name == x) { y[j] = a.Students[i]; j++; i++; }
                        else { i++; }
                    }
                    Student[] z = new Student[j];
                    i = 0;
                    while (j > 0) { z[i] = y[i]; j--; i++; }

                    for (int k = 0; k < z.Length; k++)
                    {
                        Console.WriteLine(($"{z[k].Name} {z[k].Surname} \n{z[k].BirthDate.ToRead} \n{z[k].Tele}" +
                        "\n----------------------------"));
                    }
                    if (z.Length == 0) { Console.WriteLine("Student is not found.\n----------------------------"); }
                    return z;
                }
                public static Student[] SearchBySurname(StGroup a)
                {
                    Console.WriteLine("Search for :...");
                    string x = Console.ReadLine();
                    Console.WriteLine("----------------------------");
                    int i = 0; int j = 0;
                    Student[] y = new Student[a.NumStud];
                    while (i < a.NumStud)
                    {
                        if (a.Students[i].Surname == x) { y[j] = a.Students[i]; j++; i++; }
                        else { i++; }
                    }
                    Student[] z = new Student[j];
                    i = 0;
                    while (j > 0) { z[i] = y[i]; j--; i++; }

                    for (int k = 0; k < z.Length; k++)
                    {
                        Console.WriteLine(($"{z[k].Name} {z[k].Surname} \n{z[k].BirthDate.ToRead} \n{z[k].Tele}" +
                            "\n----------------------------"));
                    }
                    if (z.Length == 0) { Console.WriteLine("Student is not found.\n----------------------------"); }
                    return z;
                }
                public static Student[] SearchByTele(StGroup a)
                {
                    Console.WriteLine("Search for :...");
                    long x = long.Parse(Console.ReadLine());
                    Console.WriteLine("----------------------------");
                    int i = 0; int j = 0;
                    Student[] y = new Student[a.NumStud];
                    while (i < a.NumStud)
                    {
                        if (a.Students[i].Tele == x) { y[j] = a.Students[i]; j++; i++; }
                        else { i++; }
                    }
                    Student[] z = new Student[j];
                    i = 0;
                    while (j > 0) { z[i] = y[i]; j--; i++; }

                    for (int k = 0; k < z.Length; k++)
                    {
                        Console.WriteLine(($"{z[k].Name} {z[k].Surname} \n{z[k].BirthDate.ToRead} \n{z[k].Tele}" +
                            "\n----------------------------"));
                    }
                    if (z.Length == 0) { Console.WriteLine("Student is not found.\n----------------------------"); }
                    return z;
                }
                public static void DeleteByName(StGroup a)
                {
                    Student[] x = SearchByName(a);
                    if (x.Length > 1)
                    {
                        Console.WriteLine("Select a student.\n---------------------------- ");
                        int i = 0;
                        while (i < x.Length)
                        {
                            Console.WriteLine($"Press {i + 1}. to delete {x[i].Name} {x[i].Surname}.");
                            i++;

                        }
                        Console.WriteLine("Press 0 if you finished\n----------------------------");
                        int d = 0;
                        while (true)
                        {
                            int y = Convert.ToInt32(Console.ReadLine());
                            if (y <= i )
                            {
                                a.Students = RemoveAt(a.Students, Array.IndexOf(a.Students, x[y-1])); d++;
                                break;
                            }
                            else if (y == 0) { break; }
                            else { Console.WriteLine("Please read instructions ;)"); }
                        }

                        a.NumStud = a.NumStud - d;

                    }
                    else { a.Students = RemoveAt(a.Students, Array.IndexOf(a.Students, x[0])); a.NumStud = a.NumStud - 1; }

                }
                public static void SortByBirthdate(StGroup a)
                {

                    for (int i = 0; i < a.NumStud; i++)
                    {
                        Array.Sort(a.Students,
                           delegate (Student x, Student y) { return x.BirthDate.Day.CompareTo(y.BirthDate.Day); });
                        Array.Sort(a.Students,
                          delegate (Student x, Student y) { return x.BirthDate.Month.CompareTo(y.BirthDate.Month); });
                        Array.Sort(a.Students,
                          delegate (Student x, Student y) { return x.BirthDate.Year.CompareTo(y.BirthDate.Year); });
                    }

                }
            }

        public static void Main()
        {
            Student Mul = new Student("Mulham","Shaheen", new Date(21, 1, 2001), 89026121473);
            Student pol = new Student("Vika", "Viktarova", new Date(20, 3, 2001), 89026001475);
            Student dus = new Student("Daria", "Shakarivo", new Date(25, 5, 2002), 89111111111);
            Student den = new Student("Denis", "Polorotove", new Date(18, 4, 2000), 89026125483);
            Student sas = new Student("Alexander", "Alexanderovich", new Date(30, 8, 1999), 89026178973);
            Student sas1 = new Student("Alexander", "Mardini", new Date(1, 9, 1997), 89026178973);

            StGroup Ka = new StGroup("Ka-203", 6, new Student[6] { Mul,pol,dus,den,sas,sas1 });

             for (int i = 0; i < Ka.NumStud; i++) { Student.WriteData_Vso(Ka.Students[i]) ; }
             Console.WriteLine("\n----------------------------");

            while (true)
            {
                Console.WriteLine("Press 1 to add a student.\nPress 2  delete a student." +
                   "\nPress 3 for search for students.\nPress 4 to sort by age.\nPress 5 to view all the students." +
                   "\nPress 0 if you finished\n----------------------------");

                string x = (Console.ReadLine());
                Console.WriteLine("----------------------------");
                if (x == "1")
                { 
                    Console.WriteLine("How many students you would like to add...");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Ka = StGroup.AddStudent(Ka, num);
                }
                else if (x == "2") { StGroup.DeleteByName(Ka); }
                else if (x == "3") 
                {
                    Console.WriteLine("Search by...\nPress N to search by first name.\nPress S to search by Surname." +
                        "\nPress T to search by telephone number.\nPress 0 if you finished\n----------------------------");
                    while(true)
                    {
                        string y = (Console.ReadLine());
                        if (y == "N") { StGroup.SearchByName(Ka); }
                        else if (y == "S") { StGroup.SearchBySurname(Ka); }
                        else if (y == "T") { StGroup.SearchByTele(Ka); }
                        else if (y == "0") { break; }
                        else { Console.WriteLine("Please read instructions ;)"); }
                    }
                }
                else if (x == "4") {StGroup.SortByBirthdate(Ka); }
                else if (x == "5") { for (int i = 0; i < Ka.NumStud; i++) { Student.WriteData_Vso(Ka.Students[i]); } }
                else if (x == "0") { break; }
                else { Console.WriteLine("Please read instructions ;)"); }
                Console.WriteLine("----------------------------");
            }
            

        }
    }
}

