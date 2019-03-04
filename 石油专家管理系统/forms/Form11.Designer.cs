namespace 石油专家管理系统
{
    partial class Form11
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Beige;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 45);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "random";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series1.YValuesPerPoint = 3;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(622, 315);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            title1.Name = "时间";
            this.chart1.Titles.Add(title1);
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Beige;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(12, 396);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "random";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series2.YValuesPerPoint = 3;
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(622, 315);
            this.chart2.TabIndex = 4;
            this.chart2.Text = "chart2";
            this.chart2.Click += new System.EventHandler(this.chart2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(907, 101);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 28);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(193, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "套管压力VS立管压力";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(221, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "泥浆池增量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(939, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "计算结果";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(732, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "地层压力（MPa）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(736, 427);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "最大套压（MPa）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(698, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "终了循环压力（MPa）";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(695, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "初始循环压力（MPa）";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(766, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "压井排量(m3)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(681, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(223, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "压井泥浆密度（kg/m3）";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(729, 492);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 25);
            this.label10.TabIndex = 23;
            this.label10.Text = "溢流到井口时间(s)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(709, 558);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(186, 25);
            this.label11.TabIndex = 24;
            this.label11.Text = "泥浆池最大增量(m3)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(748, 626);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 25);
            this.label12.TabIndex = 25;
            this.label12.Text = "压井施工时间(s)";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(907, 296);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(155, 28);
            this.textBox2.TabIndex = 26;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(907, 232);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(155, 28);
            this.textBox3.TabIndex = 27;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(907, 166);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(155, 28);
            this.textBox4.TabIndex = 28;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(907, 359);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(155, 28);
            this.textBox5.TabIndex = 29;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(907, 424);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(155, 28);
            this.textBox6.TabIndex = 30;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(906, 623);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(155, 28);
            this.textBox7.TabIndex = 31;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(907, 555);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(155, 28);
            this.textBox8.TabIndex = 32;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(907, 489);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(155, 28);
            this.textBox9.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.AliceBlue;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1100, 677);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 35);
            this.button1.TabIndex = 34;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.AliceBlue;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(906, 677);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 35);
            this.button2.TabIndex = 35;
            this.button2.Text = "施工报告";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(1213, 723);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form11";
            this.Text = "工程师法计算结果";
            this.Load += new System.EventHandler(this.Form11_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}