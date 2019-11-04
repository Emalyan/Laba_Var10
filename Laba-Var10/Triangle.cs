using System;

namespace Laba_Var10
{
    public class Triangle
    {
        private Point A;
        private Point B;
        private Point C;

        public Triangle() 
        {
            A = SetValueFromConsole("A");
            B = SetValueFromConsole("B");
            C = SetValueFromConsole("C");            
        }
        
        public Triangle(Point A, Point B, Point C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        private Point SetValueFromConsole(string coordinateName)
        {
            Console.WriteLine($"Введите координаты вершины {coordinateName}");

            Point point = new Point
            {
                x = GetValue("x"),
                y = GetValue("y"),
            };                        

            return point;
        }        

        private double GetValue(string axis)
        {
            string value = "";
            var isValid = false;

            Console.WriteLine($"Введите значение по оси {axis}");
                        
            while (!isValid)
            {
                value = Console.ReadLine();
                isValid = Validate(value);
            }                                    

            return double.Parse(value);
        }

        private bool Validate(string value)
        {
            var isValid = double.TryParse(value, out _);
            if (!isValid)
                Console.WriteLine("Введите корректное значение");

            return isValid;
        }

        public double SideAB 
        {
            get
            {
                return Math.Sqrt(Math.Pow(B.x - A.x, 2) + Math.Pow(B.y - A.y, 2));
            }            
        }        

        public double SideBC
        {
            get
            {
                return Math.Sqrt(Math.Pow(C.x - B.x, 2) + Math.Pow(C.y - B.y, 2));
            }
        }

        public double SideCA
        {
            get
            {
                return Math.Sqrt(Math.Pow(C.x - A.x, 2) + Math.Pow(C.x - A.x, 2));
            }
        }

        public double AngleABC
        {
            get
            {
                var angle = (Math.Pow(SideAB, 2) + Math.Pow(SideBC, 2) - Math.Pow(SideCA, 2)) / 2 * SideAB * SideBC;
                return Math.Cos(angle * Math.PI / 180);
            }
        }

        public double AngleBAC
        {
            get
            {
                var angle = (Math.Pow(SideAB, 2) + Math.Pow(SideCA, 2) - Math.Pow(SideBC, 2)) / 2 * SideAB * SideCA;
                return Math.Cos(angle * Math.PI / 180);
            }
        }

        public double AngleACB
        {
            get
            {
                var angle = (Math.Pow(SideCA, 2) + Math.Pow(SideBC, 2) - Math.Pow(SideAB, 2)) / 2 * SideCA * SideBC;
                return Math.Cos(angle * Math.PI / 180);
            }
        }        

        public void Transfer(double distance)
        {
            A.x += distance;
            B.x += distance;
            C.x += distance;
        }        

        public void ShowInfo()
        {
            Console.WriteLine("Координаты вершин \t Длины сторон \t Углы(рад)");
            Console.WriteLine($"({Math.Round(A.x, 1)};{Math.Round(A.y, 1)})({Math.Round(B.x, 1)};" +
                $"{Math.Round(B.y, 1)})({Math.Round(C.x, 1)};{Math.Round(C.y, 1)}) \t {Math.Round(SideAB, 1)}, " +
                $"{Math.Round(SideBC, 1)}, {Math.Round(SideCA, 1)} \t {Math.Round(AngleBAC, 1)}, " +
                $"{Math.Round(AngleABC, 1)}, {Math.Round(AngleACB, 1)}");            
        }

        public static bool IsTrianglesCross(Triangle firstTriangle, Triangle secondTriangle)
        {
            Point[] pointsInFirstTrg =
                { firstTriangle.A, firstTriangle.B, firstTriangle.C, firstTriangle.A };
            Point[] pointsInSecondTrg =
                { secondTriangle.A, secondTriangle.B, secondTriangle.C, secondTriangle.A };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {                    
                    var isCross = IsLinesCross(pointsInFirstTrg[i].x, pointsInFirstTrg[i].y,
                        pointsInFirstTrg[i + 1].x, pointsInFirstTrg[i + 1].y, pointsInSecondTrg[j].x,
                        pointsInSecondTrg[j].y, pointsInSecondTrg[j + 1].x, pointsInSecondTrg[j + 1].y);

                    if (isCross)
                        return isCross;
                }
            }

            return false;
        }

        private static bool IsLinesCross(double ax1, double ay1, double ax2, double ay2,
           double bx1, double by1, double bx2, double by2)
        {
            double dx1 = ax2 - ax1;
            double dy1 = ay2 - ay1;
            double dx2 = bx2 - bx1;
            double dy2 = by2 - by1;
            double dxx = ax1 - bx1;
            double dyy = ay1 - ay1;

            if ((Math.Abs(dy2) * Math.Abs(dx1) - Math.Abs(dx2) * Math.Abs(dy1)) == 0)
                return false;

            if ((Math.Abs(dx1) * Math.Abs(dyy) - Math.Abs(dy1) * Math.Abs(dxx)) < 0)
                return false;

            if ((Math.Abs(dx2) * Math.Abs(dyy) - Math.Abs(dy2) * Math.Abs(dxx)) < 0)
                return false;

            return true;
        }
    }
}
