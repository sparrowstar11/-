﻿namespace 石油专家管理系统
{
    partial class Form12
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.工程编号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.井号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.钻井液度DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.钻井排量DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.泵压DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.转速DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.转DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.转DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sheet2BindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.石油专家DataSet1 = new 石油专家管理系统.石油专家DataSet1();
            this.sheet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.石油专家DataSet = new 石油专家管理系统.石油专家DataSet();
            this.sheet2_TableAdapter = new 石油专家管理系统.石油专家DataSetTableAdapters.Sheet2_TableAdapter();
            this.sheet2BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sheet2_TableAdapter1 = new 石油专家管理系统.石油专家DataSet1TableAdapters.Sheet2_TableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheet2BindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.石油专家DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.石油专家DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheet2BindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(-1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(1097, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目管理";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.AliceBlue;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(121, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 36);
            this.button1.TabIndex = 22;
            this.button1.Text = "编辑";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.AliceBlue;
            this.button10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button10.Location = new System.Drawing.Point(8, 21);
            this.button10.Margin = new System.Windows.Forms.Padding(4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(88, 36);
            this.button10.TabIndex = 21;
            this.button10.Text = "删除";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.工程编号DataGridViewTextBoxColumn,
            this.井号DataGridViewTextBoxColumn,
            this.钻井液度DataGridViewTextBoxColumn,
            this.钻井排量DataGridViewTextBoxColumn,
            this.泵压DataGridViewTextBoxColumn,
            this.转速DataGridViewTextBoxColumn,
            this.转DataGridViewTextBoxColumn,
            this.转DataGridViewTextBoxColumn1});
            this.dataGridView1.DataSource = this.sheet2BindingSource2;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 83);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1097, 278);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // 工程编号DataGridViewTextBoxColumn
            // 
            this.工程编号DataGridViewTextBoxColumn.DataPropertyName = "工程编号";
            this.工程编号DataGridViewTextBoxColumn.HeaderText = "工程编号";
            this.工程编号DataGridViewTextBoxColumn.Name = "工程编号DataGridViewTextBoxColumn";
            this.工程编号DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.工程编号DataGridViewTextBoxColumn.Width = 96;
            // 
            // 井号DataGridViewTextBoxColumn
            // 
            this.井号DataGridViewTextBoxColumn.DataPropertyName = "井号";
            this.井号DataGridViewTextBoxColumn.HeaderText = "井号";
            this.井号DataGridViewTextBoxColumn.Name = "井号DataGridViewTextBoxColumn";
            this.井号DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.井号DataGridViewTextBoxColumn.Width = 66;
            // 
            // 钻井液度DataGridViewTextBoxColumn
            // 
            this.钻井液度DataGridViewTextBoxColumn.DataPropertyName = "钻井液度";
            this.钻井液度DataGridViewTextBoxColumn.HeaderText = "钻井液度";
            this.钻井液度DataGridViewTextBoxColumn.Name = "钻井液度DataGridViewTextBoxColumn";
            this.钻井液度DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.钻井液度DataGridViewTextBoxColumn.Width = 96;
            // 
            // 钻井排量DataGridViewTextBoxColumn
            // 
            this.钻井排量DataGridViewTextBoxColumn.DataPropertyName = "钻井排量";
            this.钻井排量DataGridViewTextBoxColumn.HeaderText = "钻井排量";
            this.钻井排量DataGridViewTextBoxColumn.Name = "钻井排量DataGridViewTextBoxColumn";
            this.钻井排量DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.钻井排量DataGridViewTextBoxColumn.Width = 96;
            // 
            // 泵压DataGridViewTextBoxColumn
            // 
            this.泵压DataGridViewTextBoxColumn.DataPropertyName = "泵压";
            this.泵压DataGridViewTextBoxColumn.HeaderText = "泵压";
            this.泵压DataGridViewTextBoxColumn.Name = "泵压DataGridViewTextBoxColumn";
            this.泵压DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.泵压DataGridViewTextBoxColumn.Width = 66;
            // 
            // 转速DataGridViewTextBoxColumn
            // 
            this.转速DataGridViewTextBoxColumn.DataPropertyName = "转速";
            this.转速DataGridViewTextBoxColumn.HeaderText = "转速";
            this.转速DataGridViewTextBoxColumn.Name = "转速DataGridViewTextBoxColumn";
            this.转速DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.转速DataGridViewTextBoxColumn.Width = 66;
            // 
            // 转DataGridViewTextBoxColumn
            // 
            this.转DataGridViewTextBoxColumn.DataPropertyName = "300转";
            this.转DataGridViewTextBoxColumn.HeaderText = "300转";
            this.转DataGridViewTextBoxColumn.Name = "转DataGridViewTextBoxColumn";
            this.转DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.转DataGridViewTextBoxColumn.Width = 75;
            // 
            // 转DataGridViewTextBoxColumn1
            // 
            this.转DataGridViewTextBoxColumn1.DataPropertyName = "600转";
            this.转DataGridViewTextBoxColumn1.HeaderText = "600转";
            this.转DataGridViewTextBoxColumn1.Name = "转DataGridViewTextBoxColumn1";
            this.转DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.转DataGridViewTextBoxColumn1.Width = 75;
            // 
            // sheet2BindingSource2
            // 
            this.sheet2BindingSource2.DataMember = "Sheet2$";
            this.sheet2BindingSource2.DataSource = this.石油专家DataSet1;
            // 
            // 石油专家DataSet1
            // 
            this.石油专家DataSet1.DataSetName = "石油专家DataSet1";
            this.石油专家DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sheet2BindingSource
            // 
            this.sheet2BindingSource.DataMember = "Sheet2$";
            this.sheet2BindingSource.DataSource = this.石油专家DataSet;
            // 
            // 石油专家DataSet
            // 
            this.石油专家DataSet.DataSetName = "石油专家DataSet";
            this.石油专家DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sheet2_TableAdapter
            // 
            this.sheet2_TableAdapter.ClearBeforeFill = true;
            // 
            // sheet2BindingSource1
            // 
            this.sheet2BindingSource1.DataMember = "Sheet2$";
            this.sheet2BindingSource1.DataSource = this.石油专家DataSet;
            // 
            // sheet2_TableAdapter1
            // 
            this.sheet2_TableAdapter1.ClearBeforeFill = true;
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 357);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form12";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目查看";
            this.Load += new System.EventHandler(this.Form12_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheet2BindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.石油专家DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.石油专家DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheet2BindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private 石油专家DataSet 石油专家DataSet;
        private System.Windows.Forms.BindingSource sheet2BindingSource;
        private 石油专家DataSetTableAdapters.Sheet2_TableAdapter sheet2_TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工程编号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 井号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 钻井液度DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 钻井排量DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 泵压DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 转速DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 转DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 转DataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource sheet2BindingSource1;
        private 石油专家DataSet1 石油专家DataSet1;
        private System.Windows.Forms.BindingSource sheet2BindingSource2;
        private 石油专家DataSet1TableAdapters.Sheet2_TableAdapter sheet2_TableAdapter1;
    }
}