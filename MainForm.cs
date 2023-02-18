using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathStatLab1
{
    public partial class MainForm : Form
    {
        public SimClass simClass;

        public MainForm()
        {
            InitializeComponent();

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

            foreach (var item in result)
            {
                ResultTable.Rows.Add(item.Key, item.Value, (double)item.Value / simClass.n);
            }
        }
    }
}
