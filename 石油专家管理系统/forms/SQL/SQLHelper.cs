using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace 石油专家管理系统
{
    class SQLHelper
    {
        
        public static DataSet Query(string sSql)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source =.; Initial Catalog = 石油专家; Integrated Security = True";
            conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sSql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
            
            return ds;
        }
        public  static DataSet read(string sql)

        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=石油专家;Integrated Security=True";
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }
        public static DataTable xQuery(string sSql)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source =.; Initial Catalog = 石油专家; Integrated Security = True";
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sSql, conn);
            DataTable ds = new DataTable();
            adapter.Fill(ds);

            return ds;
        }
        public static int  ExQuery(string sSql)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source =.; Initial Catalog = 石油专家; Integrated Security = True";
            conn.Open();
            SqlCommand sql = new SqlCommand(sSql, conn);
            int redit = sql.ExecuteNonQuery();
            return redit;
        }
        public static DataTable ExecuteDataTable(string sql)
        {
            SqlConnection ceConn = new  SqlConnection();
            try
            {

                ceConn.Open();
                DataTable data = new DataTable();
                DataSet ds = new DataSet();
                SqlDataAdapter ceSda = new SqlDataAdapter(sql, ceConn);
                ceSda.Fill(ds);
                data = ds.Tables[0];
                return data;
            }
            catch (Exception e)
            {
                ceConn.Close();
                return null;
            }
        }
        public static class CommonSql
        {//-----------------钢材性能数据--------------------------------
         //插入数据前，判断某条钢材性能数据是否已经存在！
            public static string strJugeSteelPerfBysteelNo = "select count(steelNo) as countNO  from SteelPerf where steelNo=";
            //插入钢材性能数据到数据库 
            public static string strInsertSteelPerf = "insert into SteelPerf values(@steelNo, @density,@elasModul,@possionRate,@yeildStren,@tensileStren,@linearExpanPara)";
            //查询钢材性能数据
            public static string strSelectSteelPerf = "select steelNo,density,elasModul,possionRate, yeildStren,tensileStren,linearExpanPara from SteelPerf";
            //删除指定钢材性能编号的钢材数据
            public static string strDelSteelPerfbyNo = "delete from SteelPerf where steelNo=";
            //更新指定钢材性能编号的钢材数据
            public static string strUpdateSteelPerfbyNo = "update SteelPerf SET density =@density,elasModul=@elasModul,possionRate=@possionRate,yeildStren=@yeildStren,tensileStren=@tensileStren,linearExpanPara=@linearExpanPara where steelNo=@steelNo";
            //-----------NEW------------------------------------------
            //查询钢材性能编号
            public static string strSelectNoDuplicateSteelNo = "select distinct steelNo from SteelPerf";
            //查询钢材性能编号
            public static string strSelectKNYLSteelNo = "select distinct kangNeiYa from SteelPerf where steelNo=";

            //--------------管材性能数据----------------------------------------- 
            //插入数据前，判断某条管材性能数据是否已经存在！
            public static string strJugeTubePerfBytubeNo = "select count(tubeNo) as countNO  from TubePerf where tubeNo=";
            //插入管材性能数据到数据库 
            public static string strInsertTubePerf = "insert into TubePerf values(@tubeNo, @tubeType,@extDiameter,@massPerLength,@steelNo,@interDiameter,@extPressStern,@interPressStern,@tensileStren,@twistStren,@thickness)";
            //查询管材性能编号
            public static string strQueryTubeNo = "select max(tubeNo) as MaxNo from TubePerf";
            //查询管材类型
            public static string strQueryTubeType = "select distinct tubeType from TubePerf";
            //查询指定管材类型情况下的外径值
            public static string strQueryTubeExtDiameterByTubeType = "select distinct extDiameter from TubePerf where tubeType=";
            //查询指定管材类型和外径值情况下的内径值
            public static string strQueryTubeInterDiameterByTypeExt = "select distinct interDiameter from TubePerf where tubeType=@tubeType and extDiameter=@extDiameter";
            //查询指定管材类型、外径值、内径值的情况下的壁厚值
            public static string strQueryTubeThicknessByTypeExtInter = "select distinct thickness from TubePerf where tubeType=@tubeType and extDiameter=@extDiameter and interDiameter=@interDiameter";
            //查询指定管材类型、外径值、内径值、壁厚值的情况下的钢级
            public static string strQueryTubeSteelByTypeExtInterThick = "select distinct steelNo from TubePerf where tubeType=@tubeType and extDiameter=@extDiameter and interDiameter=@interDiameter and thickness=@thickness";
            //查询指定管材类型、外径值、内径值、壁厚值、钢级的情况下的单位长度质量
            public static string strQueryTubeMassByTypeExtInterThickSteel = "select distinct massPerLength from TubePerf where tubeType=@tubeType and extDiameter=@extDiameter and interDiameter=@interDiameter and thickness=@thickness and steelNo=";

            //删除指定钢材性能编号的管材数据
            public static string strDelTubePerfbyNo = "delete from TubePerf where tubeNo=";
            //更新指定管材性能编号的管材数据
            public static string strUpdateTubePerfbyNo = "update TubePerf SET tubeType =@tubeType,extDiameter=@extDiameter,massPerLength=@massPerLength,steelNo=@steelNo,interDiameter=@interDiameter,extPressStern=@extPressStern, interPressStern=@interPressStern,tensileStren=@tensileStren,twistStren=@twistStren,thickness=@thickness where tubeNo=@tubeNo";

            //------------------------------钻具基础数据----------------------------------------------------------------------------------------
            public static string strGetDrillTools = "select * from DrillToolsData";
            public static string strGetDrillToolsAll = "select drillToolID,drilltoolname,drilltoolmodel,outterdiameter,innerdiameter,wallthickness from DrillToolsData";
            public static string strGetDrillToolName = "select distinct drillToolName from DrillToolsData";
            public static string strGetDrillModels = "Select DrillToolModel From DrillToolsData  WHERE drilltoolname=";
            public static string strGetDrillInfoByModel = "Select DrillToolID,DrillToolModel,OutterDiameter,InnerDiameter,WallThickness From DrillToolsData  WHERE drilltoolname=";
            //--------------------------------钻具组合数据---------------------------------------------------------------------------------------------
            //查询当前"某井"的钻具组合最大序号
            public static string strQueryOrderNobyWellID = "select max(OrderID) as MaxNo from DrillToolsComb where WellID=";
            //插入某井的钻具组合数据到数据库 
            public static string strInsertDrillToolComb = "insert into DrillToolsComb(WellID, OrderID,DrillToolID,DrillToolName,DrillToolModel,OutterDiameter,InnerDiameter,WallThickness,Length,TotalLength) values(@WellID, @OrderID,@DrillToolID,@DrillToolName,@DrillToolModel,@OutterDiameter,@InnerDiameter,@WallThickness,@Length,@TotalLength)";
            //查询某井的钻具组合数据
            public static string strSelectDrillToolComb = "select WellID,OrderID,DrillToolID,DrillToolName,DrillToolModel,OutterDiameter,InnerDiameter,WallThickness,Length,TotalLength from DrillToolsComb where WellID=";
            //删除指定井号和序号的钻具组合数据
            public static string strDelDrillToolbyWellIDAndOrderID = "delete from DrillToolsComb where WellID=@WellID and OrderID=@OrderID";
            //插入数据前，判断某条井的钻具组合数据是否已经存在！
            public static string strJugeDrillCombByWellID = "select count(WellID) as countNO  from DrillToolsComb where WellID=";
            //删除某井的所有钻具组合数据
            public static string strDelDrillCombByWellID = "delete from DrillToolsComb where WellID=";
            //插入数据前，判断某井的某条钻具组合数据是否已经存在！
            public static string strJugeDrillCombByWellIDAndOrderID = "select count(WellID) as countNO  from DrillToolsComb where WellID=@WellID and OrderID=@OrderID";
            //删除某井的所有钻具组合数据
            public static string strDelDrillCombByWellIDAndOrderID = "delete from DrillToolsComb where WellID=@WellID and OrderID=@OrderID";
            //------------------------------井眼轨迹数据------------------------------------------------------------------------------------
            //插入数据前，判断某条井的井眼轨迹数据是否已经存在！
            public static string strJugeWellTraceByWellID = "select count(WellID) as countNO  from WellTraceData where WellID=";
            //删除某井的所有井眼轨迹数据
            public static string strDelWellTraceByWellID = "delete from WellTraceData where WellID=";
            //删除某井某轨迹号井眼轨迹数据
            public static string strDelWellTraceByWellIDAndTraceID = "delete from WellTraceData where WellID=@WellID and TraceID=@TraceID";
            //插入某井的井眼轨迹数据到数据库 
            public static string strInsertWellTrace = "insert into WellTraceData(WellID,TraceID,WellDepth,WellHoleAngle,WellAngle) values(@WellID,@TraceID,@WellDepth,@WellHoleAngle,@WellAngle)";
            //查询某井的井眼轨迹数据
            // public static string strSelectWellTrace = "select WellID, TraceID,WellDepth,WellHoleAngle,WellAngle from WellTraceData where WellID=";
            public static string strSelectWellTrace = "select 工程编号, ";
            //查询某井的井眼轨迹数据的行数
            // public static string strSelectWellTraceCount = "select count(WellID) as WellTraceCount from WellTraceData where WellID=";
          public static string strSelectWellTraceCount = "select count(工程编号) as WellTraceCount from Sheet3$ where 工程编号=";
            //查询某井的井眼轨迹编号
            public static string strSelectWellTraceMaxID = "select max(TraceID) from WellTraceData where WellID=";
            //---------------------井数据--------------------------------------------------------------------------------------------------
            //插入数据前，判断某条井的基础数据是否已经存在！
            public static string strJugeWellDataByWellID = "select count(WellID) as countNO  from WellBasicData where WellID=";
            public static string strGetWellInfo = "select distinct WellID,CompanyName,DrillingCrewName from WellBasicData";
            //查询井号
            public static string strGetWellID = "select distinct WellID from WellBasicData";
            public static string strGetWell = "select distinct WellID,WellType,WellDepth from WellBasicData";
            public static string strGetCompanyCrewInfoByWellID = "select distinct CompanyName,DrillingCrewName from WellBasicData where WellID=";
            //查询某井的所有数据 
            public static string strSelectWellBasicDataByWellID = "select WellID, CompanyName,DrillingCrewName,AreaName,WellType,WellDepth,CasingShoeDepth,PipeDiameter,DrillHeadSize,DrillFluidDensity," +
                                                          "DrillDisplacement,GeothermyRation,WellTemp,WellEyeKuoDaLv,SlowPumpWellDepth,SlowPumpPressLoss,SlowPumpDisplacement,TgGj,JkEdYl,LyPlYl from WellBasicData  where WellID=";
            //ZY--20180915---------------
            public static string strSelectWellBasicByWellID = "select WellID,CompanyName ,DrillingCrewName ,AreaName,WellType,WellDepth,CasingShoeDepth, PipeDiameter, DrillHeadSize, DrillFluidDensity," +
                                                           "DrillDisplacement, PumpPressure,Speed, Turn_300,Turn_600, GeothermyRation, WellTemp, WellEyeSize, WellEyeKuoDaLv, SlowPumpWellDepth, SlowPumpPressLoss," +
                                                           "SlowPumpDisplacement, TgGj, JkEdYl, LyPlYl, SlowPumpDrillFluidDensity, YlQkMs  FROM  WellBasicData  where WellID=";
            //插入某井的基础数据到数据库  
            public static string strInsertWellData = "insert into WellBasicData(WellID, CompanyName,DrillingCrewName,AreaName,WellType,WellDepth,CasingShoeDepth," +
                                                      "PipeDiameter,DrillHeadSize,DrillFluidDensity,DrillDisplacement,PumpPressure,Speed,Turn_300,Turn_600,GeothermyRation,WellTemp,WellEyeSize,WellEyeKuoDaLv,SlowPumpWellDepth," +
                                                      "SlowPumpPressLoss,SlowPumpDisplacement,TgGj,JkEdYl,LyPlYl,YlQkMs) values(@WellID, @CompanyName,@DrillingCrewName,@AreaName,@WellType,@WellDepth,@CasingShoeDepth," +
                                                      "@PipeDiameter,@DrillHeadSize,@DrillFluidDensity,@DrillDisplacement,@PumpPressure,@Speed,@Turn_300,@Turn_600,@GeothermyRation,@WellTemp,@WellEyeSize,@WellEyeKuoDaLv,@SlowPumpWellDepth," +
                                                      "@SlowPumpPressLoss,@SlowPumpDisplacement,@TgGj,@JkEdYl,@LyPlYl,@YlQkMs)";


            //删除某井的所有基础数据
            public static string strDelWellDatabByWellID = "delete from WellBasicData where WellID=";
            //更新工程井中钻头尺寸
            public static string updateWellDataDrillHeadSize = "update WellBasicData set DrillHeadSize=@DrillHeadSize where WellID=@WellID";

            //----------井身结构------------------------------------------------------------
            //查询得到最大开次
            public static string selectWellDepthStrctureKC = "select max(OpenTimes) OpenTimes from WellDepthStrcture where WellID =";
            //查询井深结构数据列表
            public static string strWellDepthStrcture = "select * from WellDepthStrcture  where WellID=";
            //插入数据前，判断某条井深结构数据是否已经存在！
            public static string strJugeWellDepthStrctureByWellID = "select count(WellID) as countNO  from WellDepthStrcture where WellID=";
            //删除某井的某条井深结构数据
            public static string strDelWellDepthStrcturebByWellID = "delete from WellDepthStrcture where WellID=";
            //插入某井身结构数据到数据库  
            public static string strInsertWellDepthStrcture = "insert into WellDepthStrcture(WellID, LowCasingDepth,OpenTimes,NakedEyeDepth,CasingSzie,CasingWallThickness,CasingStiffness," +
                                                      "WellEyeSize) values(@WellID, @LowCasingDepth,@OpenTimes,@NakedEyeDepth,@CasingSzie,@CasingWallThickness,@CasingStiffness," +
                                                      "@WellEyeSize)";
            //删除某井某条井深结构数据
            public static string strDelWellDepthStrcturebByWellIDAndOpenTimes = "delete from WellDepthStrcture where WellID=@WellID and OpenTimes=@OpenTimes";

            //----------新建工程------------------------------------------------------------
            //查询某井的工程编号
            public static string strSelectWellMaxProjID = "select max (ProjID) from ProjData where WellID=";
            public static string strSelectMaxProjIDStu = "select max(cast(ProjID as integer)) from ProjData where WellID=";
            public static string strInsertProjData = "insert into ProjData(WellID, ProjID,ProjName,DateTime ) values(@WellID, @ProjID,@ProjName,@DateTime)";
            //插入数据前，判断某井的某工程--基础数据是否已经存在！
            public static string strJugeProjWellBasic = "select count(ProjID) as countNO  from ProjWellBasicData where ProjID=";

            //--------------工程下的井的基础数据-------------------------------------------------------
            //查询某井的所有数据 
            public static string strSelectProjWellBasicDataByWellIDProjID = "select WellID,ProjID,CompanyName,DrillingCrewName,AreaName,WellType,WellDepth,CasingShoeDepth,PipeDiameter,DrillHeadSize,DrillFluidDensity," +
                                                          "DrillDisplacement,GeothermyRation,WellTemp,WellEyeKuoDaLv,SlowPumpWellDepth,SlowPumpPressLoss,SlowPumpDisplacement,TgGj,JkEdYl,LyPlYl,PumpPressure,Speed,Turn_300,Turn_600,WellEyeSize,SlowPumpDrillFluidDensity,YlQkMs from ProjWellBasicData  where WellID=";
            //插入数据前，判断某条井的某工程下的---基础数据是否已经存在！
            public static string strJugeWellDataByWellIDProjID = "select count(WellID) as countNO  from ProjWellBasicData where WellID=";
            //删除某井的某工程下的所有基础数据
            public static string strDelWellDatabByWellIDProjID = "delete from ProjWellBasicData where WellID=";
            //插入某井的某工程下的基础数据到数据库  
            public static string strInsertWellDataByWellIDProjID = "insert into ProjWellBasicData(WellID,ProjID,CompanyName,DrillingCrewName,AreaName,WellType,WellDepth,CasingShoeDepth," +
                                                      "PipeDiameter,DrillHeadSize,DrillFluidDensity,DrillDisplacement,PumpPressure,Speed,Turn_300,Turn_600,GeothermyRation,WellTemp,WellEyeSize,WellEyeKuoDaLv,SlowPumpWellDepth," +
                                                      "SlowPumpPressLoss,SlowPumpDisplacement,TgGj,JkEdYl,LyPlYl,YlQkMs) values(@WellID,@ProjID,@CompanyName,@DrillingCrewName,@AreaName,@WellType,@WellDepth,@CasingShoeDepth," +
                                                      "@PipeDiameter,@DrillHeadSize,@DrillFluidDensity,@DrillDisplacement,@PumpPressure,@Speed,@Turn_300,@Turn_600,@GeothermyRation,@WellTemp,@WellEyeSize,@WellEyeKuoDaLv,@SlowPumpWellDepth," +
                                                      "@SlowPumpPressLoss,@SlowPumpDisplacement,@TgGj,@JkEdYl,@LyPlYl,@YlQkMs)";
            //更新项目中井的基本数据
            public static string updateWellDataByWellIDProjID = "update ProjWellBasicData set CompanyName=@CompanyName,DrillingCrewName=@DrillingCrewName,AreaName=@AreaName,WellType=@WellType,WellDepth=@WellDepth," +
                                                             "CasingShoeDepth=@CasingShoeDepth,PipeDiameter=@PipeDiameter,DrillFluidDensity=@DrillFluidDensity,DrillDisplacement=@DrillDisplacement,PumpPressure=@PumpPressure,Speed=@Speed,Turn_300=@Turn_300,Turn_600=@Turn_600,GeothermyRation=@GeothermyRation,WellTemp=@WellTemp," +
                                                             "WellEyeSize=@WellEyeSize,WellEyeKuoDaLv=@WellEyeKuoDaLv,SlowPumpWellDepth=@SlowPumpWellDepth,SlowPumpPressLoss=@SlowPumpPressLoss,SlowPumpDisplacement=@SlowPumpDisplacement,TgGj=@TgGj," +
                                                             "JkEdYl=@JkEdYl,LyPlYl=@LyPlYl,YlQkMs=@YlQkMs where WellID=@WellID and ProjID=@ProjID";
            //更新工程井中钻头尺寸
            public static string updateProjWellDataDrillHeadSize = "update ProjWellBasicData set DrillHeadSize=@DrillHeadSize where WellID=@WellID and ProjID=@ProjID";

            //--------------工程下的井身结构数据-------------------------------------------------------
            //插入某井身结构数据到数据库  
            public static string strInsertProWellDepthStrcture = "insert into ProjWellDepthStrcture(WellID,ProjID,OpenTimes,LowCasingDepth,NakedEyeDepth,CasingSzie,CasingWallThickness,CasingStiffness," +
                                                      "WellEyeSize) values(@WellID,@ProjID,@OpenTimes,@LowCasingDepth,@NakedEyeDepth,@CasingSzie,@CasingWallThickness,@CasingStiffness," +
                                                      "@WellEyeSize)";
            //查询井深结构数据列表
            public static string strProWellDepthStrcture = "select * from ProjWellDepthStrcture  where WellID=";
            //插入数据前，判断某条井深结构数据是否已经存在！
            public static string strJugeProWellDepthStrctureByWellID = "select count(WellID) as countNO  from ProjWellDepthStrcture where WellID=";
            //删除某井的某条井深结构数据
            public static string strDelProWellDepthStrcturebByWellID = "delete from ProjWellDepthStrcture where WellID=";
            //删除某井某条井深结构数据
            public static string strDelProWellDepthStrctureb = "delete from ProjWellDepthStrcture where WellID=@WellID and OpenTimes=@OpenTimes and ProjID=@ProjID";


            //--------------------------------工程下的钻具组合数据---------------------------------------------------------------------------------------------

            //查询某井的某工程下钻具组合数据
            public static string strSelectProjDrillToolComb = "select WellID,OrderID,DrillToolID,DrillToolName,DrillToolModel,OutterDiameter,InnerDiameter,WallThickness,Length,TotalLength,ProjID from ProjDrillToolsComb where WellID=";
            //插入数据前，判断某井的某工程的钻具组合数据是否已经存在！
            public static string strJugeProjDrillCombByProjID = "select count(ProjID) as countNO  from ProjDrillToolsComb where WellID=";
            //删除某井的某工程的所有钻具组合数据
            public static string strDelDrillCombByWellIDProjID = "delete from ProjDrillToolsComb where WellID=";
            //删除某井某工程某序号的钻具组合数据
            public static string strDelProDrillCombByWellIDAndProjID = "delete from ProjDrillToolsComb where WellID=@WellID and OrderID=@OrderID and ProjID=@ProjID";
            //插入某井的某工程的钻具组合数据到数据库 
            public static string strInsertProjDrillToolComb = "insert into ProjDrillToolsComb(WellID, OrderID,DrillToolID,DrillToolName,DrillToolModel,OutterDiameter,InnerDiameter,WallThickness,Length,TotalLength,ProjID) values(@WellID, @OrderID,@DrillToolID,@DrillToolName,@DrillToolModel,@OutterDiameter,@InnerDiameter,@WallThickness,@Length,@TotalLength,@ProjID)";
            //查询当前"某井"的某工程的钻具组合最大序号
            public static string strQueryOrderNobyWellIDProjID = "select max(OrderID) as MaxNo from ProjDrillToolsComb where WellID=";
            //插入数据前，判断某井某工程某条的钻具组合数据是否已经存在！
            public static string strJugeProjDrillCombByProjIDAndWellIDAndOrderID = "select count(ProjID) as countNO  from ProjDrillToolsComb where WellID=@WellID and OrderID=@OrderID and ProjID=@ProjID";

            //--------------------------工程下的溢流数据---------------------------------------------------------------------------------------
            //插入数据前，判断某条井的某工程下的---溢流数据-是否已经存在！
            public static string strJugeYLDataByWellIDProjID = "select count(WellID) as countNO  from ProYiLiuData where WellID=";
            //删除某井的某工程下的所有溢流数据
            public static string strDelYLDatabByWellIDProjID = "delete from ProYiLiuData where WellID=";
            //插入某井的某工程下的溢流数据到数据库  
            public static string strInsertYLDataByWellIDProjID = "insert into ProYiLiuData(ProjID,WellID,GuanJinLiYa,GuanJinTaoYa,NjcZenL,IsYlTC" +
                                                                 ") values(@ProjID,@WellID,@GuanJinLiYa,@GuanJinTaoYa,@NjcZenL,@IsYlTC)";

            //查询某井的某工程下的溢流数据到数据库  
            public static string strSelectYLDataByWellIDProjID = "select ProjID,WellID,GuanJinLiYa,GuanJinTaoYa,NjcZenL,IsYlTC from ProYiLiuData  where WellID=";


            //---------------------工程下的工况数据----------------------------------------------------------------------------------------------
            //插入数据前，判断某条井的某工程下的---工况数据-是否已经存在！
            public static string strJugeWCDataByWellIDProjID = "select count(WellID) as countNO  from ProjWrokCondition where WellID=";
            //删除某井的某工程下的所有工况数据
            public static string strDelWCDatabByWellIDProjID = "delete from ProjWrokCondition where WellID=";
            //插入某井的某工程下的工况数据到数据库  
            public static string strInsertWCDataByWellIDProjID = "insert into ProjWrokCondition(ProjID,WellID,WorkCond,OilType,H2S,LouShi,Memo" +
                                                                 ") values(@ProjID,@WellID,@WorkCond,@OilType,@H2S,@LouShi,@Memo)";

            //查询某井的某工程下的工况数据到数据库  
            public static string strSelectWCDataByWellIDProjID = "select ProjID,WellID,WorkCond,OilType,H2S,LouShi,Memo from ProjWrokCondition  where WellID=";
        }
    }
}
