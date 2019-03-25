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
    public partial class Form14 : Form
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
        string type;
        double D;
        double x1;
        double x2;
        double hg;
        int re;
        double[] shen;
        double[] alfa;
        double[] fai;
        int NT = 299;
        public Form14(string s, string x, string y, double dep, double tgxDep, double douWellTemp, double douTgDiameter, double douZtSize, double douWellEyeKDL, double douZjyDensity,
            double douZjyPL, double douDrZWL, double douDbsWellDepth, double douDbsTaoya, double douDbsPL, double douZgOutterDiameter, double douZgWallThickness, double pd, double pa,
            double vgain, double dens, string companyName, string drillingCrewName, double[,] tw, string no, double ztl, string type, double hg,double[]shen,double[]alfa,double[]fai)
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
            this.type = type;
            this.hg = hg;
            this.ztl = ztl;
            this.shen = shen;
            this.alfa = alfa;
            this.fai = fai;
            InitializeComponent();
            radioButton1.Visible = false;
            string s1 = "select 井口装置额定工作压力 from  [dbo].[Sheet2$] where 工程编号='" + yy + "'";
            string s2 = "select 裸眼薄弱地层破裂压力 from  [dbo].[Sheet2$] where 工程编号='" + yy + "'";
            DataSet read1 = SQLHelper.read(s1);
            DataSet read2 = SQLHelper.read(s2);
            x1 = Convert.ToDouble(read1.Tables[0].Rows[0]["井口装置额定工作压力"]);
            x2 = Convert.ToDouble(read2.Tables[0].Rows[0]["裸眼薄弱地层破裂压力"]);
            D = douZtSize * (douWellEyeKDL + 1);

            if (no == "钻进")
            {
                if (ss != "gas")
                {
                    //推荐方法 工程师
                    radioButton6.Checked = true;


                }
                if (ss == "gas" && type == "yes")
                {

                    //推荐方法 工程师
                    radioButton6.Checked = true;
                }
                if (ss == "gas" && type == "no")
                {
                    //推荐方法 压回
                    radioButton9.Checked = true;
                }
            }
            if (no == "空井")
            {
                if (ss != "gas")
                {
                    //推荐方法 压回 四倍
                    radioButton9.Checked = true;

                }
                if (ss == "gas" && type == "yes")
                {
                    //推荐方法 置换法
                    radioButton5.Checked = true;
                }
                if (ss == "gas" && type == "no")
                {
                    //推荐方法 压回 八倍
                    radioButton9.Checked = true;
                }
            }
            if (no == "起下钻")
            {
                radioButton1.Visible = true;
                if (ss != "gas")
                {



                    //推荐方法 工程师
                    radioButton1.Checked = true;

                }
                if (ss == "gas" && type == "yes")
                {


                    //推荐方法 工程师
                    radioButton1.Checked = true;


                }
                if (ss == "gas" && type == "no")
                {
                    //推荐方法 压回 八倍
                    radioButton9.Checked = true;
                }
            }
        }


        private void Form14_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(xx=="直井")
            {

       
          
                if (no == "钻进")
                {
                    if (ss != "gas")
                    {
                        if (radioButton6.Checked == true)//使用工程师法
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
                            Form11 f = new Form11(Q, pp, pm1, pti, ptf, pamax, vgainmax, ovtime, shigongTime, pax, pitgain, circulatingtime, ptime, pdd);
                            f.Show();

                        }
                        if (radioButton9.Checked == true)//使用压回法
                        {
                            /// <summary>
                            /// 直井-----钻进---油 油水 地层水---压回法
                            /// </summary> 

                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1, 0);
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

                            Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                            f.Show();



                        }
                        if (radioButton5.Checked == true)
                        {
                            MessageBox.Show("非法操作");



                        }
                        if (radioButton10.Checked == true)
                        {
                            /// <summary>
                            /// 直井-----钻进---油 油水 地层水---司钻法
                            /// </summary> 

                            string lo = "select 内径 from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            DataSet n = SQLHelper.read(lo);
                            string lo2 = "select 外径  from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            string lo3 = "select 长度 from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            DataSet n2 = SQLHelper.read(lo2);
                            DataSet n3 = SQLHelper.read(lo3);
                            List<double> ZJI = new List<double>();
                            List<double> ZJO = new List<double>();
                            List<double> ZJL = new List<double>();
                            for (int i = 0; i < n.Tables[0].Rows.Count; i++)
                            {
                                ZJL.Add(Convert.ToDouble(n3.Tables[0].Rows[i]["长度"]));
                                ZJI.Add(Convert.ToDouble(n.Tables[0].Rows[i]["内径"]));
                                ZJO.Add(Convert.ToDouble(n2.Tables[0].Rows[i]["外径"]));
                            }
                            int nt2 = n.Tables[0].Rows.Count;
                            SZmethod sz = new SZmethod();
                            sz.SZMethod(yy, yy, xx, ss, ZJI, ZJO, ZJL, nt2);
                            double pc = douDbsTaoya / douDbsWellDepth;
                            sz.SZF(pd, pa, vgain, douZjyDensity, douZjyPL, dep, tgxDep, x1, x2, 0, D, douZtSize, douDrZWL, douWellTemp, pc);

                            double Q = sz.getQyj();//压井排量
                            double pp = sz.getPp();//地层压力
                            double pm1 = sz.getyjden();//压井泥浆密度
                            double pti = sz.getPti();//初始循环压力
                            double ptf = sz.getPtf();//终了循环压力
                            double pamax = sz.getpamax();//最大套压
                                                         // double vgainmax = sz.getVgainmax();//泥浆池最大增量
                            double pyx = sz.getPyx();//井口最大允许套压
                            double ovtime = sz.getOvtime();//溢流到井口时间
                            double shigongTime = sz.getShigongTime();//压井施工时间-------------------------------输出数据7
                            double[] pat = sz.getPat();
                            double[] pdt = sz.getPdt();
                            double[] tyjp = sz.gettyjp();
                            double[] tyjd = sz.gettyjd();

                       //     Form11 ff = new Form11(Q, pp, pm1, pti, ptf, pamax, pyx, ovtime, shigongTime, pat, pdt, tyjp, tyjd);
                           // ff.Show();


                        }

                    }
                    if (ss == "gas" && type == "yes")
                    {

                        if (radioButton6.Checked == true)//使用工程师法
                        {
                            /// <summary>
                            /// 直井-----钻进---气---工程师
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
                            Form11 f = new Form11(Q, pp, pm1, pti, ptf, pamax, vgainmax, ovtime, shigongTime, pax, pitgain, circulatingtime, ptime, pdd);
                            f.Show();

                        }
                        if (radioButton9.Checked == true)//使用压回法
                        {
                            /// <summary>
                            /// 直井-----钻进---气---压回法
                            /// </summary> 

                            //钻进 8倍
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1);
                            int re = s.Pressure_back_8Time_ZuanJin();
                            if (re == 1)
                            {
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
                                f.Show();


                            }
                        }
                        if (radioButton5.Checked == true)
                        {
                            /// <summary>
                            /// 直井-----钻进---气---置换法
                            /// </summary> 
                            double[] V = new double[15];    //注入压井液的体积
                            double[] PPa = new double[15];  //注入压井液之后的套管压力
                            double[] Pcha = new double[15];  //释放气体后的压力
                            ReplacementMethod p = new ReplacementMethod();
                            p.Replacement_method_wdp(dep, tgxDep, douZtSize, douZgOutterDiameter, pa, 0, douWellTemp, douZjyDensity, vgain, douZjyPL, x1, x2, ref V, ref PPa, ref Pcha, ztl);
                            Form15 po = new Form15(V, PPa, Pcha);
                            po.Show();

                        }
                        if (radioButton10.Checked == true)
                        {
                            /// <summary>
                            /// 直井-----钻进---气---司钻法
                            /// </summary> 
                            /// 


                            string lo = "select 内径 from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            DataSet n = SQLHelper.read(lo);
                            string lo2 = "select 外径  from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            string lo3 = "select 长度 from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            DataSet n2 = SQLHelper.read(lo2);
                            DataSet n3 = SQLHelper.read(lo3);
                            List<double> ZJI = new List<double>();
                            List<double> ZJO = new List<double>();
                            List<double> ZJL = new List<double>();
                            for (int i = 0; i < n.Tables[0].Rows.Count; i++)
                            {
                                ZJL.Add(Convert.ToDouble(n3.Tables[0].Rows[i]["长度"]));
                                ZJI.Add(Convert.ToDouble(n.Tables[0].Rows[i]["内径"]));
                                ZJO.Add(Convert.ToDouble(n2.Tables[0].Rows[i]["外径"]));
                            }
                            int nt2 = n.Tables[0].Rows.Count;
                            SZmethod sz = new SZmethod();
                            sz.SZMethod(yy, yy, xx, ss, ZJI, ZJO, ZJL, nt2);
                            double pc = douDbsTaoya / douDbsWellDepth;
                            sz.SZF(pd, pa, vgain, douZjyDensity, douZjyPL, dep, tgxDep, x1, x2, 0, D, douZtSize, douDrZWL, douWellTemp, pc);
                            double Q = sz.getQyj();//压井排量
                            double pp = sz.getPp();//地层压力
                            double pm1 = sz.getyjden();//压井泥浆密度
                            double pti = sz.getPti();//初始循环压力
                            double ptf = sz.getPtf();//终了循环压力
                            double pamax = sz.getpamax();//最大套压
                                                         // double vgainmax = sz.getVgainmax();//泥浆池最大增量
                            double pyx = sz.getPyx();//井口最大允许套压
                            double ovtime = sz.getOvtime();//溢流到井口时间
                            double shigongTime = sz.getShigongTime();//压井施工时间-------------------------------输出数据7
                            double[] pat = sz.getPat();
                            double[] pdt = sz.getPdt();
                            double[] tyjp = sz.gettyjp();
                            double[] tyjd = sz.gettyjd();
                            double[] pitgain = sz.getpitgain();
                            Form11 ff = new Form11(Q, pp, pm1, pti, ptf, pamax, pyx, ovtime, shigongTime, pat, pdt, tyjp, tyjd,pitgain,1);
                            ff.Show();


                        }
                    }
                    if (ss == "gas" && type == "no")
                    {
                        if (radioButton9.Checked == true)//推荐压回法
                        {
                            /// <summary>
                            /// 直井-----钻进---8倍（气高硫化氢）---压回法--不压破
                            /// </summary>

                            //钻进 8倍
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1);
                            int re = s.Pressure_back_8Time_ZuanJin();
                            if (re == 1)
                            {
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
                                f.Show();


                            }
                            else
                            {
                                MessageBox.Show("会压破，有风险,请选用工程师法");

                            }
                        }
                        if (radioButton6.Checked == true)//工程师法
                        {
                            /// <summary>
                            /// 直井-----钻进---8倍（气高硫化氢）---压破 --工程师法
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


                        }
                        if (radioButton5.Checked == true)//置换法
                        {
                            /// <summary>
                            /// 直井-----钻进---气高硫化氢---置换法
                            /// </summary>
                            double[] V = new double[15];    //注入压井液的体积
                            double[] PPa = new double[15];  //注入压井液之后的套管压力
                            double[] Pcha = new double[15];  //释放气体后的压力
                            ReplacementMethod p = new ReplacementMethod();
                            p.Replacement_method_wdp(dep, tgxDep, douZtSize, douZgOutterDiameter, pa, 0, douWellTemp, douZjyDensity, vgain, douZjyPL, x1, x2, ref V, ref PPa, ref Pcha, ztl);
                            Form15 po = new Form15(V, PPa, Pcha);
                            po.Show();
                        }
                        if (radioButton10.Checked == true)//司钻法

                        {
                            /// <summary>
                            /// 直井-----钻进---气高硫化氢--司钻法
                            /// </summary>


                            string lo = "select 内径 from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            DataSet n = SQLHelper.read(lo);
                            string lo2 = "select 外径  from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            string lo3 = "select 长度 from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            DataSet n2 = SQLHelper.read(lo2);
                            DataSet n3 = SQLHelper.read(lo3);
                            List<double> ZJI = new List<double>();
                            List<double> ZJO = new List<double>();
                            List<double> ZJL = new List<double>();
                            for (int i = 0; i < n.Tables[0].Rows.Count; i++)
                            {
                                ZJL.Add(Convert.ToDouble(n3.Tables[0].Rows[i]["长度"]));
                                ZJI.Add(Convert.ToDouble(n.Tables[0].Rows[i]["内径"]));
                                ZJO.Add(Convert.ToDouble(n2.Tables[0].Rows[i]["外径"]));
                            }
                            int nt2 = n.Tables[0].Rows.Count;
                            SZmethod sz = new SZmethod();
                            sz.SZMethod(yy, yy, xx, ss, ZJI, ZJO, ZJL, nt2);
                            double pc = douDbsTaoya / douDbsWellDepth;
                            sz.SZF(pd, pa, vgain, douZjyDensity, douZjyPL, dep, tgxDep, x1, x2, 0, D, douZtSize, douDrZWL, douWellTemp, pc);
                            double Q = sz.getQyj();//压井排量
                            double pp = sz.getPp();//地层压力
                            double pm1 = sz.getyjden();//压井泥浆密度
                            double pti = sz.getPti();//初始循环压力
                            double ptf = sz.getPtf();//终了循环压力
                            double pamax = sz.getpamax();//最大套压
                                                         // double vgainmax = sz.getVgainmax();//泥浆池最大增量
                            double pyx = sz.getPyx();//井口最大允许套压
                            double ovtime = sz.getOvtime();//溢流到井口时间
                            double shigongTime = sz.getShigongTime();//压井施工时间-------------------------------输出数据7
                            double[] pat = sz.getPat();
                            double[] pdt = sz.getPdt();
                            double[] tyjp = sz.gettyjp();
                            double[] tyjd = sz.gettyjd();

                       //     Form11 ff = new Form11(Q, pp, pm1, pti, ptf, pamax, pyx, ovtime, shigongTime, pat, pdt, tyjp, tyjd);
//ff.Show();

                        }
                    }
                }




                ////////一下为空井工况


















                else if (no == "空井")
                {
                    if (ss != "gas")
                    {
                        if (radioButton9.Checked == true)//压回法
                        {
                            /// <summary>
                            /// 空井-----直井---油水--压回法
                            /// </summary>
                            double D = douZtSize * (douWellEyeKDL + 1);
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1, 0);
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

                            Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                            f.Show();


                        }
                        if (radioButton5.Checked == true)//置换法
                        {
                            MessageBox.Show("非法操作");





                        }
                        if (radioButton6.Checked == true)//工程师法

                        {
                            /// <summary>
                            /// 空井-----直井---油水--工程师法
                            /// </summary>
                            /// 抢下钻具 当 钻进用
                            /// 
                            string name = "工程";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();


                        }
                        if (radioButton10.Checked == true)
                        {
                            /// <summary>
                            /// 空井-----直井---油水--司钻法
                            /// </summary>
                            /// 抢下钻具 当钻进用
                            /// 

                            string name = "司钻";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();



                        }
                    }
                    if (ss == "gas" && type == "yes")
                    {
                        if (radioButton5.Checked == true)//置换法
                        {
                            /// <summary>
                            /// 空井-----直井---气--置换法
                            /// </summary>
                            /// 
                            double[] V = new double[15];    //注入压井液的体积
                            double[] PPa = new double[15];  //注入压井液之后的套管压力
                            double[] Pcha = new double[15];  //释放气体后的压力
                            ReplacementMethod p = new ReplacementMethod();
                            p.Replacement_method_wodp(dep, tgxDep, douZtSize, douZgOutterDiameter, pa, 0, douWellTemp, douZjyDensity, vgain, douZjyPL, x1, x2, ref V, ref PPa, ref Pcha);
                            Form15 po = new Form15(V, PPa, Pcha);
                            po.Show();

                        }
                        if (radioButton6.Checked == true)//工程师法

                        {
                            /// <summary>
                            /// 空井-----直井---气--工程师法
                            /// </summary>
                            /// 抢下钻具 当钻进用
                            /// 
                            string name = "工程";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();

                        }
                        if (radioButton10.Checked == true)//司钻法
                        {
                            /// <summary>
                            /// 空井-----直井---气--司钻法
                            /// </summary>
                            /// 抢下钻具 当钻进用 
                            /// 
                            string name = "司钻";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();

                        }
                        if (radioButton9.Checked == true)//压回法
                        {
                            /// <summary>
                            /// 空井-----直井---气--8倍压回法
                            /// </summary>
                            double D = douZtSize * (douWellEyeKDL + 1);
                            ztl = 0;
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1);
                            s.Pressure_back_8Time();
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

                            Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                            f.Show();


                        }
                    }
                    if (ss == "gas" && type == "no")
                    {
                        if (radioButton5.Checked == true)//置换法
                        {
                            /// <summary>
                            /// 空井-----直井---气--置换法
                            /// </summary>
                            double[] V = new double[15];    //注入压井液的体积
                            double[] PPa = new double[15];  //注入压井液之后的套管压力
                            double[] Pcha = new double[15];  //释放气体后的压力
                            ReplacementMethod p = new ReplacementMethod();
                            p.Replacement_method_wodp(dep, tgxDep, douZtSize, douZgOutterDiameter, pa, 0, douWellTemp, douZjyDensity, vgain, douZjyPL, x1, x2, ref V, ref PPa, ref Pcha);
                            Form15 po = new Form15(V, PPa, Pcha);
                            po.Show();
                        }
                        if (radioButton6.Checked == true)//工程师法

                        {
                            /// <summary>
                            /// 空井-----直井---气--工程师法
                            /// </summary>
                            /// 抢下钻具 当钻进用 
                            string name = "工程";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();

                        }
                        if (radioButton10.Checked == true)//司钻法
                        {
                            /// <summary>
                            /// 空井-----直井---气--司钻法
                            /// </summary>
                            /// 抢下钻具 当钻进用 
                            string name = "司钻";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();
                        }
                        if (radioButton9.Checked == true)//压回法
                        {
                            /// <summary>
                            /// 空井-----直井---气--压回法
                            /// </summary>
                            double D = douZtSize * (douWellEyeKDL + 1);

                            ztl = 0;
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1);
                            s.Pressure_back_8Time();
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

                            Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                            f.Show();


                        }
                    }
                }





                //////////////////起下钻



                else
                {

                    if (radioButton1.Checked == true)
                    {
                        double Yjdenmax = 0;
                        double Yjdenmin = 0;
                        isZjyDensityConfigJudge.isZjyDensityConfigJudge_ZhiJing(ztl, tgxDep, dens, x2, dep, pa, D, douZgOutterDiameter, vgain, douZjyDensity, hg, ref Yjdenmin, ref Yjdenmax);

                        Form16 fn = new Form16(Yjdenmax, Yjdenmin, ss, xx, yy, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity,
                 douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa,
               vgain, dens, companyName, drillingCrewName, tw, no, ztl, type, hg);
                        fn.Show();
                    }
                    if (ss != "gas")
                    {
                        if (radioButton9.Checked == true)
                        {
                            /// <summary>
                            /// 起下钻-----直井---油水--压回
                            /// </summary>
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1, 0);
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

                            Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                            f.Show();

                        }
                        if (radioButton6.Checked == true)
                        {
                            /// <summary>
                            /// 起下钻-----直井---油水--工程师  抢下钻具
                            /// </summary>
                            string name = "工程";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();
                        }
                        if (radioButton10.Checked == true)
                        {
                            /// <summary>
                            /// 起下钻-----直井---油水--司钻法 抢下钻具

                            /// </summary>
                            string name = "司钻";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();
                        }
                        if (radioButton5.Checked == true)
                        {
                            MessageBox.Show("非法操作");
                        }
                    }
                    if (ss == "gas" && type == "yes")
                    {
                        if (radioButton5.Checked == true)//推荐置换法
                        {
                            /// <summary>
                            /// 起下钻-----直井---气--置换法
                            /// </summary>
                            double[] V = new double[15];    //注入压井液的体积
                            double[] PPa = new double[15];  //注入压井液之后的套管压力
                            double[] Pcha = new double[15];  //释放气体后的压力
                            ReplacementMethod p = new ReplacementMethod();
                            p.Replacement_method_wdp(dep, tgxDep, douZtSize, douZgOutterDiameter, pa, 0, douWellTemp, douZjyDensity, vgain, douZjyPL, x1, x2, ref V, ref PPa, ref Pcha, ztl);
                            Form15 po = new Form15(V, PPa, Pcha);
                            po.Show();
                        }
                        if (radioButton6.Checked == true)//抢下钻具 工程师
                        {
                            /// <summary>
                            /// 起下钻-----直井---气--工程师 
                            /// </summary>
                            string name = "工程";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();
                        }
                        if (radioButton10.Checked == true)//抢下司钻法
                        {
                            /// <summary>
                            /// 起下钻-----直井---气--司钻法
                            /// </summary>
                            string name = "司钻";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();
                        }
                        if (radioButton9.Checked == true)//压回 八倍 
                        {
                            /// <summary>
                            /// 起下钻-----直井---气--压回
                            /// </summary>
                            double D = douZtSize * (douWellEyeKDL + 1);
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1);
                            s.Pressure_back_8Time();
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

                            Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                            f.Show();

                        }
                        if (ss == "gas" && type == "no")
                        {
                            if (radioButton9.Checked == true)//压回 八倍 推荐
                            {
                                /// <summary>
                                /// 起下钻-----直井---气--压回
                                /// </summary>
                                double D = douZtSize * (douWellEyeKDL + 1);
                                Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1);
                                s.Pressure_back_8Time();
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

                                Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                                f.Show();

                            }
                            if (radioButton5.Checked == true)//置换法
                            {
                                /// <summary>
                                /// 起下钻-----直井---气--置换法

                                /// </summary>

                                double[] V = new double[15];    //注入压井液的体积
                                double[] PPa = new double[15];  //注入压井液之后的套管压力
                                double[] Pcha = new double[15];  //释放气体后的压力
                                ReplacementMethod p = new ReplacementMethod();
                                p.Replacement_method_wdp(dep, tgxDep, douZtSize, douZgOutterDiameter, pa, 0, douWellTemp, douZjyDensity, vgain, douZjyPL, x1, x2, ref V, ref PPa, ref Pcha, ztl);
                                Form15 xp = new Form15(V, PPa, Pcha);
                                xp.Show();


                            }
                            if (radioButton6.Checked == true)//抢下钻具 工程师
                            {
                                /// <summary>
                                /// 起下钻-----直井---气--工程师 
                                /// </summary>
                                string name = "工程";
                                MessageBox.Show("抢下钻具");
                                Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                                fx.Show();
                            }
                            if (radioButton10.Checked == true)//抢下司钻法
                            {
                                /// <summary>
                                /// 起下钻-----直井---气--司钻法
                                /// </summary>
                                string name = "司钻";
                                MessageBox.Show("抢下钻具");
                                Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                                fx.Show();
                            }
                        }


                    }
                }



            }
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            //之前都是直井
            //-------------------------------------------------------------------------------------------------------------------------------------------------------
            else
            {
               
                if (no == "钻进")
                {
                    if (ss != "gas")
                    {
                        if (radioButton6.Checked == true)//使用工程师法
                        {
                            /// <summary>
                            /// 定向井-----钻进---油 油水 地层水---工程师
                            /// </summary> 
                            EngMethod me = new EngMethod(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter,
                            douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, 0, ss, dens);
                            me.directionWell(ss, dens,tw,shen,alfa,fai,NT);
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
                            Form11 f = new Form11(Q, pp, pm1, pti, ptf, pamax, vgainmax, ovtime, shigongTime, pax, pitgain, circulatingtime, ptime, pdd);
                            f.Show();

                        }
                        if (radioButton9.Checked == true)//使用压回法
                        {
                            /// <summary>
                            /// 定向井-----钻进---油 油水 地层水---压回法
                            /// </summary> 

                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1, 0);
                            s.Pressure_back_with_trace_4Time(NT,shen,alfa,fai);

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

                            Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                            f.Show();



                        }
                        if (radioButton5.Checked == true)
                        {
                            MessageBox.Show("非法操作");



                        }
                        if (radioButton10.Checked == true)
                        {
                            /// <summary>
                            /// 定向井-----钻进---油 油水 地层水---司钻法
                            /// </summary> 

                            string lo = "select 内径 from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            DataSet n = SQLHelper.read(lo);
                            string lo2 = "select 外径  from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            string lo3 = "select 长度 from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            DataSet n2 = SQLHelper.read(lo2);
                            DataSet n3 = SQLHelper.read(lo3);
                            List<double> ZJI = new List<double>();
                            List<double> ZJO = new List<double>();
                            List<double> ZJL = new List<double>();
                            for (int i = 0; i < n.Tables[0].Rows.Count; i++)
                            {
                                ZJL.Add(Convert.ToDouble(n3.Tables[0].Rows[i]["长度"]));
                                ZJI.Add(Convert.ToDouble(n.Tables[0].Rows[i]["内径"]));
                                ZJO.Add(Convert.ToDouble(n2.Tables[0].Rows[i]["外径"]));
                            }
                            int nt2 = n.Tables[0].Rows.Count;
                            SZmethod sz = new SZmethod();
                            sz.SZMethod(yy, yy, xx, ss, ZJI, ZJO, ZJL, nt2);
                            double pc = douDbsTaoya / douDbsWellDepth;
                            sz.SZF_wt(pd, pa, vgain, douZjyDensity, douZjyPL, dep, tgxDep, x1, x2, 0, D, douZtSize, douDrZWL, douWellTemp, pc,tw);

                            double Q = sz.getQyj();//压井排量
                            double pp = sz.getPp();//地层压力
                            double pm1 = sz.getyjden();//压井泥浆密度
                            double pti = sz.getPti();//初始循环压力
                            double ptf = sz.getPtf();//终了循环压力
                            double pamax = sz.getpamax();//最大套压
                                                         // double vgainmax = sz.getVgainmax();//泥浆池最大增量
                            double pyx = sz.getPyx();//井口最大允许套压
                            double ovtime = sz.getOvtime();//溢流到井口时间
                            double shigongTime = sz.getShigongTime();//压井施工时间-------------------------------输出数据7
                            double[] pat = sz.getPat();
                            double[] pdt = sz.getPdt();
                            double[] tyjp = sz.gettyjp();
                            double[] tyjd = sz.gettyjd();

                       //     Form11 ff = new Form11(Q, pp, pm1, pti, ptf, pamax, pyx, ovtime, shigongTime, pat, pdt, tyjp, tyjd);
                         //   ff.Show();


                        }

                    }
                    if (ss == "gas" && type == "yes")
                    {

                        if (radioButton6.Checked == true)//使用工程师法
                        {
                            /// <summary>
                            /// 定向井-----钻进---气---工程师
                            /// </summary> 
                            EngMethod me = new EngMethod(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter,
                       douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, 0, ss, dens);
                            me.directionWell(ss, dens,tw,shen,alfa,fai,NT);
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
                            Form11 f = new Form11(Q, pp, pm1, pti, ptf, pamax, vgainmax, ovtime, shigongTime, pax, pitgain, circulatingtime, ptime, pdd);
                            f.Show();

                        }
                        if (radioButton9.Checked == true)//使用压回法
                        {
                            /// <summary>
                            /// 定向井-----钻进---气---压回法
                            /// </summary> 

                            //钻进 8倍
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1);
                            int re = s.Pressure_back_with_trace_8Time_ZuanJin(NT,shen,alfa,fai);
                            if (re == 1)
                            {
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
                                f.Show();


                            }
                        }
                        if (radioButton5.Checked == true)
                        {
                            /// <summary>
                            /// 直井-----钻进---气---置换法
                            /// </summary> 
                      /*      double[] V = new double[15];    //注入压井液的体积
                            double[] PPa = new double[15];  //注入压井液之后的套管压力
                            double[] Pcha = new double[15];  //释放气体后的压力
                            ReplacementMethod p = new ReplacementMethod();
                            p.Replacement_method_with_trace_wdp(NT,tgxDep, douZtSize, douZgOutterDiameter, pa, 0, douWellTemp, douZjyDensity, vgain, douZjyPL, x1, x2, ref V, ref PPa, ref Pcha, ztl);
                            Form15 po = new Form15(V, PPa, Pcha);
                            po.Show();*/

                        }
                        if (radioButton10.Checked == true)
                        {
                            /// <summary>
                            /// 直井-----钻进---气---司钻法
                            /// </summary> 
                            /// 


                            string lo = "select 内径 from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            DataSet n = SQLHelper.read(lo);
                            string lo2 = "select 外径  from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            string lo3 = "select 长度 from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            DataSet n2 = SQLHelper.read(lo2);
                            DataSet n3 = SQLHelper.read(lo3);
                            List<double> ZJI = new List<double>();
                            List<double> ZJO = new List<double>();
                            List<double> ZJL = new List<double>();
                            for (int i = 0; i < n.Tables[0].Rows.Count; i++)
                            {
                                ZJL.Add(Convert.ToDouble(n3.Tables[0].Rows[i]["长度"]));
                                ZJI.Add(Convert.ToDouble(n.Tables[0].Rows[i]["内径"]));
                                ZJO.Add(Convert.ToDouble(n2.Tables[0].Rows[i]["外径"]));
                            }
                            int nt2 = n.Tables[0].Rows.Count;
                            SZmethod sz = new SZmethod();
                            sz.SZMethod(yy, yy, xx, ss, ZJI, ZJO, ZJL, nt2);
                            double pc = douDbsTaoya / douDbsWellDepth;
                            sz.SZF_wt(pd, pa, vgain, douZjyDensity, douZjyPL, dep, tgxDep, x1, x2, 0, D, douZtSize, douDrZWL, douWellTemp, pc,tw);
                            double Q = sz.getQyj();//压井排量
                            double pp = sz.getPp();//地层压力
                            double pm1 = sz.getyjden();//压井泥浆密度
                            double pti = sz.getPti();//初始循环压力
                            double ptf = sz.getPtf();//终了循环压力
                            double pamax = sz.getpamax();//最大套压
                                                         // double vgainmax = sz.getVgainmax();//泥浆池最大增量
                            double pyx = sz.getPyx();//井口最大允许套压
                            double ovtime = sz.getOvtime();//溢流到井口时间
                            double shigongTime = sz.getShigongTime();//压井施工时间-------------------------------输出数据7
                            double[] pat = sz.getPat();
                            double[] pdt = sz.getPdt();
                            double[] tyjp = sz.gettyjp();
                            double[] tyjd = sz.gettyjd();

                         //   Form11 ff = new Form11(Q, pp, pm1, pti, ptf, pamax, pyx, ovtime, shigongTime, pat, pdt, tyjp, tyjd);
                         //   ff.Show();


                        }
                    }
                    if (ss == "gas" && type == "no")
                    {
                        if (radioButton9.Checked == true)//推荐压回法
                        {
                            /// <summary>
                            /// 定向井-----钻进---8倍（气高硫化氢）---压回法--不压破
                            /// </summary>

                            //钻进 8倍
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1);
                            int re = s.Pressure_back_with_trace_8Time_ZuanJin(NT,shen,alfa,fai);
                            if (re == 1)
                            {
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
                                f.Show();


                            }
                            else
                            {
                                MessageBox.Show("会压破，有风险,请选用工程师法");

                            }
                        }
                        if (radioButton6.Checked == true)//工程师法
                        {
                            /// <summary>
                            /// 定向井-----钻进---8倍（气高硫化氢）---压破 --工程师法
                            /// </summary>
                            EngMethod me = new EngMethod(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter,
                            douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, 0, ss, dens);
                            me.directionWell(ss, dens,tw,shen,alfa,fai,NT);
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


                        }
                        if (radioButton5.Checked == true)//置换法
                        {
                            /// <summary>
                            /// 定向井-----钻进---气高硫化氢---置换法
                            /// </summary>
                        /*    double[] V = new double[15];    //注入压井液的体积
                            double[] PPa = new double[15];  //注入压井液之后的套管压力
                            double[] Pcha = new double[15];  //释放气体后的压力
                            ReplacementMethod p = new ReplacementMethod();
                            p.Replacement_method_with_trace_wdp(NT,dep, tgxDep, douZtSize, douZgOutterDiameter, pa, 0, douWellTemp, douZjyDensity, vgain, douZjyPL, x1, x2, ref V, ref PPa, ref Pcha, ztl);
                            Form15 po = new Form15(V, PPa, Pcha);
                            po.Show();*/
                        }
                        if (radioButton10.Checked == true)//司钻法

                        {
                            /// <summary>
                            ///定向井-----钻进---气高硫化氢--司钻法
                            /// </summary>


                            string lo = "select 内径 from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            DataSet n = SQLHelper.read(lo);
                            string lo2 = "select 外径  from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            string lo3 = "select 长度 from [dbo].[Sheet4$] where 工程编号='" + yy + "' and 钻具名称 ='钻杆'";
                            DataSet n2 = SQLHelper.read(lo2);
                            DataSet n3 = SQLHelper.read(lo3);
                            List<double> ZJI = new List<double>();
                            List<double> ZJO = new List<double>();
                            List<double> ZJL = new List<double>();
                            for (int i = 0; i < n.Tables[0].Rows.Count; i++)
                            {
                                ZJL.Add(Convert.ToDouble(n3.Tables[0].Rows[i]["长度"]));
                                ZJI.Add(Convert.ToDouble(n.Tables[0].Rows[i]["内径"]));
                                ZJO.Add(Convert.ToDouble(n2.Tables[0].Rows[i]["外径"]));
                            }
                            int nt2 = n.Tables[0].Rows.Count;
                            SZmethod sz = new SZmethod();
                            sz.SZMethod(yy, yy, xx, ss, ZJI, ZJO, ZJL, nt2);
                            double pc = douDbsTaoya / douDbsWellDepth;
                            sz.SZF_wt(pd, pa, vgain, douZjyDensity, douZjyPL, dep, tgxDep, x1, x2, 0, D, douZtSize, douDrZWL, douWellTemp, pc,tw);
                            double Q = sz.getQyj();//压井排量
                            double pp = sz.getPp();//地层压力
                            double pm1 = sz.getyjden();//压井泥浆密度
                            double pti = sz.getPti();//初始循环压力
                            double ptf = sz.getPtf();//终了循环压力
                            double pamax = sz.getpamax();//最大套压
                                                         // double vgainmax = sz.getVgainmax();//泥浆池最大增量
                            double pyx = sz.getPyx();//井口最大允许套压
                            double ovtime = sz.getOvtime();//溢流到井口时间
                            double shigongTime = sz.getShigongTime();//压井施工时间-------------------------------输出数据7
                            double[] pat = sz.getPat();
                            double[] pdt = sz.getPdt();
                            double[] tyjp = sz.gettyjp();
                            double[] tyjd = sz.gettyjd();
//
                        //    Form11 ff = new Form11(Q, pp, pm1, pti, ptf, pamax, pyx, ovtime, shigongTime, pat, pdt, tyjp, tyjd);
                        //    ff.Show();

                        }
                    }
                }




                ////////一下为空井工况


















                else if (no == "空井")
                {
                    if (ss != "gas")
                    {
                        if (radioButton9.Checked == true)//压回法
                        {
                            /// <summary>
                            /// 空井-----定向井---油水--压回法
                            /// </summary>
                            double D = douZtSize * (douWellEyeKDL + 1);
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1, 0);
                            s.Pressure_back_with_trace_4Time(NT,shen,alfa,fai);

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

                            Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                            f.Show();


                        }
                        if (radioButton5.Checked == true)//置换法
                        {
                            MessageBox.Show("非法操作");





                        }
                        if (radioButton6.Checked == true)//工程师法

                        {
                            /// <summary>
                            /// 空井-----定向井---油水--工程师法
                            /// </summary>
                            /// 抢下钻具 当 钻进用
                            /// 
                            string name = "工程";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();


                        }
                        if (radioButton10.Checked == true)
                        {
                            /// <summary>
                            /// 空井-----直井---油水--司钻法
                            /// </summary>
                            /// 抢下钻具 当钻进用
                            /// 

                            string name = "司钻";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();



                        }
                    }
                    if (ss == "gas" && type == "yes")
                    {
                        if (radioButton5.Checked == true)//置换法
                        {
                            /// <summary>
                            /// 空井-----直井---气--置换法
                            /// </summary>
                            /// 
                         /*   double[] V = new double[15];    //注入压井液的体积
                            double[] PPa = new double[15];  //注入压井液之后的套管压力
                            double[] Pcha = new double[15];  //释放气体后的压力
                            ReplacementMethod p = new ReplacementMethod();
                            p.Replacement_method_with_trace_wodp(NT,dep, tgxDep, douZtSize, douZgOutterDiameter, pa, 0, douWellTemp, douZjyDensity, vgain, douZjyPL, x1, x2, ref V, ref PPa, ref Pcha);
                            Form15 po = new Form15(V, PPa, Pcha);
                            po.Show();*/

                        }
                        if (radioButton6.Checked == true)//工程师法

                        {
                            /// <summary>
                            /// 空井-----直井---气--工程师法
                            /// </summary>
                            /// 抢下钻具 当钻进用
                            /// 
                            string name = "工程";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();

                        }
                        if (radioButton10.Checked == true)//司钻法
                        {
                            /// <summary>
                            /// 空井-----直井---气--司钻法
                            /// </summary>
                            /// 抢下钻具 当钻进用 
                            /// 
                            string name = "司钻";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();

                        }
                         if (radioButton9.Checked == true)//压回法
                        {
                            /// <summary>
                            /// 空井-----直井---气--8倍压回法
                            /// </summary>
                            double D = douZtSize * (douWellEyeKDL + 1);
                            ztl = 0;
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1);
                            s.Pressure_back_8Time();
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

                            Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                            f.Show();


                        }
                    }
                    if (ss == "gas" && type == "no")
                    {
                        if (radioButton5.Checked == true)//置换法
                        {
                            /// <summary>
                            /// 空井-----直井---气--置换法
                            /// </summary>
                            double[] V = new double[15];    //注入压井液的体积
                            double[] PPa = new double[15];  //注入压井液之后的套管压力
                            double[] Pcha = new double[15];  //释放气体后的压力
                            ReplacementMethod p = new ReplacementMethod();
                            p.Replacement_method_wodp(dep, tgxDep, douZtSize, douZgOutterDiameter, pa, 0, douWellTemp, douZjyDensity, vgain, douZjyPL, x1, x2, ref V, ref PPa, ref Pcha);
                            Form15 po = new Form15(V, PPa, Pcha);
                            po.Show();
                        }
                        if (radioButton6.Checked == true)//工程师法

                        {
                            /// <summary>
                            /// 空井-----直井---气--工程师法
                            /// </summary>
                            /// 抢下钻具 当钻进用 
                            string name = "工程";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();

                        }
                        if (radioButton10.Checked == true)//司钻法
                        {
                            /// <summary>
                            /// 空井-----直井---气--司钻法
                            /// </summary>
                            /// 抢下钻具 当钻进用 
                            string name = "司钻";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();
                        }
                        if (radioButton9.Checked == true)//压回法
                        {
                            /// <summary>
                            /// 空井-----直井---气--压回法
                            /// </summary>
                            double D = douZtSize * (douWellEyeKDL + 1);

                            ztl = 0;
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1);
                            s.Pressure_back_8Time();
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

                            Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                            f.Show();


                        }
                    }
                }





                //////////////////起下钻



                else
                {

                    if (radioButton1.Checked == true)
                    {
                        double Yjdenmax = 0;
                        double Yjdenmin = 0;
                        isZjyDensityConfigJudge.isZjyDensityConfigJudge_ZhiJing(ztl, tgxDep, dens, x2, dep, pa, D, douZgOutterDiameter, vgain, douZjyDensity, hg, ref Yjdenmin, ref Yjdenmax);

                        Form16 fn = new Form16(Yjdenmax, Yjdenmin, ss, xx, yy, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity,
                 douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa,
               vgain, dens, companyName, drillingCrewName, tw, no, ztl, type, hg);
                        fn.Show();
                    }
                    if (ss != "gas")
                    {
                        if (radioButton9.Checked == true)
                        {
                            /// <summary>
                            /// 起下钻-----直井---油水--压回
                            /// </summary>
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1, 0);
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

                            Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                            f.Show();

                        }
                        if (radioButton6.Checked == true)
                        {
                            /// <summary>
                            /// 起下钻-----直井---油水--工程师  抢下钻具
                            /// </summary>
                            string name = "工程";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();
                        }
                        if (radioButton10.Checked == true)
                        {
                            /// <summary>
                            /// 起下钻-----直井---油水--司钻法 抢下钻具

                            /// </summary>
                            string name = "司钻";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();
                        }
                        if (radioButton5.Checked == true)
                        {
                            MessageBox.Show("非法操作");
                        }
                    }
                    if (ss == "gas" && type == "yes")
                    {
                        if (radioButton5.Checked == true)//推荐置换法
                        {
                            /// <summary>
                            /// 起下钻-----直井---气--置换法
                            /// </summary>
                            double[] V = new double[15];    //注入压井液的体积
                            double[] PPa = new double[15];  //注入压井液之后的套管压力
                            double[] Pcha = new double[15];  //释放气体后的压力
                            ReplacementMethod p = new ReplacementMethod();
                            p.Replacement_method_wdp(dep, tgxDep, douZtSize, douZgOutterDiameter, pa, 0, douWellTemp, douZjyDensity, vgain, douZjyPL, x1, x2, ref V, ref PPa, ref Pcha, ztl);
                            Form15 po = new Form15(V, PPa, Pcha);
                            po.Show();
                        }
                        if (radioButton6.Checked == true)//抢下钻具 工程师
                        {
                            /// <summary>
                            /// 起下钻-----直井---气--工程师 
                            /// </summary>
                            string name = "工程";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();
                        }
                        if (radioButton10.Checked == true)//抢下司钻法
                        {
                            /// <summary>
                            /// 起下钻-----直井---气--司钻法
                            /// </summary>
                            string name = "司钻";
                            MessageBox.Show("抢下钻具");
                            Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                            fx.Show();
                        }
                        if (radioButton9.Checked == true)//压回 八倍 
                        {
                            /// <summary>
                            /// 起下钻-----直井---气--压回
                            /// </summary>
                            double D = douZtSize * (douWellEyeKDL + 1);
                            Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1);
                            s.Pressure_back_8Time();
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

                            Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                            f.Show();

                        }
                        if (ss == "gas" && type == "no")
                        {
                            if (radioButton9.Checked == true)//压回 八倍 推荐
                            {
                                /// <summary>
                                /// 起下钻-----直井---气--压回
                                /// </summary>
                                double D = douZtSize * (douWellEyeKDL + 1);
                                Pressure_back_killing s = new Pressure_back_killing(yy, yy, xx, ss, dep, pd, pa, D, douZgOutterDiameter, vgain, douZjyDensity, douZjyPL, ztl, x2, tgxDep, x1);
                                s.Pressure_back_8Time();
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

                                Form13 f = new Form13(yy, dep, douZjyDensity, douZjyPL, pd, pa, yjden, Qyj, patmax, atyj, ss, pp, vyj, tyj, pat, t1, t2);
                                f.Show();

                            }
                            if (radioButton5.Checked == true)//置换法
                            {
                                /// <summary>
                                /// 起下钻-----直井---气--置换法

                                /// </summary>

                                double[] V = new double[15];    //注入压井液的体积
                                double[] PPa = new double[15];  //注入压井液之后的套管压力
                                double[] Pcha = new double[15];  //释放气体后的压力
                                ReplacementMethod p = new ReplacementMethod();
                                p.Replacement_method_wdp(dep, tgxDep, douZtSize, douZgOutterDiameter, pa, 0, douWellTemp, douZjyDensity, vgain, douZjyPL, x1, x2, ref V, ref PPa, ref Pcha, ztl);
                                Form15 xp = new Form15(V, PPa, Pcha);
                                xp.Show();


                            }
                            if (radioButton6.Checked == true)//抢下钻具 工程师
                            {
                                /// <summary>
                                /// 起下钻-----直井---气--工程师 
                                /// </summary>
                                string name = "工程";
                                MessageBox.Show("抢下钻具");
                                Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                                fx.Show();
                            }
                            if (radioButton10.Checked == true)//抢下司钻法
                            {
                                /// <summary>
                                /// 起下钻-----直井---气--司钻法
                                /// </summary>
                                string name = "司钻";
                                MessageBox.Show("抢下钻具");
                                Form5 fx = new Form5(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter, douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, ss, dens, name, no, 0, 0);
                                fx.Show();
                            }
                        }


                    }
                }




            }

            //-------------------------------




        }
    }
}

    

