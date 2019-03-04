using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace 石油专家管理系统.Calcuation
{
    /// <summary>
    /// 井眼轨迹计算
    /// </summary>
    class WellTrace
    {
        private string strWellNo;//井号
        private double[] SHEN;//井深
        private double[] ALFA;//井斜角
        private double[] FAI;//方位角
        private double[,] TW;//井眼轨迹计算结果
        private int NT;//轨井迹的行数
        private int NT1;// 离散个数，固定值 300？

        private double ALFA0D = 0.0;
        private double ALFAND = 0.0;
        private double FAI0D = 0.0;
        private double FAIND = 0.0;

        private double S;
        private double SALFA;
        private double SFAI;

        private const double PI = 3.1415926;

        string papath = "OUTPUT.txt";
        /// <summary>
        /// 构造方法
        /// </summary>
        public WellTrace(string WellNo)
        {
            this.strWellNo = WellNo;
            this.readWellTraceDatafromDB(strWellNo);
        }

        /// <summary>
        /// 根据井号从数据库读取井眼轨迹数据
        /// </summary>
        /// <param name="WellNo"></param>
        public void readWellTraceDatafromDB(string WellNo)
        {

            this.strWellNo = WellNo;
            DataTable dtWellNo = SQLHelper.ExecuteDataTable(SQLHelper.CommonSql.strSelectWellTraceCount + "'" + WellNo + "'");
            NT = int.Parse(dtWellNo.Rows[0]["WellTraceCount"].ToString()); //行数
            SHEN = new double[NT + 1];//计算从下标1开始 
            ALFA = new double[NT + 1];
            FAI = new double[NT + 1];
            DataTable dtWellData = SQLHelper.ExecuteDataTable(SQLHelper.CommonSql.strSelectWellTrace + "'" + WellNo + "'");
            //遍历datatable 
            for (int i = 0; i < dtWellData.Rows.Count; i++)
            {
                SHEN[i+1] = double.Parse(dtWellData.Rows[i]["WellDepth"].ToString());//井深
                ALFA[i+1] = double.Parse(dtWellData.Rows[i]["WellHoleAngle"].ToString());//井斜角
                FAI[i+1] = double.Parse(dtWellData.Rows[i]["WellAngle"].ToString());//方位角
            }
            //--------输出井眼轨迹参数到文件----------
           // FileOpp.writeWellTraceOriginal(papath, NT, SHEN, ALFA, FAI);
        }

        /// <summary>
        /// 返回井眼轨迹行数
        /// </summary>
        /// <returns></returns>
        public int getNt()
        {
            return NT;
        }

        /// <summary>
        /// 返回井深
        /// </summary>
        /// <returns></returns>
        public double[] getShen()
        {
            return SHEN;
        }


        /// <summary>
        /// 返回井斜角
        /// </summary>
        /// <returns></returns>
        public double[] getAlfa()
        {
            return ALFA;
        }

        /// <summary>
        /// 返回方位角
        /// </summary>
        /// <returns></returns>
        public double[] getFai()
        {
            return FAI;
        }

        /// <summary>
        /// 返回计算值
        /// </summary>
        /// <returns></returns>
        public double[,] getTw()
        {
            return TW;
        }

        /// <summary>
        /// 返回计算值
        /// </summary>
        /// <returns></returns>
        public double getSALFA()
        {
            return SALFA;
        }

        /// <summary>
        /// 返回计算值
        /// </summary>
        /// <returns></returns>
        public double getSFAI()
        {
            return SFAI;
        }


        /// <summary>
        /// 三次样条函数计算井眼轨迹
        /// </summary>
        public void wellBore_Trace(int iflag, ref double S, ref double SALFA, ref double SFAI)
        {
            double[] DD = new double[NT + 1];
            double[,] AM = new double[NT + 1, NT + 1];
            double[,] TempAM = new double[NT + 1, NT + 1];
            double[] XD = new double[NT + 1];
            double[] DM = new double[NT + 1];
            double[] XM = new double[NT + 1];


            DD[1] = (6.0 / (SHEN[2] - SHEN[1])) * ((ALFA[2] - ALFA[3]) / (SHEN[2] - SHEN[1]) - ALFA0D);
            DD[NT] = (6.0 / (SHEN[NT] - SHEN[NT - 1])) * (ALFAND - (ALFA[NT] - ALFA[NT - 1]) / (SHEN[NT] - SHEN[NT - 1]));
            XD[1] = (6.0 / (SHEN[2] - SHEN[1])) * ((FAI[2] - FAI[3]) / (SHEN[2] - SHEN[1]) - FAI0D);
            XD[NT] = (6.0 / (SHEN[NT] - SHEN[NT - 1])) * (FAIND - (FAI[NT] - FAI[NT - 1]) / (SHEN[NT] - SHEN[NT - 1]));
            AM[1, 1] = 2.0;
            AM[1, 2] = 1.0;
            AM[NT, NT - 1] = 0.0;
            AM[NT, NT] = 2.0;
            //---------AM副本，准备做参数传递----------------------
            TempAM[1, 1] = 2.0;
            TempAM[1, 2] = 1.0;
            TempAM[NT, NT - 1] = 0.0;
            TempAM[NT, NT] = 2.0;
            for (int i = 2; i <= NT - 1; i++)
            {
                AM[i, i] = 2.0;
                AM[i, i + 1] = (SHEN[i + 1] - SHEN[i]) / (SHEN[i + 1] - SHEN[i - 1]);
                AM[i, i - 1] = 1 - AM[i, i + 1];
                //---------AM副本，准备做参数传递----------------------
                TempAM[i, i] = 2.0;
                TempAM[i, i + 1] = (SHEN[i + 1] - SHEN[i]) / (SHEN[i + 1] - SHEN[i - 1]);
                TempAM[i, i - 1] = 1 - AM[i, i + 1];
            }//end for 

            for (int i = 2; i <= NT - 1; i++)
            {
               double  AX1 = (ALFA[i + 1] - ALFA[i]) / (SHEN[i + 1] - SHEN[i]);
               double AX2 = (ALFA[i] - ALFA[i - 1]) / (SHEN[i] - SHEN[i - 1]);
                DD[i] = 6.0 * (AX1 - AX2) / (SHEN[i + 1] - SHEN[i - 1]);
                double AX3 = (FAI[i + 1] - FAI[i]) / (SHEN[i + 1] - SHEN[i]);
                double AX4 = (FAI[i] - FAI[i - 1]) / (SHEN[i] - SHEN[i - 1]);
                XD[i] = 6.0 * (AX3 - AX4) / (SHEN[i + 1] - SHEN[i - 1]);

            }//end if 
            ////---------------XD -----------------------------
            //string XDpath = "XD.txt";
            //FileOpp.writeXM(XDpath, iflag, XD);

            //---------------AM--FIRST -----------------------------
            //string am1path = "AM1.txt";
            //FileOpp.writeAM(am1path, iflag, AM); 
            
            //---------------AM--SND -----------------------------
            //string am2path = "AM2.txt";
            //FileOpp.writeAM(am2path, iflag, TempAM);

            DM = MathCompute.Gaudip(AM,DD,NT);//调用高斯消去求解方程组

            ////---------------AM--TEMP -----------------------------
            //string TEMPpath = "TEMPAM.txt";
            //FileOpp.writeAM(TEMPpath, iflag, TempAM);

            XM = MathCompute.Gaudip(TempAM, XD, NT);//调用高斯消去求解方程组

          
            ////---------------DM -----------------------------
            //string DMpath = "DM.txt";
            //FileOpp.writeXM(DMpath, iflag, DM);
            ////---------------XM -----------------------------
            //string XMpath = "XM.txt";
            //FileOpp.writeXM(XMpath, iflag,XM);


            for (int i = 1; i <= NT - 1;i++ )
            {
              
                if((S>=SHEN[i])&&(S<=SHEN[i+1]))
                 {

                     SALFA = (DM[i] * Math.Pow((SHEN[i + 1] - S),3)) / (6.0 * (SHEN[i + 1] - SHEN[i]))  
                            + (DM[i+1] * Math.Pow((S - SHEN[i]),3))/ (6.0 * (SHEN[i + 1] - SHEN[i]))
                             + (ALFA[i+1] / (SHEN[i+1] - SHEN[i]) - (DM[i+1] * (SHEN[i+1] - SHEN[i])) / 6.0) 
                             * (S - SHEN[i])
                             + (ALFA[i] / (SHEN[i+1] - SHEN[i]) - (DM[i] * (SHEN[i+1] - SHEN[i])) / 6.0) 
                             * (SHEN[i+1] - S);

                     SFAI=(XM[i]* Math.Pow((SHEN[i + 1]-S),3))/(6.0*(SHEN[i + 1] -SHEN[i]))
                         +(XM[i + 1] *Math.Pow((S-SHEN[i]),3))/(6.0*(SHEN[i + 1] -SHEN[i]))
                         +(FAI[i + 1] /(SHEN[i + 1] -SHEN[i])-(XM[i + 1] *(SHEN[i + 1] -SHEN[i]))/6.0)
                         *(S-SHEN[i])
                         +(FAI[i]/(SHEN[i + 1] -SHEN[i])-(XM[i]*(SHEN[i + 1] -SHEN[i]))/6.0)
                         *(SHEN[i + 1] -S);
                
                }//END IF
         

            }//END FOR

            //return S;


        }//end sub

        /// <summary>
        /// 井眼轨迹计算子程序
        /// </summary>
        public void wellTrace_XYZ(int NT1)
        {

            TW = new double[NT1+1, 10];
            double ADD = SHEN[NT] / (NT1 - 1.0); //单位长度 
            double SS = 0.0;
            double XX = 0.0;
            double YY = 0.0;
            double ZZ = 0.0;
          
            for (int i = 1; i <= NT1; i++)
            {
                this.wellBore_Trace(i, ref SS, ref SALFA, ref SFAI);
                TW[i, 1] = SS;     //井深
                TW[i, 2] = SALFA;   //井斜
                TW[i, 3] = SFAI;    // 方位角

                //string SFAIpath = "SFAI.txt";
                //FileOpp.writeXX(SFAIpath, i, SFAI);

                TW[i, 4] = XX;      //闭合距
                TW[i, 5] = YY;     //闭合方位
                TW[i, 6] = ZZ;     //垂深

                SALFA = (SALFA / 180) * PI;
                SFAI = (SFAI / 180) * PI;

                SS = SS + ADD;
                XX = XX + ADD * Math.Sin(SALFA) * Math.Cos(SFAI);

               

                YY = YY + ADD * Math.Sin(SALFA) * Math.Sin(SFAI);
                ZZ = ZZ + ADD * Math.Cos(SALFA);
                TW[i, 7] = Math.Sqrt(Math.Pow(XX, 2) + Math.Pow(YY, 2));


                if (Math.Abs(YY) < 0.000001)
                {
                    if (Math.Abs(XX) < 0.000001)
                    {
                        TW[i, 8] = 0.0;

                    }
                    else if (Math.Abs(XX) > 0.000001)
                    {
                        if (XX > 0.0)
                        {
                            TW[i, 8] = 0.0;

                        }
                        else if (XX < 0.0)
                        {
                            TW[i, 8] = 180.0;

                        }//end if

                    }//end if


                }
                else if (Math.Abs(YY) > 0.000001)
                {
                    TW[i, 8] = 90.0 - (180 / PI) * Math.Atan(XX / YY);
                }//end if

                if (i > 1)
                {
                   double AF1 = (TW[i-1,2] / 180.0) * PI;
                   double AF2 = SALFA;
                   double FA1 = (TW[i - 1, 3] / 180.0) * PI;
                   double FA2 = SFAI;
                   double COSYM = Math.Cos(AF1) * Math.Cos(AF2) + Math.Sin(AF1) * Math.Sin(AF2) * Math.Cos(FA1 - FA2);
                   TW[i, 9] = (Math.Acos(COSYM) * 180) / (ADD * PI); 

                }//end if
 

            }//end for 10
            TW[1, 9] = TW[2, 9] + (TW[2, 9] - TW[3, 9]); 
            //---------------井眼轨迹参数输出 -----------------------------
           // FileOpp.writeWellTraceComputed(papath, NT1,TW);
        }
    }
}
