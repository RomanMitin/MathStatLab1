using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathStatLab1
{
    public class SimClass
    {
        public double time;
        public double lambda;
        public UInt32 n;
        SortedDictionary<int, int> result;

        private double X;


        private const int fact_size = 100;
        private double[] factorials = new double[fact_size];

        public SimClass()
        {
            InitFactorials();
        }

        private void InitFactorials()
        {
            double mul = 1.0;
            factorials[0] = 1.0;
            for (int i = 1; i < fact_size; i++)
            {
                mul *= i;
                factorials[i] = mul;
            }
        }

        public SortedDictionary<int, int> simulate()
        {
            Random random = new Random();
            result = new SortedDictionary<int, int>();

            for (int i = 0;i < n; i++)
            {
                int RandomVarValue = GetRandomVarValue(random.NextDouble(), lambda * time);
                int tmp_val;

                if (result.TryGetValue(RandomVarValue, out tmp_val))
                {
                    result[RandomVarValue]++;
                }
                else
                {
                    result.Add(RandomVarValue, 1);
                }

            }

            return result;
        }

        public double GetX()
        {
            Int64 sum = 0;

            foreach (var item in result)
            {
                sum += item.Key * item.Value;
            }

            X = Convert.ToDouble(sum) / n;

            return X;
        }

        private int GetRandomVarValue(double u, double lambda)
        {
            int result = 0;
            double p = Math.Exp(-lambda);
            double sum = p;

            while(sum < u)
            {
                p *= lambda / ++result;
                sum += p;
            }

            return result;
        }

        public double GetS2()
        {
            double tmp = 0;
            foreach (var item in result)
            {
                tmp += item.Value * (item.Key - X) * (item.Key - X);
            }

            tmp /= n;

            return tmp;
        }

        internal int GetR()
        {
            return result.Last().Key - result.First().Key;
        }

        internal double GetMe()
        {
            int size = result.Count;
            if(size % 2 == 1)
            {
                return result.ElementAt(size / 2).Key;
            }
            else
            {
                return (result.ElementAt(size / 2).Key + result.ElementAt(size / 2 - 1).Key) / 2.0;
            }
        }

        internal double getProbability(int k)
        {
            double trueLambda = lambda * time;

            return (Math.Pow(trueLambda, k) / factorials[k]) * Math.Exp(-trueLambda);
        }
    }
}
