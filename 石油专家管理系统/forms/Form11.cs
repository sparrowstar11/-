using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace 石油专家管理系统
{
    public partial class Form11 : Form
    {
        double Q;
        double pp;
        double pm1;
        double pti;
        double ptf;
        double pamax;
        double vgainmax;
        double ovtime;
        double shigongtime;
        public Form11(double Q ,double pp,double pm1,double pti,double ptf,double pamax,double vgainmax,double ovtime,double shigongtime,double[] pax ,double[] pitgain, double[] circulatingtime, double[] ptime, double[] pdd)
        {
            InitializeComponent();
            this.Q = Q;
            this.pp = pp;
            this.pm1 = pm1;
            this.pti = pti;
            this.ptf = ptf;
            this.pamax = pamax;
            this.vgainmax = vgainmax;
            this.ovtime = ovtime;
            this.shigongtime = shigongtime;
            textBox1.Text = Q.ToString();
            textBox2.Text= pp.ToString();
            textBox3.Text = pm1.ToString();
            textBox4.Text = pti.ToString();
            textBox9.Text = ptf.ToString();
            textBox5.Text = pamax.ToString();
            textBox6.Text = vgainmax.ToString();
            textBox7.Text = ovtime.ToString();
            textBox8.Text = shigongtime.ToString();
            var chart = chart1.ChartAreas[0];
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;
            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.IsEndLabelVisible = true;
            double time1 = circulatingtime.Max();
            double time2 = ptime.Max();
            double ya = pax.Max();
            double ya2 = pdd.Max();
            double max;
            double time;
            if (ya > ya2)
                max = ya;
            else
                max = ya2;
            if (time1 > time2)
                time = time1;
            else
                time = time2;
            time= Math.Ceiling(time);
          /* while(time%5!=0)
            {
                time++;
            }
            while(max%5!=0)
            {
                max++;
            }*/
            chart.AxisX.Minimum = 0;
            chart.AxisX.Maximum =Math.Ceiling( time);
            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = Math.Ceiling(max);
            chart.AxisX.Interval = Math.Ceiling(time) / 5;
            chart.AxisY.Interval = Math.Ceiling( max) /5;
            chart1.Series.Add("套管压力");
            chart1.Series.Add("立管压力");
            chart1.Series["套管压力"].ChartType = SeriesChartType.Line;
            chart1.Series["套管压力"].Color = Color.Red;
            chart1.Series["立管压力"].ChartType = SeriesChartType.Line;
            chart1.Series["立管压力"].Color = Color.Blue;
            chart1.Series[0].IsVisibleInLegend = false;
            for(int i=0;i<circulatingtime.Length;i++)
            {
                if(pax[i]!=0||circulatingtime[i]!=0)
                chart1.Series["套管压力"].Points.AddXY(circulatingtime[i], pax[i]);
            }
            for (int i = 0; i <ptime.Length; i++)
            {
              if(pdd[i]!=0||ptime[i]!=0)
                chart1.Series["立管压力"].Points.AddXY(ptime[i], pdd[i]);
            }



            chart2.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Number;
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "";
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "";
            chart2.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = true;double time3 = circulatingtime.Max();
            time3 = Math.Ceiling(time3);
            double pit = pitgain.Max();
            /*while (time3%5!=0)
            {
                time3++;
            }
            
            pit = Math.Ceiling(pit);
            while(pit%5!=0)
            {
                pit++;
            }*/
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum =Math.Ceiling( time3);
            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = Math.Ceiling(pit);
            chart2.ChartAreas[0].AxisX.Interval = Math.Ceiling(time3)/5;
            chart2.ChartAreas[0].AxisY.Interval = Math.Ceiling(pit)/5;
            chart2.Series.Add("泥浆池增量");
            chart2.Series["泥浆池增量"].ChartType = SeriesChartType.Line;
            chart2.Series["泥浆池增量"].Color = Color.Green;
            chart2.Series[0].IsVisibleInLegend = false;
            for(int i=0;i<circulatingtime.Length;i++)
            {
                if (pitgain[i] != 0||circulatingtime[i]!=0)
                chart2.Series["泥浆池增量"].Points.AddXY(circulatingtime[i], pitgain[i]);
            }


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
    }
}
