using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using 石油专家管理系统.forms;

namespace 石油专家管理系统
{
    public partial class Form8 : Form
    {
        Form1 f1;
        string s;
        public Form8(Form1 form1)
        {
            f1 = form1;
            InitializeComponent();
        }

        public Form8()
        {
            InitializeComponent();
        }
        public Form8(string s)
        {
            this.s = s;
            InitializeComponent();
            textBox1.Text = s;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x6;
            double x7;
            double x16;
            char[] m = textBox1.Text.ToCharArray();
            string s = "select 井型 from [dbo].[Sheet2$] where 工程编号='" + textBox1.Text + "'";
            string s2 = "select 井深 from [dbo].[井2] where 工程编号='" + textBox1.Text + "'";
            string s3 = "select 套管鞋深度 from [dbo].[井2]  where 工程编号='" + textBox1.Text + "'";
            string s4 = "select 钻井液度 from [dbo].[Sheet2$] where 工程编号='" + textBox1.Text + "'";
            string s5 = "select 井眼扩大率 from [dbo].[井2]  where 工程编号='" + textBox1.Text + "'";
            
            string s8 = "select  套管尺寸 from   [dbo].[Sheet5$] where 开次=(select max(开次) from [dbo].[Sheet5$] where 工程编号='" + textBox1.Text + "')and 工程编号='" + textBox1.Text + "'";
            string s9 = "select 井眼尺寸 from [dbo].[井2] where 工程编号='" + textBox1.Text + "'";
            string s10 = "select 井口温度 from  [dbo].[Sheet2$] where 工程编号='" + textBox1.Text + "' ";
            string s11 = "select 钻井排量 from [dbo].[Sheet2$] where 工程编号='" + textBox1.Text + "'";
            string s12 = "select 地热增温率 from [dbo].[Sheet2$] where 工程编号='" + textBox1.Text + "'";
            string s13 = "select 井深 from [dbo].[Sheet2$] where 工程编号='" + textBox1.Text + "'";
            string s14 = "select 压耗 from [dbo].[Sheet2$] where 工程编号='" + textBox1.Text + "'";
            string s15 = "select 低泵速排量 from [dbo].[Sheet2$] where 工程编号='" + textBox1.Text + "'";
            
            string s17 = "select 公司名称 from  [dbo].[Sheet1$] where 井号='" + m[0] + "'";
            string s18 = "select 井队 from [dbo].[Sheet1$] where 井号='" + m[0] + "'";
            string s19 = "select 工况 from [dbo].[Sheet4$] where 工程编号='" + textBox1.Text + "'";
            DataSet read2 = SQLHelper.read(s2);
            DataSet read = SQLHelper.read(s);
            DataSet read3 = SQLHelper.read(s3);
            DataSet read4 = SQLHelper.read(s4);
            DataSet read5 = SQLHelper.read(s5);
           
            DataSet read8 = SQLHelper.read(s8);
            DataSet read9 = SQLHelper.read(s9);
            DataSet read10 = SQLHelper.read(s10);
            DataSet read11 = SQLHelper.read(s11);
            DataSet read12 = SQLHelper.read(s12);
            DataSet read13 = SQLHelper.read(s13);
            DataSet read14 = SQLHelper.read(s14);
            DataSet read15 = SQLHelper.read(s15);

            DataSet read17 = SQLHelper.read(s17);
            DataSet read18 = SQLHelper.read(s18);
            DataSet read19 = SQLHelper.read(s19);
            string x = read.Tables[0].Rows[0]["井型"].ToString().Trim();
            double x2 = Convert.ToDouble(read2.Tables[0].Rows[0]["井深"]);
            double x3 = Convert.ToDouble(read3.Tables[0].Rows[0]["套管鞋深度"]);
            double x4 = Convert.ToDouble(read4.Tables[0].Rows[0]["钻井液度"]);
            double x5 = Convert.ToDouble(read5.Tables[0].Rows[0]["井眼扩大率"]);

            double x8 = Convert.ToDouble(read8.Tables[0].Rows[0]["套管尺寸"]);
            double x9 = Convert.ToDouble(read9.Tables[0].Rows[0]["井眼尺寸"]);
            double x10 = Convert.ToDouble(read10.Tables[0].Rows[0]["井口温度"]);
            double x11 = Convert.ToDouble(read11.Tables[0].Rows[0]["钻井排量"]);
            double x12 = Convert.ToDouble(read12.Tables[0].Rows[0]["地热增温率"]);
            double x13 = Convert.ToDouble(read13.Tables[0].Rows[0]["井深"]);
            double x14 = Convert.ToDouble(read14.Tables[0].Rows[0]["压耗"]);
            double x15 = Convert.ToDouble(read15.Tables[0].Rows[0]["低泵速排量"]);

            string x17 = read17.Tables[0].Rows[0]["公司名称"].ToString().Trim();
            string x18 = read18.Tables[0].Rows[0]["井队"].ToString().Trim();
            string no = read19.Tables[0].Rows[0]["工况"].ToString().Trim();
            //////



            if(no!="空井")
            {
                    string s6 = "select 外径 from [dbo].[Sheet4$] where 工程编号='" + textBox1.Text + "'and 钻具名称='钻杆'";
                    string s7 = "select sum(长度) 总长 from [dbo].[Sheet4$] where 工程编号='" + textBox1.Text + "' ";
                    string s16 = "select 壁厚 from [dbo].[Sheet4$] where 工程编号='" + textBox1.Text + "'and 钻具名称='钻杆'";
                    DataSet read6 = SQLHelper.read(s6);
                    DataSet read7 = SQLHelper.read(s7);
                    DataSet read16 = SQLHelper.read(s16);
                     x6 = Convert.ToDouble(read6.Tables[0].Rows[0]["外径"]);
                     x7 = Convert.ToDouble(read7.Tables[0].Rows[0]["总长"]);
                     x16 = Convert.ToDouble(read16.Tables[0].Rows[0]["壁厚"]);
            }
            else
            {
                 x6 = 0;
                 x7 = 0;
                 x16 = 0;
            }
           
            if (no == "钻进")
            {
                if (x == "定向井")
                {

                }
                else
                {
                    double[,] tw = { };
                    double dens = 0;
                    double hg = 0;
                    string result = Fluidtype.drilling.JudeEarthTypeUnderQiXiaZuan(textBox1.Text, x, x2, x3, x4, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), x9, x5, x6, x8, x7, tw, 0, ref dens);
                    MessageBox.Show(dens.ToString());
                    if (radioButton2.Checked)
                    {
                        Form7 fro = new Form7(result, x, textBox1.Text, x2, x3, x10, x8, x9, x5, x4, x11, x12, x13, x14, x15, x6, x16, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), dens, x17, x18, tw, no, x7,hg);
                        this.Close();
                        fro.Show();
                        this.Dispose();
                    }
                }
            }
            else
            {
                if (x == "定向井")
                {

                }
                else
                {
                    double[,] tw = { };
                    double dens = 0;
                    double hg = 0;
                    string result = Fluidtype.kongjingqixiazuan.JudeEarthTypeUnderZuanJing2(textBox1.Text, x, x2, x3, x4, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), x9, x5, x6, x8, tw, 0, ref dens,ref hg);
                    MessageBox.Show(dens.ToString());
                    if (radioButton2.Checked)
                    {
                          Form7 fro = new Form7(result, x, textBox1.Text, x2, x3, x10, x8, x9, x5, x4, x11, x12, x13, x14, x15, x6, x16, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), dens, x17, x18, tw, no, x7,hg); 
                        this.Close();
                          fro.Show();
                          this.Dispose();
                    }
                }
            }




        }
    }
}

