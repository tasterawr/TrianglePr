using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglePr
{
    class Triangle
    {
        Point p1;
        Point p2;
        Point p3;

        public Triangle()
        {

        }

        public bool SetPoints(Point p1, Point p2, Point p3)
        {
            try
            {
                CheckPoints(p1, p2, p3);
                this.p1 = p1;
                this.p2 = p2;
                this.p3 = p3;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckPoints(Point p1, Point p2, Point p3)
        {
            if ((p3.X - p1.X) / (p2.X - p1.X) == (p3.Y - p1.Y) / (p2.Y - p1.Y))
            {
                PrintMessage("Ошибка ввода: Треугольник является вырожденным.");
                throw new ArgumentException("Ошибка ввода: Треугольник является вырожденным.");
            }

            double vec1_len = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
            double vec2_len = Math.Sqrt((p3.X - p1.X) * (p3.X - p1.X) + (p3.Y - p1.Y) * (p3.Y - p1.Y));
            double vec3_len = Math.Sqrt((p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y));

            if (vec1_len > vec2_len + vec3_len || vec2_len > vec1_len + vec3_len
                || vec3_len > vec1_len + vec2_len)
            {
                PrintMessage("Ошибка ввода: Длина одной из сторон больше суммы двух других.");
                throw new ArgumentException("Ошибка ввода: Длина одной из сторон больше суммы двух других.");
            }

            return true;
        }

        public double GetArea()
        {
            double deter = (p1.X - p3.X) * (p2.Y - p3.Y) - (p1.Y - p3.Y) * (p2.X - p3.X);
            return Math.Abs(deter * 0.5);
        }

        public double GetPerimeter()
        {
            double vec1_len = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
            double vec2_len = Math.Sqrt((p3.X - p1.X) * (p3.X - p1.X) + (p3.Y - p1.Y) * (p3.Y - p1.Y));
            double vec3_len = Math.Sqrt((p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y));

            return vec1_len + vec2_len + vec3_len;
        }

        public Point P1
        {
            get { return new Point(p1); }
            set => p1 = new Point(value);
        }

        public Point P2
        {
            get { return new Point(p2); }
            set => p2 = new Point(value);
        }

        public Point P3
        {
            get { return new Point(p3); }
            set => p3 = new Point(value);
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
