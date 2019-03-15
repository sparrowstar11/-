using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 石油专家管理系统.forms
{
    public partial class Form15 : Form
    {
        double[] V;
        double[] PPa;
        double[] Pcha;
        public Form15(double []V,double [] PPa,double[] Pcha)
        {
            InitializeComponent();
            this.V = V;
            this.PPa = PPa;
            this.Pcha = Pcha;
            for(int i=0;i<V.Length;i++)
            {
                int index = this.dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "第" + Convert.ToInt32( i+1) + "阶段";
                dataGridView1.Rows[index].Cells[1].Value = V[i];
                dataGridView1.Rows[index].Cells[2].Value = PPa[i];
                dataGridView1.Rows[index].Cells[3].Value = Pcha[i];
                
            }
           
        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }
    }
}
