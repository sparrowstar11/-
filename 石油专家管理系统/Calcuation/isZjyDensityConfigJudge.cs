using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 石油专家管理系统.Calcuation
{
    class isZjyDensityConfigJudge
    {
        const double PI = 3.14159265;
        const double g = 0.00981;
        /// <summary>
        /// 起下钻工况能否配置密度判断---------直井
        /// 单位：Pa，m，m2，kg/m3，9.81
        /// 
        /// </summary>
        /// <param name="ztl">钻头位置深度</param>
        /// <param name="hshoe">套管鞋位置深度</param>
        /// <param name="denyl">溢流流体密度</param>-------
        /// <param name="Pbs">Pbs=40000000 //套管鞋破裂压力 Pa-----------用户输入
        /// <param name="h">井深</param>
        /// <param name="Pa">关井套压,Pa</param>
        /// <param name="D">井眼直径</param>
        /// <param name="Dp">钻杆直径</param>
        /// <param name="Vgain">溢流体积</param>
        /// <param name="zjden">钻井液密度</param>
        /// <param name="hg">液柱高度，m</param>
        /// <returns>1表示能配置，0表示不能配置</returns>

        public static void isZjyDensityConfigJudge_ZhiJing(double ztl, double hshoe, double denyl, double Pbs, double h,
                                                   double Pa, double D, double Dp, double Vgain, double zjden, double hg,ref double Yjdenmin,ref double Yjdenmax)

        {
            //----------定义变量(变量必须先定义再使用)，赋初值---------------
            //double Userden = 0;   //-------------------------------------------用户输入的钻井液密度，须传入
            //double Cdpca1 = 0;   //单位长度井眼容积容积，上
            //double Cdpca2 = 0;   //单位长度井眼容积容积，下
            //double hg = 0;       //气体长度 m

            double yjdenmin = 0;
            double yjdenmax = 0;

            //Cdpca1 = Math.PI * Math.Pow(D / 1000, 2) - szvjo/h;  //单位长度环空体积,上
            //Cdpca2 = Math.PI * (Math.Pow(D / 1000, 2)) / 4;  //单位长度环空体积,下       

            //工程师法压井液密度 Kg/m^3。密度求解公式详见推导。yjdenmin即为最小压井密度。

            //hg = Vgain / Cdpca2;   //气体高度（长度） m 

            if (hg > h - ztl)
            {
                //hg = (Vgain - (h - ztl) * Cdpca2) / Cdpca1 + (h - ztl);  //淹没情况，情况2
                yjdenmin = denyl + h / ztl * (zjden - denyl);
            }
            else
            {
                yjdenmin = zjden + Pa / g / ztl;              //，情况1
            }

            //已知承受最大压力，位置判断,求最大压井密度。
            if (hshoe <= ztl)
            {
                yjdenmax = Pbs / (g * hshoe);  //全是重浆
            }
            else
            {
                if (hg <= h - hshoe)
                {
                    yjdenmax = (Pbs - zjden * g * (hshoe - ztl)) / (g * ztl);//重浆加钻井液
                }
                else
                {
                    if (hg >= h - ztl)
                    {
                        yjdenmax = (Pbs - denyl * g * (hshoe - ztl)) / (g * ztl);  //重浆加侵入浆
                    }
                    else
                    {
                        yjdenmax = (Pbs - zjden * g * (h - hg - ztl) - denyl * g * (hshoe - (h - hg))) / (g * ztl);//重浆加钻井液加侵入液
                    }
                }
            }
            Yjdenmax = yjdenmax;
            Yjdenmin = yjdenmin;

            /*
            if (Userden >= yjdenmin && Userden <= yjdenmax)
            {
                return 1;
            }
            else
            {
                return 0;
            }*/


        }





        /// <summary>
        /// 起下钻工况能否配置密度判断---------定向井
        /// 单位：Pa，m，m2，kg/m3，9.81
        /// 
        /// </summary>
        /// <param name="ztl">钻头位置深度</param>
        /// <param name="hshoe">套管鞋位置深度</param>
        /// <param name="denyl">溢流流体密度</param>-------
        /// <param name="Pbs">Pbs=40000000 //套管鞋破裂压力 Pa-----------用户输入
        /// <param name="h">井深</param>
        /// <param name="Pa">关井套压</param>
        /// <param name="D">井眼直径</param>
        /// <param name="Dp">钻杆直径</param>
        /// <param name="Vgain">溢流体积</param>
        /// <param name="zjden">钻井液密度</param>
        /// <param name="hg">液柱高度，m</param>
        /// <returns>1表示能配置，0表示不能配置</returns>

        public static void isZjyDensityConfigJudge_DXJ(double ztl, double hshoe, double denyl, double Pbs, double Pa, double D, double Dp,
            double Vgain, double zjden, double[] js, double[] jxj, double[] cs, int nt, double hg)
        {
            //----------定义变量(变量必须先定义再使用)，赋初值---------------

            //-------------------------------------------用户输入的钻井液密度，须传入

            //double Cdpca1 = 0;   //单位长度井眼容积容积，上
            //double Cdpca2 = 0;   //单位长度井眼容积容积，下
            //double h = js[nt];   //井深初值，后面转换成垂深
            //double hg = 0;       //气体长度 m

            //输出：
            double yjdenmin = 0;
            double yjdenmax = 0;

            //Cdpca1 = Math.PI * Math.Pow(D / 1000, 2) - szvjo/cs[nt];  //单位长度环空体积,上----------------
            //Cdpca2 = Math.PI * (Math.Pow(D / 1000, 2)) / 4;  //单位长度环空体积,下       

            int m1 = 0;  //中间参数
            for (int i = 1; i <= nt; i++)
            {
                jxj[i] = jxj[i] * PI / 180;
            }

            //确定溢流气体垂向高度
            // hg = Vgain / Cdpca2;   //气体高度（长度） m 
            //if (hg > h - ztl)
            //{
            //    hg = (Vgain - (h - ztl) * Cdpca2) / Cdpca1 + (h - ztl);  //淹没情况，情况2
            //}
            for (int i = 1; i <= nt; i++)
            {
                if (js[i] >= js[nt] - hg)
                {
                    m1 = i;
                    break;
                }
            }
            hg = cs[nt] - (cs[m1] - (js[m1] - hg) * Math.Cos(jxj[m1]));   //溢流深度，倒


            //确定钻头位置处垂深
            for (int i = 1; i <= nt; i++)
            {
                if (js[i] >= ztl)
                {
                    m1 = i;    //标记
                    break;
                }
            }
            ztl = cs[m1] - (js[m1] - ztl) * Math.Cos(jxj[m1]);   //钻头位置处垂深，赋给原ztl

            //确定套管鞋位置垂深
            for (int i = 1; i <= nt; i++)
            {
                if (js[i] >= hshoe)
                {
                    m1 = i;    //标记
                    break;
                }
            }
            hshoe = cs[m1] - (js[m1] - hshoe) * Math.Cos(jxj[m1]);   //套管鞋垂深，赋给原hshoe

            double h = cs[nt];  //垂深，赋给原h。


            //工程师法压井液密度 Kg/m^3。密度求解公式详见推导。yjdenmin即为最小压井密度。
            if (hg > h - ztl)
            {
                yjdenmin = denyl + h / ztl * (zjden - denyl);
            }
            else
            {
                yjdenmin = zjden + Pa / g / ztl;              //，情况1
            }


            //已知承受最大压力，位置判断,求最大压井密度。
            if (hshoe <= ztl)
            {
                yjdenmax = Pbs / (g * hshoe);
            }
            else
            {
                if (hg <= h - hshoe)
                {
                    yjdenmax = (Pbs - zjden * g * (hshoe - ztl)) / (g * ztl);//重浆加钻井液
                }
                else
                {
                    if (hg >= h - ztl)
                    {
                        yjdenmax = (Pbs - denyl * g * (hshoe - ztl)) / (g * ztl);  //重浆加侵入液
                    }
                    else
                    {
                        yjdenmax = (Pbs - zjden * g * (h - hg - ztl) - denyl * g * (hshoe - (h - hg))) / (g * ztl);//重浆加钻井液加侵入液
                    }
                }
            }


          

        }

    }
}
