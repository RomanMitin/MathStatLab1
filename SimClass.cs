using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathStatLab1
{
    public struct SimClass
    {
        public double time;
        public double lambda;
        public UInt32 n;

        public SortedDictionary<int, int> simulate()
        {
            Random random = new Random();
            SortedDictionary<int, int> result = new SortedDictionary<int, int>();

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

    }
}
