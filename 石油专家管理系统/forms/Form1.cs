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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            treeView1.ExpandAll();


        }

        private void 系统_Click(object sender, EventArgs e)
        {

        }

        private void 系统_MouseEnter(object sender, EventArgs e)
        {

        }

        private void 系统_MouseLeave(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox3.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseEnter_1(object sender, EventArgs e)
        {
            this.pictureBox1.Cursor = Cursors.Hand;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form3 s = new Form3(this);
            s.TopLevel = false;
            s.Dock = DockStyle.Fill;
            s.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(s);
            s.Show();

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.Cursor = Cursors.Hand;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox4.Cursor = Cursors.Hand;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox5.Cursor = Cursors.Hand;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox6.Cursor = Cursors.Hand;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }



        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox9.Cursor = Cursors.Hand;
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox10.Cursor = Cursors.Hand;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (treeView1.SelectedNode.Name == "工程师法")
                {

                }
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form4 Form = new Form4(this);
            Form.Show();
        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "查看")
            {

                panel6.Controls.Clear();
                Form12 s = new Form12(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel6.Controls.Add(s);
                s.Show();
            }

            if (e.Node.Text == "新建")
            {

                Form4 Form = new Form4(this);
                Form.Show();
                Form.TopMost = true;
            }
            if (e.Node.Text == "基本信息")
            {
                panel6.Controls.Clear();
                Form2 s = new Form2(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel6.Controls.Add(s);
                s.Show();
            }
            if (e.Node.Text == "钻具组合")
            {
                panel6.Controls.Clear();
                Form5 s = new Form5(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel6.Controls.Add(s);
                s.Show();
            }
            if (e.Node.Text == "井轨数据")
            {
                panel6.Controls.Clear();
                Form6 s = new Form6(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel6.Controls.Add(s);
                s.Show();
            }

            if (e.Node.Text == "井轨数据")
            {
                panel6.Controls.Clear();
                Form6 s = new Form6(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel6.Controls.Add(s);
                s.Show();
            }

            if (e.Node.Text == "井身结构参数")
            {
                panel6.Controls.Clear();
                Form9 s = new Form9(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel6.Controls.Add(s);
                s.Show();
            }
            if (e.Node.Text == "溢流情况描述")
            {
                panel6.Controls.Clear();
                Form10 s = new Form10(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel6.Controls.Add(s);
                s.Show();
            }
            if (e.Node.Text == "计算")
            {
                Form8 Form = new Form8();
                Form.Show();
                Form.TopMost = true;
            }

        }



        private void treeView3_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form4 Form = new Form4();

            Form.ShowDialog();

            this.Dispose();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel6.Controls.Clear();
            Form12 s = new Form12(this);
            s.TopLevel = false;
            s.Dock = DockStyle.Fill;
            s.FormBorderStyle = FormBorderStyle.None;
            panel6.Controls.Add(s);
            s.Show();
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            if (label3.Text != "")
            {
                panel6.Controls.Clear();
                Form2 s = new Form2(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel6.Controls.Add(s);
                s.Show();

            }
            else
                MessageBox.Show("请选择工程号或者新建工程");
          
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (label3.Text != "")
            {
               panel6.Controls.Clear();
                Form5 s = new Form5(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel6.Controls.Add(s);
                s.Show();
            }
            else
                MessageBox.Show("请选择工程号或者新建工程");

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (label3.Text != "")
            {
                panel6.Controls.Clear();
                Form6 s = new Form6(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel6.Controls.Add(s);
                s.Show();
            }
            else
                MessageBox.Show("请选择工程号或者新建工程");

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (label3.Text != "")
            {
                panel6.Controls.Clear();
                Form9 s = new Form9(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel6.Controls.Add(s);
                s.Show();

            }
            else
                MessageBox.Show("请选择工程号或者新建工程");
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (label3.Text != "")
            {
                panel6.Controls.Clear();
                Form10 s = new Form10(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel6.Controls.Add(s);
                s.Show();
            }
            else
                MessageBox.Show("请选择工程号或者新建工程");

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if(label3.Text!="")
            {
                string s = label3.Text;
                Form8 Form = new Form8(s);
                Form.Show();

            }
            else
            MessageBox.Show("请选择工程号或者新建工程");
        }

        private void panel6_Resize(object sender, EventArgs e)
        {
        Form2 frm = new Form2();
            if (frm != null)
            {
                frm.Size = this.panel6.Size;
            }


        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}




          
      

      
     
       

