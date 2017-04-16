using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Iterration
{
    public class GradientCalculator
    {
        private double xk1 = 0;
        private double xk2 = 0;
        private double xk3 = 0;
        private double xk4 = 0;
        private double zz = 0;
        private double zz1 = 0;
        private double zz2 = 0;
        private double beta = 0;
        private double azz = 0;
        private double t = 0;
        private double[] pz = new double[4];
        private double[] az = new double[4];
        private double[] pp = new double[4];
        private double[,] arrayA;
        private double[] arrayB;

        public GradientCalculator(double[,] arrayA, double[] arrayB)
        {
            this.arrayA = arrayA;
            this.arrayB = arrayB;
            PrimeApproximation();
            Console.WriteLine(CalculatePrimeDotProduct());
            Console.WriteLine(NewPrimeApproximationCalculator(pz));
            Console.WriteLine(IterationParameter());
            Console.WriteLine() ;
            Console.WriteLine(Netiktis());
            check();
        }

        private double[] PrimeApproximation()
        {
            for (int i = 0; i < arrayB.Length; i++) { pz[i] = -arrayB[i]; }
            return pz;
        }

        private double CalculatePrimeDotProduct()
        {
            for (int i = 0; i < pz.Length; i++) { zz = zz + Math.Pow(PrimeApproximation()[i], 2); }
            Console.WriteLine("zz {0}", zz);
            return zz;
        }

        private double[] NewPrimeApproximationCalculator(double[] pz)
        {
            for (int i = 0; i < pz.Length; i++)
            {
                az[i] = (arrayA[i, 0] * pz[0]) + (arrayA[i, 1] * pz[1]) + (arrayA[i, 2] * pz[2]) + (arrayA[i, 3] * pz[3]);
                azz = azz + (az[i] * PrimeApproximation()[i]);
                Console.WriteLine("az {0}", azz);
            }
            return az;
        }

        private double IterationParameter()
        {
            return zz / azz;
        }

        private double[] Netiktis()
        {
            for (int i = 0; i< pz.Length; i++)
            { 
                Console.WriteLine("pz[] old {0}", pz[i]);
                pz[i] = pz[i] - (zz/azz * az[i]);
                zz1 = Math.Pow(pz[i], 2);

                Console.WriteLine("iterparam = {0}\naz[] = {1}\npz[] new = {2}\nzz = {3}", zz/azz, az[i], pz[i], zz1);
            }
            return pz;
        }

        private void check()
        {
            if (zz1 < Math.Pow(0.0001, 2))
            {
                Console.WriteLine("zz1 = {0} pow = {1}", zz1, Math.Pow(0.0001, 2));
                Console.WriteLine("tru");
            }
            else
            {
                Console.WriteLine("false");
                Console.WriteLine("zz1 = {0} pow = {1}", zz1, Math.Pow(0.0001, 2));
                beta = zz1 / zz;
                Console.WriteLine(beta);
            }


            for (int i = 0; i < arrayB.Length; i++)
            {
                pp[i] = zz1 + (beta * PrimeApproximation()[i]);
                Console.WriteLine("zz1 = {0}, zz2 = {1}, pz[] = {2}, pp[] = {3}", zz1, beta, PrimeApproximation()[i], pp[i]);
            }

            for (int i = 0; i < pz.Length; i++)
            {
                az[i] = (arrayA[i, 0] * pp[0]) + (arrayA[i, 1] * pp[1]) + (arrayA[i, 2] * pp[2]) + (arrayA[i, 3] * pp[3]);
                Console.WriteLine(az[i]);
            }
            double zp = 0;
            double netekpp = 0;
            double azpp = 0;
            for (int i = 0; i < pz.Length; i++)
            {
                netekpp += Netiktis()[i] + pp[i];
                azpp += az[i] * pp[i];
                Console.WriteLine("------------netiktis = {0}", azpp);
            }
            Console.WriteLine("-+++++++++answer = {0}", netekpp / azpp);
        }


    }
}
