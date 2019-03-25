using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 石油专家管理系统.Calcuation
{
    class SZmethod
    {
        

            private const double PI = 3.1415926;
            private const double g = 9.81;
            private const int NT = 300;
            private string strWellNo;//井号------输入1
            private string strProjID;//工程号------输入2
            private string strWellType;//井型---直井，水平井，定向井  ------输入3
            private string oiltype = "";  //判断流体类型：气体，液体！！！！！！！！！！！！！！！------输入4
                                          /// <param name="NT2"></param>钻具组合组数
                                          /// <param name="ZJI"></param>钻杆内径,mm
                                          /// <param name="ZJO"></param>钻杆外径,mm
                                          /// <param name="ZJL"></param>钻杆长度，m
            List<double> ZJI;
            List<double> ZJO;
            List<double> ZJL;
            int NT2;

            //--------------赋初始值------------------------
            //double Pp = 0;//地层压力
            //double yjden = 0;//压井液密度
            //double Pyx = 0;//最大允许井口套压
            //double Qyj = 0;//压井排量




            //输出------------------------------------------------------------------------------------
            //private double Vdl = 0;//堵漏体积
            //private double tdl1 = 0;//堵漏剂到达地层时间
            //private double dlden = 0;//堵漏浆密度
            //private double tdl = 0;//堵漏施工时间
            private double Qyj = 0;//压井排量，堵漏浆排量，稠浆排量 
            private double Pp = 0;//地层压力
            private double Pyx = 0;//井口最大安全压力
            private double yjden = 0;//压井液密度
            private double Pamax = 0;//最大井口套压
            private double ovtime = 0;//溢流到井口的时间
            private double shigongTime = 0;//压井施工总时间
            private double Pti;//!初始循环压力------------------------------------------------------输出数据4
            private double Ptf;//!终了循环压力----------------------------------------------- 输出数据5
                               //套压曲线输出数组
            double[] Pat = new double[54];//套压曲线： tyjp[1-10] 与P at[1-10] 
            double[] Pdt = new double[5];//立压曲线: tyjd[1-4] 与 Pdt[1-4]
        double[] pitgain = new double[54];
            double[] tyjp = new double[54];
            double[] tyjd = new double[5];


            public void SZMethod(string strWellID, string strProjID, string strWellType, string oiltype, List<double> ZJI, List<double> ZJO, List<double> ZJL, int NT2)
            {
                this.strWellNo = strWellID;
                this.strProjID = strProjID;
                this.strWellType = strWellType;
                this.oiltype = oiltype;
                this.ZJI = ZJI;
                this.ZJO = ZJO;
                this.ZJL = ZJL;
                this.NT2 = NT2;

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
            /// <summary>
            /// 地层类型
            /// </summary>
            /// <returns></returns>
            public string getoiltype()
            {

                return oiltype;

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
            /// 返回压井液密度 g/m^3------输出5
            /// </summary>
            /// <returns></returns>
            public double getyjden()
            {

                return yjden;

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
            /// 返回最大套压------输出3
            /// </summary>
            /// <returns></returns>
            public double getPyx()
            {

                return Pyx;

            }



            /// <summary> 
            /// 返回套压曲线
            /// </summary>
            /// <returns></returns>
            public double[] getPat()
            {

                return Pat;

            }
            /// <summary>
            /// 返回立压曲线
            /// </summary>
            /// <returns></returns>
            public double[] getPdt()
            {

                return Pdt;

            }

            /// <summary> 
            /// 返回套压时间
            /// </summary>
            /// <returns></returns>
            public double[] gettyjp()
            {

                return tyjp;

            }
            /// <summary> 
            /// 返回立压时间
            /// </summary>
            /// <returns></returns>
            public double[] gettyjd()
            {

                return tyjd;

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

            public double getpamax()
            {
                return Pamax;

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
        public double []getpitgain()
        {
            return pitgain;
        }





            ///////////////////////////////////////////////////以下为方法主体，分定向井与直井，气液都可以用--------------------------------------------------------



            /// <summary>
            /// 钻井---气---司钻法06--本身只适用于钻进气，暂时先通用。
            /// </summary>
            /// <param name="Pd">立管压力</param>
            /// <param name="Pa">套管压力</param>
            /// <param name="Vgain">溢流流体体积</param>
            /// <param name="zjden">钻井液密度</param>-------实际传入为上一次施工的压井液密度
            /// <param name="Qzj">钻井排量</param>
            /// <param name="h">井深</param>
            /// <param name="htx">套管鞋深度</param>
            /// <param name="Psafejk">井口耐压值</param>
            /// <param name="Psafetx">套鞋耐压值</param> 
            /// <param name="Psafetg">套管耐压值</param> 
            /// <param name="D">井眼直径，套管直径</param>
            /// <param name="Dly">裸眼直径</param>
            /// <param name="gt">地热增温率</param>     gt = douDrZWL;//地热增温率,  Ts = douWellTemp;//井口温度
            /// <param name="Ts">井口温度，℃</param>
            /// <param name="pc">单位长度循环压耗，MPa/m </param>---------预先先处理。地泵速压耗/地泵速井深       
            public void SZF(double Pd, double Pa, double Vgain, double zjden, double Qzj, double h, double htx,
                                  double Psafejk, double Psafetx, double Psafetg, double D, double Dly, double gt, double Ts, double pc)
            {
                //--------------赋初始值------------------------
                //double Pp = 0;//地层压力
                //double yjden = 0;//压井液密度
                //double Pyx = 0;//最大允许井口套压
                //double Qyj = 0;//压井排量
                //double Pamax = 0;//最大井口套压
                //double ovtime = 0;//溢流到井口的时间
                //double shigongTime = 0;//压井施工总时间

                //double[] Pat = new double[54];//套压曲线： tyjp[] 与Pat[] ----------------------------------套压曲线
                //double[] Pdt = new double[5];//立压曲线:   tyjd[1-4] 与 Pdt[1-4]----------------------------套压曲线立压曲线

                //double[] tyjp = new double[54];
                //double[] tyjd = new double[5];

                //钻具以及体积计算
                double vhs = PI * (Math.Pow((D / 1000), 2)) / 4;     //单位长度套管段容积，无钻杆////////////1207
                double vlys = PI * (Math.Pow((Dly / 1000), 2)) / 4;  //单位长度裸眼段容积，无钻杆
                double vhz = vhs * htx + vlys * (h - htx);           //井眼总容积，无钻杆,m3
                double szjvi = 0; double szjvo = 0;
                ZJZH(ref szjvi, ref szjvo);  //调用<钻具组合>函数
                double vhs2 = vhs - szjvo / h;      //套管段环空面积，含钻杆
                double vlys2 = vlys - szjvo / h;    //裸眼段环空面积，含钻杆
                double vhz1 = vhz - szjvo;    //环空总容积减去钻杆

                //气体高度计算
                double hg = Vgain / vlys2;
                if (hg > h - htx)
                {
                    hg = (h - htx) + (Vgain - vlys2 * (h - htx)) / vhs2;
                }
                double Dens = (zjden - (Pa - Pd) / 0.00981 / hg);

                //计算
                Pp = zjden * 0.00981 * h + Pd;////////////-------------------------------------------------输出1
                yjden = Pp / 0.00981 / h + 0.05;////////////-----------------------------------------------输出2，压井液密度g/cm3
                Pyx = Math.Min(Math.Min(0.9 * Psafejk, Psafetx - yjden * 0.00981 * htx), 0.8 * Psafetg - yjden * 0.00981 * htx);//取三个数中的最小值
                                                                                                                                ////////////---------------------------------------------------------输出6，井口最大允许套压（MPa）

                Qyj = Qzj;////////////-----------------------------------------------输出3，压井液排量，L/s
                double tdl1 = szjvi / (Qyj / 1000);



                //钻进-气-司钻法。.......................
                //对应参数赋值。
                double Q = Qzj / 1000;
                double hly = h - htx;
                double vlyz = vlys2 * hly;
                double Gm = 0.00981 * zjden;
                double Pw = (zjden - (Pa - Pd) / 0.00981 / hg) * 0.00981 * hg; //Pw = Dens * 0.00981 * hw;
                Pti = Pd + pc * h;//!初始循环压力////////////----------------------------------------------------------输出4
                Ptf = yjden * pc * h / zjden;//!终了循环压力////////////-----------------------------------------------输出5
                double pp = Pp;
                double pm1 = yjden;
                double Vd = szjvi / h;
                double Vdz = szjvi;
                double vh = vhs2; //PI * (Math.Pow((D / 1000), 2) - Math.Pow((Dp / 1000), 2)) / 4;
                double vly = vlys2; //PI * (Math.Pow((Dly / 1000), 2) - Math.Pow((Dp / 1000), 2)) / 4;
                double vth = vh * htx;
                double vhzz = vhz;
                double Gm1 = pm1 * 0.00981;
                //中间参数
                double Vx2 = 0, Px1 = 0, qm1 = 0, ym1 = 0, Tx1 = 0, Vx1 = 0, hx1 = 0;

                //常量
                double zx = 1;
                double ZB = 1;
                double K0 = 273;
                double tB = h / gt + Ts + K0;//gt = douDrZWL;//地热增温率,  Ts = douWellTemp;//井口温度

                double T1 = tdl1 + vhz1 / (Qyj / 1000);//一阶段时间，新井浆到达井底
                int N1 = 50;
                double Dt1 = T1 / N1;
                int i = 1;
                double Txs = Ts + K0;

                Pat[0] = Pa;
                tyjp[0] = 0;
            pitgain[0] = Vgain;

                //(1)司钻法第一周循环


                while (i <= N1)
                {
                    qm1 = Dt1 * i * Q;//片段时间进入的体积
                    if (qm1 <= vlyz)
                    {
                        ym1 = qm1 / vlys2;//进入外环空的钻井液的则算长度
                    }
                    else if (qm1 > vlyz)
                    {
                        ym1 = hly + (qm1 - vlyz) / vhs2;
                    }
                    Tx1 = Ts + K0 + (h - ym1) / gt;
                    Px1 = Pp - Gm * ym1 - Pw;//气体上部压力
                    Vx1 = Pp * Tx1 * zx * Vgain / Px1 / tB / ZB;//此刻气体体积
                                                                //Vx2 = ym1 * vlys2;//
                    Vx2 = Vx1 + qm1;//下部流体+气体 的体积
                    hx1 = 0;

                    if (Vx2 >= vhz1 + szjvi)
                    {
                        ovtime = Dt1 * (i - 1);//溢流到井口时间////////////-----------------------------------------------输出8
                        break;//退出循环
                    }

                    if (Vx2 <= vlyz)
                    {
                        hx1 = Vx1 / vlys2;
                    }
                    else if (Vx2 > vlyz && qm1 < vlyz)
                    {
                        hx1 = (vlyz - qm1) / vlys2 + (Vx2 - vlyz) / vhs2;
                    }
                    else if (qm1 > vlyz)
                    {
                        hx1 = Vx1 / vh;
                    }
                    //画曲线 
                    Pat[i] = Pp - (h - hx1) * Gm - Pw;
                    tyjp[i] = Dt1 * i;
                pitgain[i] = Vx1;
                    i++;
                }

                //!排除溢流
                double T2 = Vx1 / Q;
                tyjp[i] = T1 + T2;
                Pat[i] = pp - Gm * h;
            pitgain[i] = 0;

                // !排除溢流
                double T3 = Vdz / Q;
                tyjp[1 + i] = T1 + T2 + T3;
                Pat[1 + i] = pp - Gm * h;

                //循环环空泥浆替换为重泥浆
                double T4 = vhzz / Q;
                tyjp[1 + i + 1] = T1 + T2 + T3 + T4;
                Pat[1 + i + 1] = 0;

                Pamax = Pat.Max();////////////-----------------------------------------------输出7，最大套压值
                shigongTime = T1 + T2 + T3 + T4;////////////---------------------------------输出9，压井施工时间/60，min

                //循环压力计算	
                tyjd[1] = 0;
                Pdt[1] = Pti;
                tyjd[2] = T1 + T2;
                Pdt[2] = Pti;
                tyjd[3] = T1 + T2 + T3;
                Pdt[3] = Ptf;
                tyjd[4] = T1 + T2 + T3 + T4;
                Pdt[4] = Ptf;
            }


            /// <summary>
            /// 定向井---钻井---气---司钻法06
            /// </summary>
            /// <param name="Pd">立管压力</param>
            /// <param name="Pa">套管压力</param>
            /// <param name="Vgain">溢流流体体积</param>
            /// <param name="zjden">钻井液密度</param>-------实际传入为上一次施工的压井液密度
            /// <param name="Qzj">钻井排量</param>
            /// <param name="h">井深</param>
            /// <param name="htx">套管鞋深度</param>
            /// <param name="Psafejk">井口耐压值</param>
            /// <param name="Psafetx">套鞋耐压值</param> 
            /// <param name="Psafetg">套管耐压值</param> 
            /// <param name="D">井眼直径，套管直径</param>
            /// <param name="Dly">裸眼直径</param>
            /// <param name="gt">地热增温率</param>     gt = douDrZWL;//地热增温率,  Ts = douWellTemp;//井口温度
            /// <param name="Ts">井口温度，℃</param>
            /// <param name="pc">单位长度循环压耗，MPa/m </param>---------预先先处理。地泵速压耗/地泵速井深       
            public void SZF_wt(double Pd, double Pa, double Vgain, double zjden, double Qzj, double h, double htx,
                                  double Psafejk, double Psafetx, double Psafetg, double D, double Dly, double gt, double Ts, double pc, double[,] TW)
            {
                //--------------赋初始值------------------------
                //double Pp = 0;//地层压力
                //double yjden = 0;//压井液密度
                //double Pyx = 0;//最大允许井口套压
                //double Qyj = 0;//压井排量
                //double Pamax = 0;//最大井口套压
                //double ovtime = 0;//溢流到井口的时间
                //double shigongTime = 0;//压井施工总时间

                //double[] Pat = new double[54];//套压曲线： tyjp[1-10] 与P at[1-10] 
                //double[] Pdt = new double[5];//立压曲线: tyjd[1-4] 与 Pdt[1-4]

                //double[] tyjp = new double[54];
                //double[] tyjd = new double[5];

                //钻具以及体积计算
                double vhs = PI * (Math.Pow((D / 1000), 2)) / 4;     //单位长度套管段容积，无钻杆////////////1207
                double vlys = PI * (Math.Pow((Dly / 1000), 2)) / 4;  //单位长度裸眼段容积，无钻杆
                double vhz = vhs * htx + vlys * (h - htx);           //井眼总容积，无钻杆,m3
                double szjvi = 0; double szjvo = 0;
                ZJZH(ref szjvi, ref szjvo);  //调用<钻具组合>函数
                double vhs2 = vhs - szjvo / h;      //套管段环空面积，含钻杆
                double vlys2 = vlys - szjvo / h;    //裸眼段环空面积，含钻杆
                double vhz1 = vhz - szjvo;    //环空总容积减去钻杆

                double hcs = HtoV(TW, h);
                double htxcs = HtoV(TW, htx);

                //气体高度计算
                double hg = Vgain / vlys2;
                if (hg > h - htx)
                {
                    hg = (h - htx) + (Vgain - vlys2 * (h - htx)) / vhs2;
                }
                hg = hcs - HtoV(TW, h - hg);
                double Dens = (zjden - (Pa - Pd) / 0.00981 / hg);

                //计算
                Pp = zjden * 0.00981 * hcs + Pd;
                yjden = Pp / 0.00981 / hcs + 0.05;
                Pyx = Math.Min(Math.Min(0.9 * Psafejk, Psafetx - yjden * 0.00981 * htxcs), 0.8 * Psafetg - yjden * 0.00981 * htxcs);//取三个数中的最小值
                Qyj = Qzj;
                double tdl1 = szjvi / (Qyj / 1000);



                //钻进-气-司钻法。.......................
                //对应参数赋值。
                double Q = Qzj / 1000;
                double hly = h - htx;
                double vlyz = vlys2 * hly;
                double Gm = 0.00981 * zjden;
                double Pw = (zjden - (Pa - Pd) / 0.00981 / hg) * 0.00981 * hg; //Pw = Dens * 0.00981 * hw;
                Pti = Pd + pc * h;//!初始循环压力
                Ptf = yjden * pc * h / zjden;//!终了循环压力
                double pp = Pp;
                double pm1 = yjden;
                double Vd = szjvi / h;
                double Vdz = szjvi;
                double vh = vhs2; //PI * (Math.Pow((D / 1000), 2) - Math.Pow((Dp / 1000), 2)) / 4;
                double vly = vlys2; //PI * (Math.Pow((Dly / 1000), 2) - Math.Pow((Dp / 1000), 2)) / 4;
                double vth = vh * htx;
                double vhzz = vhz;
                double Gm1 = pm1 * 0.00981;
                //中间参数
                double Vx2 = 0, Px1 = 0, qm1 = 0, ym1 = 0, Tx1 = 0, Vx1 = 0, hx1 = 0;
                double ym1c = 0, hx1c = 0;
                //常量
                double zx = 1;
                double ZB = 1;
                double K0 = 273;
                double tB = h / gt + Ts + K0;//gt = douDrZWL;//地热增温率,  Ts = douWellTemp;//井口温度

                double T1 = tdl1 + vhz1 / (Qyj / 1000);//一阶段时间，新井浆到达井底
                int N1 = 50;
                double Dt1 = T1 / N1;
                int i = 1;
                double Txs = Ts + K0;

                Pat[0] = Pa;
                tyjp[0] = 0;

                //Pw=Dens*0.00981*(TW(NT1,6)-hwcs)      !溢流在井底产生的气柱压力
                //pax(1)=pa                 !初始套压
                //  circulatingtime(1)=0
                //pitgain(1)=Vgain

                //(1)司钻法第一周循环


                while (i <= N1)
                {
                    qm1 = Dt1 * i * Q;//片段时间进入的体积
                    if (qm1 <= vlyz)
                    {
                        ym1 = qm1 / vlys2;//进入外环空的钻井液的则算长度
                    }
                    else if (qm1 > vlyz)
                    {
                        ym1 = hly + (qm1 - vlyz) / vhs2;
                    }
                    ym1c = hcs - HtoV(TW, h - ym1);//新进钻井液则算深度

                    Tx1 = Ts + K0 + (h - ym1) / gt;
                    Px1 = Pp - Gm * ym1c - Pw;//气体上部压力
                    Vx1 = Pp * Tx1 * zx * Vgain / Px1 / tB / ZB;//此刻气体体积
                                                                //Vx2 = ym1 * vlys2;//

                    Vx2 = Vx1 + qm1;//下部流体+气体 的体积

                    if (Vx2 >= vhz1 + szjvi)
                    {
                        ovtime = Dt1 * (i - 1);//溢流到井口时间
                        break;//退出循环
                    }

                    if (Vx2 <= vlyz)
                    {
                        hx1 = Vx1 / vlys2;
                    }
                    else if (Vx2 > vlyz && qm1 < vlyz)
                    {
                        hx1 = (vlyz - qm1) / vlys2 + (Vx2 - vlyz) / vhs2;
                    }
                    else if (qm1 > vlyz)
                    {
                        hx1 = Vx1 / vh;
                    }
                    hx1c = (hcs - ym1c) - HtoV(TW, h - ym1 - hx1);//上升后的溢流高度则算深度
                                                                  //Pw = (zjden - (Pa - Pd) / 0.00981 / hx1c) * 0.00981 * hx1c;
                                                                  //画曲线 
                    Pat[i] = Pp - (hcs - hx1c) * Gm - Pw;
                    tyjp[i] = Dt1 * i;
                    i++;
                }

                //!排除溢流
                double T2 = Vx1 / Q;
                tyjp[i] = T1 + T2;
                Pat[i] = pp - Gm * hcs;
                // pitgain(1+N11+1)=0

                // !排除溢流
                double T3 = Vdz / Q;
                tyjp[1 + i] = T1 + T2 + T3;
                Pat[1 + i] = pp - Gm * hcs;

                //循环环空泥浆替换为重泥浆
                double T4 = vhzz / Q;
                tyjp[1 + i + 1] = T1 + T2 + T3 + T4;
                Pat[1 + i + 1] = 0;

                Pamax = Pat.Max();
                shigongTime = T1 + T2 + T3 + T4;

                //循环压力计算	
                tyjd[1] = 0;
                Pdt[1] = Pti;
                tyjd[2] = T1 + T2;
                Pdt[2] = Pti;
                tyjd[3] = T1 + T2 + T3;
                Pdt[3] = Ptf;
                tyjd[4] = T1 + T2 + T3 + T4;
                Pdt[4] = Ptf;
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




        }
    
}
