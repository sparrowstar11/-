﻿using System;
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
            Form4 Form = new Form4();
          
            Form.ShowDialog();
         
            this.Dispose();


        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                panel6.Controls.Clear();
                Form4 s = new Form4(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel6.Controls.Add(s);
                s.Show();
            }

        }

    

        private void treeView3_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

           if (e.Node.Level == 0)
            {
                panel2.Controls.Clear();
                Form3 s = new Form3(this);
                s.TopLevel = false;
                s.Dock = DockStyle.Fill;
                s.FormBorderStyle = FormBorderStyle.None;
                panel2.Controls.Add(s);
                s.Show();
            }
            if (e.Node.Index== 1)
            {
                Form4 Form = new Form4();
               
                Form.ShowDialog();
                this.panel2.Visible = false;

                this.Dispose();
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form4 Form = new Form4();

            Form.ShowDialog();

            this.Dispose();
        }
    }
}



          
      

      
     
       

