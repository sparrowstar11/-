using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Newp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            if(sender!=null && sender is GroupBox)
            {
                GroupBox gbx = sender as GroupBox;
                e.Graphics.Clear(gbx.BackColor);
                Color color = Color.FromArgb(215, 225, 230);
                Pen p = new Pen(color, 1);
                int w = gbx.Width;
                int h = gbx.Height;
                Brush b = null;
                if (gbx.Parent != null)
                    b = new SolidBrush(gbx.Parent.BackColor);
                else
                    b = new SolidBrush(this.BackColor);
                //绘制直线
                e.Graphics.DrawLine(p, 3, h - 1, w - 4, h - 1);                     //bottom
                e.Graphics.DrawLine(p, 0, h - 4, 0, 12);                            //left
                e.Graphics.DrawLine(p, w - 1, h - 4, w - 1, 12);                    //right
                e.Graphics.FillRectangle(b, 0, 0, w, 8);
                e.Graphics.DrawLine(p, 3, 8, 10, 8);                                //lefg top
                e.Graphics.DrawLine(p,e.Graphics.MeasureString(gbx.Text,gbx.Font).Width + 8, 8, w - 4, 8);                                  //right top

                //绘制文字
                e.Graphics.DrawString(gbx.Text, gbx.Font, Brushes.Blue, 10, 0);     //title
                                                                                    //绘制弧线
                e.Graphics.DrawArc(p, new Rectangle(0, 8, 10, 10), 180, 90);        //left top
                e.Graphics.DrawArc(p, new Rectangle(w - 11, 8, 10, 10), 270, 90);   //right top
                e.Graphics.DrawArc(p, new Rectangle(0, h - 11, 10, 10), 90, 90);    //left bottom
                e.Graphics.DrawArc(p, new Rectangle(w - 11, h - 11, 10, 10), 0, 90);//right bottom
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            if (sender != null && sender is GroupBox)
            {
                GroupBox gbx = sender as GroupBox;
                e.Graphics.Clear(gbx.BackColor);
                Color color = Color.FromArgb(215, 225, 230);
                Pen p = new Pen(color, 1);
                int w = gbx.Width;
                int h = gbx.Height;
                Brush b = null;
                if (gbx.Parent != null)
                    b = new SolidBrush(gbx.Parent.BackColor);
                else
                    b = new SolidBrush(this.BackColor);
                //绘制直线
                e.Graphics.DrawLine(p, 3, h - 1, w - 4, h - 1);                     //bottom
                e.Graphics.DrawLine(p, 0, h - 4, 0, 12);                            //left
                e.Graphics.DrawLine(p, w - 1, h - 4, w - 1, 12);                    //right
                e.Graphics.FillRectangle(b, 0, 0, w, 8);
                e.Graphics.DrawLine(p, 3, 8, 10, 8);                                //lefg top
                e.Graphics.DrawLine(p, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 8, w - 4, 8);                                  //right top

                //绘制文字
                e.Graphics.DrawString(gbx.Text, gbx.Font, Brushes.Blue, 10, 0);     //title
                                                                                    //绘制弧线
                e.Graphics.DrawArc(p, new Rectangle(0, 8, 10, 10), 180, 90);        //left top
                e.Graphics.DrawArc(p, new Rectangle(w - 11, 8, 10, 10), 270, 90);   //right top
                e.Graphics.DrawArc(p, new Rectangle(0, h - 11, 10, 10), 90, 90);    //left bottom
                e.Graphics.DrawArc(p, new Rectangle(w - 11, h - 11, 10, 10), 0, 90);//right bottom
            }
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            if (sender != null && sender is GroupBox)
            {
                GroupBox gbx = sender as GroupBox;
                e.Graphics.Clear(gbx.BackColor);
                Color color = Color.FromArgb(215, 225, 230);
                Pen p = new Pen(color, 1);
                int w = gbx.Width;
                int h = gbx.Height;
                Brush b = null;
                if (gbx.Parent != null)
                    b = new SolidBrush(gbx.Parent.BackColor);
                else
                    b = new SolidBrush(this.BackColor);
                //绘制直线
                e.Graphics.DrawLine(p, 3, h - 1, w - 4, h - 1);                     //bottom
                e.Graphics.DrawLine(p, 0, h - 4, 0, 12);                            //left
                e.Graphics.DrawLine(p, w - 1, h - 4, w - 1, 12);                    //right
                e.Graphics.FillRectangle(b, 0, 0, w, 8);
                e.Graphics.DrawLine(p, 3, 8, 10, 8);                                //lefg top
                e.Graphics.DrawLine(p, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 8, w - 4, 8);                                  //right top

                //绘制文字
                e.Graphics.DrawString(gbx.Text, gbx.Font, Brushes.Blue, 10, 0);     //title
                                                                                    //绘制弧线
                e.Graphics.DrawArc(p, new Rectangle(0, 8, 10, 10), 180, 90);        //left top
                e.Graphics.DrawArc(p, new Rectangle(w - 11, 8, 10, 10), 270, 90);   //right top
                e.Graphics.DrawArc(p, new Rectangle(0, h - 11, 10, 10), 90, 90);    //left bottom
                e.Graphics.DrawArc(p, new Rectangle(w - 11, h - 11, 10, 10), 0, 90);//right bottom
            }
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            if (sender != null && sender is GroupBox)
            {
                GroupBox gbx = sender as GroupBox;
                e.Graphics.Clear(gbx.BackColor);
                Color color = Color.FromArgb(215, 225, 230);
                Pen p = new Pen(color, 1);
                int w = gbx.Width;
                int h = gbx.Height;
                Brush b = null;
                if (gbx.Parent != null)
                    b = new SolidBrush(gbx.Parent.BackColor);
                else
                    b = new SolidBrush(this.BackColor);
                //绘制直线
                e.Graphics.DrawLine(p, 3, h - 1, w - 4, h - 1);                     //bottom
                e.Graphics.DrawLine(p, 0, h - 4, 0, 12);                            //left
                e.Graphics.DrawLine(p, w - 1, h - 4, w - 1, 12);                    //right
                e.Graphics.FillRectangle(b, 0, 0, w, 8);
                e.Graphics.DrawLine(p, 3, 8, 10, 8);                                //lefg top
                e.Graphics.DrawLine(p, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 8, w - 4, 8);                                  //right top

                //绘制文字
                e.Graphics.DrawString(gbx.Text, gbx.Font, Brushes.Blue, 10, 0);     //title
                                                                                    //绘制弧线
                e.Graphics.DrawArc(p, new Rectangle(0, 8, 10, 10), 180, 90);        //left top
                e.Graphics.DrawArc(p, new Rectangle(w - 11, 8, 10, 10), 270, 90);   //right top
                e.Graphics.DrawArc(p, new Rectangle(0, h - 11, 10, 10), 90, 90);    //left bottom
                e.Graphics.DrawArc(p, new Rectangle(w - 11, h - 11, 10, 10), 0, 90);//right bottom
            }
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Paint(object sender, PaintEventArgs e)
        {
            if (sender != null && sender is GroupBox)
            {
                GroupBox gbx = sender as GroupBox;
                e.Graphics.Clear(gbx.BackColor);
                Color color = Color.FromArgb(215, 225, 230);
                Pen p = new Pen(color, 1);
                int w = gbx.Width;
                int h = gbx.Height;
                Brush b = null;
                if (gbx.Parent != null)
                    b = new SolidBrush(gbx.Parent.BackColor);
                else
                    b = new SolidBrush(this.BackColor);
                //绘制直线
                e.Graphics.DrawLine(p, 3, h - 1, w - 4, h - 1);                     //bottom
                e.Graphics.DrawLine(p, 0, h - 4, 0, 12);                            //left
                e.Graphics.DrawLine(p, w - 1, h - 4, w - 1, 12);                    //right
                e.Graphics.FillRectangle(b, 0, 0, w, 8);
                e.Graphics.DrawLine(p, 3, 8, 10, 8);                                //lefg top
                e.Graphics.DrawLine(p, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 8, w - 4, 8);                                  //right top

                //绘制文字
                e.Graphics.DrawString(gbx.Text, gbx.Font, Brushes.Blue, 10, 0);     //title
                                                                                    //绘制弧线
                e.Graphics.DrawArc(p, new Rectangle(0, 8, 10, 10), 180, 90);        //left top
                e.Graphics.DrawArc(p, new Rectangle(w - 11, 8, 10, 10), 270, 90);   //right top
                e.Graphics.DrawArc(p, new Rectangle(0, h - 11, 10, 10), 90, 90);    //left bottom
                e.Graphics.DrawArc(p, new Rectangle(w - 11, h - 11, 10, 10), 0, 90);//right bottom
            }
        }

        private void groupBox6_Paint(object sender, PaintEventArgs e)
        {
            if (sender != null && sender is GroupBox)
            {
                GroupBox gbx = sender as GroupBox;
                e.Graphics.Clear(gbx.BackColor);
                Color color = Color.FromArgb(215, 225, 230);
                Pen p = new Pen(color, 1);
                int w = gbx.Width;
                int h = gbx.Height;
                Brush b = null;
                if (gbx.Parent != null)
                    b = new SolidBrush(gbx.Parent.BackColor);
                else
                    b = new SolidBrush(this.BackColor);
                //绘制直线
                e.Graphics.DrawLine(p, 3, h - 1, w - 4, h - 1);                     //bottom
                e.Graphics.DrawLine(p, 0, h - 4, 0, 12);                            //left
                e.Graphics.DrawLine(p, w - 1, h - 4, w - 1, 12);                    //right
                e.Graphics.FillRectangle(b, 0, 0, w, 8);
                e.Graphics.DrawLine(p, 3, 8, 10, 8);                                //lefg top
                e.Graphics.DrawLine(p, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 8, w - 4, 8);                                  //right top

                //绘制文字
                e.Graphics.DrawString(gbx.Text, gbx.Font, Brushes.Blue, 10, 0);     //title
                                                                                    //绘制弧线
                e.Graphics.DrawArc(p, new Rectangle(0, 8, 10, 10), 180, 90);        //left top
                e.Graphics.DrawArc(p, new Rectangle(w - 11, 8, 10, 10), 270, 90);   //right top
                e.Graphics.DrawArc(p, new Rectangle(0, h - 11, 10, 10), 90, 90);    //left bottom
                e.Graphics.DrawArc(p, new Rectangle(w - 11, h - 11, 10, 10), 0, 90);//right bottom
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            this.Dispose();
        }
    }
}
