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
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

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
            Form2 form = new Form2();
            this.Close();
            form.Show();
            this.Dispose();
        }
    }
}
