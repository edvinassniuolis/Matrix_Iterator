using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Iterration
{
    public class SeidelCalculator
    {
        public static void CalculateSeidelMethod(double[,] arrayA, double[] arrayB)
        {
            double xk1 = 0;
            double xk2 = 0;
            double xk3 = 0;
            double xk4 = 0;

            Console.WriteLine("i\tx1\t\t\tx2\t\t\tx3\t\tx4");
            for (int i = 0; i < 20; i++)
            {
                xk1 = (arrayB[0] - (arrayA[0, 1] * xk2) - (arrayA[0, 2] * xk3) - (arrayA[0, 3] * xk4)) / arrayA[0, 0];
                xk2 = (arrayB[1] - (arrayA[1, 0] * xk1) - (arrayA[1, 2] * xk3) - (arrayA[1, 3] * xk4)) / arrayA[1, 1];
                xk3 = (arrayB[2] - (arrayA[2, 0] * xk1) - (arrayA[2, 1] * xk2) - (arrayA[2, 3] * xk4)) / arrayA[2, 2];
                xk4 = (arrayB[3] - (arrayA[3, 0] * xk1) - (arrayA[3, 1] * xk2) - (arrayA[3, 2] * xk3)) / arrayA[3, 3];
                Console.WriteLine("{0}  {1}  {2}  {3}  {4}", i + 1, xk1, xk2, xk3, xk4);
            }
        }
        public static double[,] calculateA(double[,] arrayD, double[,] arrayC, int variant)
        {
            double[,] kc = new double[4, 4];
            double[,] arrayA = new double[4, 4];
                
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    kc[i, j] = arrayC[i, j] * variant;
                    arrayA[i, j] = kc[i, j] + arrayD[i, j];
                }
            }
            return arrayA;
        }
    }
}
