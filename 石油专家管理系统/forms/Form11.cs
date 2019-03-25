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
        double Q;//压井排量
        double pp;//地层压力
        double pm1;//压井泥浆密度
        double pti;//初始循环压力
        double ptf;//终了循环压力
        double pamax;//最大套压
        double vgainmax;//泥浆池最大增量
        double ovtime;//溢流到井口时间
        double shigongtime;//压井施工时间
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
            textBox3.Text =Math.Round( Q,2).ToString();
            textBox1.Text= Math.Round(pp,2).ToString();
            textBox4.Text = Math.Round(pm1,2).ToString();
            textBox2.Text = Math.Round(pti,2).ToString();
            textBox5.Text = Math.Round(ptf,2).ToString();
            textBox6.Text = Math.Round(pamax,2).ToString();
            textBox8.Text = Math.Round(vgainmax,2).ToString();
            textBox9.Text = Math.Round(ovtime,2).ToString();
            textBox7.Text = Math.Round(shigongtime,2).ToString();
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
            max = Math.Ceiling(max);
           while(time%5!=0)
            {
                time++;
            }
            while(max%5!=0)
            {
                max++;
            }
            chart.AxisX.Minimum = 0;
            chart.AxisX.Maximum =time;
            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = max;
            chart.AxisX.Interval = time / 5;
            chart.AxisY.Interval = max /5;
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
            while (time3%5!=0)
            {
                time3++;
            }
            
            pit = Math.Ceiling(pit);
            while(pit%5!=0)
            {
                pit++;
            }
            pit = pit + 5;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum =time3;
            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = pit;
            chart2.ChartAreas[0].AxisX.Interval = time3/5;
            chart2.ChartAreas[0].AxisY.Interval = pit/5;
            chart2.Series.Add("泥浆池增量");
            chart2.Series["泥浆池增量"].ChartType = SeriesChartType.Line;
            chart2.Series["泥浆池增量"].Color = Color.Red;
            chart2.Series[0].IsVisibleInLegend = false;
            for(int i=0;i<circulatingtime.Length;i++)
            {
                if (pitgain[i] != 0||circulatingtime[i]!=0)
                chart2.Series["泥浆池增量"].Points.AddXY(circulatingtime[i], pitgain[i]);
            }


        }
        double[] circulatingtime;
        double[] pax;
        double[] ptime;
        double[] pdd;
        public Form11(double Q, double pp, double pm1, double pti, double ptf, double pamax, double pyx, double ovtime, double shigongtime, double[] pat, double[] pdt, double[] tyjp, double[] tyjd,double[] pitgain,int mm)
        {
            this.Q = Q;
            this.pp = pp;
            this.pm1 = pm1;
            this.pti = pti;
            this.ptf = ptf;
            this.pamax = pamax;
            this.vgainmax = pyx;
            this.ovtime = ovtime;
            this.shigongtime = shigongtime;
            this.pax = pat;
            this.pdd = pdt;
            this.circulatingtime = tyjp;
            this.ptime = tyjd;
            InitializeComponent();
            textBox3.Text = Math.Round(Q, 2).ToString();
            textBox1.Text = Math.Round(pp, 2).ToString();
            textBox4.Text = Math.Round(pm1, 2).ToString();
            textBox2.Text = Math.Round(pti, 2).ToString();
            textBox5.Text = Math.Round(ptf, 2).ToString();
            textBox6.Text = Math.Round(pamax, 2).ToString();
            textBox8.Text = Math.Round(vgainmax, 2).ToString();
            textBox9.Text = Math.Round(ovtime, 2).ToString();
            textBox7.Text = Math.Round(shigongtime, 2).ToString();
            label11.Text = "井口最大允许套压";
            
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
            time = Math.Ceiling(time);
            max = Math.Ceiling(max);
            while (time % 5 != 0)
            {
                time++;
            }
            while (max % 5 != 0)
            {
                max++;
            }
            chart.AxisX.Minimum = 0;
            chart.AxisX.Maximum = time;
            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = max;
            chart.AxisX.Interval = time / 5;
            chart.AxisY.Interval = max / 5;
            chart1.Series.Add("套管压力");
            chart1.Series.Add("立管压力");
            chart1.Series["套管压力"].ChartType = SeriesChartType.Line;
            chart1.Series["套管压力"].Color = Color.Red;
            chart1.Series["立管压力"].ChartType = SeriesChartType.Line;
            chart1.Series["立管压力"].Color = Color.Blue;
            chart1.Series[0].IsVisibleInLegend = false;
            for (int i = 0; i < circulatingtime.Length; i++)
            {
                if (pax[i] != 0 || circulatingtime[i] != 0)
                    chart1.Series["套管压力"].Points.AddXY(circulatingtime[i], pax[i]);
            }
            for (int i = 0; i < ptime.Length; i++)
            {
                if (pdd[i] != 0 || ptime[i] != 0)
                    chart1.Series["立管压力"].Points.AddXY(ptime[i], pdd[i]);
            }
            var chart0= chart2.ChartAreas[0];
            chart0.AxisX.IntervalType = DateTimeIntervalType.Number;
            chart0.AxisX.LabelStyle.Format = "";
            chart0.AxisY.LabelStyle.Format = "";
            chart0.AxisY.LabelStyle.IsEndLabelVisible = true;
            chart0.AxisX.Minimum = 0;
            chart0.AxisX.Maximum = tyjp.Max();
            chart0.AxisY.Minimum = 0;
            chart0.AxisY.Maximum = pitgain.Max();
            chart0.AxisX.Interval = tyjp.Max() / 5;
            chart0.AxisY.Interval = pitgain.Max ()/ 5;
            chart2.Series.Add("泥浆池增量");
     
            chart2.Series["泥浆池增量"].ChartType = SeriesChartType.Line;
            chart2.Series["泥浆池增量"].Color = Color.Red;
         
            chart2.Series[0].IsVisibleInLegend = false;
            for (int i = 0; i <tyjp.Length; i++)
            {
                if (tyjp[i] != 0 || pitgain[i] != 0)
                    chart2.Series["泥浆池增量"].Points.AddXY(tyjp[i], pitgain[i]);
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
