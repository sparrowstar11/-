using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using 石油专家管理系统.Calcuation;

namespace 石油专家管理系统
{
    public partial class Form5 : Form
    {
        Form1 f1;
        int temp=0;
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
        double Qyj;
        double userdens;
        double[] shen = { 0 };
        double[] alfa = { 0 };
        string name;
        double[] fai = { 0 };
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
        public Form5(string yy, string xx,double  dep,double tgxDep,double douWellTemp,double douTgDiameter,double douZtSize, double douWellEyeKDL,double douZjyDensity,double douZjyPL,double douDrZWL,double douDbsWellDepth,double douDbsTaoya,double douDbsPL,double douZgOutterDiameter, double douZgWallThickness,double pd,double pa,double vgain,string companyName,string drillingCrewName,double [,] tw,double[] shen, double []alfa,double [] fai,string ss,double dens,string name,string no,double userdens,double Q)
       
        {
            InitializeComponent();
            this.yy = yy;
            this.xx = xx;
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
            this.drillingCrewName = drillingCrewName;
            this.tw = tw;
            this.shen = shen;
            this.alfa = alfa;
            this.fai = fai;
            this.ss = ss;
            this.dens = dens;
            this.name = name;
            this.no = no;
            this.Qyj = Q;
            this.userdens = userdens;
            button15.Text = "压井计算";
            temp = 1;
        }
        public Form5()
        {
            InitializeComponent();
        }
        private void button15_Click(object sender, EventArgs e)
        {
        
            if (temp==1)
            {

                if(xx=="直井")
                {
                    if (no == "空井" && name == "工程" || no == "起下钻" && name == "工程")
                    {
                        string s6 = "select 外径 from [dbo].[Sheet4$] where 工程编号='" + yy + "'and 钻具名称='钻杆'";
                        string s16 = "select 壁厚 from [dbo].[Sheet4$] where 工程编号='" + yy + "'and 钻具名称='钻杆'";
                        string s7 = "select sum(长度) 总长 from [dbo].[Sheet4$] where 工程编号='" + yy + "' ";
                        DataSet read6 = SQLHelper.read(s6);
                        DataSet read7 = SQLHelper.read(s7);
                        DataSet read16 = SQLHelper.read(s16);
                        douZgOutterDiameter = Convert.ToDouble(read6.Tables[0].Rows[0]["外径"]);
                        ztl = Convert.ToDouble(read7.Tables[0].Rows[0]["总长"]);
                        douZgWallThickness = Convert.ToDouble(read16.Tables[0].Rows[0]["壁厚"]);
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
                    if (no == "空井" && name == "司钻" || no == "起下钻" && name == "司钻")
                    {

                        string s6 = "select 外径 from [dbo].[Sheet4$] where 工程编号='" + yy + "'and 钻具名称='钻杆'";
                        string s16 = "select 壁厚 from [dbo].[Sheet4$] where 工程编号='" + yy + "'and 钻具名称='钻杆'";
                        string s7 = "select sum(长度) 总长 from [dbo].[Sheet4$] where 工程编号='" + yy + "' ";
                        DataSet read6 = SQLHelper.read(s6);
                        DataSet read7 = SQLHelper.read(s7);
                        DataSet read16 = SQLHelper.read(s16);
                        douZgOutterDiameter = Convert.ToDouble(read6.Tables[0].Rows[0]["外径"]);
                        ztl = Convert.ToDouble(read7.Tables[0].Rows[0]["总长"]);
                        douZgWallThickness = Convert.ToDouble(read16.Tables[0].Rows[0]["壁厚"]);
                        double D = douZtSize * (douWellEyeKDL + 1);
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

                     //   Form11 ff = new Form11(Q, pp, pm1, pti, ptf, pamax, pyx, ovtime, shigongTime, pat, pdt, tyjp, tyjd);
                    //    ff.Show();
                        this.Close();
                        this.Dispose();
                    }

                    if (no == "起下钻" && (name != "工程" && name != "司钻"))
                    {

                        double T1 = 0;
                        double Tz = 0;
                        double pp = 0;
                        double Pd0 = 0;
                        double Pd1 = 0;
                        int NT1 = 0;//定向井数据
                        EngMethod me = new EngMethod(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter,
                   douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, 0, ss, dens);
                        me.EngMethod_QiXiaZuan_Big(NT1, userdens, ztl, ref Qyj, ref T1, ref Tz, ref pp, ref Pd0, ref Pd1);
                        MessageBox.Show(Qyj.ToString() + " " + T1.ToString());
                    }
                }/*
                else
                {
                    if (no == "空井" && name == "工程" || no == "起下钻" && name == "工程")
                    {
                        string s6 = "select 外径 from [dbo].[Sheet4$] where 工程编号='" + yy + "'and 钻具名称='钻杆'";
                        string s16 = "select 壁厚 from [dbo].[Sheet4$] where 工程编号='" + yy + "'and 钻具名称='钻杆'";
                        string s7 = "select sum(长度) 总长 from [dbo].[Sheet4$] where 工程编号='" + yy + "' ";
                        DataSet read6 = SQLHelper.read(s6);
                        DataSet read7 = SQLHelper.read(s7);
                        DataSet read16 = SQLHelper.read(s16);
                        douZgOutterDiameter = Convert.ToDouble(read6.Tables[0].Rows[0]["外径"]);
                        ztl = Convert.ToDouble(read7.Tables[0].Rows[0]["总长"]);
                        douZgWallThickness = Convert.ToDouble(read16.Tables[0].Rows[0]["壁厚"]);
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
                        this.Dispose();
                    }
                    if (no == "空井" && name == "司钻" || no == "起下钻" && name == "司钻")
                    {

                        string s6 = "select 外径 from [dbo].[Sheet4$] where 工程编号='" + yy + "'and 钻具名称='钻杆'";
                        string s16 = "select 壁厚 from [dbo].[Sheet4$] where 工程编号='" + yy + "'and 钻具名称='钻杆'";
                        string s7 = "select sum(长度) 总长 from [dbo].[Sheet4$] where 工程编号='" + yy + "' ";
                        DataSet read6 = SQLHelper.read(s6);
                        DataSet read7 = SQLHelper.read(s7);
                        DataSet read16 = SQLHelper.read(s16);
                        douZgOutterDiameter = Convert.ToDouble(read6.Tables[0].Rows[0]["外径"]);
                        ztl = Convert.ToDouble(read7.Tables[0].Rows[0]["总长"]);
                        douZgWallThickness = Convert.ToDouble(read16.Tables[0].Rows[0]["壁厚"]);
                        double D = douZtSize * (douWellEyeKDL + 1);
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

                        Form11 ff = new Form11(Q, pp, pm1, pti, ptf, pamax, pyx, ovtime, shigongTime, pat, pdt, tyjp, tyjd);
                        ff.Show();
                        this.Close();
                        this.Dispose();
                    }
                    if (no == "起下钻" && (name != "工程" && name != "司钻"))
                    {

                        double T1 = 0;
                        double Tz = 0;
                        double pp = 0;
                        double Pd0 = 0;
                        double Pd1 = 0;
                        int NT1 = 300;//定向井数据
                        EngMethod me = new EngMethod(yy, xx, dep, tgxDep, douWellTemp, douTgDiameter, douZtSize, douWellEyeKDL, douZjyDensity, douZjyPL, douDrZWL, douDbsWellDepth, douDbsTaoya, douDbsPL, douZgOutterDiameter,
                   douZgWallThickness, pd, pa, vgain, companyName, drillingCrewName, tw, shen, alfa, fai, 0, ss, dens);
                        me.EngMethod_QiXiaZuan_Big(NT1, userdens, ztl, ref Qyj, ref T1, ref Tz, ref pp, ref Pd0, ref Pd1);
                        MessageBox.Show(Qyj.ToString() + " " + T1.ToString());
                    }


                }*/







             
            }
            else
            {
                 this.pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\组合效果2.png");
            }
         
            
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
            string s;
            if (temp == 0)
            {
                s = "insert into [dbo].[Sheet4$] (钻具名称,钻具型号,外径,内径,壁厚,长度,工程编号,工况) values('" + comboBox1.SelectedItem + "','" + comboBox2.SelectedItem + "','" + wl + "','" + nl + "','" + bh + "','" + textBox1.Text + "','" + f1.label3.Text + "','" + comboBox3.Text + "')";
            }
            else
            {
                 s = "insert into [dbo].[Sheet4$] (钻具名称,钻具型号,外径,内径,壁厚,长度,工程编号,工况) values('" + comboBox1.SelectedItem + "','" + comboBox2.SelectedItem + "','" + wl + "','" + nl + "','" + bh + "','" + textBox1.Text + "','" + yy+ "','" + comboBox3.Text + "')";

            }
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
            string s;
            if(temp==0)
            {
                s = "select * from [dbo].[Sheet4$] where 工程编号='" + f1.label3.Text + "'";
            }
            else
            {
                 s = "select * from [dbo].[Sheet4$] where 工程编号='" + yy+ "'";
            }
          
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
            string selectsql;
            if(temp==0)
            {
                selectsql = "Select *   from [dbo].[Sheet4$] where 工程编号='" + f1.label3.Text + "'";
            }
            else
            {
                selectsql = "Select *   from [dbo].[Sheet4$] where 工程编号='" + yy + "'";
            }
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
