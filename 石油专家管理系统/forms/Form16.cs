using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 石油专家管理系统.Calcuation;

namespace 石油专家管理系统.forms
{
    public partial class Form16 : Form
    {
        double yjmax;
        double yjmin;
        string ss;//地层类型
        string xx;//井型
        string yy;//工程编号
        double dep;//井深
        double tgxDep;//套管鞋深度
        double douWellTemp;//井口温度
        double douTgDiameter;//套管直径
        double douZtSize;//钻头尺寸
        double douWellEyeKDL;//井眼扩大率
        double douZjyDensity;//钻井液密度
        double douZjyPL;//钻井液排量
        double douDrZWL;//地热增温率
        double douDbsWellDepth;//低泵速井深
        double douDbsTaoya;//低泵速压耗
        double douDbsPL;//低泵速排量
        double douZgOutterDiameter;//钻杆外径
        double douZgWallThickness;//钻杆壁厚
        double pd;//关井立压；
        double pa;//关井套压;
        double vgain;//泥浆池增量
        string companyName;//公司名称
        double dens;
        string drillingCrewName;//钻井队名称
        double[,] tw;
        string no;
        double ztl;
        string type;
        double D;
        double x1;
        double x2;
        double hg;
        int re;

        double[] shen = { 0 };
        double[] alfa = { 0 };
        double[] fai = { 0 };
        public Form16()
        {
            InitializeComponent();
        }
        public Form16(double yjmax,double yjmin, string s, string x, string y, double dep, double tgxDep, double douWellTemp, double douTgDiameter, double douZtSize, double douWellEyeKDL, double douZjyDensity,
            double douZjyPL, double douDrZWL, double douDbsWellDepth, double douDbsTaoya, double douDbsPL, double douZgOutterDiameter, double douZgWallThickness, double pd, double pa,
            double vgain, double dens, string companyName, string drillingCrewName, double[,] tw, string no, double ztl, string type, double hg)
        {
            InitializeComponent();
            this.yjmax = yjmax;
            this.yjmin = yjmin;
            yjmax = Math.Round(yjmax, 2);
            yjmin = Math.Round(yjmin, 2);
            this.ss = s;
            xx = x;
            yy = y;
            this.dep = dep;
            this.tgxDep = tgxDep;
            this.douWellTemp = douWellTemp;
            this.douTgDiameter = douTgDiameter;
            this.douZtSize = douZtSize;
            this.douWellEyeKDL = douWellEyeKDL;
            this.douZjyDensity = douZjyDensity;
            this.douZjyPL = douZjyPL;
            this.douDrZWL = douDrZWL;
            this.douDbsWellDepth = douDbsWellDepth;
            this.douDbsTaoya = douDbsTaoya;
            this.douDbsPL = douDbsPL;
            this.douZgOutterDiameter = douZgOutterDiameter;
            this.douZgWallThickness = douZgWallThickness;
            this.pd = pd;
            this.pa = pa;
            this.vgain = vgain;
            this.companyName = companyName;
            this.dens = dens;
            this.drillingCrewName = drillingCrewName;
            this.tw = tw;
            this.no = no;
            this.type = type;
            this.hg = hg;
            label1.Text = yjmin.ToString();
            label2.Text = yjmax.ToString();
            
           

        }
        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {


                if (Convert.ToDouble(textBox1.Text) >= Convert.ToDouble(label1.Text) && Convert.ToDouble(textBox1.Text) <= Convert.ToDouble(label2.Text))
                {
                    EngMethod me = new EngMethod(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter,
               douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, 0, ss, dens);
                    double tyj = 0;
                    double t1 = 0;
                    double Qyj = 0;
                    double Ppc = 0;
                    double Vvj = 0;

                    me.EngMethod_QiXiaZuan_Small(ztl, ref t1, ref tyj, ref Qyj, ref Ppc, ref Vvj, Convert.ToDouble(textBox1.Text));
                    string name = "工程";
                    MessageBox.Show("抢下钻具");
                    Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, Convert.ToDouble(textBox1.Text), Qyj);
                    fx.Show();


                }

            }
            else
            {

            }
        }
    }
}
