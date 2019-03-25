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
    public partial class Form7 : Form
    {
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
        double hg;
        double[] shen;
        double[] alfa;
        double[] fai;
        public Form7(string s, string x, string y, double dep, double tgxDep,double douWellTemp, double douTgDiameter, double douZtSize,double douWellEyeKDL, double douZjyDensity ,
            double douZjyPL,double douDrZWL,double douDbsWellDepth,double douDbsTaoya,double douDbsPL,double douZgOutterDiameter,double douZgWallThickness,double pd,double pa, 
            double vgain, double dens,string companyName,string drillingCrewName ,double [,]tw,string no,double ztl,double hg,double []shen,double []alfa,double[] fai)
        {
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
            this.hg = hg;
            this.ztl = ztl;
            this.shen = shen;
            this.alfa = alfa;
            this.fai = fai;
            InitializeComponent();
            if (ss == "null")
            {

            }
            if (ss == "gas")
                radioButton5.Checked = true;
            if (ss == "oil")
                radioButton6.Checked = true;
            if (ss == "wateroil")
                radioButton10.Checked = true;
            if (ss == "water")
                radioButton9.Checked = true;
            textBox2.Text = yy;
            if(no=="钻进")
            {
                radioButton1.Checked = true;
            }
            if(no=="空井")
            {
                radioButton2.Checked = true;
            }
            if(no=="起下钻")
            {
                radioButton7.Checked = true;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type;

            if(radioButton8.Checked==true||radioButton3.Checked==true)
            {
                type = "yes";
            }
            else
            {
                type = "no";
            }
            Form14 f = new Form14( ss,  xx,  yy, dep,  tgxDep,  douWellTemp,  douTgDiameter, douZtSize, douWellEyeKDL,  douZjyDensity,
             douZjyPL,  douDrZWL,  douDbsWellDepth,  douDbsTaoya,  douDbsPL,  douZgOutterDiameter, douZgWallThickness,  pd, pa,
           vgain,  dens,  companyName,  drillingCrewName, tw,  no,  ztl,type,hg,shen,alfa,fai);
            f.Show();
            this.Close();
            this.Dispose();



         
        }
    }
}
