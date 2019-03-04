using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 石油专家管理系统
{
    public partial class Form5 : Form
    {
        Form1 f1;
        public Form5(Form1 form1)
        {
            f1 = form1;
            InitializeComponent();
            DataSet dds = new DataSet();//创建dataset实例
            string selectsql = "Select *   from [dbo].[Sheet4$] where 工程编号='" + f1.label3.Text + "'";
            SqlDataAdapter sqlDap = new SqlDataAdapter(selectsql, conn);//创建DataAdapter数据适配器实例
            DataTable dt = new DataTable();
            sqlDap.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                dataGridView1.DataSource = dt;
            }
        }
        public Form5()
        {
            InitializeComponent();
        }

        private void button15_Click(object sender, EventArgs e)
        {

            this.pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\组合效果2.png");
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("PDF钻头");
            comboBox1.Items.Add("钻杆");
            comboBox1.Items.Add("钻铤");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.SelectedItem == "PDF钻头")
            {
                comboBox2.Items.Add("ZT0001");
            }
            else if (comboBox1.SelectedItem =="钻铤")
            {
                comboBox2.Items.Add("ZD0001");
            }
            else if (comboBox1.SelectedItem=="钻杆")
            {
                comboBox2.Items.Add("ZG0001");
                comboBox2.Items.Add("ZG0002");
                comboBox2.Items.Add("ZG0003");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string wl="0";
            string nl="0";
            string bh="0";
            if (comboBox1.SelectedIndex == 0)
            if (comboBox2.SelectedIndex== 0)
                {
                    wl = "225";
                    nl = "240";
                    bh = "15";
                }
            if (comboBox1.SelectedIndex == 1)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    wl = "444.2";
                    nl = "420.2";
                    bh = "24";
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    wl = "333.3";
                    nl = "310";
                    bh = "23";
                }
                else if(comboBox2.SelectedIndex == 2)
                {
                    wl = "127";
                    nl = "105";
                    bh = "11";
                }
            }
            if (comboBox1.SelectedIndex == 2)
                if (comboBox2.SelectedIndex == 0)
                {
                    wl = "158.8";
                    nl = "71.4";
                    bh = "43.7";
                }
            string s= "insert into [dbo].[Sheet4$] (钻具名称,钻具型号,外径,内径,壁厚,长度,工程编号,工况) values('"+comboBox1.SelectedItem+"','"+comboBox2.SelectedItem+"','"+wl+"','"+nl+"','"+bh+"','"+textBox1.Text+"','"+f1.label3.Text+"','"+comboBox3.Text+"')";
            int b =SQLHelper.ExQuery(s);
            if(b>0)
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
            tianjia();
        }
        public void tianjia()
        {
            string s = "select * from [dbo].[Sheet4$] where 工程编号='" + f1.label3.Text + "'";
            DataTable dt= SQLHelper.xQuery(s);
           
            dataGridView1.DataSource = dt;
        }
        static string str = @"Data Source=.;Initial Catalog=石油专家;Integrated Security=True";
        SqlConnection conn = new SqlConnection(str);
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (dataGridView1.SelectedRows.Count != 1) return;
            if (dataGridView1.CurrentRow == null) return;
            DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (row["序号"] == null) return;
            string bd = Convert.ToString(row["序号"]);
            string sql = "delete from [dbo].[Sheet4$] where 序号 ='" + bd + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int del = cmd.ExecuteNonQuery();
            if (del == 1)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
            newfill();
            conn.Close();
        }
        public void newfill() //刷新
        {

            DataSet dds = new DataSet();//创建dataset实例
            string selectsql = "Select *   from [dbo].[Sheet4$] where 工程编号='" + f1.label3.Text + "'";
            SqlDataAdapter sqlDap = new SqlDataAdapter(selectsql, conn);//创建DataAdapter数据适配器实例
            DataTable dt = new DataTable();
            sqlDap.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                dataGridView1.DataSource = dt;
            }

        }
    }
}
