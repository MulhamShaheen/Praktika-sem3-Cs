using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace Lab_3
{
    class Lab_3
    {
        public class Graphic_Editor
        {
            public double Avarege_Area;
            public static List<Shape> drawen_Shapes = new List<Shape>();
            public Graphic_Editor()
            {

                Avarege_Area = 0 ;

            }
            public List<Shape> Drawen_Shapes
            {
                get { return drawen_Shapes; }
                set { drawen_Shapes = value; }
            }
            public double AvArea()
            {
                double A = 0;
                int n = 0;
                foreach (Shape S in drawen_Shapes)
                {
                    n += 1;
                    A += S.GetArea();
                    Avarege_Area = A/n;
                }
                return A/n;
            }
            public enum Shapes
            {
                None,
                Circule,
                Square,
                Ellipse,
                Rectangle
            }
            //ublic static List<Shape> _Drawen_Shapes =
              //      new List<Shape>();
        }
        public abstract class Shape
            {
                public double Area;
                public int Width;
                public Graphic_Editor.Shapes Type;
                public Shape() { }
                public abstract double GetArea();
                public abstract void Draw_Shape();
                public Shape(int _width)
                {
                    Width = _width;
                }
                public void Draw(int x, int y)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    try
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 + x, Console.WindowHeight / 2 + y);
                        Console.Write("*");
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                    }
                }
            }
        public class Square : Shape
            {
                public int side;

                public int Width;
                public Square(int a, int _width) : base(_width)
                { side = a; Width = _width; Area = GetArea(); Type = Graphic_Editor.Shapes.Square; }
                public override double GetArea() => side * side - (Width * side * 4);
                public override void Draw_Shape()
                {
                    Console.Clear();
                    for (int i = 0; i <= side; i++)
                    {

                        int y = side;
                        Draw(i, y);
                        Draw(y, i);
                        Draw(i, -y);
                        Draw(y, -i);
                        Draw(-i, -y);
                        Draw(-y, -i);
                        Draw(-i, y);
                        Draw(-y, i);
                    }

                }
            }
        class Circule : Shape
        {
            public int radius;

            public int Width;
            public Circule(int n, int _width) : base(_width)
            { radius = n; Width = _width; Area = GetArea(); Type = Graphic_Editor.Shapes.Circule; }

            public override double GetArea() => 3.14 * radius * radius - (Width * radius * 2 * 3.14);
            public override void Draw_Shape()
            {
                Console.Clear();

                for (int i = 0; i <= radius; i++)
                {

                    int y = Convert.ToInt32(Math.Sqrt((Convert.ToDouble(radius) * radius) - i * i));
                    Draw(i, y);
                    Draw(-i, y);
                    Draw(-i, -y);
                    Draw(i, -y);
                }
                
            }
        }

        class Ellipse : Shape
            {
                public int axis1, axis2;
                public int Width;
                public Ellipse(int a, int b, int _width) : base(_width)
                { axis1 = a; axis2 = b; Width = _width; Area = GetArea(); Type = Graphic_Editor.Shapes.Ellipse; }
                public override double GetArea() => 3.14 * axis1 * axis2 -
                    (Width * 2 * 3.14 * Math.Sqrt((axis1 * axis1) / 2 + (axis2 * axis2) / 2));
                public override void Draw_Shape()
                {
                    Console.Clear();
                    for (int i = 0; i <= axis1; i++)
                    {

                        int y = Convert.ToInt32(axis2 * Math.Sqrt(1 - ((i * i) / (Convert.ToDouble(axis1) * Convert.ToDouble(axis1)))));
                        Draw(i, y);
                        Draw(-i, y);
                        Draw(i, -y);
                        Draw(-i, -y);
                    }
                }
            }

        class Rectangle : Shape
            {
                public int side1, side2;

                public int Width;
                public Rectangle(int a, int b, int _width) : base(_width)
                { side1 = a; side2 = b; Width = _width; Area = GetArea(); Type = Graphic_Editor.Shapes.Rectangle; }
                public override double GetArea() => side1 * side2 - (2 * Width * (side2 + side1));
                public override void Draw_Shape()
                {
                    Console.Clear();
                    for (int i = 0; i <= side1; i++)
                    {

                        int y = side2;
                        Draw(i, y);
                        Draw(-i, y);
                        Draw(i, -y);
                        Draw(-i, -y);
                    }
                    for (int i = 0; i <= side2; i++)
                    {

                        int y = side1;
                        Draw(y, i);
                        Draw(-y, i);
                        Draw(y, -i);
                        Draw(-y, -i);
                    }
                }
            }
        static void AddSquar(Graphic_Editor Ge)
        {
            Console.WriteLine("Side of your Square = ...");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Width of the boarder of your Square = ...");
            int b = Convert.ToInt32(Console.ReadLine());
            Ge.Drawen_Shapes.Add(new Square(a, b));
            Ge.AvArea();
        }
        static void AddCircule(Graphic_Editor Ge)
            {
                Console.WriteLine("Redius of your Circule = ...");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Width of the boarder of your Circule = ...");
                int b = Convert.ToInt32(Console.ReadLine());
                Ge.Drawen_Shapes.Add(new Circule(a, b));
                Ge.AvArea();
            }
        static void AddEllipse(Graphic_Editor Ge)
            {
                Console.WriteLine("X Axis of your Ellipse = ...");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Y Axis of your Ellipse = ...");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Width of the boarder of your Ellipse = ...");
                int c = Convert.ToInt32(Console.ReadLine());
                Ge.Drawen_Shapes.Add(new Ellipse(a, b, c));
                Ge.AvArea();
            }
        static void AddRectangle(Graphic_Editor Ge)
            {
                Console.WriteLine("Length of your Rectangle = ...");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Width of your Rectangle = ...");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Width of the boarder of your Rectangle = ...");
                int c = Convert.ToInt32(Console.ReadLine());
                Ge.Drawen_Shapes.Add(new Rectangle(a, b, c));
                Ge.AvArea();
            }

        static void SortByArea(Graphic_Editor Ge)
        {
            Ge.Drawen_Shapes.Sort((x, y) => x.Area.CompareTo(y.Area));
            for (int i = 0; i < Ge.Drawen_Shapes.Count-1; i++)
            {
                double X = Ge.Drawen_Shapes.ElementAt(i).Area;
                double Y = Ge.Drawen_Shapes.ElementAt(i+1).Area;
                if (X == Y) { SortByWidth( Ge.Drawen_Shapes.GetRange(3, 4)); }
            }
            Ge.Drawen_Shapes.Reverse();
        }

        static void SortByWidth(List<Shape> drawen_Shapes)
        {
            drawen_Shapes.Sort((x, y) => x.Width.CompareTo(y.Width));
        }
            
        
        public static void Main()
        {
            
            Graphic_Editor Ge = new Graphic_Editor();
           
            Square MySquar = new Square(5, 1);

            Ge.Drawen_Shapes.Add(MySquar);
            Circule MyCircule = new Circule(15, 0);

            Ge.Drawen_Shapes.Add(MyCircule);
            Ellipse MyElipse = new Ellipse(15, 15, 3);

            Ge.Drawen_Shapes.Add(MyElipse);
            Rectangle MyRectangle = new Rectangle(5, 6, 2);

            Ge.Drawen_Shapes.Add(MyRectangle);
            Ge.AvArea();
            SortByArea(Ge);

            foreach (Shape o in Ge.Drawen_Shapes)
            {
                Console.WriteLine($"{o.Type} [ Area = {o.Area} Width = {o.Width} ]");
            }
            //string path = @"C:\MyJSON.txt";
            //if (!File.Exists(path))
            //{
              //  Console.WriteLine("File does not exist :(");
            //}

            //string S = File.ReadAllText(path);
            //using (StreamReader Reader = File.OpenText(path))
            //{
            //  string s;
            //while ((s = Reader.ReadLine()) != null)
            //{
            //  Console.WriteLine(s);
            //Shape NewSq = JsonConvert.DeserializeObject<Shape>(s);
            //}
            //s = Reader.ReadLine();
            //}
            //string MySquare = JsonConvert.SerializeObject(MySquar);
            //Square NewSq = JsonConvert.DeserializeObject<Square>(S);
            //Console.WriteLine(NewSq.Area);
            Console.WriteLine(Ge.AvArea());
            while (true)
            {
                Console.WriteLine("Press 1 to add a shape." +
                    "\nPress 2 to view area and the width of border for every shape " +
                   "\nPress 3 to sort all shapes by area. " +
                   "\nPress 4 to view the biggest 4 shapes " +
                   "\nPress 5 to Draw smallest three shapes." +
                   "\nPress 6 to view the average area of all shapes." +
                   "\nPress 7 to read the file in the path [C:\\ReadMyJSON.txt] " +
                   "\nPress 8 to write a shape from the list to the path [D:\\WriteMyJSON.txt] "+
                   "\nPress 0 if you finished\n----------------------------");
                string x = Console.ReadLine();
                Console.WriteLine("----------------------------");
                if (x == "1")
                {
                    while (true)
                    {
                        Console.WriteLine("Press 1 to add a square.\n" +
                       "Press 2 to add a circule.\n" +
                       "Press 3 to add an elipse.\n" +
                       "Press 4 to add a rectangile.\n" +
                       "Press 0 if you finished");

                        string y = Console.ReadLine();
                        if (y == "1") { AddSquar(Ge); }
                        else if (y == "2") { AddCircule(Ge); }
                        else if (y == "3") { AddEllipse(Ge); }
                        else if (y == "4") { AddRectangle(Ge); }
                        else if (y == "0") { break; }
                        Console.WriteLine("----------------------------");
                    }

                }
                else if (x == "2")
                {
                    foreach (Shape Sh in Ge.Drawen_Shapes)
                    {
                        Console.WriteLine($"{Sh.Type} [ Area = {Sh.Area} Width = {Sh.Width} ]");
                    }
                    Console.WriteLine("----------------------------");
                }
                else if (x == "3")
                {
                    SortByArea(Ge);
                }
                else if (x == "4")
                {
                    foreach (Shape Sh in Ge.Drawen_Shapes.GetRange(0, 4))
                    {
                        Console.WriteLine($"{Sh.Type} [ Area = {Sh.Area} Width = {Sh.Width} ]");
                    }
                }
                else if (x == "5")
                {
                    Ge.Drawen_Shapes.Reverse();
                    foreach (Shape Sh in Ge.Drawen_Shapes.GetRange(0, 3))
                    {
                        Sh.Draw_Shape();
                        Console.SetCursorPosition(0, Console.WindowHeight + 2);
                        Console.WriteLine("Press any key to see the next shape");
                        Console.ReadKey();
                    }
                    Ge.Drawen_Shapes.Reverse();
                }
                
                else if (x == "6")
                {
                    Console.WriteLine($"The average area :{Ge.Avarege_Area} ");
                }
                else if (x == "7")
                {
                    string path = @"D:\ReadMyJSON.txt";
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("File does not exist :(");
                    }
                    
                    Console.WriteLine("Press 1 to read a square" +
                       "\nPress 1 to read a circule" +
                       "\nPress 3 to read an elipse " +
                       "\nPress 4 to read a rectangle " +
                       "\n ----------------------------");
                    string Z = Console.ReadLine();
                    
                    
                    using (StreamReader Reader = File.OpenText(path))
                    {
                        string s;
                        while ((s = Reader.ReadLine()) != null)
                        {
                            if (Z == "1") 
                            {
                                Square NewSq;
                                try
                                {
                                    NewSq = JsonConvert.DeserializeObject<Square>(s);
                                    Console.WriteLine($"{NewSq.Type} [ Area = {NewSq.Area} Width = {NewSq.Width} ]");
                                }
                                catch(JsonReaderException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                
                            }

                            else if (Z == "2") 
                            {
                                Circule NewSq;
                                try
                                {
                                    NewSq = JsonConvert.DeserializeObject<Circule>(s);
                                    Console.WriteLine($"{NewSq.Type} [ Area = {NewSq.Area} Width = {NewSq.Width} ]");
                                }
                                catch (JsonReaderException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
 
                            }
                            else if (Z == "3")
                            {
                                Ellipse NewSq;
                                try
                                {
                                    NewSq = JsonConvert.DeserializeObject<Ellipse>(s);
                                    Console.WriteLine($"{NewSq.Type} [ Area = {NewSq.Area} Width = {NewSq.Width} ]");
                                }
                                catch (JsonReaderException e)
                                {
                                    Console.WriteLine(e.Message);
                                }  
                            }

                            else if (Z == "4")
                            {
                                Rectangle NewSq;
                                try
                                {
                                    NewSq = JsonConvert.DeserializeObject<Rectangle>(s);
                                    Console.WriteLine($"{NewSq.Type} [ Area = {NewSq.Area} Width = {NewSq.Width} ]");
                                }
                                catch (JsonReaderException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                           
                            //string MySquare = JsonConvert.SerializeObject(MySquar);
                            //Console.WriteLine(MySquare);
                        }
                    }

                }   
                else if (x == "8")
                {
                    string path = @"D:\WriteMyJSON.txt";
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("File does not exist :(");
                    }
                    Console.WriteLine("Press a number to write the shape to the file"+
                       "\n ----------------------------");
                    int k = 1;
                    foreach (Shape o in Ge.Drawen_Shapes)
                    {
                        Console.WriteLine($"{k}-{o.Type} [ Area = {o.Area} Width = {o.Width} ]");
                        k++;
                    }

                    using (StreamWriter writer = new StreamWriter(path,true))
                    {
                        int Z = Convert.ToInt32(Console.ReadLine());
                        Shape X = Ge.Drawen_Shapes.ElementAt(Z-1);
                        writer.WriteLine(JsonConvert.SerializeObject(X));
                    }
                }
                else if (x == "0") { break; }
            }
        }
    }
}





   
