using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 石油专家管理系统.Calcuation
{
    class ReplacementMethod
    {
        /// <summary>
        /// 置换法----------------------------------
        /// </summary>
   
            private const double PI = 3.1415926;
            private const double g = 0.00981;

            private string strWellNo;//井号
            private string strWellType;//井型---直井，水平井，定向井
            private double H;//井深
            private double H_shoe;//套管鞋深度 
            private double T;//井口温度---基础数据中 
            private double D_jy;//钻头尺寸 
            private double Den_zj;//钻井液密度
            private double Q;//钻井液排量  douZjyPL/2;
            private double Do_zg;//钻杆外径 
            private double Pa;//关井套压 
            private double V1;//泥浆池增量

            private double Pb = 0;    //井底压力-----------------------------------------用户输入
            private double Pam = 0;   //井口耐压值-----------------------------------------用户输入
            private double Pbs = 0;   //套管鞋破裂压力 Pa----------------------------------用户输入 

            //-------------定义输出变量---------------------------------------三个数组一行列表，没有曲线
            double[] V = new double[15];    //注入压井液的体积
            double[] PPa = new double[15];  //注入压井液之后的套管压力
            double[] Pcha = new double[15];  //释放气体后的压力
                                             /// <summary>
                                             /// 构造方法--无参
                                             /// </summary>
            public ReplacementMethod()
            {


            }


            /// <summary>
            /// 直井-------空井工况
            /// </summary>
            /// <param name="g"></param>
            /// <param name="H"></param>
            /// <param name="H_shoe"></param>
            /// <param name="D_jy"></param>
            /// <param name="Do_zg"></param>
            /// <param name="Pa"></param>
            /// <param name="Pb"></param>
            /// <param name="T"></param>
            /// <param name="Den_zj"></param>
            /// <param name="V1"></param>
            /// <param name="Q"></param>
            /// <param name="Pam"></param>
            /// <param name="Pbs"></param>
            /// <param name="V"></param>
            /// <param name="PPa"></param>
            /// <param name="Pcha"></param>
            public void Replacement_method_wodp(double H, double H_shoe, double D_jy, double Do_zg, double Pa, double Pb, double T,
                              double Den_zj, double V1, double Q, double Pam, double Pbs, ref double[] V, ref double[] PPa, ref double[] Pcha)
            {
                //----------定义变量(变量必须先定义再使用)，赋初值---------------

                double Cdpca = 0;    //单位长度钻杆环空容积 
                double Hg = 0;       //气体长度 m
                double Den_yj = 0;   //压井液密度 kg/m^3
                double P_shoe = 0;   //套管鞋处压力 Pa
                double Dpf = 0;      //套管鞋安全临界压力增量 Pa
                double DV = 0;       //注入压井液的体积
                double[] DP = new double[15];    //套管压力下降值，与泵入的液柱压力相等
                double a = 0;
                double b = 0;
                double c = 0;        //中间系数
                double x = 0;
                double x1 = 0;
                double x2 = 0;
                double y = 0;
            D_jy = D_jy / 1000;
            Do_zg = Do_zg / 1000;
            //-------------------------计算-------------------------
            Cdpca = 3.14159265 / 4 * Math.Pow(D_jy, 2);
                Hg = V1 / Cdpca;
                Den_yj = Pa / g / Hg;
                P_shoe = Pa + Den_zj * g * (H_shoe - V1 / Cdpca);

                //解Den_yj*(V/Cdpca)*g+Pa*V1/(V1-V)-Pa=Pbs
                //即为注入压井液产生的液柱压力和压缩气体的压力
                if (Pa >= 0)
                {
                    for (int i = 1; i < 15; i++)
                    {
                        Dpf = (Pbs - P_shoe) / 2;
                        a = -Den_yj / Cdpca * g;
                        b = Den_yj * g * V1 / Cdpca + Pa + Dpf;
                        c = -Dpf * V1;
                        x1 = Math.Floor(10000 * ((-b + Math.Pow((Math.Pow(b, 2) - 4 * a * c), 0.5)) / 2 / a));
                        x2 = Math.Floor(10000 * ((-b - Math.Pow((Math.Pow(b, 2) - 4 * a * c), 0.5)) / 2 / a));
                        x = Math.Min(x1, x2);

                        y = Math.Floor(10000 * ((Pam - Pa) * V1 / Pam));
                        DV = Math.Min(x, y) / 10000;
                        V[i] = DV;/////////////////////////////////输出
                        PPa[i] = Pa * V1 / (V1 - DV); /////////////////////输出

                        DP[i] = Den_yj * g * V[i] / Cdpca;
                        Pa = Pa - DP[i];
                        V1 = V1 - DV;
                        Pcha[i] =Pa;
                    }
                }

            }





            /// <summary>
            /// 直井-------起下钻、落鱼工况
            /// </summary>
            /// <param name="g"></param>
            /// <param name="H"></param>
            /// <param name="H_shoe"></param>
            /// <param name="D_jy"></param>
            /// <param name="Do_zg"></param>
            /// <param name="Pa"></param>
            /// <param name="Pb"></param>
            /// <param name="T"></param>
            /// <param name="Den_zj"></param>
            /// <param name="V1"></param>
            /// <param name="Q"></param>
            /// <param name="Pam"></param>
            /// <param name="Pbs"></param>
            /// <param name="V"></param>
            /// <param name="PPa"></param>
            /// <param name="Pcha"></param>
            public void Replacement_method_wdp(double H, double H_shoe, double D_jy, double Do_zg, double Pa, double Pb, double T,
                                       double Den_zj, double V1, double Q, double Pam, double Pbs, ref double[] V, ref double[] PPa, ref double[] Pcha, double ztl)
            {
                //----------定义变量(变量必须先定义再使用)，赋初值---------------

                double Cdpca = 0;    //单位长度钻杆环空容积 
                double Hg = 0;       //气体长度 m
                double Den_yj = 0;   //压井液密度 kg/m^3
                double P_shoe = 0;   //套管鞋处压力 Pa
                double Dpf = 0;      //套管鞋安全临界压力增量 Pa
                double DV = 0;       //注入压井液的体积
                double[] DP = new double[15];    //套管压力下降值，与泵入的液柱压力相等
                double a = 0;
                double b = 0;
                double c = 0;        //中间系数
                double x = 0;
                double x1 = 0;
                double x2 = 0;
                double y = 0;
                D_jy = D_jy / 1000;
                Do_zg = Do_zg / 1000;

            //-------------------------计算-------------------------
            Cdpca = PI / 4 * (Math.Pow(D_jy, 2) - Math.Pow(Do_zg, 2));
                Hg = V1 / Cdpca;
                Den_yj = Pa / g / Hg;
                P_shoe = Pa + Den_zj * g * (H_shoe - V1 / Cdpca);

                //解Den_yj*(V/Cdpca)*g+Pa*V1/(V1-V)-Pa=Pbs
                //即为注入压井液产生的液柱压力和压缩气体的压力
                if (Pa >= 0)
                {
                    for (int i = 1; i < 15; i++)
                    {
                        Dpf = (Pbs - P_shoe) / 2;
                        a = -Den_yj / Cdpca * g;
                        b = Den_yj * g * V1 / Cdpca + Pa + Dpf;
                        c = -Dpf * V1;
                        x1 = Math.Floor(10000 * ((-b + Math.Pow((Math.Pow(b, 2) - 4 * a * c), 0.5)) / 2 / a));
                        x2 = Math.Floor(10000 * ((-b - Math.Pow((Math.Pow(b, 2) - 4 * a * c), 0.5)) / 2 / a));
                        x = Math.Min(x1, x2);

                        y = Math.Floor(10000 * ((Pam - Pa) * V1 / Pam));
                        DV = Math.Min(x, y) / 10000;
                        V[i] = DV;/////////////////////////////////输出
                        PPa[i] = Pa * V1 / (V1 - DV); /////////////////////输出

                        DP[i] = Den_yj * g * V[i] / Cdpca;
                        Pa = Pa - DP[i];
                        V1 = V1 - DV;
                        Pcha[i] = Pa;
                    }
                }

            }



            /// <summary>
            /// 定向井-----------------------起下钻、落鱼工况
            /// </summary>
            /// <param name="g"></param>
            /// <param name="nt"></param>
            /// <param name="H_shoe"></param>
            /// <param name="D_jy"></param>
            /// <param name="Do_zg"></param>
            /// <param name="Pa"></param>
            /// <param name="Den_zj"></param>
            /// <param name="V1"></param>
            /// <param name="Pbs"></param>
            /// <param name="js"></param>
            /// <param name="jxj"></param>
            /// <param name="cs"></param>
            /// <param name="vout"></param>
            /// <param name="sfPa"></param>
            /// <param name="zrPa"></param>
            public void Replacement_method_with_trace_wdp(int nt, double H_shoe, double D_jy, double Do_zg, double Pa, double Den_zj,
                                double V1, double Pbs, double[] js, double[] jxj, double[] cs, ref double[] vout, ref double[] sfPa, ref double[] zrPa, double ztl)
            {
                //----------定义变量(变量必须先定义再使用)，赋初值---------------
                //double ztl = js[300];     //增加一个钻头的位置 起下钻工况 和空井工况  输入
                double Cdpca1 = 0;    //单位长度钻杆环空容积 
                double Cdpca2 = 0;    //单位长度井眼容积容积 
                double Cdpca = 0;
                double vwdp = 0;       //有钻杆段环空容积
                double hg = 0;       //气体长度 m
                double yjden = 0;   //压井液密度 kg/m^3
                double P_shoe = 0;   //套管鞋处压力 Pa
                double Dpf = 0;      //安全临界压力增量 Pa
                double v = 0;     //加入钻井液 v 
                double v2 = 0;    //????????????
                double dph = 0;     //增加的液柱压力
                double dpg = 0;       //气体压缩产生的压力


                int m1 = 0;
                int m2 = 0;
                int m3 = 0;
                int j = 0;           //中间系数
                double cs1 = 0;
                double cs2 = 0;
                double cs3 = 0;




                //-------------------------计算-------------------------
                Cdpca1 = PI / 4 * (Math.Pow(D_jy, 2) - Math.Pow(Do_zg, 2));
                Cdpca2 = PI / 4 * Math.Pow(D_jy, 2);
                vwdp = ztl * Cdpca1;

                for (int i = 1; i <= nt; i++)
                {
                    jxj[i] = jxj[i] * PI / 180;
                }

                if (V1 <= vwdp)
                {
                    Cdpca = Cdpca1;
                    hg = V1 / Cdpca;

                    for (int i = 1; i <= nt; i++)
                    {
                        if (js[i] >= hg)
                        {
                            m1 = i;
                            break;  //跳出循环
                        }
                    }
                    cs1 = cs[m1] - Math.Cos(jxj[m1]) * (js[m1] - hg);   //初始液面   334
                    yjden = Pa / g / cs1;           //压井液密度 垂深计算

                    for (int i = 1; i <= nt; i++)
                    {
                        if (js[i] >= H_shoe)
                        {
                            m2 = i;
                            break;  //跳出循环
                        }
                    }
                    cs2 = cs[m2] - Math.Cos(jxj[m2]) * (js[m2] - H_shoe);   //套管鞋垂深
                    P_shoe = Pa + Den_zj * g * (cs[nt] - cs2);  //用垂深计算初始套管鞋处压力
                    Dpf = (Pbs - P_shoe) / 2;    //安全压力增量 保守所写 可修改  

                    //加入钻井液 v 

                    for (int k = 1; k <= 10; k++)
                    {
                        for (j = (int)(10000 * V1); j >= 0; j--)
                        {
                            v = (double)j / 10000;
                            for (int i = 1; i <= nt; i++)
                            {
                                if (js[i] >= (V1 / Cdpca - v / Cdpca))
                                {
                                    m3 = i;  //寻找出加入钻井液v后的液面下最近的一点
                                    break;  //跳出循环
                                }
                            }
                            cs3 = (cs[m3] - Math.Cos(jxj[m3]) * (js[m3] - V1 / Cdpca + v / Cdpca)); //加入压井液液面垂深
                            dph = yjden * g * (cs1 - cs3);     //增加的液柱压力
                            dpg = Pa * V1 / (V1 - v) - Pa;       //气体压缩产生的压力
                                                                 //注入压井液产生的压力接近设定的安全压力
                            if ((Dpf - (dph + dpg) < 100000) && (Dpf - (dph + dpg) > 0))
                            {
                                vout[k] = v;
                                break;  //跳出循环跳出循环jjj。。区别自然循环到0
                            }
                        }
                        if (j == -1)
                        {
                            break;  //如果j自然循环到0则跳出kkk
                        }
                        cs1 = cs3;
                        zrPa[k] = Pa + dpg;
                        sfPa[k] = Pa - dph;
                        V1 = V1 - v;   //剩余气体体积?????????????????????
                        Pa = sfPa[k];
                    }
                }
                else
                {
                    v2 = V1 - vwdp;
                    hg = ztl + v2 / Cdpca2;  //气柱长度
                    for (int i = 1; i <= nt; i++)
                    {
                        if (js[i] >= hg)
                        {
                            m1 = i;
                            break;  //跳出循环
                        }
                    }
                    cs1 = cs[m1] - Math.Cos(jxj[m1]) * (js[m1] - hg);   //初始液面   334
                    yjden = Pa / g / cs1;           //压井液密度 垂深计算

                    for (int i = 1; i <= nt; i++)
                    {
                        if (js[i] >= H_shoe)
                        {
                            m2 = i;
                            break;  //跳出循环
                        }
                    }
                    cs2 = cs[m2] - Math.Cos(jxj[m2]) * (js[m2] - H_shoe);   //套管鞋垂深
                    P_shoe = Pa + Den_zj * g * (cs[nt] - cs2);  //用垂深计算初始套管鞋处压力
                    Dpf = (Pbs - P_shoe) / 2;    //安全压力增量 保守所写 可修改
                                                 //加入钻井液 v   
                    for (int k = 1; k <= 10; k++)
                    {
                        for (j = (int)(10000 * V1); j >= 0; j--)
                        {
                            v = (double)j / 10000;
                            if (v <= v2)
                            {
                                Cdpca = Cdpca2;
                            }
                            else
                            {
                                Cdpca = Cdpca1;
                            }

                            for (int i = 1; i <= nt; i++)
                            {
                                if (js[i] >= (V1 / Cdpca - v / Cdpca))
                                {
                                    m3 = i;  //寻找出加入钻井液v后的液面下最近的一点
                                    break;  //跳出循环
                                }
                            }
                            cs3 = (cs[m3] - Math.Cos(jxj[m3]) * (js[m3] - V1 / Cdpca + v / Cdpca)); //加入压井液液面垂深
                            dph = yjden * g * (cs1 - cs3);     //增加的液柱压力
                            dpg = Pa * V1 / (V1 - v) - Pa;       //气体压缩产生的压力
                                                                 //注入压井液产生的压力接近设定的安全压力
                            if ((Dpf - (dph + dpg) < 100000) && (Dpf - (dph + dpg) > 0))
                            {
                                vout[k] = v;
                                break;  //跳出循环跳出循环jjj。。区别自然循环到0
                            }
                        }
                        if (j == -1)
                        {
                            break;  //如果j自然循环到0则跳出kkk
                        }
                        cs1 = cs3;
                        zrPa[k] = Pa + dpg;
                        sfPa[k] = Pa - dph;
                        V1 = V1 - v;   //剩余气体体积?????????????????????
                        Pa = sfPa[k];
                    }
                }



            }


            /// <summary>
            /// 定向井-----------------------空井工况
            /// </summary>
            /// <param name="g"></param>
            /// <param name="nt"></param>
            /// <param name="H_shoe"></param>
            /// <param name="D_jy"></param>
            /// <param name="Do_zg"></param>
            /// <param name="Pa"></param>
            /// <param name="Den_zj"></param>
            /// <param name="V1"></param>
            /// <param name="Pbs"></param>
            /// <param name="js"></param>
            /// <param name="jxj"></param>
            /// <param name="cs"></param>
            /// <param name="vout"></param>
            /// <param name="sfPa"></param>
            /// <param name="zrPa"></param>
            public void Replacement_method_with_trace_wodp(int nt, double H_shoe, double D_jy, double Do_zg, double Pa, double Den_zj,
                                 double V1, double Pbs, double[] js, double[] jxj, double[] cs, ref double[] vout, ref double[] sfPa, ref double[] zrPa)
            {
                //----------定义变量(变量必须先定义再使用)，赋初值---------------
                double ztl = js[300];     //增加一个钻头的位置 起下钻工况 和空井工况  输入 ------从工况参数取ztl
                double Cdpca = 0;   //单位长度井眼容积容积
                double hg = 0;       //气体长度 m
                double yjden = 0;   //压井液密度 kg/m^3
                double P_shoe = 0;   //套管鞋处压力 Pa
                double Dpf = 0;      //套管鞋安全临界压力增量 Pa
                double v = 0;     //加入钻井液 v 
                double dph = 0;     //增加的液柱压力
                double dpg = 0;       //气体压缩产生的压力

                int m1 = 0;
                int m2 = 0;
                int m3 = 0;
                int j = 0;           //中间系数
                double cs1 = 0;
                double cs2 = 0;
                double cs3 = 0;




                //-------------------------计算-------------------------
                for (int i = 1; i <= nt; i++)
                {
                    jxj[i] = jxj[i] * PI / 180;
                }

                hg = V1 / Cdpca;

                for (int i = 1; i <= nt; i++)
                {
                    if (js[i] >= hg)
                    {
                        m1 = i;
                        break;  //跳出循环
                    }
                }
                cs1 = cs[m1] - Math.Cos(jxj[m1]) * (js[m1] - hg);   //初始液面   334
                yjden = Pa / g / cs1;           //压井液密度 垂深计算

                for (int i = 1; i <= nt; i++)
                {
                    if (js[i] >= H_shoe)
                    {
                        m2 = i;
                        break;  //跳出循环
                    }
                }
                cs2 = cs[m2] - Math.Cos(jxj[m2]) * (js[m2] - H_shoe);   //套管鞋垂深
                P_shoe = Pa + Den_zj * g * (cs[nt] - cs2);  //用垂深计算初始套管鞋处压力
                Dpf = (Pbs - P_shoe) / 2;    //安全压力增量 保守所写 可修改  

                //加入钻井液 v 

                for (int k = 1; k <= 10; k++)
                {
                    for (j = (int)(10000 * V1); j >= 0; j--)
                    {
                        v = (double)j / 10000;
                        for (int i = 1; i <= nt; i++)
                        {
                            if (js[i] >= (V1 / Cdpca - v / Cdpca))
                            {
                                m3 = i;  //寻找出加入钻井液v后的液面下最近的一点
                                break;  //跳出循环
                            }
                        }
                        cs3 = (cs[m3] - Math.Cos(jxj[m3]) * (js[m3] - V1 / Cdpca + v / Cdpca)); //加入压井液液面垂深
                        dph = yjden * g * (cs1 - cs3);     //增加的液柱压力
                        dpg = Pa * V1 / (V1 - v) - Pa;       //气体压缩产生的压力
                                                             //注入压井液产生的压力接近设定的安全压力
                        if ((Dpf - (dph + dpg) < 100000) && (Dpf - (dph + dpg) > 0))
                        {
                            vout[k] = v;
                            break;  //跳出循环跳出循环jjj。。区别自然循环到0
                        }
                    }
                    if (j == -1)
                    {
                        break;  //如果j自然循环到0则跳出kkk
                    }
                    cs1 = cs3;
                    zrPa[k] = Pa + dpg;  //注入v压井液后 套压
                    sfPa[k] = Pa - dph;  //开节流阀放气后 套压
                    V1 = V1 - v;   //剩余气体体积?????????????????????
                    Pa = sfPa[k];
                }



            }

        }
}
