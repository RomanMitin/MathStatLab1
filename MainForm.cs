using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MathStatLab1
{
    public partial class MainForm : Form
    {
        public SimClass simClass;

        public MainForm()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

            simClass = new SimClass();

            simClass.time = double.Parse(TimeTextBox.Text);
            simClass.lambda = double.Parse(LambdaTextBox.Text);
            simClass.n = UInt32.Parse(ntextBox.Text);

        }

        

        private void TimeTextBox_TextChanged(object sender, EventArgs e)
        {
            if(!double.TryParse(TimeTextBox.Text, out simClass.time))
            {
                MessageBox.Show("Wrong time, try again");
                TimeTextBox.Text = simClass.time.ToString();
            }
        }

        private void LambdaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(LambdaTextBox.Text, out simClass.lambda))
            {
                MessageBox.Show("Wrong lamda, try again");
                LambdaTextBox.Text = simClass.lambda.ToString();
            }

        }

        private void ntextBox_TextChanged(object sender, EventArgs e)
        {
            if (!UInt32.TryParse(ntextBox.Text, out simClass.n))
            {
                MessageBox.Show("Wrong n, try again");
                ntextBox.Text = simClass.n.ToString();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ResultTable.Rows.Clear();

            var result = simClass.simulate();

            double MaxDiffProb = 0.0;
            foreach (var item in result)
            {
                double prob = simClass.getProbability(item.Key);
                double Frequency = (double)item.Value / simClass.n;
                ResultTable.Rows.Add(item.Key, item.Value, Frequency, prob);
                MaxDiffProb = Math.Max(Math.Abs(Frequency - prob), MaxDiffProb);
            }
            MaxDiffProbTextBox.Text = MaxDiffProb.ToString();

            double tmp;
            double trueLambda = simClass.lambda * simClass.time;

            NumericalParam[0, 0].Value = trueLambda.ToString(); 
            tmp = simClass.GetX();
            NumericalParam[1, 0].Value = tmp.ToString();
            NumericalParam[2, 0].Value = Math.Abs(tmp - trueLambda);
            NumericalParam[3, 0].Value = trueLambda.ToString();
            tmp = simClass.GetS2();
            NumericalParam[4, 0].Value = tmp;
            NumericalParam[5, 0].Value = Math.Abs(tmp - trueLambda);
            NumericalParam[6, 0].Value = simClass.GetMe();
            NumericalParam[7, 0].Value = simClass.GetR();

            DistrFunctionsChart.Series.Clear();

            Series trueDistrFunc = simClass.getTrueDistSeries();
            Series StatDistrFunc = simClass.getStatDistSeries();
            trueDistrFunc.BorderWidth = 2;
            StatDistrFunc.BorderWidth = 2;
            trueDistrFunc.ChartType = SeriesChartType.StepLine;
            StatDistrFunc.ChartType = SeriesChartType.StepLine;


            DistrFunctionsChart.Series.Add(trueDistrFunc);
            DistrFunctionsChart.Series.Add(StatDistrFunc);
        }
    }
}
