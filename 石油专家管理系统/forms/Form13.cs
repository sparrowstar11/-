using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 石油专家管理系统.forms
{
    public partial class Form13 : Form
    {
        string yy;//井号
        double dep;//井深
        double douZjyDensity;//钻井液密度
        double douZjyPL;//钻井排量
        double pd;//关井立压
        double pa;////关井套压
        double pp;//地层压力
        double yjden ; //压井液密度 kg/m^3------输出5  
        double Qyj ;     //压井排量------输出2
        double vyj ; //压井泥浆量，4倍。输出
        double pat1;
        double tyj ;//压井施工时间，输出
        public Form13(string yy,double dep,double douZjyDensity, double douZjyPL,double pd,double pa,double yjden,double Qyj, double pat1, List<double> atyj,string ss, double pp,double vyj,double tyj, List<double>pat)
        {
            InitializeComponent();
            this.yy = yy;
            textBox1.Text = yy;
            this.dep = dep;
            textBox2.Text = Math.Round(dep,2).ToString();
            this.douZjyDensity = douZjyDensity;
            textBox6.Text = Math.Round(douZjyDensity,2).ToString();
            this.douZjyPL = douZjyPL;
            textBox4.Text = Math.Round(douZjyPL,2).ToString();
            this.pd = pd;
            textBox7.Text = Math.Round(pd,2).ToString();
            this.pa = pa;
            textBox3.Text = Math.Round(pa,2).ToString();
            this.pp = pp;
            textBox8.Text = Math.Round(pp,2).ToString();
            this.yjden = yjden;
            textBox12.Text = Math.Round(yjden,2).ToString();
            this.Qyj = Qyj;
            textBox9.Text = Math.Round(Qyj,2).ToString();
            this.vyj = vyj;
            textBox13.Text = Math.Round(vyj,2).ToString();
            this.pat1 = pat1;
            textBox10.Text = Math.Round(pat1,2).ToString();
            this.tyj = tyj;
            textBox14.Text = Math.Round(tyj,2).ToString();
            textBox11.Text = ss;

            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Number;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "";
            chart1.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = true; double time3 = atyj.Max();
            time3 = Math.Ceiling(time3);
            double pit = pat.Max();
            /*while (time3%5!=0)
            {
                time3++;
            }
            
            pit = Math.Ceiling(pit);
            while(pit%5!=0)
            {
                pit++;
            }*/
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = Math.Ceiling(time3);
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = Math.Ceiling(pit);
            chart1.ChartAreas[0].AxisX.Interval = Math.Ceiling(time3) / 5;
            chart1.ChartAreas[0].AxisY.Interval = Math.Ceiling(pit) / 5;
            chart1.Series.Add("套压曲线");
            chart1.Series["套压曲线"].ChartType = SeriesChartType.Line;
            chart1.Series["套压曲线"].Color = Color.Red;
            chart1.Series[0].IsVisibleInLegend = false;
            for (int i = 0; i < atyj.Count; i++)
            {
                if (pat[i] != 0 || atyj[i] != 0)
                    chart1.Series["套压曲线"].Points.AddXY(atyj[i], pat[i]);
            }


        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
