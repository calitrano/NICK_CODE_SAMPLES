/*
   Microsoft SQL Server Integration Services Script Task
   Write scripts using Microsoft Visual C# 2008.
   The ScriptMain is the entry point class of the script.
*/
//
// SSIS TO check the counts of the tables in two environments after and app. copy.
// Created by Nick DeNora 3/19/2014 Viva San Giuseppe!
// Nick DeNora 4/30/14 Adding code to write file and put out error code if table counts not equal.
// Nick DeNora 5/5/14 moving this into DR testing.

using System;
using System.Data;
using Microsoft.SqlServer.Dts.Runtime;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.IO;

namespace ST_ed08981c527a4f4eab2607c95253191e.csproj
{
    [Microsoft.SqlServer.Dts.Tasks.ScriptTask.SSISScriptTaskEntryPointAttribute]
    public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
    {

        #region VSTA generated code
        enum ScriptResults
        {
            Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
            Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
        };
        #endregion

        /*
		The execution engine calls this method when the task executes.
		To access the object model, use the Dts property. Connections, variables, events,
		and logging features are available as members of the Dts property as shown in the following examples.

		To reference a variable, call Dts.Variables["MyCaseSensitiveVariableName"].Value;
		To post a log entry, call Dts.Log("This is my log text", 999, null);
		To fire an event, call Dts.Events.FireInformation(99, "test", "hit the help message", "", 0, true);

		To use the connections collection use something like the following:
		ConnectionManager cm = Dts.Connections.Add("OLEDB");
		cm.ConnectionString = "Data Source=localhost;Initial Catalog=AdventureWorks;Provider=SQLNCLI10;Integrated Security=SSPI;Auto Translate=False;";

		Before returning from this method, set the value of Dts.TaskResult to indicate success or failure.
		
		To open Help, press F1.
	*/
        string ms_conn1 = "SKIBOB.DEV.BUS.COM.HYPHFM.bpmadmin1";  // For initial testing.
        string ms_conn2 = "STIPED.CERT.BUS.COM.HYPHFM.bpmadmin2"; // For initial testing.
   //     string ms_conn3 = "BEKISS.PROD.BUS.COM.bpmadmin"; // this connection is set to connection 2 down in QueryTables()
     //   string ms_conn4 = "HEDGER.PROD.BUS.COM.HYPHFM.bpmadmin"; // PROD
        string ms_Env1 = "";
        string ms_Env2 = "";
        string ms_Tbl1Cnt = "";
        string ms_Tbl2Cnt = "";
        string ms_TblName = "";
        string ms_htmlBody = "";

        public void Main()
        {

            
        //    string htmlMessageTo = Dts.Variables["HTMLEmailTo"].Value.ToString();
       //   CompareVariables();
       //      CreateEmail("EMAIL HAS BEEN SEND FROM SSIS"); // for testing... nick 3/19/2014


            QueryTables();

// This was to add FDM copy in here 
//            if (Dts.Variables["MIGRATEFDM"].Value.ToString()=="Y")
  //          {
        //        ClearTargetFDMTable(ms_conn1, ms_conn2, "");
    //            PopulateTargetFDMTable(ms_conn1, ms_conn2, "");
      //      }
       

        }
        string GetConnectionType(string ps_ServerName)
        {
            string ls_ServerName = "";
            string ls_Conn = "";
            ls_ServerName = ps_ServerName;
            switch (ls_ServerName)
            {
              case "DEV":
                 ls_Conn= "SKIBOB.DEV.BUS.COM.HYPHFM.bpmadmin1";
                  break;
                case "CERT":
                  ls_Conn = "STIPED.CERT.BUS.COM.HYPHFM.bpmadmin2";
                  break;
                case "DR":
                  ls_Conn = "BEKISS.PROD.BUS.COM.bpmadmin"; 
                    break;
                case "PROD":
                   ls_Conn = "HEDGER.PROD.BUS.COM.HYPHFM.bpmadmin";
                    break;
                default:
                    break;
                    // Maybe define and error here and stop program.. ? Nickey D. 4/14/14
            }
            return ls_Conn;
        }

        
        bool QueryTables()
        {

           // ms_conn2 = ms_conn3; // for bekiss!

            ms_conn1 = GetConnectionType(Dts.Variables["ENV1"].Value.ToString());

            ms_conn2 = GetConnectionType(Dts.Variables["ENV2"].Value.ToString());

            ms_Env1 = Dts.Variables["ENV1"].Value.ToString();

            ms_Env2 = Dts.Variables["ENV2"].Value.ToString();
             
            string ls_count = "";
            string ls_number = "";
            string ls_tableName = "";
            string ls_year = "";
       //     string ls_conn1 = "SKIBOB.DEV.BUS.COM.HYPHFM.bpmadmin1";
         //   string ls_conn2 = "STIPED.CERT.BUS.COM.HYPHFM.bpmadmin2";

            string ls_currentYear = DateTime.Now.Year.ToString();

            ms_htmlBody += CreateHtmlHeader();

            for (int t = 0; t < 2; t++) // NOT USING DCT FOR NOW NPD 3/21/2014
            {
                switch (t)
                {
                    case 0:
                        ls_tableName = "DCN_";
                        break;
                    case 1:
                        ls_tableName = "DCE_";
                        break;
                    case 2:
                        ls_tableName = "DCT_";
                        break;
                    default:
                        break;
                }


                ls_year = "_" + ls_currentYear + "]";
                for (int y = 2; y > 0; y--)
                {
                    Int32 li_year = Convert.ToInt32(ls_currentYear);
                    li_year = li_year - y; // START WITH LAST YEAR... 
                    ls_year = li_year.ToString();

                    for (int i = 1; i < 11; i++)
                    {
                        ls_number = i.ToString();
                        ls_count = DoesTableExist(ms_conn1, ls_tableName + ls_number + "_" + ls_year);
                        ms_Tbl1Cnt = ls_count;
                        ls_count = DoesTableExist(ms_conn2, ls_tableName + ls_number + "_" + ls_year);
                        ms_Tbl2Cnt = ls_count;
                        //   MessageBox.Show(" TABLE NAME  ", ls_tableName + ls_number + "_" + ls_year + "  COUNT - > " + ls_count);
                        if (ls_count == "-1")
                        {
                            ls_count = "0";
                            continue;
                        }
                        else
                        {
                            ms_TblName = ls_tableName + ls_number + "_" + ls_year;
                            ms_htmlBody += CreateHtmlBody(ms_conn1, ms_Tbl1Cnt, ms_conn2, ms_Tbl2Cnt);
                            if (ms_Tbl1Cnt != ms_Tbl2Cnt)
	                            {
                                    Dts.Variables["COMP_FAILED"].Value = "true";
                                    ms_htmlBody += "<html><body><h3>TABLE COMPARE FAILED, COUNTS ARE NOT EQUAL!</h3></body></html>";
                                    CreateEmail(ms_htmlBody);
                                    return true;
                                                          		 
                            	}
                        }
                    }
                }
            }
            CreateEmail(ms_htmlBody);
            return true;
        }
        string CreateHtmlHeader()
        {
            return "<html><body><h3>App.Copy has completed!</h3></body></html>";
        }
        string CreateHtmlBad()
        {
            return "<html><body><h3>App.Copy has completed!</h3><p>The App. copy table compare failed. <BR>The counts did <b>NOT</b> match. DEV was "+ ms_Tbl1Cnt+ " and CERT was " + ms_Tbl2Cnt + "." + "</p></body></html>";
        }
        string CreateHtmlGood()
        {
            return "<html><body><h3>App.Copy has completed!</h3><p>The App. copy table compare was succesfull. <BR>The counts matched. DEV was " + ms_Tbl1Cnt + " and CERT was " + ms_Tbl2Cnt + "." + "</p></body></html>";
        }
        string CreateHtmlBody(string ps_cnn1, string ps_tblCnt1,string ps_cnn2, string ps_tblCnt2)
        {
            return "<html><body><p><BR>The count for " + ms_Env1 + " for table " + ms_TblName +  " was " + ms_Tbl1Cnt + " and " + ms_Env2 + " for table " + ms_TblName + " was " + ms_Tbl2Cnt + "." + "</p></body></html>";
        }
        void CreateEmail(string ps_HtmlBody)
        {

            string ls_HtmlBody = ps_HtmlBody;
            // HTMLEmails
           // string htmlMessageTo = Dts.Variables["HTMLEmails"].Value.ToString();
          ///  string htmlMessageTo = "ndenora@BUS.com,bfinkel@BUS.com,acarland@BUS.com,sgalante2@BUS.com";
            string htmlMessageTo = Dts.Variables["HTMLEmailTo"].Value.ToString();
            string htmlMessageFrom = Dts.Variables["HTMLEmailFrom"].Value.ToString();
            string htmlMessageSubject = Dts.Variables["HTMLEmailSubject"].Value.ToString();
           // string htmlMessageBody = Dts.Variables["HTMLEmailBody"].Value.ToString();
            string htmlMessageBody = ls_HtmlBody;
            string smtpServer = Dts.Variables["HTMLEmailServer"].Value.ToString();

            SendMailMessage(htmlMessageTo, htmlMessageFrom, htmlMessageSubject, htmlMessageBody, true, smtpServer);

            Dts.TaskResult = (int)ScriptResults.Success;

        }
        private void SendMailMessage(string SendTo, string From, string Subject, string Body, bool IsBodyHtml, string Server)
        {

            MailMessage htmlMessage;
            SmtpClient mySmtpClient;

            htmlMessage = new MailMessage(From,SendTo, Subject, Body);
            htmlMessage.IsBodyHtml = IsBodyHtml;

            mySmtpClient = new SmtpClient(Server);
            mySmtpClient.Credentials = CredentialCache.DefaultNetworkCredentials;
            mySmtpClient.Send(htmlMessage);

        }
       string DoesTableExist(string ps_conn, string ps_tableName)
        {
            string ls_tblName = "";
            string ls_count = "";
            string ls_conn = ps_conn;

            try
                {

                    ls_tblName = ps_tableName;       
                    string ls_SQL =

                     " IF  EXISTS " +
                     " (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BUSCONSRPT_" +
                     ls_tblName +
                     "]') AND " +
                     " type in (N'U')) " +
                     " select count(*) " +
                     " from [HYPHFM].[dbo].[BUSCONSRPT_" + ls_tblName + "]"+
                     " ELSE SELECT -1 "
                            ;

                ConnectionManager cm;
                System.Data.SqlClient.SqlConnection sqlConn;
                System.Data.SqlClient.SqlCommand sqlComm;

                cm = Dts.Connections[ls_conn]; // ado connection.

                sqlConn = (System.Data.SqlClient.SqlConnection)cm.AcquireConnection(Dts.Transaction);
                sqlComm = new System.Data.SqlClient.SqlCommand(ls_SQL, sqlConn);
                object o= sqlComm.ExecuteScalar();
                cm.ReleaseConnection(sqlConn);
                ls_count = o.ToString();

                }
                catch (Exception e)
                {
                    MessageBox.Show("An error has occured dummy  -->> " + e.Message);

                }
                return ls_count;

        }

        string GetFDMConnectionType(string ps_ServerName)
        {
            string ls_ServerName = "";
            string ls_Conn = "";
            ls_ServerName = ps_ServerName;
            switch (ls_ServerName)
            {
                case "DEV":
                    ls_Conn = "SKIBOB.DEV.BUS.COM.FDM_BUSConsol.bpmadmin";
                    break;
                case "CERT":
                    ls_Conn = "STIPED.CERT.BUS.COM.FDM_BUSConsol.bpmadmin";
                    break;
                case "DR":
                    ls_Conn = "BEKISS.PROD.BUS.COM.FDM_BUSConsol.bpmadmin";
                    break;
                case "PROD":
                    ls_Conn = "HEDGER.PROD.BUS.COM.FDM_BUSConsol.bpmadmin";
                    break;
                default:
                    break;
                // Maybe define and error here and stop program.. ? Nickey D. 4/14/14
            }
            return ls_Conn;
        }
  
        string ClearTargetFDMTable(string ps_Env1, string ps_Env2, string ps_tableName)
        {

            // this may be used in future... right now done in sproc. npd 5/5/14

            string ls_tblName = "";
            string ls_count = "";
            string ls_conn = ps_Env2;
             //  ls_conn = "STIPED.CERT.BUS.COM.FDM_BUSConsol.bpmadmin";
          
            try
            {

                ls_tblName = ps_tableName;
                string ls_SQL =

                 //" IF  EXISTS " +
                 //" (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BUSCONSRPT_" +
                 //ls_tblName +
                 //"]') AND " +
                 //" type in (N'U')) " +
                 //" select count(*) " +
                 //" from [HYPHFM].[dbo].[BUSCONSRPT_" + ls_tblName + "]" +
                 //" ELSE SELECT -1 "
                 //       ;

                 " delete from dbo.TEMP_NICK ";



                ConnectionManager cm;
                System.Data.SqlClient.SqlConnection sqlConn;
                System.Data.SqlClient.SqlCommand sqlComm;

                cm = Dts.Connections[ls_conn]; // ado connection.

                sqlConn = (System.Data.SqlClient.SqlConnection)cm.AcquireConnection(Dts.Transaction);
                sqlComm = new System.Data.SqlClient.SqlCommand(ls_SQL, sqlConn);
                object o = sqlComm.BeginExecuteNonQuery();
                cm.ReleaseConnection(sqlConn);
                ls_count = o.ToString();

            }
            catch (Exception e)
            {
              Console.WriteLine("An error has occured in Deleting FDM MAPPING TABLE IN DEST  -->> " + e.Message);

            }
            return ls_count;

        }


        string PopulateTargetFDMTable(string ps_Env1, string ps_Env2, string ps_tableName)
        {
            // this may be used in future... right now done in sproc. npd 5/5/14

            string ls_tblName = "";
            string ls_count = "";
            string ls_conn = ps_Env1;
            string ls_conn2 = ps_Env2;
            string ls_name = "nick was here";
            DateTime ldt_TIME = DateTime.Today;
            
           // ldt_TIME = ldt_TIME.TimeOfDay;
         //   ls_conn = "SKIBOB.DEV.BUS.COM.FDM_BUSConsol.bpmadmin";
           // ls_conn2 = "STIPED.CERT.BUS.COM.FDM_BUSConsol.bpmadmin";



            try
            {

                ls_tblName = ps_tableName;
                string ls_SQL =

                 //" IF  EXISTS " +
                    //" (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BUSCONSRPT_" +
                    //ls_tblName +
                    //"]') AND " +
                    //" type in (N'U')) " +
                    //" select count(*) " +
                    //" from [HYPHFM].[dbo].[BUSCONSRPT_" + ls_tblName + "]" +
                    //" ELSE SELECT -1 "
                    //       ;


                    //"SET IDENTITY_INSERT dbo.tDataMap ON " +
                    //"insert into dbo.tDataMap  " +
                    //"(  " +
                    //"		[PartitionKey]  " +
                    //"      ,[DimName]  " +
                    //"      ,[SrcKey]  " +
                    //"      ,[SrcDesc]  " +
                    //"      ,[TargKey]  " +
                    //"      ,[WhereClauseType]  " +
                    //"      ,[WhereClauseValue]  " +
                    //"      ,[ChangeSign]  " +
                    //"      ,[Sequence]  " +
                    //"      ,[DataKey]  " +
                    //"      ,[VBScript]  " +
                    //")  " +
                    //"select  " +
                    //"		[PartitionKey]  " +
                    //"      ,[DimName]  " +
                    //"      ,[SrcKey]  " +
                    //"      ,[SrcDesc]  " +
                    //"      ,[TargKey]  " +
                    //"      ,[WhereClauseType]  " +
                    //"      ,[WhereClauseValue]  " +
                    //"      ,[ChangeSign]  " +
                    //"      ,[Sequence]  " +
                    //"      ,[DataKey]  " +
                    //"      ,[VBScript]  " +
                    //"from   " +
                    //ls_conn +
                    ////[skibob.dev.BUS.com]
                    //".FDM_BUSConsol.dbo.tdatamap  " +
                    //"SET IDENTITY_INSERT dbo.tDataMap OFF  "
                    //;

                    "  INSERT INTO [DBO].[TEMP_NICK] " +
                    "           ([NAME] " +
                    "           ,[TIME_OF_DAY]) " +
                    "     VALUES " +
                    "           ( '" + ls_name + "',Getdate())"
                    // ldt_TIME + ")"
                    ;


                 //"  INSERT INTO [DBO].[TEMP_NICK] " +
                 //   "           ([NAME] " +
                 //   "           ,[TIME_OF_DAY]) " +
                 //   "     VALUES " +
                 //   "           ( '" + ls_name + "',Getdate())"



                ConnectionManager cm;
                System.Data.SqlClient.SqlConnection sqlConn;
                System.Data.SqlClient.SqlCommand sqlComm;

                cm = Dts.Connections[ls_conn2]; // ado connection.

                sqlConn = (System.Data.SqlClient.SqlConnection)cm.AcquireConnection(Dts.Transaction);
                sqlComm = new System.Data.SqlClient.SqlCommand(ls_SQL, sqlConn);
                object o = sqlComm.BeginExecuteNonQuery();
                cm.ReleaseConnection(sqlConn);
                ls_count = o.ToString();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured in POPULATING FDM MAPPING TABLE IN DEST  -->> " + e.Message);

            }
            return ls_count;

        }
        void CreateErrorFile()
        {
            string pathString = @"c:\test.txt";
            //  string fileName = "test.txt";
            // Delete the file if it exists. 
            if (File.Exists(pathString))
            {
                File.Delete(pathString);
            }

            using (StreamWriter outfile = new StreamWriter(pathString))
            {
                outfile.WriteLine("nick was here Error Code 3333");
            }

            return;
        }
             
 
    }
}