using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 石油专家管理系统.Calcuation
{
    class Pressure_back_killing
    {
        private const double PI = 3.1415926;
        private const double g = 9.81;
        private const int NT = 300;

        //1.基础参数---------------------
        private string strWellNo;//井号------输入1
        private string strProjID;//工程号------输入2
        private string strWellType;//井型---直井，水平井，定向井  ------输入3
        private string companyName;
        private string drillingCrewName;
        private string oiltype = "";  //判断流体类型：气体，液体！！！！！！！！！！！！！！！------输入4
        private double h;//井深------输入5
        private double hcs;//垂深 
        private int nt;           //300组井眼轨迹数 
        private double Pd;   //关井立管压力。-----------输入5
        private double Pa;   //关井套管压力 Pa-------------初始井口压力----------输入6
        private double Pp;   //地层压力。-----------输入5
        private double D;  //井眼直径 mm------输入7
        private double Dp;   //钻杆外径 mm
        private double Dly;   //钻头尺寸 mm 
        private double Vgain;    //溢流体积------输入8
        private double zjden;  //钻井液密度 Kg/m^3------输入9
        private double Qzj;   // 钻井排量 m^3/s------输入10 
        private double ztl;  //钻头位置深度--全压回时用
        private double Pbs;//套管鞋破裂压力
        private double hshoe;//套管鞋深度
        private double htx;//套管鞋深度
        private double denyl;//溢流密度
        private double douJkEdYl;//井口承压 
        private double hly; //裸眼长度


        private double ZtingLength;//钻铤累加长度
        private double ZganLength = 0;//钻杆累加长度

        private double Pm;//钻井液密度
        private double qn;//钻井液排量  
        private string steelNo;//钢级  
        private double Vdz;//钻具内容积 
        private double vhz1;    //环空总容积
        private double vjt;    //井筒总容积
        private double m_TaoGuanKangNeiYa;//套管抗内压强度
        private double m_LyPlYl;//裸眼薄弱地层破裂压力 
        private double m_maxGJYl;//最大允许关井套压


        //-------------定义输出变量-------------
        private List<double> Pat = new List<double>();  //套压变化数组，需要画图,数组画出来就ok（随脚标）------输出1
        private List<double> atyj = new List<double>();  //压井施工时间---new add ------------输出 --画图 
        private double Qyj = 0;     //压井排量------输出2
        private double Patmax = 0;  //最大套压------输出3   //最大施工泵压 // Pat（1）
        private double tyj = 0;  //压井施工时间------输出4
        private double yjden = 0;   //压井液密度 kg/m^3------输出5  
        private double Vyj = 0;  //压井泥浆量，从外面调进来了-------输出 //压井液总量：
        private double t2 = 0;  //漏失完水的时间，输出，画图（4倍压回法时用，见流程图）
        private double t1 = 0;  //压缩气的时间，输出，画图（钻进时压回法用，见流程图） ----
        private double Pderta = 0;  //渗流阻力，Mpa-----输出（4倍时用，见流程图） 

        private double vlyz;// //裸眼段总容积


        private double hw;//井底溢流高度
        private double pp;  //地层压力
        private double ddden;  // 附加当量钻井液密度
        private double deltP;   //压井中井底附加安全压力：
        private double Qyjmax;//压井排量
        private double Qyjmin;//防止气体上窜最低压井排量

        /// <param name="NT2"></param>钻具组合组数
        /// <param name="ZJI"></param>钻杆内径,mm
        /// <param name="ZJO"></param>钻杆外径,mm
        /// <param name="ZJL"></param>钻杆长度，m
        List<double> ZJI;
        List<double> ZJO;
        List<double> ZJL;
        int NT2;



        //---溢流同层-----------------------------------------------------
        private double douDrZWL;//地热增温率
        private double douDbsWellDepth;//低泵速井深
        private double douDbsTaoya;//低泵速套压
        private double Ts;//井口温度---基础数据中 
                          //压回11补充
        private List<double> tdlp = new List<double>();//堵漏泵压曲线：tdlp[0-3] 与Pat[0-3] 
                                                       /// <summary>
                                                       /// 构造方法--无参
        public Pressure_back_killing()
        {

        }
        /// </summary>
        ///  <param name="oiltype">地层流体类型</param>
        /// <param name="h">井深</param>
        /// <param name="Pd">关井立压</param>
        /// <param name="Pa">关井套管压力</param>
        /// <param name="D">井眼直径</param>
        /// <param name="Dp">钻杆外径</param>
        /// <param name="Dly">钻头尺寸</param>
        /// <param name="hd">低泵速实验井深m</param>
        /// <param name="pcd">低泵速情况下循环压耗 Pa</param>
        /// <param name="Vgain">溢流体积</param>
        /// <param name="zjden">钻井液密度 Kg/m^3</param>
        /// <param name="Qzj">钻井排量 m^3/s</param>
        /// <param name="Pbs">套管鞋破裂压力 Pa</param>
        /// <param name="hshoe">套管鞋深度 Pa</param> 
        /// <param name="denyl">溢流流体密度</param>
        public Pressure_back_killing(string strWellID, string strProjID, string strWellType, string oiltype,
                                       double h, double Pd, double Pa, double D,
                                       double Dp, double Vgain, double zjden, double Qzj, double ztl,
                                       double Pbs, double hshoe, double douJkEdYl)
        {
            this.strWellNo = strWellID;
            this.strProjID = strProjID;
            this.strWellType = strWellType;
            this.h = h;
            this.Pd = Pd;
            this.Pa = Pa;
            this.D = D;
            this.Vgain = Vgain;
            this.zjden = zjden;
            this.Qzj = Qzj;
            this.ztl = ztl;
            this.oiltype = oiltype;
            this.Pbs = Pbs;
            this.hshoe = hshoe;
            this.douJkEdYl = douJkEdYl;//井口耐压值



        }





        /// <summary>
        /// 8.27----适用于钻进工况、起下钻的油水工况
        /// </summary>
        /// <param name="strWellID"></param>
        /// <param name="strProjID"></param>
        /// <param name="strWellType"></param>
        /// <param name="oiltype"></param>
        /// <param name="h"></param>
        /// <param name="Pd"></param>
        /// <param name="Pa"></param>
        /// <param name="D"></param>
        /// <param name="Dp"></param>
        /// <param name="Vgain"></param>
        /// <param name="zjden"></param>
        /// <param name="Qzj"></param>
        /// <param name="ztl"></param>
        /// <param name="Pbs"></param>
        /// <param name="hshoe"></param>
        /// <param name="douJkEdYl"></param>
        /// <param name="Dly"></param>
        public Pressure_back_killing(string strWellID, string strProjID, string strWellType, string oiltype,
                                     double h, double Pd, double Pa, double D,
                                     double Dp, double Vgain, double zjden, double Qzj, double ztl,
                                     double Pbs, double hshoe, double douJkEdYl, double Dly)
        {
            this.strWellNo = strWellID;
            this.strProjID = strProjID;
            this.strWellType = strWellType;
            this.h = h;
            this.Pd = Pd;
            this.Pa = Pa;
            this.D = D;
            this.Vgain = Vgain;
            this.zjden = zjden;
            this.Qzj = Qzj;
            this.ztl = ztl;
            this.oiltype = oiltype;
            this.Pbs = Pbs;
            this.hshoe = hshoe;
            this.douJkEdYl = douJkEdYl;//井口耐压值
            this.Dly = Dly;


        }

        //10.7-压井施工单
        /// <param name="Dly">裸眼直径</param>
        /// <param name="D">井眼直径，套管直径</param>
        /// <param name="htx">套管鞋深度</param>
        public Pressure_back_killing(string strWellID, string strProjID, string strWellType, string oiltype,
                                    double h, double Pd, double Pa, double D,
                                    double Dp, double Vgain, double zjden, double Qzj, double ztl,
                                    double Pbs, double hshoe, double Dly,
                                    string companyName, string drillingCrewName, double ZtingLength,
                                    List<double> ZJL, double douTgxPlYl, double douJkEdYl, double douTgKNYl, string steelNo,
                                   List<double> ZJI, List<double> ZJO, int NT2)
        {
            this.strWellNo = strWellID;
            this.strProjID = strProjID;
            this.strWellType = strWellType;
            this.h = h;
            this.Pd = Pd;
            this.Pa = Pa;
            this.D = D;
            this.Vgain = Vgain;
            this.zjden = zjden;
            this.Qzj = Qzj;
            this.ztl = ztl;
            this.oiltype = oiltype;
            this.Pbs = Pbs;
            this.hshoe = hshoe;

            this.douJkEdYl = douJkEdYl;//井口耐压值
            this.Dly = Dly;
            this.companyName = companyName;
            this.drillingCrewName = drillingCrewName;
            //钻铤累加长度
            this.ZtingLength = ZtingLength;
            //钻杆累加长度
            for (int i = 0; i < ZJL.Count; i++)
            {
                this.ZganLength = this.ZganLength + ZJL[i];
            }
            m_TaoGuanKangNeiYa = douTgKNYl;//套管抗内压强度
            m_LyPlYl = douTgxPlYl;//裸眼薄弱地层破裂压力 
            this.steelNo = steelNo;//钢级  
            if (oiltype == "oil")
            {
                this.ddden = 0;  // 附加当量钻井液密度
            }
            else
            {
                this.ddden = 0.05;  // 附加当量钻井液密度
            }

            this.ZJI = ZJI;
            this.ZJO = ZJO;
            this.ZJL = ZJL;
            this.NT2 = NT2;


        }



        ///8.28 适用于起下钻的高含硫气体工况
        public Pressure_back_killing(string strWellID, string strProjID, string strWellType, string oiltype,
                                    double h, double Pd, double Pa, double D,
                                    double Dp, double Vgain, double zjden, double Qzj, double ztl,
                                    double Pbs, double hshoe, double douJkEdYl, double Dly,
                                       List<double> ZJI, List<double> ZJO, List<double> ZJL, int NT2)
        {
            this.strWellNo = strWellID;
            this.strProjID = strProjID;
            this.strWellType = strWellType;
            this.h = h;
            this.Pd = Pd;
            this.Pa = Pa;
            this.D = D;
            this.Vgain = Vgain;
            this.zjden = zjden;
            this.Qzj = Qzj;
            this.ztl = ztl;
            this.oiltype = oiltype;
            this.Pbs = Pbs;
            this.hshoe = hshoe;
            this.douJkEdYl = douJkEdYl;//井口耐压值
            this.Dly = Dly;
            this.ZJI = ZJI;
            this.ZJO = ZJO;
            this.ZJL = ZJL;
            this.NT2 = NT2;

        }
        public Pressure_back_killing(string strWellID, string strProjID, string strWellType, string oiltype,
                                    double h, double Pd, double Pa, double D,
                                    double Dp, double Vgain, double zjden, double Qzj, double ztl, double douJkEdYl)
        {
            this.strWellNo = strWellID;
            this.strProjID = strProjID;
            this.strWellType = strWellType;
            this.h = h;
            this.Pd = Pd;
            this.Pa = Pa;
            this.D = D;
            this.Vgain = Vgain;
            this.zjden = zjden;
            this.Qzj = Qzj;
            this.ztl = ztl;
            this.oiltype = oiltype;

        }


        //溢流同层
        public Pressure_back_killing(string strWellID, string strProjID, string strWellType, string oiltype,
                                 double h, double Pd, double Pa, double D,
                                 double Dp, double Vgain, double zjden, double Qzj, double ztl,
                                 double Pbs, double hshoe, double Dly,
                                 string companyName, string drillingCrewName, double ZtingLength,
                                 List<double> ZJL, double douTgxPlYl, double douJkEdYl, double douTgKNYl, string steelNo,
                                List<double> ZJI, List<double> ZJO, int NT2, double douWellTemp, double douDrZWL, double douDbsWellDepth, double douDbsTaoya)
        {
            this.strWellNo = strWellID;
            this.strProjID = strProjID;
            this.strWellType = strWellType;
            this.h = h;
            this.Pd = Pd;
            this.Pa = Pa;
            this.D = D;
            this.Vgain = Vgain;
            this.zjden = zjden;
            this.Qzj = Qzj;
            this.ztl = ztl;
            this.oiltype = oiltype;
            this.Pbs = Pbs;
            this.hshoe = hshoe;

            this.douJkEdYl = douJkEdYl;//井口耐压值
            this.Dly = Dly;
            this.companyName = companyName;
            this.drillingCrewName = drillingCrewName;
            //钻铤累加长度
            this.ZtingLength = ZtingLength;
            //钻杆累加长度
            for (int i = 0; i < ZJL.Count; i++)
            {
                this.ZganLength = this.ZganLength + ZJL[i];
            }
            m_TaoGuanKangNeiYa = douTgKNYl;//套管抗内压强度
            m_LyPlYl = douTgxPlYl;//裸眼薄弱地层破裂压力 
            this.steelNo = steelNo;//钢级  
            if (oiltype == "oil")
            {
                this.ddden = 0;  // 附加当量钻井液密度
            }
            else
            {
                this.ddden = 0.05;  // 附加当量钻井液密度
            }

            this.ZJI = ZJI;
            this.ZJO = ZJO;
            this.ZJL = ZJL;
            this.NT2 = NT2;
            this.Ts = douWellTemp;//井口温度
            this.douDrZWL = douDrZWL;//地热增温率
            this.douDbsWellDepth = douDbsWellDepth;//低泵速井深
            this.douDbsTaoya = douDbsTaoya;//低泵速套压

        }








        ////以下为方法主体，分为钻进压回，4倍压回（起下钻与空井的油水），8倍压回（起下钻与空井的气），with_trace即为定向井，压回法曲线输出方式见PDF




        /// <summary>
        /// 直井-----压回法8倍---钻进过程中---硫化氢
        /// </summary> 

        /// <param name="hd">低泵速实验井深m</param>
        /// <param name="pcd">低泵速情况下循环压耗 Pa</param>
        /// <param name="Vgain">溢流体积</param>
        /// <param name="zjden">钻井液密度 Kg/m^3</param>
        /// <param name="Qzj">钻井排量 m^3/s</param>
        /// <param name="Pat"></param>
        /// <param name="Patmax"></param> 
        /// <param name="Vyj">压井泥浆量 m^3</param>
        /// <param name="Pderta">渗流阻力 Mpa</param>
        /// <return>压漏判断，1不压漏，0压漏</return>
        public int Pressure_back_8Time_ZuanJin()
        {
            //----------返回值-----------
            int result_sfyl = 0;
            //----------定义变量，赋初值---------------
            double Cdpca = 0;   //单位长度井眼容积容积 

            //double Pp = 0;     //地层压力 Pp ,更改为计算，钻进根据Pd计算，落鱼和起下钻可根据 Pa 估算。

            double pc = 0;    //单位深度循环压耗  Pa/m         
            double hg = 0;       //气体长度 m
            double V2 = 0;    //达到地层压力时,气体体积

            double K = 15;  //地层渗透率，mD
            double u = 9;  //钻井液粘度 mPa.s
            double re = 1000;  //控制半径m
            double rw = (D / 2) / 1000; //井眼半径
            double hh = 10;  //储层厚度，m

            List<double> vt = new List<double>();
            List<double> pt = new List<double>();

            //-------------------------计算-------------------------
            // pc = pcd / hd;  //单位深度循环压耗  Pa/m
            Cdpca = Math.PI * (Math.Pow(D / 1000, 2) - Math.Pow(Dp / 1000, 2)) / 4;  //单位长度环空体积
            this.Qyj = Qzj / 2;   //压井排量-------------具体取值需要依据现场。
            Pp = Pd + zjden * g * h;   //地层压力 Pa   
            hg = Vgain / Cdpca;   //气体高度（长度） m                                            //初始时钻井液垂深
            this.yjden = zjden + 50;              //压回法压井液密度 Kg/m^3  0.05为h2s安全值
            Pderta = (Qyj * 1000) * u * Math.Log(re / rw) / (2 * PI * K * hh) * 1000000;  //++++++++++++++

            V2 = (Pa + zjden * g * (h - hg)) * Vgain / (Pp + Pderta);    //达到地层压力时,气体体积
            this.t1 = (Vgain - V2) / Qyj;  //第一阶段时间 气体量不变 p1*v1=p2*v2


            pt.Add(Pa + zjden * g * (h - hg));
            vt.Add(Vgain);
            Pat.Add(Pa); //初值对应0时刻i从1算

            //第一阶段，压缩阶段。
            for (int i = 1; i <= Math.Floor(t1); i++)
            {
                vt.Add(vt[i - 1] - Qyj);//vt[i]=vt[i-1]-Qyj;
                pt.Add(pt[i - 1] * vt[i - 1] / vt[i]);// pt[i]=pt[i-1]*vt[i-1]/vt[i];
                Pat.Add(pt[i] - zjden * g * (h - hg) - yjden * g * Qyj * i / Cdpca);   //压井时的套压
            }
            Pat.Add(Pa + Pderta);  //++++++++++++++

            //第二阶段开始漏失 假定以压井排量漏失
            this.t2 = V2 / Qyj;   //漏失完需要的时间

            Patmax = Pat[0];  //输出
            for (int i = 1; i <= 1 + t1; i++)
            {
                if (Pat[i] > Patmax)
                {
                    this.Patmax = Pat[i];
                }
            }

            Vyj = Vgain * 8;  //压井泥浆量，4倍。输出                
            this.tyj = Vyj / Qyj;  //压井施工时间，输出
            Pat.Add(Pderta + Pp - yjden * g * hg - zjden * g * (h - hg));
            Pat.Add(Pderta + Pp - yjden * g * Vyj / Cdpca - zjden * g * (h - Vyj / Cdpca));

            //停泵 套压为0  再用工程师法压井 循环钻井液.    
            double PPbs = 0;//临时存储套管鞋实际所受压力
            double h1 = 0;  //已压入的压井液折算深度
            h1 = Qyj * t1 / Cdpca;
            PPbs = Patmax + yjden * g * h1 + zjden * g * (hshoe - h1);
            if (Pbs >= PPbs)
            {
                result_sfyl = 1;  //不会压漏   返回1
            }
            else
            {
                result_sfyl = 0;   //会压漏   返回0
            }

            return result_sfyl;
        }

        /// <summary>
        /// 直井-----压回法---4倍压井---起下钻 & 落鱼 & 空井---油水---
        /// </summary> 
        ///  <param name="oiltype">地层流体类型</param>
        /// <param name="h">井深</param> 
        /// <param name="Pa">关井套管压力</param>
        /// <param name="D">井眼直径</param>
        /// <param name="Dp">钻杆外径</param>
        /// <param name="hd">低泵速实验井深m</param>
        /// <param name="pcd">低泵速情况下循环压耗 Pa</param>
        /// <param name="Vgain">溢流体积</param>
        /// <param name="zjden">钻井液密度 Kg/m^3</param>
        /// <param name="Qzj">钻井排量 m^3/s</param>
        /// <param name="Pat"></param>
        /// <param name="Patmax"></param> 
        /// <param name="Vyj">压井泥浆量 m^3</param>  
        /// <param name="Pderta">渗流阻力 Mpa</param>      
        public void Pressure_back_4Time()
        {

            //----------定义变量，赋初值---------------
            //double Cdpca = 0;   //单位长度井眼容积容积 
            //double Pderta = 0;  //渗流阻力
            double K = 15;  //地层渗透率，mD
            double u = 9;  //钻井液粘度 mPa.s
            double re = 1000;  //控制半径m+++++++++++++++++++++++
            double rw = (D / 2) / 1000; //井眼半径
            double hh = 10;  //储层厚度，m

            //double Pp = 0;     //地层压力 Pa ,更改为计算，钻进根据Pd计算，落鱼和起下钻可根据 Pa 估算。
            //double pc = 0;    //单位深度循环压耗  Pa/m         


            //List<double> vt = new List<double>();
            // List<double> pt = new List<double>();

            //-------------------------计算-------------------------
            //pc = pcd / hd;  //单位深度循环压耗  Pa/m
            // Cdpca = Math.PI * (Math.Pow(D / 1000, 2) - Math.Pow(Dp / 1000, 2)) / 4;  //单位长度环空体积        
            //Cdpca = Math.PI * (Math.Pow(D / 1000, 2)) / 4;  //单位长度井眼容积 ，下部

            Pderta = (Qyj * 1000) * u * Math.Log(re / rw) / (2 * PI * K * hh) * 1000000;  //+++++++++++

            this.Qyj = Qzj / 2;   //压井排量-------------具体取值需要依据现场。
            Pp = zjden * g * h;   //地层压力 Pa          
            this.yjden = zjden;              //压回法压井液密度 Kg/m^3

            //直接进入第二阶段，开始漏失，假定以压井排量漏失           
            Pat.Add(Pa + Pderta);
            Patmax = Pat[0];
            t2 = Vgain / Qyj;   //漏失完需要的时间                     
            Vyj = Vgain * 4;  //压井泥浆量，4倍。输出                
            this.tyj = Vyj / Qyj;  //压井施工时间，输出
            //停泵 套压为0  再用工程师法压井 循环钻井液.  

        }


        /// <summary>
        /// 直井-----压回法8倍---起下钻 & 落鱼 & 空井----硫化氢（空井时ztl设为0）
        /// </summary> 
        /// 
        /// <param name="h">井深</param>
        /// 
        /// <param name="Pd">井口立管压力</param>
        /// 
        /// <param name="Pa">关井套管压力</param>
        /// <param name="D">井眼直径</param>
        /// <param name="Dp">钻杆外径</param>
        /// <param name="hd">低泵速实验井深m</param>
        /// <param name="pcd">低泵速情况下循环压耗 Pa</param>
        /// <param name="Vgain">溢流体积</param>
        /// <param name="zjden">钻井液密度 Kg/m^3</param>
        /// <param name="Qzj">钻井排量 m^3/s</param>
        /// <param name="Pat"></param>
        /// <param name="Patmax"></param>
        /// 
        /// <param name="Vyj">压井泥浆量 m^3</param>
        /// <param name="ztl">钻头位置深度 m </param>
        /// <param name="Pderta">渗流阻力 Mpa</param>
        public void Pressure_back_8Time()
        {

            //----------定义变量，赋初值---------------
            double Cdpca1 = 0;   //单位长度井眼环空容积 ，上部
            double Cdpca2 = 0;   //单位长度井眼容积 ，下部
            double K = 15;  //地层渗透率，mD
            double u = 9;  //钻井液粘度 mPa.s
            double re = 1000;  //控制半径m
            double rw = (D / 2) / 1000; //井眼半径
            double hh = 10;  //储层厚度，m

            //double Pp = 0;     //地层压力 Pa ,更改为计算，钻进根据Pd计算，落鱼和起下钻可根据 Pa 估算。

            double pc = 0;    //单位深度循环压耗  Pa/m         
            double hg = 0;       //气体长度 m
            double V2 = 0;    //达到地层压力时,气体体积


            List<double> vt = new List<double>();
            List<double> pt = new List<double>();

            //-------------------------计算-------------------------
            //pc = pcd / hd;  //单位深度循环压耗  Pa/m           
            Cdpca1 = Math.PI * (Math.Pow(D / 1000, 2) - Math.Pow(Dp / 1000, 2)) / 4;  //单位长度井眼环空容积 ，上部
            Cdpca2 = Math.PI * (Math.Pow(D / 1000, 2)) / 4;  //单位长度井眼容积 ，下部
            if (ztl == 0) { Cdpca1 = Cdpca2; }  //空井，按井眼算。
            Pderta = (Qyj * 1000) * u * Math.Log(re / rw) / (2 * PI * K * hh) * 1000000;
            this.Qyj = Qzj / 2;   //压井排量-------------具体取值需要依据现场。
            Pp = zjden * g * h;   //地层压力 Pa   
            hg = Vgain / Cdpca2;   //气体高度（长度） m   ，假设低于钻头位置
            //初始时钻井液垂深
            this.yjden = zjden + 0.05;              //压回法压井液密度 Kg/m^3  0.05为h2s安全值

            V2 = (Pa + zjden * g * (h - hg)) * Vgain / (Pp);    //达到地层压力时,气体体积
            this.t1 = (Vgain - V2) / Qyj;  //第一阶段时间 气体量不变 p1*v1=p2*v2


            pt.Add(Pa + zjden * g * (h - hg));

            vt.Add(Vgain);

            Pat.Add(Pa); //初值对应0时刻i从1算

            //第一阶段，压缩阶段。
            for (int i = 1; i <= Math.Floor(t1); i++)
            {
                vt.Add(vt[i - 1] - Qyj);//vt[i]=vt[i-1]-Qyj;
                pt.Add(pt[i - 1] * vt[i - 1] / vt[i]);// pt[i]=pt[i-1]*vt[i-1]/vt[i];
                Pat.Add(pt[i] - zjden * g * ((h - hg) - Qyj * i / Cdpca1 + Qyj * i / Cdpca2) - yjden * g * Qyj * i / Cdpca1);   //压井时的套压
            }
            Pat.Add(Pa + Pderta);

            //第二阶段开始漏失 假定以压井排量漏失
            this.t2 = V2 / Qyj;   //漏失完需要的时间

            Patmax = Pat[0];  //输出
            for (int i = 1; i <= 1 + t1; i++)
            {
                if (Pat[i] > Patmax)
                {
                    this.Patmax = Pat[i];
                }
            }

            Vyj = Vgain * 8;  //压井泥浆量，4倍。输出                
            this.tyj = Vyj / Qyj;  //压井施工时间，输出
            //假设8倍压入后，压井液都还没到ztl位置
            Pat.Add(Pderta + Pp - yjden * g * Vgain / Cdpca1 - zjden * g * (h - Vgain / Cdpca1));  //一倍时
            Pat.Add(Pderta + Pp - yjden * g * Vyj / Cdpca1 - zjden * g * (h - Vyj / Cdpca1));  //八倍时

            //停泵 套压为0  再用工程师法压井 循环钻井液.    

        }





        /// <summary>
        /// 定向井-----压回法8倍---钻进过程中---硫化氢
        /// </summary>
        /// <param name="nt">离散点300</param>
        /// 
        /// <param name="Pd">井口立管压力</param>
        /// 
        /// <param name="Pa">关井套管压力</param>
        /// <param name="D">井眼直径</param>
        /// <param name="Dp">钻杆外径</param>
        /// <param name="hd">低泵速实验井深m</param>
        /// <param name="pcd">低泵速情况下循环压耗 Pa</param>
        /// <param name="Vgain">溢流体积</param>
        /// <param name="zjden">钻井液密度 Kg/m^3</param>
        /// <param name="Qzj">钻井排量 m^3/s</param>
        /// <param name="js">井深</param>
        /// <param name="jxj">井斜角</param>
        /// <param name="cs">垂深</param>
        /// <param name="Pat"></param>
        /// <param name="Patmax"></param>
        /// 
        /// <param name="Vyj">压井泥浆量 m^3</param>
        /// <param name="Pderta">渗流阻力 Mpa</param>
        public int Pressure_back_with_trace_8Time_ZuanJin(int nt, double[] js, double[] jxj, double[] cs)
        {
            //----------返回值-----------
            int result_sfyl = 0;
            //----------定义变量，赋初值--------------- 
            double Cdpca = 0;   //单位长度井眼容积容积 

            int m1 = 0;
            double cs1 = 0;         //中间系数
            double cs2 = 0;

            double pc = 0;    //单位深度循环压耗  Pa/m   
            double hg = 0;       //气体长度 m
            double V2 = 0;    //达到地层压力时,气体体积
            //double t1 = 0;    //第一阶段时间 气体量不变 p1*v1=p2*v2
            //double t2 = 0;   //漏失完需要的时间

            double K = 15;  //地层渗透率，mD
            double u = 9;  //钻井液粘度 mPa.s
            double re = 1000;  //控制半径m
            double rw = (D / 2) / 1000; //井眼半径
            double hh = 10;  //储层厚度，m

            List<double> vt = new List<double>();
            List<double> pt = new List<double>();

            //-------------------------计算-------------------------
            for (int i = 1; i <= nt; i++)
            {
                jxj[i] = jxj[i] * 3.14159265 / 180;  //换为弧度制
            }

            //pc = pcd / hd;  //单位深度循环压耗  Pa/m
            Cdpca = Math.PI * (Math.Pow(D / 1000, 2) - Math.Pow(Dp / 1000, 2)) / 4;  //单位长度环空体积
            Qyj = Qzj / 2;   //压井排量
            Pp = Pd + zjden * g * cs[nt];  //地层压力 Pa      //井下有落鱼的情况（无法利用钻杆得出立压套压）需输入地层压力 单独输入
            hg = Vgain / Cdpca;   //气体高度（长度） m
            Pderta = (Qyj * 1000) * u * Math.Log(re / rw) / (2 * PI * K * hh) * 1000000;

            for (int i = 1; i <= nt; i++)
            {
                if (js[i] >= js[nt] - hg)
                {
                    m1 = i;
                    break;
                }
            }

            cs1 = cs[nt] - cs[m1] + (hg - js[nt] + js[m1]) * Math.Cos(jxj[m1]);   //溢流垂深（垂直高度）
            cs2 = cs[nt] - cs1;                                            //初始时钻井液垂深

            yjden = zjden + 50;                              //压回法压井液密度 Kg/m^3

            //对于井底气体，第一阶段，先压缩 
            V2 = (Pa + zjden * g * cs2) * Vgain / (Pp + Pderta);    //达到地层压力时,气体体积
            this.t1 = (Vgain - V2) / Qyj;  //第一阶段时间 气体量不变 p1*v1=p2*v2 
            pt.Add(Pa + zjden * g * cs2);
            vt.Add(Vgain);

            this.Pat.Add(Pa);
            for (int i = 1; i <= Math.Floor(this.t1); i++)
            {
                vt.Add(vt[i - 1] - Qyj);  //vt[i]=vt[i-1]-Qyj;
                pt.Add(pt[i - 1] * vt[i - 1] / vt[i]);  //pt[i] = pt[i - 1] * vt[i - 1] / vt[i];
                this.Pat.Add(pt[i] - zjden * g * cs2 - yjden * g * Qyj * i / Cdpca); //Pat[i] = pt[i] - zjden * g * cs2 - yjden * g * Qyj * i / Cdpca;   //压井时的套压
            }

            //第二阶段开始漏失 假定以压井排量漏失
            this.t2 = V2 / Qyj;   //漏失完需要的时间
            this.Pat.Add(Pa + Pderta);
            Patmax = Pat[0];
            for (int i = 1; i <= 1 + t1; i++)
            {
                if (Pat[i] > Patmax)
                {
                    Patmax = Pat[i];
                }
            }


            Vyj = Vgain * 8;  //压井泥浆量，8倍。
            this.tyj = Vyj / Qyj;  //压井施工时间，输出

            double cs3 = Vyj / Cdpca;
            for (int i = 1; i <= nt; i++)
            {
                if (js[i] >= cs3)
                {
                    m1 = i;    //标记
                    break;
                }
            }
            cs3 = cs[m1] - (js[m1] - cs3) * Math.Cos(jxj[m1]);   //垂深

            this.Pat.Add(Pderta + Pp - yjden * g * cs1 - zjden * g * (cs[nt] - cs1));
            this.Pat.Add(Pderta + Pp - yjden * g * cs3 - zjden * g * (cs[nt] - cs3));


            //停泵 套压为0  再用工程师法压井 循环钻井液.   


            ///////////////////////////////////////////////////---------最大套压判断是否压漏
            double PPbs = 0;//临时存储套管鞋实际所受压力
            double h1 = 0;  //已压入的压井液折算深度
            h1 = Qyj * t1 / Cdpca;

            //h1转换到垂深
            for (int i = 1; i <= nt; i++)
            {
                if (js[i] >= js[nt] - h1)
                {
                    m1 = i;
                    break;
                }
            }
            h1 = cs[m1] - (js[m1] - h1) * Math.Cos(jxj[m1]);   //h1垂深

            //hshoe转换到垂深
            for (int i = 1; i <= nt; i++)
            {
                if (js[i] >= js[nt] - hshoe)
                {
                    m1 = i;
                    break;
                }
            }
            hshoe = cs[m1] - (js[m1] - hshoe) * Math.Cos(jxj[m1]);   //hshoe垂深

            PPbs = Patmax + yjden * g * h1 + zjden * g * (hshoe - h1);
            if (Pbs >= PPbs)
            {
                result_sfyl = 1;  //不会压漏   返回1
            }
            else
            {
                result_sfyl = 0;   //会压漏   返回0
            }

            return result_sfyl;

        }

        /// <summary>
        /// 定向井-----压回法---4倍压井---起下钻 & 落鱼 & 空井---油水---
        /// </summary>
        /// <param name="nt">离散点300</param>
        /// 
        /// <param name="Pa">关井套管压力</param>
        /// <param name="D">井眼直径</param>
        /// <param name="Dp">钻杆外径</param>
        /// <param name="hd">低泵速实验井深m</param>
        /// <param name="pcd">低泵速情况下循环压耗 Pa</param>
        /// <param name="Vgain">溢流体积</param>
        /// <param name="zjden">钻井液密度 Kg/m^3</param>
        /// <param name="Qzj">钻井排量 m^3/s</param>
        /// <param name="js">井深</param>
        /// <param name="jxj">井斜角</param>
        /// <param name="cs">垂深</param>
        /// <param name="Pat"></param>
        /// <param name="Patmax"></param>
        /// 
        /// <param name="Vyj">压井泥浆量 m^3</param>
        /// <param name="Pderta">渗流阻力 Mpa</param>
        public void Pressure_back_with_trace_4Time(int nt, double[] js, double[] jxj, double[] cs)
        {
            //----------定义变量，赋初值--------------- 

            double K = 15;  //地层渗透率，mD
            double u = 9;  //钻井液粘度 mPa.s
            double re = 1000;  //控制半径m+++++++++++++++++++++++
            double rw = (D / 2) / 1000; //井眼半径 
            double hh = 10;  //储层厚度，m

            //List<double> vt = new List<double>();
            //List<double> pt = new List<double>();

            //-------------------------计算-------------------------

            Qyj = Qzj / 2;   //压井排量
            Pderta = (Qyj * 1000) * u * Math.Log(re / rw) / (2 * PI * K * hh) * 1000000;  //+++++++++++
            this.yjden = zjden;                              //压回法压井液密度 Kg/m^3
            Pp = zjden * g * cs[nt];  //地层压力 Pa      //井下有落鱼的情况（无法利用钻杆得出立压套压）需输入地层压力 单独输入
            //直接进入第二阶段，开始漏失，假定以压井排量漏失           
            Pat.Add(Pa + Pderta);
            Patmax = Pat[0];
            this.t2 = Vgain / Qyj;   //漏失完需要的时间                     
            Vyj = Vgain * 4;  //压井泥浆量，4倍。输出                
            this.tyj = Vyj / Qyj;  //压井施工时间，输出
        }

        /// <summary>
        /// 定向井-----压回法8倍---起下钻 & 落鱼 & 空井----硫化氢（空井时ztl设为0）
        /// </summary>
        /// <param name="nt">离散点300</param>
        /// 
        /// <param name="Pa">关井套管压力</param>
        /// <param name="D">井眼直径</param>
        /// <param name="Dp">钻杆外径</param>
        /// <param name="hd">低泵速实验井深m</param>
        /// <param name="pcd">低泵速情况下循环压耗 Pa</param>
        /// <param name="Vgain">溢流体积</param>
        /// <param name="zjden">钻井液密度 Kg/m^3</param>
        /// <param name="Qzj">钻井排量 m^3/s</param>
        /// <param name="js">井深</param>
        /// <param name="jxj">井斜角</param>
        /// <param name="cs">垂深</param>
        /// <param name="Pat"></param>
        /// <param name="Patmax"></param>
        /// 
        /// <param name="Vyj">压井泥浆量 m^3</param>
        /// <param name="ztl">钻头位置深度 m </param>
        /// <param name="Pderta">渗流阻力 Mpa</param>

        public void Pressure_back_with_trace_8Time(int nt, double[] js, double[] jxj, double[] cs)
        {
            //----------定义变量，赋初值--------------- 
            double Cdpca1 = 0;   //单位长度井眼环空容积 ，上部
            double Cdpca2 = 0;   //单位长度井眼容积 ，下部

            double K = 15;  //地层渗透率，mD
            double u = 9;  //钻井液粘度 mPa.s
            double re = 1000;  //控制半径m
            double rw = (D / 2) / 1000; //井眼半径
            double hh = 10;  //储层厚度，m

            //double Pp = 0;     //地层压力 Pa ,更改为计算，钻进根据Pd计算，落鱼和起下钻可根据 Pa 估算。

            int m1 = 0;
            double cs1 = 0;         //中间系数
            double cs2 = 0;

            double pc = 0;    //单位深度循环压耗  Pa/m   
            double hg = 0;       //气体长度 m
            double V2 = 0;    //达到地层压力时,气体体积


            List<double> vt = new List<double>();
            List<double> pt = new List<double>();

            //-------------------------计算-------------------------
            for (int i = 1; i <= nt; i++)
            {
                jxj[i] = jxj[i] * 3.14159265 / 180;  //换为弧度制
            }

            //pc = pcd / hd;  //单位深度循环压耗  Pa/m

            Cdpca1 = Math.PI * (Math.Pow(D / 1000, 2) - Math.Pow(Dp / 1000, 2)) / 4;  //单位长度井眼环空容积 ，上部
            Cdpca2 = Math.PI * (Math.Pow(D / 1000, 2)) / 4;  //单位长度井眼容积 ，下部
            if (ztl == 0) { Cdpca1 = Cdpca2; }  //空井，按井眼算。

            Pderta = (Qyj * 1000) * u * Math.Log(re / rw) / (2 * PI * K * hh) * 1000000;
            Qyj = Qzj / 2;   //压井排量
            Pp = zjden * g * cs[nt];  //地层压力 Pa      //井下有落鱼的情况（无法利用钻杆得出立压套压）需输入地层压力 单独输入
            hg = Vgain / Cdpca2;   //气体高度（长度） m

            for (int i = 1; i <= nt; i++)
            {
                if (js[i] >= js[nt] - hg)
                {
                    m1 = i;
                    break;
                }
            }

            cs1 = cs[nt] - cs[m1] + (hg - js[nt] + js[m1]) * Math.Cos(jxj[m1]);   //溢流垂深（垂直高度）
            cs2 = cs[nt] - cs1;                                            //初始时钻井液垂深

            yjden = zjden + 0.05;                              //压回法压井液密度 Kg/m^3

            //对于井底气体，第一阶段，先压缩 
            V2 = (Pa + zjden * g * cs2) * Vgain / (Pp);    //达到地层压力时,气体体积
            this.t1 = (Vgain - V2) / Qyj;  //第一阶段时间 气体量不变 p1*v1=p2*v2 

            pt.Add(Pa + zjden * g * cs2);

            vt.Add(Vgain);

            Pat.Add(Pa);

            for (int i = 1; i <= Math.Floor(t1); i++)
            {
                vt.Add(vt[i - 1] - Qyj);  //vt[i]=vt[i-1]-Qyj;
                pt.Add(pt[i - 1] * vt[i - 1] / vt[i]);  //pt[i] = pt[i - 1] * vt[i - 1] / vt[i];
                Pat.Add(pt[i] - zjden * g * cs2 - yjden * g * Qyj * i / Cdpca1);  //xxxxxxxxxxxxxxxxxxxxxxxx
                //Pat[i] = pt[i] - zjden * g * cs2 - yjden * g * Qyj * i / Cdpca;   //压井时的套压

            }

            Pat.Add(Pa + Pderta);
            //第二阶段开始漏失 假定以压井排量漏失
            this.t2 = V2 / Qyj;   //漏失完需要的时间

            Patmax = Pat[0];
            for (int i = 1; i <= t1 + 1; i++)
            {
                if (Pat[i] > Patmax)
                {
                    Patmax = Pat[i];
                }
            }

            Vyj = 8 * Vgain;  //压井泥浆量，井筒全压回。            
            this.tyj = Vyj / Qyj;  //压井施工时间，输出

            //假设8倍压入后，压井液都还没到ztl位置
            //找垂深
            for (int i = 1; i <= nt; i++)
            {
                if (js[i] >= Vgain / Cdpca1)
                {
                    m1 = i;
                    break;
                }
            }
            cs1 = cs[nt] - cs[m1] + (hg - js[nt] + js[m1]) * Math.Cos(jxj[m1]);   //，下
            cs2 = cs[nt] - cs1;                                            //,上
            Pat.Add(Pderta + Pp - yjden * g * cs1 - zjden * g * cs2);  //一倍时
            //找垂深
            for (int i = 1; i <= nt; i++)
            {
                if (js[i] >= Vyj / Cdpca1)
                {
                    m1 = i;
                    break;
                }
            }
            cs1 = cs[nt] - cs[m1] + (hg - js[nt] + js[m1]) * Math.Cos(jxj[m1]);   //，下
            cs2 = cs[nt] - cs1;
            Pat.Add(Pderta + Pp - yjden * g * cs1 - zjden * g * cs2);  //八倍时

            //停泵 套压为0  再用工程师法压井 循环钻井液.    
        }














        /// <summary>
        ///钻具组合求钻杆内外体积,EngYL_ZJ用到，里面有些变量没来的及定义
        /// </summary>
        /// <param name="NT2"></param>钻具组合组数
        /// <param name="ZJI"></param>钻杆内径,mm
        /// <param name="ZJO"></param>钻杆外径,mm
        /// <param name="ZJL"></param>钻杆长度，m
        /// <param name="szjvi"></param>累加得钻具内体积-----------输出
        /// <param name="szjvo"></param>累加得钻具外体积-----------输出
        public void ZJZH(ref double szjvi, ref double szjvo)
        {
            double tempZJVI = 0;
            double tempZJVO = 0;

            for (int i = 0; i < NT2; i++)
            {
                tempZJVI = PI * ZJI[i] * ZJI[i] / 4 * ZJL[i] / (1000000);    //各段钻具内容积
                tempZJVO = PI * ZJO[i] * ZJO[i] / 4 * ZJL[i] / (1000000);    //各段钻具外体积
                szjvi = szjvi + tempZJVI;    //累加得钻具内体积
                szjvo = szjvo + tempZJVO;    //累加得钻具外体积
            }
        }







        /// <summary> 
        /// 返回井号
        /// </summary>
        /// <returns></returns>
        public string getWellNo()
        {

            return strWellNo;

        }

        /// <summary> 
        /// 返回工程号
        /// </summary>
        /// <returns></returns>
        public string getProjID()
        {

            return strProjID;

        }
        /// <summary> 
        /// 返回井型
        /// </summary>
        /// <returns></returns>
        public string getWellType()
        {

            return strWellType;

        }

        //公司名称
        public string getcompanyName()
        {
            return companyName;

        }
        //作业队名称
        public string getdrillingCrewName()
        {
            return drillingCrewName;

        }



        ///// <summary> 
        ///// 返回判断流体类型
        ///// </summary>
        ///// <returns></returns>
        //public string getoiltype()
        //{

        //    return oiltype;

        //}
        /// <summary> 
        /// 返回井深
        /// </summary>
        /// <returns></returns>
        public double geth()
        {

            return h;

        }
        /// <summary>
        /// 垂深
        /// </summary>
        /// <returns></returns>
        public double gethcs()
        {
            return hcs;

        }

        //套管鞋深度
        public double gethtx()
        {
            return hshoe;

        }

        //钻铤累加长度
        public double getZtingLength()
        {
            return ZtingLength;

        }
        //钻杆累加长度
        public double getZganLength()
        {
            return ZganLength;

        }

        //钻头尺寸
        public double getDly()
        {
            return Dly;

        }
        /// <summary> 
        /// 返回地层压力
        /// </summary>
        /// <returns></returns>
        public double getPp()
        {

            return Pp;

        }
        /// <summary> 
        /// 返回关井套管压力 Pa-------------初始井口压力
        /// </summary>
        /// <returns></returns>
        public double getPa()
        {

            return Pa;

        }
        /// <summary> 
        /// 返回井眼直径 mm
        /// </summary>
        /// <returns></returns>
        public double getD()
        {

            return D;

        }

        //钢级
        public string getsteelNo()
        {
            return steelNo;

        }

        //钻具内容积
        public double getVdz()
        {
            return Vdz;

        }
        //环空总容积
        public double getvhz1()
        {
            return vhz1;

        }
        //井筒总容积
        public double getvjt()
        {
            return vjt;

        }

        //套管抗内压强度
        public double getTaoGuanKangNeiYa()
        {
            return m_TaoGuanKangNeiYa;

        }
        //裸眼薄弱地层破裂压力
        public double getLyPlYl()
        {
            return m_LyPlYl;

        }
        //井口装置额定工作压力
        public double getJkEdYl()
        {
            return douJkEdYl;

        }
        /// <summary> 
        /// 返回溢流体积
        /// </summary>
        /// <returns></returns>
        public double getVgain()
        {

            return Vgain;

        }
        /// <summary> 
        /// 返回钻井液密度 Kg/m^3
        /// </summary>
        /// <returns></returns>
        public double getzjden()
        {

            return zjden;

        }

        /// <summary> 
        /// 返回钻井排量 m^3/s
        /// </summary>
        /// <returns></returns>
        public double getQzj()
        {

            return Qzj;

        }

        /// <summary> 
        /// 返回关井立压 
        /// </summary>
        /// <returns></returns>
        public double getPd()
        {

            return Pd;

        }
        /// <summary> 
        /// 返回钻井排量 m^3/s--输出1
        /// </summary>
        /// <returns></returns>
        public List<double> getPat()
        {

            return Pat;

        }

        /// <summary> 
        /// 返回时间
        /// </summary>
        /// <returns></returns>
        public List<double> getatyj()
        {

            return atyj;

        }
        //返回堵漏泵压曲线
        public List<double> gettdlp()
        {

            return tdlp;

        }
        /// <summary> 
        /// 返回压井排量------输出2
        /// </summary>
        /// <returns></returns>
        public double getQyj()
        {

            return Qyj;

        }
        /// <summary> 
        /// 防止气体上窜最低压井排量
        /// </summary>
        /// <returns></returns>
        public double getQyjmin()
        {

            return Qyjmin;

        }
        /// <summary> 
        /// 返回最大套压------输出3
        /// </summary>
        /// <returns></returns>
        public double getPatmax()
        {

            return Patmax;

        }
        /// <summary> 
        /// 返回压井施工时间------输出4
        /// </summary>
        /// <returns></returns>
        public double gettyj()
        {

            return this.tyj;

        }

        public double gett2()
        {

            return this.t2;

        }

        public double gett1()
        {

            return this.t1;

        }
        /// <summary> 
        /// 返回压井液密度 kg/m^3------输出5
        /// </summary>
        /// <returns></returns>
        public double getyjden()
        {

            return yjden;

        }

        public string getoiltype()
        {

            return oiltype;

        }

        public double getdenyl()
        {

            return denyl;
        }
        public double getPderta()
        {

            return Pderta;
        }

        //3.压井数据----------------------------------- 
        //井底溢流高度
        public double gethw()
        {
            return hw;

        }

        /// <summary>
        /// // !地层压力 输出数据1
        /// </summary>
        /// <returns></returns>
        public double getPP()
        {
            return Pp;

        }
        // 附加当量钻井液密度
        public double getddden()
        {
            return ddden;

        }
        //压井中井底附加安全压力
        public double getDeltP()
        {
            return deltP;

        }
        //压井液总量
        public double getVyj()
        {
            return Vyj;

        }



        //地热增温率
        public double getDrZWL()
        {
            return douDrZWL;

        }
        //低泵速井深
        public double getDbsWellDepth()
        {
            return douDbsWellDepth;

        }
        //低泵速套压
        public double getDbsTaoya()
        {
            return douDbsTaoya;

        }
        //井口温度---基础数据中
        public double getTs()
        {
            return Ts;

        }
        //2018.1.22---------------------------------------------------------
        public List<double> getZJI()
        {
            return ZJI;

        }
        public List<double> getZJO()
        {
            return ZJO;

        }
        public List<double> getZJL()
        {
            return ZJL;

        }
        public int getNT2()
        {
            return NT2;

        }





        /// <summary>
        /// 定向井井深转垂深通用方法。返回值即为转换后的垂深。0111。
        /// </summary>
        /// <param name="htra">待转的输入井深</param>
        /// <returns></returns>
        private double HtoV(double[,] TW, double htra)
        {
            int m1 = 0;
            for (int i = 1; i <= NT; i++)
            {
                if (TW[i, 1] >= htra)
                {
                    m1 = i;    //标记
                    break;
                }
            }
            htra = TW[m1, 6] - (TW[m1, 1] - htra) * Math.Cos(TW[m1, 2]);   //垂深
            return htra;
        }

        public Pressure_back_killing Copy()
        {
            return (Pressure_back_killing)this.MemberwiseClone();
        }
    }
}
