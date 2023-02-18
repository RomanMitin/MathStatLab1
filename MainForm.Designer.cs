namespace MathStatLab1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TimeTextBox = new System.Windows.Forms.TextBox();
            this.LambdaTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ntextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.ResultTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ResultTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time:";
            // 
            // TimeTextBox
            // 
            this.TimeTextBox.Location = new System.Drawing.Point(17, 55);
            this.TimeTextBox.Name = "TimeTextBox";
            this.TimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.TimeTextBox.TabIndex = 2;
            this.TimeTextBox.Text = "10.0";
            this.TimeTextBox.Validated += new System.EventHandler(this.TimeTextBox_TextChanged);
            // 
            // LambdaTextBox
            // 
            this.LambdaTextBox.Location = new System.Drawing.Point(17, 118);
            this.LambdaTextBox.Name = "LambdaTextBox";
            this.LambdaTextBox.Size = new System.Drawing.Size(100, 20);
            this.LambdaTextBox.TabIndex = 4;
            this.LambdaTextBox.Text = "1.0";
            this.LambdaTextBox.Validated += new System.EventHandler(this.LambdaTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lambda:";
            // 
            // ntextBox
            // 
            this.ntextBox.Location = new System.Drawing.Point(17, 184);
            this.ntextBox.Name = "ntextBox";
            this.ntextBox.Size = new System.Drawing.Size(100, 20);
            this.ntextBox.TabIndex = 6;
            this.ntextBox.Text = "100";
            this.ntextBox.TextChanged += new System.EventHandler(this.ntextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "n:";
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(17, 249);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(158, 31);
            this.StartButton.TabIndex = 7;
            this.StartButton.Text = "Start Simulation";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ResultTable
            // 
            this.ResultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.ResultTable.Location = new System.Drawing.Point(209, 27);
            this.ResultTable.Name = "ResultTable";
            this.ResultTable.Size = new System.Drawing.Size(344, 506);
            this.ResultTable.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Y";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ni";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ni/N";
            this.Column3.Name = "Column3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 545);
            this.Controls.Add(this.ResultTable);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ntextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LambdaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TimeTextBox);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MathStatLab1";
            ((System.ComponentModel.ISupportInitialize)(this.ResultTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TimeTextBox;
        private System.Windows.Forms.TextBox LambdaTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ntextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.DataGridView ResultTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

