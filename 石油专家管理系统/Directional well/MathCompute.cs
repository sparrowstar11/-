using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilPressCtrlES.Calcuation
{
    /// <summary>
    /// 数学计算模块
    /// </summary>
    public class MathCompute
    {
    
        private static double[] DIP;
        /// <summary>
        /// 构造方法
        /// </summary>
        public MathCompute()
        {


        }




        /// <summary>
        /// 解线性代数方程组   
        /// </summary>
        /// <param name="ESTIFQ"></param>
        /// <param name="ELOADQ"></param>
        /// <param name="DIP"></param>
        /// <param name="NNMAX"></param>
        public static double[] Gaudip(double[,] ESTIFQ,double[] ELOADQ,int NNMAX)
        {

            //ESTIFQ = new double[NNMAX+1, NNMAX+1];
            //ELOADQ = new double[NNMAX+1];
            DIP = new double[NNMAX+1];

            for (int n = 1; n <= NNMAX - 1; n++)
            {
                for (int i = n + 1; i <= NNMAX; i++)
                {
                    if (Math.Abs(ESTIFQ[i, n]) >= Math.Abs(ESTIFQ[n, n]))
                    {

                        double TT = ELOADQ[n];
                        ELOADQ[n] = ELOADQ[i];
                        ELOADQ[i] = TT;
                        for (int j = 1; j < NNMAX;j++ )
                        {
                            double Temp = ESTIFQ[n,j];
                            ESTIFQ[n, j] = ESTIFQ[i, j];
                            ESTIFQ[i, j] = Temp;


                        }//end for 30


                    }//end for if


                }//end for 20

                for (int i = n + 1; i <= NNMAX;i++ )
                {
                    for (int j = n+1; j < NNMAX; j++)
                    {
                        ESTIFQ[i, j] = ESTIFQ[i, j] - (ESTIFQ[i, n] / ESTIFQ[n, n]) * ESTIFQ[n, j]; 

                    }//end for 40
                    ELOADQ[i] = ELOADQ[i] - (ESTIFQ[i,n] / ESTIFQ[n,n])* ELOADQ[n];
                          
                }//end for 50
 

            }//end for 10

            for(int i=2;i<=NNMAX;i++)
            {
                for (int j = 1; i <= i-1; j++)
                {
                    ESTIFQ[i,j] = 0.0;
 

                }
 
            }
            DIP[NNMAX] = ELOADQ[NNMAX] / ESTIFQ[NNMAX, NNMAX]; 

            for (int i = NNMAX-1; i >=1; i--)
            {
                double A = 0.0;
                for (int j =i+1; j <= NNMAX; j++)
                {
                    A = A + ESTIFQ[i, j] * DIP[j];

                }//end for 70

                DIP[i] = (ELOADQ[i] - A) / ESTIFQ[i,i];

            }//end for 60
            return DIP;

        }

        //public double[,] getESTIFQ()
        //{
        //    return ESTIFQ;
        
        //}

        //public double[] getELOADQ()
        //{
        //    return ELOADQ;

        //}

        //public double[] getDIP()
        //{
        //    return DIP;

        //}
    }




}
