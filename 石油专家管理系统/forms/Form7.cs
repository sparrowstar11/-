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
        public Form7(string s, string x, string y, double dep, double tgxDep,double douWellTemp, double douTgDiameter, double douZtSize,double douWellEyeKDL, double douZjyDensity ,
            double douZjyPL,double douDrZWL,double douDbsWellDepth,double douDbsTaoya,double douDbsPL,double douZgOutterDiameter,double douZgWallThickness,double pd,double pa, 
            double vgain, double dens,string companyName,string drillingCrewName ,double [,]tw,string no,double ztl)
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
            string s1 = "select 井口装置额定工作压力 from  [dbo].[Sheet2$] where 工程编号='" + yy + "'";
            string s2 = "select 裸眼薄弱地层破裂压力 from  [dbo].[Sheet2$] where 工程编号='" + yy + "'";
            DataSet read1 = SQLHelper.read(s1);
            DataSet read2 = SQLHelper.read(s2);
            double x1 = Convert.ToDouble(read1.Tables[0].Rows[0]["井口装置额定工作压力"]);
            double x2 = Convert.ToDouble(read2.Tables[0].Rows[0]["裸眼薄弱地层破裂压力"]);
            if (no=="钻进")
            {
                if (xx == "定向井")
                {

                }
                else
                {
                    double[] shen = { 0 };
                    double[] alfa = { 0 };
                    double[] fai = { 0 };
                    if (ss != "gas")
                    {
                        /// <summary>
                        /// 直井-----钻进---油 油水 地层水---工程师
                        /// </summary> 
                        EngMethod me = new EngMethod(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter,
                        douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, 0, ss, dens);
                        me.plumbWell(ss, dens);
                        double Q = me.getQ();//压井排量
                        double pp = me.getPP();//地层压力
                        double pm1 = me.getPm1();//压井泥浆密度
                        double pti = me.getPti();//初始循环压力
                        double ptf = me.getPtf();//终了循环压力
                        double pamax = me.getPamax();//最大套压
                        double vgainmax = me.getVgainmax();//泥浆池最大增量
                        double ovtime = me.getOvtime();//溢流到井口时间
                        double shigongTime = me.getShigongTime();//压井施工时间-------------------------------输出数据7
                        double[] pax = me.getpax();
                        double[] pitgain = me.getpitgain();
                        double[] circulatingtime = me.getcircu();
                        double[] ptime = me.getptime();
                        double[] pdd = me.getpdd();
                        Form11 f = new Form11(Q, pp, pm1, pti, ptf, pamax, vgainmax, ovtime, shigongTime, pax, pitgain, circulatingtime, ptime, pdd); this.Close();
                        f.Show();
                        this.Dispose();

                    }
                    else if ((ss == "gas" && radioButton3.Checked == true) || ss == "gas" && radioButton8.Checked == true)
                    {
                        /// <summary>
                        /// 直井-----钻进---气 （不含硫化氢 含低硫化氢）---工程师
                        /// </summary> 
                        EngMethod me = new EngMethod(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter,
                        douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, 0, ss, dens);
                        me.plumbWell(ss, dens);
                        double Q = me.getQ();//压井排量
                        double pp = me.getPP();//地层压力
                        double pm1 = me.getPm1();//压井泥浆密度
                        double pti = me.getPti();//初始循环压力
                        double ptf = me.getPtf();//终了循环压力
                        double pamax = me.getPamax();//最大套压
                        double vgainmax = me.getVgainmax();//泥浆池最大增量
                        double ovtime = me.getOvtime();//溢流到井口时间
                        double shigongTime = me.getShigongTime();//压井施工时间-------------------------------输出数据7
                        double[] pax = me.getpax();
                        double[] pitgain = me.getpitgain();
                        double[] circulatingtime = me.getcircu();
                        double[] ptime = me.getptime();
                        double[] pdd = me.getpdd();
                        Form11 f = new Form11(Q, pp, pm1, pti, ptf, pamax, vgainmax, ovtime, shigongTime, pax, pitgain, circulatingtime, ptime, pdd); this.Close();
                        f.Show();
                        this.Dispose();

                    }
                    else
                    {
                        /// <summary>
                        /// 直井-----钻进---8倍（气高硫化氢）---压回法--不压破
                        /// </summary>
                        double D = douZtSize * (douWellEyeKDL + 1);
                        //钻进 8倍
                        Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl,x2 , tgxDep,x1);
                        int re= s.Pressure_back_8Time_ZuanJin();
                        if(re==1)
                        {
                            double patmax = s.getPatmax();//最大套压------输出3   //最大施工泵压 // Pat（1）
                            double vyj = s.getVyj(); //压井泥浆量，4倍。输出
                            double tyj = s.gettyj();//压井施工时间，输出
                           List< double> pat = s.getPat();//套压变化数组，需要画图,数组画出来就ok（随脚标）------输出1
                            List<double> atyj = s.getatyj(); //压井施工时间---new add ------------输出 --画图 
                            double Qyj = s.getQyj();     //压井排量------输出2
                            double yjden = s.getyjden(); //压井液密度 kg/m^3------输出5  
                            double t2 = s.gett2();//漏失完水的时间，输出，画图（4倍压回法时用，见流程图）
                            double t1 = s.gett1();//压缩气的时间，输出，画图（钻进时压回法用，见流程图） ----
                            double Pderta = s.getPderta();  //渗流阻力，Mpa-----输出（4倍时用，见流程图）
                            double pat1 = pat.Max();
                            double pp = s.getPP();
                           
                            Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd,pa,yjden,Qyj,pat1,atyj,ss,pp,vyj,tyj,pat,t1,t2);
                            f.Show();
                            this.Close();
                            this.Dispose();

                        }
                        else
                        {
                            /// <summary>
                            /// 直井-----钻进---8倍（气高硫化氢）---压破 --工程师法
                            /// </summary>
                            MessageBox.Show("会压破，有风险");
                            EngMethod me = new EngMethod(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter,
                        douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, 0, ss, dens);
                            me.plumbWell(ss, dens);
                            double Q = me.getQ();//压井排量
                            double pp = me.getPP();//地层压力
                            double pm1 = me.getPm1();//压井泥浆密度
                            double pti = me.getPti();//初始循环压力
                            double ptf = me.getPtf();//终了循环压力
                            double pamax = me.getPamax();//最大套压
                            double vgainmax = me.getVgainmax();//泥浆池最大增量
                            double ovtime = me.getOvtime();//溢流到井口时间
                            double shigongTime = me.getShigongTime();//压井施工时间-------------------------------输出数据7
                            double[] pax = me.getpax();
                            double[] pitgain = me.getpitgain();
                            double[] circulatingtime = me.getcircu();
                            double[] ptime = me.getptime();
                            double[] pdd = me.getpdd();
                            Form11 f = new Form11(Q, pp, pm1, pti, ptf, pamax, vgainmax, ovtime, shigongTime, pax, pitgain, circulatingtime, ptime, pdd); this.Close();
                            f.Show();
                            this.Dispose();
                        }
                       
                    }

                }
            }
            else if(no=="空井")
            {
                if (xx == "定向井")
                {

                }
                else
                {
                    if (ss != "gas")
                    {
                        /// <summary>
                        /// 直井-----空井---4倍（油 油水 地层水）---压回法
                        /// </summary>
                        double D = douZtSize * (douWellEyeKDL + 1);
                        Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1);
                        s.Pressure_back_4Time();
                        double patmax = s.getPatmax();//最大套压------输出3   //最大施工泵压 // Pat（1）
                        double vyj = s.getVyj(); //压井泥浆量，4倍。输出
                        double tyj = s.gettyj();//压井施工时间，输出
                        List<double> pat = s.getPat();//套压变化数组，需要画图,数组画出来就ok（随脚标）------输出1
                        List<double> atyj = s.getatyj(); //压井施工时间---new add ------------输出 --画图 
                        double Qyj = s.getQyj();     //压井排量------输出2
                        double yjden = s.getyjden(); //压井液密度 kg/m^3------输出5  
                        double t2 = s.gett2();//漏失完水的时间，输出，画图（4倍压回法时用，见流程图）
                        double t1 = s.gett1();//压缩气的时间，输出，画图（钻进时压回法用，见流程图） ----
                        double Pderta = s.getPderta();  //渗流阻力，Mpa-----输出（4倍时用，见流程图）
                        double pat1 = pat.Max();
                        double pp = s.getPP();

                        Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, pat1, atyj, ss, pp, vyj, tyj, pat, t1, t2);


                    }
                    else if ((ss == "gas" && radioButton3.Checked == true) || ss == "gas" && radioButton8.Checked == true)
                    {

                    }
                    else
                    {

                    }
                }
               
            }



         
        }
    }
}
