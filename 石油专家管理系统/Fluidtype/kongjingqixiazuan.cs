using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 石油专家管理系统.Fluidtype
{
    class kongjingqixiazuan
    {
        public static string JudeEarthTypeUnderZuanJing2(string strWellID, string strWellType, double douWellDepth, double douTgxDepth, double douZjyDensity,
                                               double douGjLy, double douGjTy, double douNjcZl, double douZtSize, double douWellEyeKDL,
                                               double douZgOutterDiameter, double douTgDiameter, double[,] TW, int NT, ref double dens)
        {
            double Pm;//钻井液密度
            double h;//井深
            double htx;//套管鞋深度
            double D;//套管直径
            double Dly;//钻头尺寸
            double Dky = 0;  //井眼扩大率
            double Pd;//关井立压,
            double Pa;//关井套压
            double Vgain;//泥浆池增量
            double Dp;//钻杆外径
            double hly;
            // double[,] TW;//计算之后的井眼轨迹数据
            //--------------赋初值-----------------------------
            Pd = douGjLy;
            Pa = douGjTy;
            Vgain = douNjcZl;
            D = douTgDiameter;//套管直径
            Dly = douZtSize;////钻头尺寸?裸眼直径
            Pm = douZjyDensity;//钻井液密度  
            Dp = douZgOutterDiameter;//钻杆外径 
            double hw = 0;

            h = douWellDepth;//井深
            htx = douTgxDepth;//套管鞋深度
            hly = h - htx;//hly是裸眼长度

            double vly = 0.25 *Math. PI * (Math.Pow(Dly / 1000, 2) - Math.Pow(Dp / 1000, 2));   //%裸眼段单位长度容积  如果 douZtSize 和douZgOutterDiameter单位是mm  就再除以1000
            double vh = 0.25 *Math. PI * (Math.Pow(D / 1000, 2) - Math.Pow(Dp / 1000, 2));   //套管段单位长度容积  同上
            double vlyz = vly * hly;  //裸眼段体积

            if (Vgain <= vlyz)
            {
                hw = Vgain / vly;
            }
            else if (Vgain > vlyz)
            {
                hw = hly + (Vgain - vlyz) / vh;
            }
            if (strWellType.Equals("定向井")) //----------------定向井------------------------------
            {
                //WellTrace wt = new WellTrace(strWellID);
                //int NT = wt.getNt();//井眼轨迹行数
                //int NT1 = 300;//固定离散值
                //wt.wellTrace_XYZ(NT1);//轨迹计算函数 
                //TW = wt.getTw();//计算之后的井眼轨迹参数
                //// double hcs = TW[NT1, 6];       //垂深 m 

                int ml = 0;
                for (int i = 1; i < NT; i++)
                {
                    if (TW[i, 1] >= hw)
                    {
                        ml = i;
                        break;
                    }

                }
                hw = TW[NT, 6] - TW[ml, 6] + (hw - TW[NT, 1] + TW[ml, 1]) * Math.Cos(TW[ml, 2]);

            }
            double Dens = Pm - (Pa - Pd) / 0.00981 / hw;//溢流密度计算
            dens = Dens;
            if ((Dens >= 0.12) && (Dens < 0.36))//溢流为天然气----------------------------------
            {
                return "gas";
            }
            else if ((Dens >= 0.36) && (Dens < 0.6))//溢流为油--------------------------------------------------------
            {
                return "oil";
            }
            else if ((Dens >= 0.60) && (Dens < 0.85))//溢流为油水混合
            {
                return "wateroil";
            }
            else if ((Dens >= 0.85) && (Dens < 1.08))//溢流为地层水
            {
                return "water";
            }
            else
            {
                return "null";
            }
        }
    }
}
