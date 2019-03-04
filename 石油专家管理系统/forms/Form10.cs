using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 石油专家管理系统
{
    public partial class Form10 : Form
    {
        Form1 f1;
        public Form10(Form1 form1)
        {
            f1 = form1;
            InitializeComponent();
        }
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = "insert into [dbo].[sheet6$] (工程编号,溢流情况描述)values('"+f1.label3.Text+"','"+textBox3.Text+"') ";
            int t = SQLHelper.ExQuery(s);
            if (t > 0)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
    }
}
