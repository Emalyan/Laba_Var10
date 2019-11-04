using System;

namespace Laba_Var10
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstTriangle = new Triangle
                (
                    new Point { x = 2, y = 3 },
                    new Point { x = 3, y = 1 },
                    new Point { x = 1, y = 1 }
                );
            var secondTriangle = new Triangle();
            var thirdTriangle = new Triangle();

            firstTriangle.ShowInfo();
            secondTriangle.ShowInfo();
            thirdTriangle.ShowInfo();            

            Console.WriteLine(Triangle.IsTrianglesCross(firstTriangle, secondTriangle));
            Console.WriteLine(Triangle.IsTrianglesCross(secondTriangle, thirdTriangle));
            Console.WriteLine(Triangle.IsTrianglesCross(thirdTriangle, firstTriangle));

            firstTriangle.Transfer(-30);
            firstTriangle.ShowInfo();

            Console.ReadKey();
        }                

                
    }
}
