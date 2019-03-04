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
    public partial class Form9 : Form
    {
        Form1 f1;
        public Form9(Form1 form1)
        {
            f1 = form1;
            InitializeComponent();
            DataSet dds = new DataSet();//创建dataset实例
            string selectsql = "Select *   from [dbo].[Sheet5$] where 工程编号='" + f1.label3.Text + "'";
            SqlDataAdapter sqlDap = new SqlDataAdapter(selectsql, conn);//创建DataAdapter数据适配器实例
            DataTable dt = new DataTable();
            sqlDap.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                dataGridView1.DataSource = dt;
            }
        }
        public Form9()
        {
            InitializeComponent();

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“石油专家DataSet3._Sheet5_”中。您可以根据需要移动或删除它。
            this.sheet5_TableAdapter.Fill(this.石油专家DataSet3._Sheet5_);
            // TODO: 这行代码将数据加载到表“石油专家DataSet2._Sheet4_”中。您可以根据需要移动或删除它。
            this.sheet4_TableAdapter.Fill(this.石油专家DataSet2._Sheet4_);
       

        }

        private void button4_Click(object sender, EventArgs e)
        {
           string s = "insert into [dbo].[Sheet5$] (开次,井眼尺寸,裸眼深度,套管尺寸,套管下深,套管壁厚,套管钢级,工程编号)values('" + textBox18.Text + "','" + textBox10.Text + "','" + textBox1.Text + "','" + textBox4.Text+ "','"+textBox3.Text+"',"+textBox2.Text+",'"+textBox5.Text+"','"+f1.label3.Text+"') ";
            int t = SQLHelper.ExQuery(s);
            if (t > 0)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
            newfill();
        }
        public void newfill() //刷新
        {

            DataSet dds = new DataSet();//创建dataset实例
            string selectsql = "Select *   from [dbo].[Sheet5$] where 工程编号='"+f1.label3.Text+"'";
            SqlDataAdapter sqlDap = new SqlDataAdapter(selectsql, conn);//创建DataAdapter数据适配器实例
            DataTable dt = new DataTable();
            sqlDap.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                dataGridView1.DataSource = dt;
            }

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
            string sql = "delete from [dbo].[Sheet5$] where 序号 ='" + bd + "'";
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
    }
}
