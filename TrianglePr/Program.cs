using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;

namespace TrianglePr
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Triangle> triangles = new List<Triangle>();
            ReadData(triangles);
            while (true)
            {
                if (!DoInteraction(triangles))
                    return;
            }
        }

        public static void ReadData(List<Triangle> triangles)
        {
            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "/input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] pts = sr.ReadLine().Split(' ');
                    List<Point> l = new List<Point>();
                    
                    foreach (string pt in pts)
                    {
                        string[] point = pt.Split(';');
                        Point p = new Point(double.Parse(point[0]), double.Parse(point[1]));
                        l.Add(p);
                    }

                    Triangle tr = new Triangle();
                    if (!tr.SetPoints(l[0], l[1], l[2]))
                        break;
                    triangles.Add(tr);
                }
            }
        }

        public static bool DoInteraction(List<Triangle> triangles)
        {
            Console.WriteLine("Считано {0} треугольников.\nИнформацию о каком треугольнике вывести? (Введите esc для выхода)", triangles.Count);
            string s = Console.ReadLine();
            if (s == "esc")
                return false;
            else
            {
                int i = int.Parse(s);
                try
                {
                    Triangle trg = triangles[i-1];
                    Console.WriteLine("Площадь треугольника = {0}", trg.GetArea());
                    Console.WriteLine("Периметр треугольника = {0}", trg.GetPerimeter());
                    Console.WriteLine("Треугольник состоит из точек: {0}, {1}, {2}", trg.P1, trg.P2, trg.P3);
                }
                catch
                {
                    return true;
                }
            }

            return true;
        }
    }
}
