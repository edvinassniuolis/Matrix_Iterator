using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Iterration
{
    public class Program
    {
        static void Main(string[] args)
        {
            int userChoice;
            double[,] arrayD = new double[,] {{1.342, 0.202, -0.599, 0.432},
                                              {0.202, 1.342, 0.202, -0.599},
                                              {-0.599, 0.202, 1.342, 0.202},
                                              {0.432, -0.599, 0.202, 1.342}};


            double[,] arrayC = new double[,] {{0.01, 0, 0, 0},
                                              {0, 0.01, 0, 0},
                                              {0, 0, 0.01, 0},
                                              {0, 0, 0, 0.01}};

            double[] arrayB = new double[] { 1.941, -0.230, -1.941, 0.230 };
            double[,] arrayA = calculateA(arrayD, arrayC, 20);

            calculateGradient(arrayA, arrayB);

            Console.WriteLine("3 task by Edvinas Sniuolis\nSelect one of the following\n" +
                              "1. Calculate linear equation using Seidel method\n" +
                              "2. Calculate linear equation using Conjugent gradient method\n" +
                              "3. Calculate linear equation using Inverse iteration method\n");

            string input = Console.ReadLine();
            Int32.TryParse(input, out userChoice);

            switch(userChoice)
            {
                case 1:
                    {
                        SeidelCalculator.CalculateSeidelMethod(SeidelCalculator.calculateA(arrayD, arrayC, 20), arrayB);
                        break;
                    }
                case 2:
                    {
                        GradientCalculator gr = new GradientCalculator(SeidelCalculator.calculateA(arrayD, arrayC, 20), arrayB);
                        break;
                    }
            }
            Console.ReadKey();
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


        public static void calculateGradient(double[,] arrayA, double[] arrayB)
        {
            double xk1 = 0;
            double xk2 = 0;
            double xk3 = 0;
            double xk4 = 0;
            double zz = 0;
            double iter = 0;
            double art = 0;
            double[] az = new double[4];
            double[] z = new double[4];

            for (int i = 0; i < arrayB.Length; i++)
            {
                z[i] = -arrayB[i];
                zz = zz + Math.Pow(z[i], 2);
                //Console.WriteLine(z[i]);
                Console.WriteLine("yuuuu {0}", zz);

            }
            for (int i = 0; i < arrayB.Length; i++)
            {
                az[i] = (arrayA[i, 0] * z[0]) + (arrayA[i, 1] * z[1]) + (arrayA[i, 2] * z[2]) + (arrayA[i, 3] * z[3]);
                iter = iter + (az[i] * z[i]);
                //Console.WriteLine("{0} * {1} + {2} * {3} + {4} * {5} + {6} * {7}", arrayA[i, 0], z[0], arrayA[i, 1], z[1], arrayA[i, 2], z[2], arrayA[i, 3], z[3]);
                Console.WriteLine(az[i]);
            }
            Console.WriteLine(iter);

            art = zz / iter;
            Console.WriteLine("art zz {0}, art iter{1}", art, iter);
            zz = 0;

            for (int i = 0; i < arrayB.Length; i++)
            {
                z[i] = z[i] - (az[i] * art);
                zz = zz + Math.Pow(z[i], 2);

                Console.WriteLine("yee {0}", z[i]);
            }
            Console.WriteLine("zz {0}", zz);

        }
    }
}
