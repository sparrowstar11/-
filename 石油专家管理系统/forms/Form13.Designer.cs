namespace 石油专家管理系统.forms
{
    partial class Form13
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(13, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(884, 233);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原始数据";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox14);
            this.groupBox2.Controls.Add(this.textBox13);
            this.groupBox2.Controls.Add(this.textBox12);
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.chart1);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(13, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(884, 507);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "计算结果";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Beige;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(0, 246);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(869, 255);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(213, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 27);
            this.textBox1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(143, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "井号";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(702, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(155, 27);
            this.textBox2.TabIndex = 19;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(213, 183);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(155, 27);
            this.textBox3.TabIndex = 20;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(213, 135);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(155, 27);
            this.textBox4.TabIndex = 21;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(213, 85);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(155, 27);
            this.textBox5.TabIndex = 22;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(702, 94);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(155, 27);
            this.textBox6.TabIndex = 23;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(702, 144);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(155, 27);
            this.textBox7.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(95, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "井径(mm)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(66, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "钻井排量(L/s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(13, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 25);
            this.label3.TabIndex = 27;
            this.label3.Text = "初始井口压力(MPa)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(502, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "钻井液密度(g/cm3)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(600, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 25);
            this.label6.TabIndex = 29;
            this.label6.Text = "井深(m)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(538, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 25);
            this.label7.TabIndex = 30;
            this.label7.Text = "关井立压(MPa)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(44, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "地层压力(MPa)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(3, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 25);
            this.label9.TabIndex = 20;
            this.label9.Text = "最大施工泵压(MPa)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(532, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 25);
            this.label10.TabIndex = 21;
            this.label10.Text = "压井泥浆量(m3)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(56, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 25);
            this.label11.TabIndex = 22;
            this.label11.Text = "压井排量(L/s)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(85, 186);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 25);
            this.label12.TabIndex = 23;
            this.label12.Text = "溢流类型";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(502, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(178, 25);
            this.label13.TabIndex = 24;
            this.label13.Text = "压井液密度(g/cm3)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(507, 134);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(173, 25);
            this.label14.TabIndex = 25;
            this.label14.Text = "压井施工时间(min)";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(213, 26);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(155, 27);
            this.textBox8.TabIndex = 26;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(213, 79);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(155, 27);
            this.textBox9.TabIndex = 27;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(213, 132);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(155, 27);
            this.textBox10.TabIndex = 28;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(213, 184);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(155, 27);
            this.textBox11.TabIndex = 29;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(702, 26);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(155, 27);
            this.textBox12.TabIndex = 30;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(702, 79);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(155, 27);
            this.textBox13.TabIndex = 31;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(702, 132);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(155, 27);
            this.textBox14.TabIndex = 32;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.AliceBlue;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(47, 794);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 35);
            this.button2.TabIndex = 36;
            this.button2.Text = "施工报告";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.AliceBlue;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(746, 794);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 35);
            this.button1.TabIndex = 37;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(909, 842);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form13";
            this.Text = "压回法计算结果";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}