using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 石油专家管理系统.Calcuation
{
        /// <summary>
        /// 工程师压井法
        /// </summary>
        public class EngMethod
        {
            //private  string strWellNo;//井号
            //private string strWellType;//井型---直井，水平井，定向井
            //private double douWellDepth;//井深
            //private double douTgxDepth;//套管斜深度
            //private double douTgDiameter;//套管直径
            //private double douZtSize;//钻头尺寸
            //private double douWellEyeKDL;//井眼扩大率
            //private double douZjyDensity;//钻井液密度
            //private double douZjyPL;//钻井液排量
            //private double douDrZWL;//地热增温率
            //private double douDbsWellDepth;//低泵速井深
            //private double douDbsTaoya;//低泵速套压
            //private double douDbsPL;//低泵速排量
            //private double douZgOutterDiameter;//钻杆外径
            //private double douZgWallThickness;//钻杆壁厚

            //1.基础参数---------------------
            private string strWellNo;//井号
            private string strWellType;//井型---直井，水平井，定向井
            private string strProjID;
            private string companyName;
            private string drillingCrewName;
            private double h;//井深 
            private double hcs;//垂深
            private double htx;//套管鞋深度
            private double ZtingLength;//钻铤累加长度
            private double ZganLength = 0;//钻杆累加长度
            private double hly; //裸眼长度
            private double Ts;//井口温度---基础数据中
            private double D;//套管直径
            private double Dly;//钻头尺寸
            private double douWellEyeKDL;//井眼扩大率
            private double Pm;//钻井液密度
            private double qn;//钻井液排量
            private double gt;//地热增温率
            private double hd;//低泵速井深
            private double pcd;//低泵速套压
            private double Qd;//低泵速排量
            private double Dp;//钻杆外径
            private double deltd;//钻杆壁厚 
            private string steelNo;//钢级


            private double Vdz;//钻具内容积 
            private double vhz1;    //环空总容积
            private double vjt;    //井筒总容积

            private double m_TaoGuanKangNeiYa;//套管抗内压强度
            private double m_LyPlYl;//裸眼薄弱地层破裂压力
            private double m_JkEdYl;//井口装置额定工作压力
            private double m_maxGJYl;//最大允许关井套压


            //2.溢流关井----------------------
            private double Pd;//关井立压
            private double pa;//关井套压 
            private double Vgain;//泥浆池增量
            private string oiltype;
            private double Dens;

            //3.压井数据------------------
            private double hw;//井底溢流高度
            private double pp;  // !地层压力 输出数据1
            private double ddden;  // 附加当量钻井液密度
            private double pm1;//!压井泥浆密度  
            private double deltp;//压井中井底附加安全压力
            private double Q;// !压井排量 
            private double pc;//初始循环压力
            private double Pti;//!初始循环压力------------------------------------------------------输出数据4
            private double Ptf;//!终了循环压力----------------------------------------------- 输出数据5
            private double pamax;//最大套压  输出数据6           
            private double vgainmax;//泥浆池最大增量  输出数据8
            private double T1; //钻杆内钻井液循环到环空时间****** 输出数据
            private double T2; //循环出原钻井液时间****** 输出数据
            private double Th;  //压井液从井底到达套管鞋时间****** 输出数据
            private double Tz;  //压井总时间****** 输出数据
                                //-----------补充成员变量---
                                //5.大工程-------------
            private double Ppc0;//混合压耗

            /// <param name="NT2"></param>钻具组合组数
            /// <param name="ZJI"></param>钻杆内径,mm
            /// <param name="ZJO"></param>钻杆外径,mm
            /// <param name="ZJL"></param>钻杆长度，m
            List<double> ZJI;
            List<double> ZJO;
            List<double> ZJL;
            int NT2;

            private const double PI = 3.1415926;
            private const int NT1 = 300;
            private
            string papath = "PA.txt";
            string pdpath = "PD.txt";
            string vgmpath = "VGM.txt";

            //----输出参数--------------------------- 


            private double ovtime;//溢流到井口时间 输出数据9 
            private double shigongTime;//压井施工时间  输出数据7
                                       //---定向井输出------------
            private double maxpax; //最大套压        输出数据 
            private double maxpitgain;   //泥浆池最大增量  输出数据
            private double[,] TW;//计算之后的井眼轨迹数据
            private double[] SHEN;
            private double[] ALFA;
            private double[] FAI;
            private int NT;


            //----补充输出----压井施工单---------------- 
            private double Vd;// //单位长度钻杆内容积
            private double vhzz;//环空容积 
            private double vlyz;// //裸眼段总容积   
            private double Vyj;// 压井施工泥浆量
            private double tyj; //压井施工时间
            private double Ppc;//终了循环压力
            private double Pd0;//初始循环压力
            private double Pd1;//终了循环压力
                               //
            private double jtzrj;//井筒总容积，大工程师使用！

            //--------------定义数组----------------------
            private double[] pax = new double[1000];
            private double[] Ptime = new double[1000]; //Ptime[3] = (Vdz + vhzz) / Q / 60;//!压井施工时间  输出数据7
            private double[] pitgain = new double[1000];
            private double[] circulatingtime = new double[1000];
            private double[] pdd = new double[1000];





            public EngMethod(string strWellNo, string strWellType, double douWellDepth, double douTgxDepth, double douWellTemp, double douTgDiameter,
                             double douZtSize, double douWellEyeKDL, double douZjyDensity, double douZjyPL, double douDrZWL,
                           double douDbsWellDepth, double douDbsTaoya, double douDbsPL, double douZgOutterDiameter, double douZgWallThickness,
                           double Pd, double pa, double Vgain, string companyName, string drillingCrewName, double[,] TW, double[] SHEN, double[] ALFA, double[] FAI, int NT,
                                    string oiltype, double Dens)
            {
                this.strWellNo = strWellNo;
                this.strWellType = strWellType;
                this.h = douWellDepth;//井深
                this.htx = douTgxDepth;//套管鞋深度
                this.Ts = douWellTemp;//井口温度
                this.D = douTgDiameter;//套管直径
                this.Dly = douZtSize;////钻头尺寸
                this.douWellEyeKDL = douWellEyeKDL;//井眼扩大率
                this.Pm = douZjyDensity;//钻井液密度
                this.qn = douZjyPL;//钻井液排量---------------------------
                this.gt = douDrZWL;//地热增温率
                this.hd = douDbsWellDepth;//低泵速井深
                this.pcd = douDbsTaoya;//低泵速套压
                this.Qd = douDbsPL;//低泵速排量
                this.Dp = douZgOutterDiameter;//钻杆外径
                this.deltd = douZgWallThickness;//钻杆壁厚
                this.hly = h - htx;
                this.Pd = Pd;
                this.pa = pa;
                this.Vgain = Vgain;
                this.companyName = companyName;//公司名称
                this.drillingCrewName = drillingCrewName;//钻井队名称
                this.TW = TW;//计算之后的井眼轨迹
                this.SHEN = SHEN;//井深
                this.ALFA = ALFA;//
                this.FAI = FAI;//方位角
                this.NT = NT;
                this.oiltype = oiltype;//地层流体类型
                this.Dens = Dens;//溢流密度

            }




            //以下为工程师主体，钻进分为直井（plumbWell）与定向井（directionWell），起下钻不分直井与定向井但分大小，小工程师为能配置下的工程师，大工程师为下钻杆后的工程师。





            /// <summary>
            /// 工程师压井法----------直井---钻进用
            /// </summary>
            /// <param name="oiltype">地层类型</param>
            /// <param name="Dens">溢流密度，算地层类型时计算得到</param>
            /// 
            /// 输出曲线1：连线（circulatingtime[i]，pax[i]），只取前几十个有数据的数，命名为套压曲线
            /// 输出曲线2：连线(Ptime[i]，pdd[i])），只有3组，命名为立压曲线。定向井相同。
            /// 
            public void plumbWell(string oiltype, double Dens)
            {

                //--------------赋初始值------------------------

                double pc = pcd / hd;
                Qd = Qd / 1000;
                Q = qn / 3;// !压井排量-------------------------------------------------------------输出数据3  
                qn = qn / 1000;
                Q = Q / 1000;
                pc = pc * h;
                pp = Pd + 0.0098 * Pm * h;  // !地层压力--------------------------------------------输出数据1
                pm1 = 102 * Pd / h + Pm;//!压井泥浆密度---------------------------------------------输出数据2
                                        // double Ptf = pm1 * pc / Pm;
                Vd = PI * (Math.Pow(((Dp - 2 * deltd) / 1000), 2)) / 4;
                double Vdz = Vd * h;
                double T1 = Vd * h / 60 / Q;
                double vh = PI * (Math.Pow((D / 1000), 2) - Math.Pow((Dp / 1000), 2)) / 4;

                double vly = PI * (Math.Pow((Dly / 1000), 2) - Math.Pow((Dp / 1000), 2)) / 4;
                vlyz = vly * hly;
                double vth = vh * htx;
                double vhz = vh * h;
                vhzz = vth + vlyz;
                double s = 0.6;
                double zx = 1;
                double ZB = 1;
                double K0 = 273;
                double tB = h / gt + Ts + K0;
                double Gm1 = pm1 * 0.0098;
                //------------------立管压力计算--------------------------------
                Pti = Pd + pc;//!初始循环压力------------------------------------------------------输出数据4
                Ptf = pm1 * pc / Pm;//!终了循环压力----------------------------------------------- 输出数据5
                                    //------------------初始状态计算------------------------------- 
                hw = 0;
                if (Vgain <= vlyz)
                {
                    hw = Vgain / vly;
                }
                else if (Vgain > vlyz)
                {
                    hw = hly + (Vgain - vlyz) / vh;
                }
                double Gm = 0.0098 * Pm;
                double Txs = Ts + K0;
                //double Dens = Pm - (pa - Pd) / 0.00981 / hw;
                double Pw = Dens * 0.00981 * hw;
                pax[1] = pa;
                circulatingtime[1] = 0;
                pitgain[1] = Vgain;
                //------------------------------计算------------------------------------
                double Pat1;
                int N1 = 0; int i = 0; int N2 = 0; int N21 = 0;
                double Dt1 = 0;
                double ym1 = 0;
                double hx1 = 0;
                double Vx2 = 0;
                double qm1 = 0;
                double Tx1 = 0;
                double Px1 = 0;
                double Vx1 = 0;
                double Vx3 = 0;
                double T2 = 0;
                double Dt2 = 0;
                double ym2 = 0;
                double ym21 = 0;
                double Tx2 = 0;
                double Px2 = 0;
                double Vx21 = 0;
                double hx2 = 0;
                double T3 = 0;
                double deltaPa = 0;
                double T4 = 0;
                double h1 = 0;
                double Vzz = 0;
                double qm2 = 0;
                double qm21 = 0;
                double Vx22 = 0;
                double h21 = 0, h22 = 0, h23 = 0;
                if (oiltype == "gas")//溢流为天然气----------------------------------
                {
                    //c************************(1)钻杆内钻井液进入裸眼
                    T1 = Vdz / Q / 60;
                    N1 = 10;
                    Dt1 = T1 / N1;
                    i = 1;
                    while (i <= N1)
                    {
                        qm1 = Dt1 * i * 60 * Q;
                        if (qm1 <= vlyz)
                        {
                            ym1 = Dt1 * i * 60 * Q / vly;
                        }
                        else if (qm1 > vlyz)
                        {
                            ym1 = hly + (qm1 - vlyz) / vh;
                        }
                        Tx1 = Ts + K0 + (h - ym1) / gt;
                        Px1 = pp - Gm * ym1 - Pw;
                        Vx1 = pp * Tx1 * zx * Vgain / Px1 / tB / ZB;
                        Vx2 = ym1 * vly;
                        Vx3 = Vx1 + Vx2;
                        if (Vx3 <= vlyz)
                        {
                            hx1 = Vx1 / vly;
                        }
                        else if (Vx3 > vlyz)
                        {
                            hx1 = (vlyz - Vx2) / vly + (Vx3 - vlyz) / vh;
                        }
                        Pat1 = pp - (h - hx1) * Gm - Pw;
                        circulatingtime[i + 1] = Dt1 * i;
                        pax[i + 1] = Pat1;
                        pitgain[i + 1] = hx1 * vly;
                        i++;
                    }//end while
                     //c************************(2)循环溢流到井口至排除
                    T2 = (vhzz - Vdz) / Q / 60;
                    N2 = 10;
                    Dt2 = T2 / N2;
                    i = 1;
                    while (i <= N2)
                    {
                        qm2 = Dt2 * i * 60 * Q;
                        qm21 = qm2 + Vdz;
                        if (qm21 <= vlyz)
                        {
                            ym2 = qm2 / vly;
                            ym21 = Vdz / vly;
                        }
                        else if ((qm21 > vlyz) && (qm2 <= vlyz))
                        {
                            ym2 = qm2 / vly;
                            ym21 = (vlyz - qm2) / vly + (Vdz - (vlyz - qm2)) / vh;
                        }
                        else if (qm2 > vlyz)
                        {
                            ym2 = hly + (qm2 - vlyz) / vh;
                            ym21 = Vdz / vh;
                        }//end if
                        Tx2 = Ts + K0 + (h - ym2 - ym21) / gt;
                        Px2 = pp - Gm * ym21 - Gm1 * ym2 - Pw;
                        Vx2 = pp * Tx2 * zx * Vgain / Px2 / tB / ZB;
                        Vx21 = Vx2 + qm2 + Vdz;

                        if (Vx21 >= vhzz)
                        {
                            break;//退出while循环，到  T2=Dt2*N21;
                        }//跳转

                        if (Vx21 <= vlyz)
                        {
                            hx2 = Vx2 / vly;
                        }
                        else if ((Vx21 > vlyz) && (qm21 <= vlyz))
                        {
                            hx2 = (vlyz - qm21) / vly + (Vx2 - (vlyz - qm21)) / vh;
                        }
                        else if (qm21 >= vlyz)
                        {
                            hx2 = Vx2 / vh;
                        }//end if

                        Pat1 = pp - (h - hx2 - ym2) * Gm - ym2 * Gm1 - Pw;
                        circulatingtime[N1 + i + 1] = Dt2 * i + T1;
                        pax[N1 + i + 1] = Pat1;
                        pitgain[N1 + i + 1] = Vx2;
                        N21 = i;
                        i++;
                    }//end while
                    pamax = pax[N1 + N2 + 1];    //!这里增加一段代码  最大套压----------------------输出数据6
                    vgainmax = pitgain[N1 + N2 + 1];//  !这里增加一段代码  泥浆池最大增量--------------输出数据8
                    ovtime = circulatingtime[N1 + N2 + 1];// !增加一段代码  溢流到井口时间----------------输出数据9
                    T2 = Dt2 * N21;
                    T3 = Vx2 / Q / 60;
                    circulatingtime[1 + N21 + 1 + N1] = T1 + T2 + T3;
                    deltaPa = ym21 * (Gm1 - Gm);
                    pax[1 + N21 + 1 + N1] = deltaPa;
                    pitgain[1 + N21 + 1 + N1] = 0;
                    T4 = Vdz / Q / 60;
                    circulatingtime[1 + N21 + 1 + 1 + N1] = T1 + T2 + T3 + T4;
                    pax[1 + N21 + N1 + 1 + 1] = 0;
                    //-----------------输出-----------------------
                    //Do I=1,1+N21+N1+1+1
                    // write(2,*)circulatingtime(I),pax(I)
                    //  ENDDO
                    // Do I=1,1+N21+1+N1
                    //     write(4,*)circulatingtime(I),pitgain(I)
                    //  ENDDO	 

                    // c*********************循环压力计算	 
                    Ptime[1] = 0;
                    pdd[1] = Pti;
                    Ptime[2] = Vdz / Q / 60;
                    pdd[2] = Ptf;
                    Ptime[3] = (Vdz + vhzz) / Q / 60; 
                    shigongTime = Ptime[3];//!压井施工时间-------------------------------输出数据7//输出Ptime 数组
                    pdd[3] = Ptf;
                    // Do I=1,3
                    //  write(3,*)Ptime(i),pdd(i)
                    //ENDDO
                  /*  FileOpp.writeFile(papath, circulatingtime, pax);
                    FileOpp.writeFile(vgmpath, circulatingtime, pitgain);
                    FileOpp.writeFile(pdpath, Ptime, pdd);*/



                }//end if
                else if (oiltype == "oil" || oiltype == "wateroil" || oiltype == "water")//溢流为油，油水，地层水--------------------------------------------------------
                {
                    // vhzz = Vdz - Vgain;
                    // Vzz = vhzz;
                    T1 = Vdz / Q / 60;
                    N1 = 10;
                    Dt1 = T1 / N1;
                    i = 1;

                    while (i <= N1)
                    {
                        qm1 = Dt1 * i * 60 * Q;
                        Vx1 = qm1 + Vgain;
                        if (Vx1 <= vlyz)
                        {
                            h1 = Vgain / vly;
                        }
                        else if ((Vx1 > vlyz) && (qm1 <= vlyz))
                        {
                            h1 = hly + (Vgain - vlyz) / vh;
                        }
                        else if (qm1 > vlyz)
                        {
                            h1 = Vgain / vh;
                        }//end if
                        pax[1 + i] = pp - Gm * (h - h1) - Dens * 0.00981 * h1;
                        circulatingtime[1 + i] = Dt1 * i;
                        pitgain[1 + i] = Vgain;
                        i++;
                    }//end while
                    T2 = (vhzz - Vdz) / Q / 60;
                    N2 = 10;
                    Dt2 = T2 / N2;
                    i = 1;
                    while (i <= N2)
                    {
                        qm2 = Dt2 * i * 60 * Q;
                        Vx21 = qm2 + Vdz + Vgain;
                        Vx22 = qm2 + Vdz;
                        if (Vx21 <= vlyz)
                        {
                            h21 = Vgain / vly;
                            h22 = Vdz / vly;
                            h23 = qm2 / vly;
                        }
                        else if ((Vx21 > vlyz) && (Vx22 <= vlyz))
                        {
                            h21 = (vlyz - Vx22) / vly + (Vgain - (vlyz - Vx22)) / vh;
                            h22 = Vdz / vly;
                            h23 = qm2 / vly;
                        }
                        else if ((qm2 <= vlyz) && (Vx22 > vlyz))
                        {
                            h21 = Vgain / vh;
                            h22 = (vlyz - qm2) / vly + (Vdz - (vlyz - qm2)) / vh;
                            h23 = qm2 / vly;
                        }
                        else if (qm2 > vlyz)
                        {
                            h21 = Vgain / vh;
                            h22 = Vdz / vh;
                            h23 = qm2 / vh;
                        }//end if

                        pax[1 + i + N1] = pp - Gm * (h - h21 - h23) - Dens * 0.00981 * h21 - Gm1 * h23;
                        circulatingtime[1 + i + N1] = Dt1 * i + T1;
                        pitgain[1 + i + N1] = Vgain;
                        i++;
                    }//END WHILE
                    pamax = pax[N1 + N2 + 1];    //!这里增加一段代码  最大套压  输出数据6
                    vgainmax = pitgain[N1 + N2 + 1];//  !这里增加一段代码  泥浆池最大增量------------------输出数据8
                    ovtime = circulatingtime[N1 + N2 + 1];// !增加一段代码  溢流到井口时间---------------输出数据9
                    T3 = Vgain / Q / 60;    //排除溢流
                    pax[1 + N2 + N1 + 1] = 0;
                    pitgain[1 + N2 + N1 + 1] = Vgain;
                    circulatingtime[1 + N2 + N1 + 1] = T1 + T2 + T3;
                    //---------------输出-----------------------------------
                    //Do I=1,1+N2+N1+1
                    //write(2,*)circulatingtime(I),pax(I)
                    //ENDDO
                    //Do I=1,1+N2+N1+1
                    // write(4,*)circulatingtime(I),pitgain(I)
                    //ENDDO 

                    // c*********************循环压力计算	 
                    Ptime[1] = 0;
                    pdd[1] = Pti;
                    Ptime[2] = Vdz / Q / 60;
                    pdd[2] = Ptf;
                    Ptime[3] = (Vdz + vhzz) / Q / 60;//!压井施工时间   输出数据7
                    shigongTime = Ptime[3];//!压井施工时间-------------------------------输出数据7
                    pdd[3] = Ptf;
                //---------------输出-----------------------------------
                //Do I=1,3
                //  write(3,*)Ptime(i),pdd(i)
                //ENDDO
                /* FileOpp.writeFile(papath, circulatingtime, pax);
                 FileOpp.writeFile(vgmpath, circulatingtime, pitgain);
                 FileOpp.writeFile(pdpath, Ptime, pdd);*/
                /// 输出曲线1：连线（circulatingtime[i]，pax[i]），只取前几十个有数据的数，命名为套压曲线
                /// 输出曲线1：连线（circulatingtime[i]，pitgain[i]），只取前几十个有数据的数，命名为泥浆池
                /// 
                /// 
                /// 输出曲线2：连线(Ptime[i]，pdd[i])），只有3组，命名为立压曲线。定向井相同。

            }

        }
        public double[] getpax()
        {
            return pax;

        }
        public double[] getpitgain()
        {
            return pitgain;
        }
        public double[] getcircu()
        {
            return circulatingtime;
        }
        public double[] getptime()
        {
            return Ptime;
        }
        public double[] getpdd()
        {
            return pdd;
        }

        /// <summary>
        /// 工程师压井法--------定向井---钻进用
        /// </summary>
        /// <param name="wellNo">井号</param>
        /// <param name="Pd">关井立压</param>
        /// <param name="pa">关井立压</param>
        /// <param name="Vgain">泥浆池增量</param>
        public void directionWell(string oiltype, double Dens, double[,] TW, double[] SHEN, double[] ALFA, double[] FAI, int NT)
            {

                ////-------------根据井号，查询井眼轨迹数据并进行计算---------------------------------
                //WellTrace wt = new WellTrace(wellNo);
                //int NT = wt.getNt();//井眼轨迹行数

                //double[] SHEN = wt.getShen();//井深
                //double[] ALFA = wt.getAlfa();//井斜
                //double[] FAI = wt.getFai();//方位角
                //wt.wellTrace_XYZ(NT1);//轨迹计算函数
                //TW = wt.getTw();//计算之后的井眼轨迹参数
                int NT1 = 300;//固定离散值
                              //--------------赋初始值------------------------
                double h = SHEN[NT];       //井深 m
                hcs = TW[NT1, 6];       //垂深 m
                hly = h - htx;
        
          
               
                Dly = Dly * (1 + douWellEyeKDL);//裸眼直径
                double pc = pcd / hd;
                qn = qn / 1000;          //排量单位转化
                Q = qn / 3;             //压井排量   **********    输出数据
                pc = pc * h;            //循环压耗计算，用井深去算不是垂深
                pp = Pd + 0.0098 * Pm * hcs;   //地层压力，注意，这里是用垂深去算****** 输出数据
                pm1 = 102 * Pd / h + Pm;       //压井液密度 ****** 输出数据
                Ptf = pm1 * pc / Pm;         //终了循环压力****** 输出数据
                Vd = PI * (Math.Pow(((Dp - 2 * deltd) / 1000), 2)) / 4;      //单位长度钻杆内容积
                double Vdz = Vd * h;                             //钻杆总容积，注意这里用井深算
                double T1 = Vd * h / 60 / Q;                          //循环钻杆内钻井液时间
                double vh = PI * (Math.Pow((D / 1000), 2) - Math.Pow((Dp / 1000), 2)) / 4;    //单位长度套管段容积
                double vly = PI * (Math.Pow((Dly / 1000), 2) - Math.Pow((Dp / 1000), 2)) / 4;  //单位长度裸眼段容积
                vlyz = vly * hly;  //裸眼段总容积
                double vth = vh * htx;     //套管段总容积
                double vhz = vh * h;       //这个参数没用
                vhzz = vth + vlyz;  //环空总容积
                double s = 0.6;
                double zx = 1;
                double ZB = 1;
                double K0 = 273;
                double tB = h / gt + Ts + K0;
                double Gm1 = pm1 * 0.0098;
                //------------------立管压力计算--------------------------------
                Pti = Pd + pc;//!初始循环压力------------------------------------------------------输出数据4
                Ptf = pm1 * pc / Pm;//!终了循环压力----------------------------------------------- 输出数据5
                                    //-------------------------定义局部变量----------------
                hw = 0.0;
                double hgd = 0.0;
                double hwcs = 0.0;
                double Gm = 0.0;
                double Txs = 0.0;
                double Pw = 0.0;
                double hcsym1 = 0.0;
                double hcsym2 = 0.0;
                double hcshx1 = 0.0;
                double Pat1 = 0.0;
                double hcdym2 = 0.0;
                double hzym2 = 0.0;
                double hcdz = 0.0;
                double hcdym21 = 0.0;
                double hzhx2 = 0.0;
                double hcshx2 = 0.0;
                double hcdhx2 = 0.0;
                double hcshxx2 = 0.0;
                double hcsh1 = 0.0;
                double hcdh1 = 0.0;
                double hcsh21 = 0.0;
                double hcdh21 = 0.0;
                double hh22 = 0.0;
                double hcshh22 = 0.0;
                double hcdhh22 = 0.0;
                double hcd22 = 0.0;
                double hh33 = 0.0;
                double hcshh33 = 0.0;
                double hcdhh33 = 0.0;
                double hcd23 = 0.0;

                int N1 = 0; int N2 = 0; int N21 = 0; int i = 0;
                double Dt1 = 0;
                double ym1 = 0;
                double hx1 = 0;
                double Vx2 = 0;
                double qm1 = 0;
                double Tx1 = 0;
                double Px1 = 0;
                double Vx1 = 0;
                double Vx3 = 0;
                double T2 = 0;
                double Dt2 = 0;
                double ym2 = 0;
                double ym21 = 0;
                double Tx2 = 0;
                double Px2 = 0;
                double Vx21 = 0;
                double hx2 = 0;
                double T3 = 0;
                double deltaPa = 0;
                double T4 = 0;
                double h1 = 0;
                double Vzz = 0;
                double qm2 = 0;
                double qm21 = 0;
                double Vx22 = 0;
                double h21 = 0, h22 = 0, h23 = 0;

                //------------------初始状态计算------------------------------- 

                if (Vgain <= vlyz)
                {
                    hw = Vgain / vly;
                }
                else if (Vgain > vlyz)
                {
                    hw = hly + (Vgain - vlyz) / vh;
                }

                //*********************根据溢流的高度判断溢流最高点垂深
                for (i = 1; i <= NT1 - 1; i++)
                {
                    hgd = TW[NT1, 1] - TW[i, 1];
                    if (hgd <= hw)
                    {
                        hwcs = TW[i, 6] - (hw - (TW[NT1, 1] - TW[i, 1])) * Math.Cos(TW[i, 2] / PI / 180);  //溢流顶端测深
                        break;
                    }
                }
                Gm = 0.0098 * Pm;
                Txs = Ts + K0;
                //Dens = Pm - (pa - Pd) / 0.00981 / hw;  //溢流密度计算
                if (oiltype == "gas")//溢流为天然气----------------------------------
                {
                    //c************************(1)钻杆内钻井液进入裸眼
                    Pw = Dens * 0.00981 * (TW[NT1, 6] - hwcs);      //溢流在井底产生的气柱压力
                    pax[1] = pa;              //初始套压
                    circulatingtime[1] = 0;
                    pitgain[1] = Vgain;
                    //c************************(1)钻杆内钻井液进入裸眼
                    T1 = Vdz / Q / 60;
                    N1 = 10;
                    Dt1 = T1 / N1;
                    i = 1;
                    while (i <= N1)
                    {
                        qm1 = Dt1 * i * 60 * Q;
                        if (qm1 <= vlyz)
                        {
                            ym1 = Dt1 * i * 60 * Q / vly;
                        }
                        else if (qm1 > vlyz)
                        {
                            ym1 = hly + (qm1 - vlyz) / vh;
                        }
                        for (int j = 1; j <= NT1 - 1; j++)
                        {
                            hgd = TW[NT1, 1] - TW[j, 1];
                            if (hgd <= ym1)
                            {
                                hcsym1 = TW[j, 6] - (ym1 - (TW[NT1, 1] - TW[j, 1])) * Math.Cos(TW[j, 2] / PI / 180);
                                break;
                            }
                        }//end of for
                        Tx1 = Ts + K0 + hcsym1 / gt;
                        Px1 = pp - Gm * (TW[NT1, 6] - hcsym1) - Pw;   //-------------------这里算错了？
                        Vx1 = pp * Tx1 * zx * Vgain / Px1 / tB / ZB;
                        Vx2 = qm1;
                        Vx3 = Vx1 + Vx2;
                        if (Vx3 <= vlyz)
                        {
                            hx1 = Vx1 / vly;
                        }
                        else if (Vx3 > vlyz)
                        {
                            hx1 = (vlyz - Vx2) / vly + (Vx3 - vlyz) / vh;
                        }
                        ym2 = hx1 + ym1;
                        for (int k = 1; k <= NT1 - 1; k++)
                        {
                            hgd = TW[NT1, 1] - TW[k, 1];
                            if (hgd <= ym2)
                            {
                                hcsym2 = TW[k, 6] - (ym2 - (TW[NT1, 1] - TW[k, 1])) * Math.Cos(TW[k, 2] / PI / 180);
                                break;
                            }
                        }//end of for

                        hcshx1 = hcsym1 - hcsym2;
                        Pat1 = pp - (TW[NT1, 6] - hcshx1) * Gm - Pw;
                        circulatingtime[i + 1] = Dt1 * i;
                        pax[i + 1] = Pat1;
                        pitgain[i + 1] = Vx1;
                        i++;//循环变量自增

                    }//end of while
                     //c************************(2)循环溢流到井口至排除
                    T2 = (vhzz - Vdz) / Q / 60;
                    N2 = 10;
                    Dt2 = T2 / N2;
                    i = 1;
                    while (i <= N2)
                    {
                        qm2 = Dt2 * i * 60 * Q;
                        qm21 = qm2 + Vdz;
                        if (qm21 <= vlyz)
                        {
                            ym2 = qm2 / vly;
                            ym21 = Vdz / vly;
                        }
                        else if ((qm21 > vlyz) && (qm2 <= vlyz))
                        {
                            ym2 = qm2 / vly;
                            ym21 = (vlyz - qm2) / vly + (Vdz - (vlyz - qm2)) / vh;
                        }
                        else if (qm2 > vlyz)
                        {
                            ym2 = hly + (qm2 - vlyz) / vh;
                            ym21 = Vdz / vh;
                        }//end if

                        for (int j = 1; j <= NT1 - 1; j++)
                        {
                            hgd = TW[NT1, 1] - TW[j, 1];
                            if (hgd <= ym2)
                            {
                                hcsym2 = TW[j, 6] - (ym2 - (TW[NT1, 1] - TW[j, 1])) * Math.Cos(TW[j, 2] / PI / 180);
                                hcdym2 = TW[NT1, 6] - hcsym2;
                                break;
                            }
                        }//end of for

                        hzym2 = ym2 + ym21;
                        for (int k = 1; k <= NT1 - 1; k++)
                        {
                            hgd = TW[NT1, 1] - TW[k, 1];
                            if (hgd <= hzym2)
                            {
                                hcsym2 = TW[k, 6] - (hzym2 - (TW[NT1, 1] - TW[k, 1])) * Math.Cos(TW[k, 2] / PI / 180);
                                hcdz = TW[NT1, 6] - hcsym2;
                                hcdym21 = hcdz - hcdym2;
                                break;
                            }
                        }//end of for 
                        Tx2 = Ts + K0 + (TW[NT1, 6] - hcdym2 - hcdym21) / gt;
                        Px2 = pp - Gm * hcdym21 - Gm1 * hcdym2 - Pw;
                        Vx2 = pp * Tx2 * zx * Vgain / Px2 / tB / ZB;
                        Vx21 = Vx2 + qm2 + Vdz;

                        if (Vx21 >= vhzz)
                        {
                            break;//退出while循环，到  T2=Dt2*N21;
                        }//跳转

                        if (Vx21 <= vlyz)
                        {
                            hx2 = Vx2 / vly;
                        }
                        else if ((Vx21 > vlyz) && (qm21 <= vlyz))
                        {
                            hx2 = (vlyz - qm21) / vly + (Vx2 - (vlyz - qm21)) / vh;
                        }
                        else if (qm21 >= vlyz)
                        {
                            hx2 = Vx2 / vh;
                        }//end if
                        hzhx2 = hx2 + ym2 + ym21;
                        for (int l = 1; l <= NT1 - 1; l++)
                        {
                            hgd = TW[NT1, 1] - TW[l, 1];
                            if (hgd <= hzhx2)
                            {
                                hcshx2 = TW[l, 6] - (hzhx2 - (TW[NT1, 1] - TW[l, 1])) * Math.Cos(TW[l, 2] / PI / 180);
                                hcdhx2 = TW[NT1, 6] - hcshx2;
                                hcshxx2 = hcdhx2 - hcdz;
                                break;
                            }
                        }//end of for  


                        Pat1 = pp - (TW[NT1, 6] - hcshxx2 - hcdym2) * Gm - hcdym2 * Gm1 - Pw;
                        circulatingtime[N1 + i + 1] = Dt2 * i + T1;
                        pax[N1 + i + 1] = Pat1;
                        pitgain[N1 + i + 1] = Vx2;
                        N21 = i;
                        i++;//循环变量自增
                    }//end while
                    maxpax = pax[N1 + N21 + 1];           //最大套压        输出数据 
                    maxpitgain = pitgain[N1 + N21 + 1];   //泥浆池最大增量  输出数据
                    T2 = Dt2 * N21;
                    T3 = Vx2 / Q / 60;
                    ovtime = T1 + T2;//溢流到井口时间 
                    circulatingtime[1 + N21 + 1 + N1] = T1 + T2 + T3;
                    deltaPa = ym21 * (Gm1 - Gm);
                    pax[1 + N21 + 1 + N1] = deltaPa;
                    pitgain[1 + N21 + 1 + N1] = 0;
                    T4 = Vdz / Q / 60;
                    circulatingtime[1 + N21 + 1 + 1 + N1] = T1 + T2 + T3 + T4;
                    pax[1 + N21 + N1 + 1 + 1] = 0;
                    //-c*********************循环压力计算
                    Ptime[1] = 0;
                    pdd[1] = Pti;
                    Ptime[2] = Vdz / Q / 60;
                    pdd[2] = Ptf;
                    Ptime[3] = (Vdz + vhzz) / Q / 60;    //压井总时间  输出数据
                    shigongTime = Ptime[3];//!压井施工时间  输出数据7
                    pdd[3] = Ptf;
                    //-----------------------输出----------------------------
                   /* FileOpp.writeFile(papath, circulatingtime, pax);
                    FileOpp.writeFile(vgmpath, circulatingtime, pitgain);
                    FileOpp.writeFile(pdpath, Ptime, pdd);*/

                }//END OF IF
                else if (oiltype == "oil" || oiltype == "wateroil" || oiltype == "water")//溢流为油-----------------------------
                {
                    pax[1] = pa;                 //初始套压
                    circulatingtime[1] = 0;
                    pitgain[1] = Vgain;
                    T1 = Vdz / Q / 60;
                    N1 = 10;
                    Dt1 = T1 / N1;
                    i = 1;

                    while (i <= N1)
                    {
                        qm1 = Dt1 * i * 60 * Q;
                        Vx1 = qm1 + Vgain;
                        if (Vx1 <= vlyz)
                        {
                            h1 = Vgain / vly;
                        }
                        else if ((Vx1 > vlyz) && (qm1 <= vlyz))
                        {
                            h1 = hly + (Vgain - vlyz) / vh;
                        }
                        else if (qm1 > vlyz)
                        {
                            h1 = Vgain / vh;
                        }//end if

                        for (int j = 1; j <= NT1 - 1; j++)
                        {
                            hgd = TW[NT1, 1] - TW[j, 1];
                            if (hgd <= h1)
                            {
                                hcsh1 = TW[j, 6] - (h1 - (TW[NT1, 1] - TW[j, 1])) * Math.Cos(TW[j, 2] / PI / 180);
                                hcdh1 = TW[NT1, 6] - hcsh1;
                                break;
                            }
                        }//end of for  
                        pax[1 + i] = pp - Gm * (TW[NT1, 6] - hcdh1) - Dens * 0.00981 * hcdh1;
                        circulatingtime[1 + i] = Dt1 * i;
                        pitgain[1 + i] = Vgain;
                        i++;
                    }//end while
                    T2 = vhzz;
                    N2 = 10;
                    Dt2 = T2 / N2;
                    i = 1;
                    while (i <= N2)
                    {
                        qm2 = Dt2 * i * 60 * Q;
                        Vx21 = qm2 + Vdz + Vgain;
                        Vx22 = qm2 + Vdz;
                        if (Vx21 <= vlyz)
                        {
                            h21 = Vgain / vly;
                            h22 = Vdz / vly;
                            h23 = qm2 / vly;
                        }
                        else if ((Vx21 > vlyz) && (Vx22 <= vlyz))
                        {
                            h21 = (vlyz - Vx22) / vly + (Vgain - (vlyz - Vx22)) / vh;
                            h22 = Vdz / vly;
                            h23 = qm2 / vly;
                        }
                        else if ((qm2 <= vlyz) && (Vx22 > vlyz))
                        {
                            h21 = Vgain / vh;
                            h22 = (vlyz - qm2) / vly + (Vdz - (vlyz - qm2)) / vh;
                            h23 = qm2 / vly;
                        }
                        else if (qm2 > vlyz)
                        {
                            h21 = Vgain / vh;
                            h22 = Vdz / vh;
                            h23 = qm2 / vh;
                        }//end if

                        for (int j = 1; j <= NT1 - 1; j++)
                        {
                            hgd = TW[NT1, 1] - TW[j, 1];
                            if (hgd <= h23)
                            {
                                hcsh21 = TW[j, 6] - (h23 - (TW[NT1, 1] - TW[j, 1])) * Math.Cos(TW[j, 2] / PI / 180);
                                hcdh21 = TW[NT1, 6] - hcsh21;
                                break;
                            }
                        }//end of for  !重泥浆高度

                        hh22 = h23 + h22;


                        for (int j = 1; j <= NT1 - 1; j++)
                        {
                            hgd = TW[NT1, 1] - TW[j, 1];
                            if (hgd <= h22)
                            {
                                hcshh22 = TW[j, 6] - (hh22 - (TW[NT1, 1] - TW[j, 1])) * Math.Cos(TW[j, 2] / PI / 180);
                                hcdhh22 = TW[NT1, 6] - hcshh22;
                                hcd22 = hcdhh22 - hcdh21;
                                break;
                            }
                        }//end of for !轻泥浆高度
                        hh33 = h21 + h22 + h23;

                        for (int j = 1; j <= NT1 - 1; j++)
                        {
                            hgd = TW[NT1, 1] - TW[j, 1];
                            if (hgd <= hh33)
                            {
                                hcshh33 = TW[j, 6] - (hh33 - (TW[NT1, 1] - TW[j, 1])) * Math.Cos(TW[j, 2] / PI / 180);
                                hcdhh33 = TW[NT1, 6] - hcshh33;
                                hcd23 = hcdhh33 - hcd22 - hcdh21;
                                break;
                            }
                        }//end of for  !溢流长度


                        pax[1 + i + N1] = pp - Gm * (TW[NT1, 6] - hcd23 - hcdh21) - Dens * 0.00981 * hcd23 - Gm1 * hcdh21;
                        circulatingtime[1 + i + N1] = Dt1 * i + T1;
                        pitgain[1 + i + N1] = Vgain;
                        maxpax = pax[N1 + N21 + 1];          // !最大套压        输出数据 
                        maxpitgain = pitgain[N1 + N21 + 1];   //!泥浆池最大增量  输出数据
                        i++;
                    }//END WHILE
                    ovtime = circulatingtime[1 + N2 + N1];//溢流到井口时间 
                    T3 = Vgain / Q / 60;    // !排除溢流
                    pax[1 + N2 + N1 + 1] = 0;
                    pitgain[1 + N2 + N1 + 1] = Vgain;
                    circulatingtime[1 + N2 + N1 + 1] = T1 + T2 + T3;

                    // c*********************循环压力计算	 
                    Ptime[1] = 0;
                    pdd[1] = Pti;
                    Ptime[2] = Vdz / Q / 60;
                    pdd[2] = Ptf;
                    Ptime[3] = (Vdz + vhzz) / Q / 60;//!压井施工时间   输出数据7
                    shigongTime = Ptime[3];//!压井施工时间  输出数据7
                    pdd[3] = Ptf;

                }


            }


        /// <summary>
        /// 工程师法压井 ---- 起下钻能配置钻井液情况下,直井定向井通用。8.28-------------
        /// </summary>
        /// <param name="D">井眼直径</param>
        /// <param name="Dp">钻杆外径</param>
        /// <param name="hd">hd=3000，低泵速实验井深m</param>
        /// <param name="pcd">pcd=6320000，低泵速情况下循环压耗 Pa</param>
        /// <param name="Qzj">钻井排量</param>
        /// <param name="ztl">钻头位置井深</param>
        /// 
        /// 输入也参与输出：
        /// <param name="Pa">管井套压，用于画图</param>，
        /// <param name="yjden">压井液密度，用户输入，判断能配置后传递下来</param>----输出
        /// 
        /// 输出：
        /// <param name="t1">第一阶段时间，用于画图，不输出</param>
        /// <param name="tyj">压井施工时间</param>----输出
        /// <param name="Qyj">压井施工排量</param>----输出
        /// <param name="Ppc">终了循环压力</param>----输出
        /// <param name="Vyj">压井施工泥浆量</param>----输出
        /// 
        /// 曲线：（时间，压力）点1（0，Pa），点2（t1，Pa），点3（t1，Ppc），点4（tyj，Ppc）连成折线。 
        public void EngMethod_QiXiaZuan_Small(double ztl, ref double t1, ref double tyj, ref double Qyj, ref double Ppc, ref double Vyj, double Userden)
        {
            //----------定义变量(变量必须先定义再使用)，赋初值---------------         

            double pc = 0;    //单位深度循环压耗  Pa/m 
            double Cdpca1 = 0;   //单位长度井眼容积容积，外
            double Cdpca2 = 0;   //单位长度井眼容积容积，内 

            //------------------------------------------------输出1，压井液密度， Userden

            //在此须先调用ZJZH函数计算钻杆内外容积！！！！！！！！！！！！！！！！！！！
            double szjvi = 0;
            double szjvo = 0;
            ZJZH(ref szjvi, ref szjvo);


            double Vdz = szjvi;                     //钻杆内容积----szjvi，由钻具组合计算得          
            double vh = PI * (Math.Pow((D / 1000), 2)) / 4;        //单位长度套管段容积不含钻杆
            double vly = PI * (Math.Pow((Dly / 1000), 2)) / 4;     //单位长度裸眼段容积不含钻杆
            double vhz = vh * htx + vly * hly;           //环空总容积不含钻杆
            double vhz1 = vhz - szjvo;                   //环空总容积减去钻杆szjvo，钻具组合计算得来
            double vjt = Vdz + vhz1;                     //井筒总容积

            //环空钻具均值处理
            double Spav = szjvo / h;               //钻杆平均截面积--
            double Dpav = Math.Sqrt(Spav * 4 / PI);     //钻杆平均外径--开方          
            vlyz = (vly - Spav) * hly;      //裸眼段环空体积
            double vth = (vh - Spav) * htx;        //套管段的容积
            double vlys = vly - Spav;              //减去钻杆后的裸眼截面积--
            double vhs = vh - Spav;                //减去钻杆后的套管截面积-
                                                   //-------------------------计算---------------

            pc = pcd / hd;  //单位深度循环压耗  Pa/m 
            Ppc = pc * Userden / Pm * ztl;  //-------------------------------------------------输出5，终了循环压压力

            Cdpca1 = Math.PI * (Math.Pow(D / 1000, 2) - Math.Pow(Dp / 1000, 2)) / 4; //单位长度环空体积,外
            Cdpca2 = Math.PI * (Math.Pow(Dp / 1000, 2)) / 4;  //单位长度环空体积,内       
            Qyj = (qn / 1000) / 2;   //-----------------------------------------------------输出2，压井排量
            t1 = Vdz / Qyj / 60;  //Cdpca2 * ztl / Qyj;
            tyj = vhs * ztl / Qyj / 60;   //t1 + Cdpca1 * ztl / Qyj;
            Vyj = Vdz + vhs * ztl;//--------------------------------------------------输出3，压井泥浆量
            this.Vyj = Vyj;
            this.tyj = tyj + t1;//--------------------------------------------------输出4，压井时间
            this.Ppc = Ppc;
            this.Vdz = Vdz;
            this.vhz1 = vhz1;

        }


        /// <summary>
        /// 工程师压井法----------小工程师之后，适用油水&气，适用直井&定向井。8.28------------
        /// </summary>
        /// 
        /// 画图：（时间，立压）点（0，Pd0），点（T1，Pd1）,点（Tz，Pd1）连成线

        public void EngMethod_QiXiaZuan_Big(int NT1, double userZyjDens, double ztl,
                                            ref double Q, ref double T1, ref double Tz,ref double pp,
                                            ref double Pd0, ref double Pd1)
        {

            //---------------------------------------------------------传入数据
            //int NT1 = 300;     //NT1
            //double pm1 = 1.5;  //!压井泥浆密度,g/cm3---------------来源于小工程师法输入   
            //double qn = 0.35;  //钻井排量，m3/s
            //double D = 215.9;  //井眼直径，mm
            //double Dp = 127;   //钻杆直径，mm
            //double zjden = 1.2;//
            //double Pm = zjden;  //钻井液密度，
            //double htx = 1000;  //套管鞋深度，m
            //double deltd = 7.5;  //钻杆壁厚，mm
            //double pcd =30 ;    //低泵速实验压力，Mpa
            //double hd=1000;  //低泵速实验井深，m

            //double Q = 0;// !压井排量---------------------------------------上步传入不变--------输出数据，3
            //double T1 = 0;  //轻泥浆循环到井底时间,min---------
            //double Tz = 0;  //压井施工时间,min--------------------------------------------------输出数据，4
            //double pp = 0;//地层压力，Mpa-------------------------------------------------------输出数据，1
            //double Pd0 = 0;//初始循环压力，Mpa--------------------------------------------------输出数据，6
            //double Pd1 = 0;//终了循环压力，Mpa--------------------------------------------------输出数据，5

            double pm1 = userZyjDens;  //压井液密度g/cm3----------------------------上步传入不变，输出数据，2

            //在此须先调用ZJZH函数计算钻杆内外容积！！！！！！！！！！！！！！！！！！！
            double szjvi = 0;
            double szjvo = 0;
            ZJZH(ref szjvi, ref szjvo);


            double Vdz = szjvi;                     //钻杆内容积-------------------------------------------------szjvi，由钻具组合计算得          
            double vh = PI * (Math.Pow((D / 1000), 2)) / 4;        //单位长度套管段容积不含钻杆
            double vly = PI * (Math.Pow((Dly / 1000), 2)) / 4;     //单位长度裸眼段容积不含钻杆
            double vhz = vh * htx + vly * hly;           //环空总容积不含钻杆
            double vhz1 = vhz - szjvo;                   //环空总容积减去钻杆******  -----------------------szjvo，钻具组合计算得来
            double vjt = Vdz + vhz1;                     //井筒总容积

            //环空钻具均值处理
            double Spav = szjvo / h;			   //钻杆平均截面积--
            double Dpav = Math.Sqrt(Spav * 4 / PI);     //钻杆平均外径------------------------------开方          
            vlyz = (vly - Spav) * hly;      //裸眼段环空体积
            double vth = (vh - Spav) * htx;        //套管段的容积
            double vlys = vly - Spav;              //减去钻杆后的裸眼截面积-------------fortran里单独为vlys
            double vhs = vh - Spav;                //减去钻杆后的套管截面积-------------fortran里单独为vhs


            double Vdzl = Vdz + (h - ztl) * Math.Pow((Dp - 2 * deltd), 2) / 1000000 * PI / 4;
            //------------------------------计算-------------------------- 
            double Gm1 = pm1 * 0.0098;
            double Gm = 0.0098 * Pm;

            T1 = Vdzl / Q / 60;  //轻泥浆循环到井底时间,min
            Tz = (vhz - szjvo - (h - ztl) * Math.Pow((Dp), 2) * PI / 4 / 1000000) / Q / 60;  //压井施工时间,min

            jtzrj = (vhz - szjvo - (h - ztl) * Math.Pow((Dp), 2) * PI / 4 / 1000000);//井筒总容积

            double pc0 = pcd / hd;  //钻井液单位井深循环压耗
            double pc1 = pc0 * Gm1 / Gm;  //压井液单位井深循环压耗
            double Ppc0 = pc1 * ztl + pc0 * (h - ztl);//混合压耗
            double Ppc1 = pc0 * h;//钻井液压耗
            int m1 = 0;

            if (strWellType == "定向井")
            {
                double hh = ztl;//转ztl
                for (int i = 1; i <= NT1; i++)
                {
                    if (TW[i, 1] >= hh)
                    {
                        m1 = i;
                        break;
                    }
                }
                ztl = (TW[m1, 6] - (TW[m1, 1] - hh) * Math.Cos(TW[m1, 2]));
                h = TW[NT1, 6];
            }

            pp = 0.0098 * Pm * h;//地层压力------------------------------------
            Pd0 = pp - Gm1 * ztl - Gm * (h - ztl) + Ppc0;//初始循环压力----------
            Pd1 = pp - Gm * h + Ppc1;//终了循环压力-------------------------

            this.pm1 = pm1;
            this.Q = Q;
            this.Ppc0 = Ppc0;
            this.pp = pp;
            this.T1 = T1;
            this.Tz = Tz;
            this.Pd0 = Pd0;
            this.Pd1 = Pd1;
            //钻具内容积等赋值-----------------------

            this.Vdz = Vdz;
            this.vhz1 = vhz1;
            this.vjt = vjt;

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




            //输出------------------------------------------------------------
            //1.基础参数------------------------------------
            //井号

            public string getWellNo()
            {
                return strWellNo;

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
            //井型
            public string getWellType()
            {
                return strWellType;

            }

            //井深
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
            //套管鞋深度
            public double gethtx()
            {
                return htx;

            }
            //钻头尺寸
            public double getDly()
            {
                return Dly;

            }
            //套管尺寸/直径
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
                return m_JkEdYl;

            }
            //最大允许关井套压
            public double getmaxGJYl()
            {
                return m_maxGJYl;

            }
            //钻井液密度
            public double getPm()
            {
                return Pm;

            }
            //钻井液排量
            public double getqn()
            {
                return qn;

            }


            //2.溢流关井数据----------------------------
            //关井套压
            public double getPa()
            {
                return pa;

            }
            //关井立压
            public double getPd()
            {
                return Pd;

            }
            //泥浆池增量
            public double getVgain()
            {
                return Vgain;

            }
            //地层类型
            public string getoiltype()
            {
                return oiltype;

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
                return pp;

            }
            // !地层压力
        
            /// <summary>
            /// 压井液密度
            /// </summary>
            /// <returns></returns>
         
            //井口最大允许套压
           
            //压井排量
           
            //套压曲线
          
            //立压曲线
           
            /// <summary>
            /// 套压时间 
            /// </summary>
            /// <returns></returns>
       
            /// <summary>
            /// 立压时间
            /// </summary>
            /// <returns></returns>
         

            // 附加当量钻井液密度
            public double getddden()
            {
                return ddden;

            }
            /// <summary>
            /// !压井泥浆密度 --输出数据2
            /// </summary>
            /// <returns></returns>
            public double getPm1()
            {
                return pm1;

            }
            /// <summary>
            /// !压井排量---输出数据3
            /// </summary>
            /// <returns></returns>
            public double getQ()
            {
                return Q;

            }
            //初始循环压力
            public double getPc()
            {
                return pc;

            }

            /// <summary>
            /// //!初始循环压力--输出数据4
            /// </summary>
            /// <returns></returns>
            public double getPti()
            {
                return Pti;

            }
            /// <summary>
            /// 终了循环压力-- 输出数据5
            /// </summary>
            /// <returns></returns>
            public double getPtf()
            {
                return Ptf;

            }
            /// <summary>
            /// 最大套压  输出数据6    
            /// </summary>
            /// <returns></returns>
            public double getPamax()
            {
                return pamax;

            }

        
            /// <summary>
            /// 定向井 最大套压  输出数据-------用这个做施工单输出 
            /// </summary>
            /// <returns></returns>
            public double getMaxpax()
            {
                return maxpax;

            }

            /// <summary>
            /// 泥浆池最大增量----输出数据8
            /// </summary>
            /// <returns></returns>
            public double getVgainmax()
            {
                return vgainmax;

            }

            /// <summary>
            /// 定向井----泥浆池最大增量----输出数据-------用这个做施工单输出
            /// </summary>
            /// <returns></returns>
            public double getMaxpitgain()
            {
                return maxpitgain;

            }


            public double getT1()
            {
                return T1;

            }
            public double getT2()
            {
                return T2;

            }
            public double getTz()
            {
                return Tz;

            }
            public double getTh()
            {
                return Th;

            }
            //4.-----------起下钻-----------第一次工程师-------------
            public double getVyj()
            {
                return Vyj;
            }
            public double gettyj()
            {
                return tyj;
            }
            public double getPpc()
            {
                return Ppc;
            }

            //井筒总容积
            public double getjtzrj()
            {
                return jtzrj;
            }

            public double gett1()
            {
                return T1;

            }

            public double getPpc0()
            {
                return Ppc0;
            }
            public double getPd0()
            {
                return Pd0;
            }
            public double getPd1()
            {
                return Pd1;
            }
            //----------------------------------------------------------------------------------------------------------------------
            /// <summary> 
            /// 返回PA，节流压力
            /// </summary>
            /// <returns></returns>
            public double[] getPA()
            {

                return pax;

            }
            /// <summary>
            /// 返回PD，立管压力
            /// </summary>
            /// <returns></returns>
            public double[] getPD()
            {
                return pdd;

            }
            /// <summary>
            /// 返回泥浆池增量，VGM
            /// </summary>
            /// <returns></returns>
            public double[] getVGM()
            {
                return pitgain;

            }
            /// <summary>
            /// 返回时间刻度
            /// </summary>
            /// <returns></returns>
            public double[] getCirculatingTime()
            {
                return circulatingtime;

            }

            /// <summary>
            /// 返回时间刻度
            /// </summary>
            /// <returns></returns>
            public double[] getPTime()
            {
                return Ptime;

            }


            /// <summary>
            /// 压井施工时间----输出数据7
            /// </summary>
            /// <returns></returns>
            public double getShigongTime()
            {
                return shigongTime;

            }

            /// <summary>
            /// 溢流到井口时间-----输出数据9 
            /// </summary>
            /// <returns></returns>
            public double getOvtime()
            {
                return ovtime;

            }
            /// <summary>
            /// 计算后的井眼轨迹数据
            /// </summary>
            /// <returns></returns>
            public double[,] getTW()
            {
                return TW;

            }

            //-----------补充输出数据--用于压井施工单----------------

            /// <summary>
            /// 钻具内容积
            /// </summary>
            /// <returns></returns>
            public double getVd()
            {
                return Vd;

            }


            public double getvhzz()
            {
                return vhzz;

            }





            public double getDp()
            {
                return Dp;

            }

            public double getvlyz()
            {
                return vlyz;

            }

            //---------补充-------


            public double getDens()//溢流密度
            {
                return Dens;

            }
            public void setDens(double Dens)//溢流密度
            {
                this.Dens = Dens;

            }

            public double[] getSHEN()//溢流密度
            {
                return SHEN;

            }
            public double[] getALFA()//溢流密度
            {
                return ALFA;

            }
            public double[] getFAI()//溢流密度
            {
                return FAI;

            }
            public int getNT()//溢流密度
            {
                return NT;

            }
       }
 }
