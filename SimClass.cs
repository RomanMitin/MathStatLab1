using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MathStatLab1
{
    public class SimClass
    {
        public double time;
        public double lambda;
        public UInt32 n;
        SortedDictionary<int, int> resultSelection;

        private double X;


        private const int fact_size = 170;
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
            resultSelection = new SortedDictionary<int, int>();

            for (int i = 0;i < n; i++)
            {
                int RandomVarValue = GetRandomVarValue(random.NextDouble(), lambda * time);
                int tmp_val;

                if (resultSelection.TryGetValue(RandomVarValue, out tmp_val))
                {
                    resultSelection[RandomVarValue]++;
                }
                else
                {
                    resultSelection.Add(RandomVarValue, 1);
                }

            }

            return resultSelection;
        }

        public double GetX()
        {
            Int64 sum = 0;

            foreach (var item in resultSelection)
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
            foreach (var item in resultSelection)
            {
                tmp += item.Value * (item.Key - X) * (item.Key - X);
            }

            tmp /= n;

            return tmp;
        }

        internal int GetR()
        {
            return resultSelection.Last().Key - resultSelection.First().Key;
        }

        internal double GetMe()
        {
            int size = resultSelection.Count;
            if(size % 2 == 1)
            {
                return resultSelection.ElementAt(size / 2).Key;
            }
            else
            {
                return (resultSelection.ElementAt(size / 2).Key + resultSelection.ElementAt(size / 2 - 1).Key) / 2.0;
            }
        }

        internal double getProbability(int k)
        {
            if(k >= fact_size)
            {
                return 0.0;
            }

            double trueLambda = lambda * time;

            

            return (Math.Pow(trueLambda, k) / factorials[k]) * Math.Exp(-trueLambda);
        }

        internal Series getTrueDistSeries()
        {
            const double EPS = 1e-3;

            Series result = new Series("Teoretical distribution");

            double trueLamda = lambda * time;

            double cur_val = 0.0;
            int x = -1;

            double coef = Math.Exp(-trueLamda);

            result.Points.AddXY(x, cur_val);

            while (cur_val < 1.0 - EPS && x < fact_size - 1)
            {
                x++;
                double expResult = Math.Pow(trueLamda, x);
                if(double.IsInfinity(expResult))
                {
                    break;
                }

                cur_val += coef * expResult / factorials[x];

                result.Points.AddXY(x, cur_val);
            }

            return result;
        }

        internal Series getStatDistSeries()
        {
            Series result = new Series("Experimental distribution");

            result.Points.AddXY(-1, 0);

            double cur_val = 0.0;

            foreach (var item in resultSelection)
            {
                cur_val += Convert.ToDouble(item.Value) / n;
                if(cur_val >= 1.0)
                {
                    cur_val = 1.0 - 1e-9;
                }
                result.Points.AddXY(item.Key, cur_val);
            }

            return result;
        }
    }
}
