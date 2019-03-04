using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newp;

namespace 石油专家管理系统
{
    public partial class Form4 : Form
    {
        Form1 f1;
        public Form4(Form1 form1)
        {
            f1 = form1;
            InitializeComponent();
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“石油专家DataSet2._Sheet1_”中。您可以根据需要移动或删除它。
            this.sheet1_TableAdapter.Fill(this.石油专家DataSet2._Sheet1_);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 Form = new Form4();
            Form.Hide();
            Form.Dispose();
            Form2 frm = new Form2();
            frm.ShowDialog();
            
        }
        private void button10_Click(object sender, EventArgs e)
        {
            string num = comboBox1.Text;
            string t = textBox1.Text;
            string sum = num + '-' + t;
            string sql = "select * from [dbo].[Sheet2$] where 工程编号='"+sum+"'";
            DataSet da= SQLHelper.Query(sql);
            if (da.Tables[0].Rows.Count>0)
            {
                MessageBox.Show("工程已经存在");
            }
            else
            {
                Form2 s = new Form2(num, sum);
                f1.panel6.Controls.Clear();
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                f1.panel6.Controls.Add(s);
                s.Show();
                f1.label3.Text = num + '-' + t;
                this.Close();
                this.Dispose();

            }
                

           
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
