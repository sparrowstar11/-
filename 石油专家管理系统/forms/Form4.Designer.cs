namespace 石油专家管理系统
{
    partial class Form4
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sheet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.石油专家DataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.石油专家DataSet2 = new 石油专家管理系统.石油专家DataSet2();
            this.label2 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.sheet1_TableAdapter = new 石油专家管理系统.石油专家DataSet2TableAdapters.Sheet1_TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sheet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.石油专家DataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.石油专家DataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(116, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "井 号";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(224, 120);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 25);
            this.textBox1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.sheet1BindingSource;
            this.comboBox1.DisplayMember = "井号";
            this.comboBox1.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(224, 46);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 26);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.ValueMember = "井号";
            // 
            // sheet1BindingSource
            // 
            this.sheet1BindingSource.DataMember = "Sheet1$";
            this.sheet1BindingSource.DataSource = this.石油专家DataSet2BindingSource;
            // 
            // 石油专家DataSet2BindingSource
            // 
            this.石油专家DataSet2BindingSource.DataSource = this.石油专家DataSet2;
            this.石油专家DataSet2BindingSource.Position = 0;
            // 
            // 石油专家DataSet2
            // 
            this.石油专家DataSet2.DataSetName = "石油专家DataSet2";
            this.石油专家DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(99, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "项目名称";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.AliceBlue;
            this.button10.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button10.Location = new System.Drawing.Point(157, 180);
            this.button10.Margin = new System.Windows.Forms.Padding(4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(111, 41);
            this.button10.TabIndex = 19;
            this.button10.Text = "新建";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.AliceBlue;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(337, 180);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 41);
            this.button2.TabIndex = 21;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // sheet1_TableAdapter
            // 
            this.sheet1_TableAdapter.ClearBeforeFill = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(572, 279);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建工程";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sheet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.石油专家DataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.石油专家DataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource 石油专家DataSet2BindingSource;
        private 石油专家DataSet2 石油专家DataSet2;
        private System.Windows.Forms.BindingSource sheet1BindingSource;
        private 石油专家DataSet2TableAdapters.Sheet1_TableAdapter sheet1_TableAdapter;
    }
}