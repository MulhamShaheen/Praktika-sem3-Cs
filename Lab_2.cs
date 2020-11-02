using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public class Class2
    {
        class set
        {
            public int Size;
            public int[] Set;
            public set(int size, int[] set1)
            {
                Set = set1;

                Size = size;
            }

            public static set operator +(set a, int b)
            {
                int[] z = a.Set;
                Array.Resize(ref z, a.Size + 1);
                z[a.Size] = b;
                set c = new set(a.Size + 1, z);
                return c;
            }
            public static set operator -(set a, int b)
            {
                int[] z = new int[a.Size];
                int j = -1;
                for (int i = 0; i < a.Size; i++)
                {
                    if (a.Set[i] == b) { j = i; i++; break; }
                    else { z[i] = a.Set[i]; }
                }
                if (j == -1) { Console.WriteLine("The Element does not excest in the set"); return a; }
                for (int i = j + 1; i < a.Size; i++)
                {
                    z[i - 1] = a.Set[i];
                }
                
                Array.Resize(ref z, a.Size - 1);

                set c = new set(a.Size - 1, z);
                return c;
            }
            public static bool operator <(set a, set b)
            {
                if (a.Size < b.Size)
                {
                    int i = 0;
                    int k = 0;
                    while (i < a.Size)
                    {
                        k = 0;
                        for (int j = 0; j < b.Size; j++)
                        {
                            if (a.Set[i] == b.Set[j]) { i++; k = 1; break; }
                        }
                        if (k == 0) { break; }
                    }
                    if (k == 1) { return true; }
                    else { return false; }
                }
                else { return false; }
            }
            public static bool operator >(set a, set b)
            {
                if (b.Size < a.Size)
                {
                    int i = 0;
                    int k = 0;
                    while (i < b.Size)
                    {
                        k = 0;
                        for (int j = 0; j < a.Size; j++)
                        {
                            if (b.Set[i] == a.Set[j]) { i++; k = 1; break; }
                        }
                        if (k == 0) { break; }
                    }
                    if (k == 1) { return true; }
                    else { return false; }
                }
                else { return false; }
            }
            public static bool operator ==(set a, set b)
            {
                if (b.Size == a.Size)
                {
                    int i = 0;
                    int k = 0;
                    int n = 0;
                    while (i < a.Size)
                    {
                        k = 0;
                        for (int j = 0; j < b.Size; j++)
                        {
                            if (a.Set[i] == b.Set[j]) { i++; k = 1;n++; break; }
                        }
                        if (k == 0) { break; }
                    }
                    if (k == 1 && n == b.Size) { return true; }
                    else { return false; }
                }
                else { return false; }

            }
            public static bool operator !=(set a, set b)
            {
                if (b.Size == a.Size)
                {
                    int i = 0;
                    int k = 0;
                    int n = 0;
                    while (i < a.Size)
                    {
                        k = 0;
                        for (int j = 0; j < b.Size; j++)
                        {
                            if (a.Set[i] == b.Set[j]) { i++; k = 1; n++; break; }
                        }
                        if (k == 0) { break; }
                    }
                    if (k == 1 && n != b.Size) { return true; }
                    else if (k == 1 && n == b.Size) { return false; }
                    else { return false; }
                }
                else if (b.Size != a.Size) { return true; }
                else { return false; }

            }
            public static set operator /(set a, set b)
            {
                set c = a;
                for (int i = 0; i < b.Size; i++)
                {
                    c = c - b.Set[i];
                }
                return c;
            }
        }
        
        public static void Main()
        {

            int[] z = { 1, 2, 3, 4, 5 };
            set a = new set(5, z);
            while (true)
            {
                Console.WriteLine("\n----------------------------");
                Console.WriteLine("Press 1 to add an element.\nPress 2  delete an element." +
                   "\nPress 3 to view the set. \nPress 4 to compare the set with another set." +
                   "\nPress 5 to find out the difference between the set with another set." +
                   "\nPress 0 if you finished\n----------------------------");

                string x = (Console.ReadLine());
                Console.WriteLine("----------------------------");
                if (x == "1")
                {
                    Console.WriteLine("What element you want to add...");
                    int num = Convert.ToInt32(Console.ReadLine());
                    a = a + num;
                }
                else if (x == "2")
                {
                    Console.WriteLine("What element you want to delete...");
                    int num = Convert.ToInt32(Console.ReadLine());
                    a = a - num;
                }
                else if (x == "3")
                {
                    for (int i = 0; i < a.Size; i++) { Console.WriteLine($"{a.Set[i]}"); }
                }
                else if (x =="4")
                {
                    Console.WriteLine("create a set to compare to ..." +
                        "\n----------------------------");
                    Console.WriteLine("Insert the set size ...");
                    int MySize = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Insert elements of your set ...");
                    int[] MyArr = new int[MySize];
                    for (int i = 0; i < MySize; i++) {MyArr[i] = Convert.ToInt32(Console.ReadLine()); }

                    set MySet = new set(MySize, MyArr);

                    Console.WriteLine("What do you want to know ...\n----------------------------");
                    while (true)
                    { 
                        Console.WriteLine("Press 1 for My Set = The Original Set ?\n" +
                            "Press 2 for My Set != The Original Set ?\n" +
                            "Press 3 for My Set < The Original Set ?\n" +
                            "Press 4 for My Set > The Original Set ?\n" +
                            "Press 0 If you finished ...");
                        string y = (Console.ReadLine());
                        Console.WriteLine("----------------------------");
                        if(y == "1") { Console.WriteLine(MySet == a); }
                        else if (y=="2") { Console.WriteLine(MySet != a); }
                        else if (y == "3") { Console.WriteLine(MySet < a); }
                        else if (y == "4") { Console.WriteLine(MySet > a); }
                        else if (y == "0") { break; }
                        Console.WriteLine("\n----------------------------");
                    }
                        

                }
                else if (x == "5") 
                {
                    Console.WriteLine("create a set ..." +
                       "\n----------------------------");
                    Console.WriteLine("Insert the set size ...");
                    int MySize = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Insert elements of your set ...");
                    int[] MyArr = new int[MySize];
                    for (int i = 0; i < MySize; i++) { MyArr[i] = Convert.ToInt32(Console.ReadLine()); }
                    Console.WriteLine("\n----------------------------");

                    set MySet = new set(MySize, MyArr);
                    set S = a / MySet;
                    for (int i = 0; i < S.Size; i++) { Console.WriteLine($"{S.Set[i]}"); };
                }
                else if (x == "0") { break;}
            }
        }
    }   
}
