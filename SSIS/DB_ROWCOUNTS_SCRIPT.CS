/*
   Microsoft SQL Server Integration Services Script Task
   Write scripts using Microsoft Visual C# 2008.
   The ScriptMain is the entry point class of the script.
*/

using System;
using System.Data;
using Microsoft.SqlServer.Dts.Runtime;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

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
        string ms_SkibobErrCnt;
        string ms_StipedErrCnt;

        public void Main()
        {

       //     CreateConn();
    //        CompareVar();
            CompareVariables();
        //    CreateEmail("null");


        }
        void CreateConn()
        {

        }
        string CreateHtmlBad()
        {
            return "<html><body><h3>App.Copy Results </h3><p>The App. copy table compare failed. <BR>The counts did <b>NOT</b> match. DEV was "+ ms_SkibobErrCnt+ " and CERT was " + ms_StipedErrCnt + "." + "</p></body></html>";
        }
        string CreateHtmlGood()
        {
            return "<html><body><h3>App.Copy Results</h3><p>The App. copy table compare was succesfull. <BR>The counts matched. DEV was " + ms_SkibobErrCnt + " and CERT was " + ms_StipedErrCnt + "." + "</p></body></html>";
        }
        void CreateEmail(string ps_HtmlBody)
        {

            string ls_HtmlBody = ps_HtmlBody;
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

            htmlMessage = new MailMessage(SendTo, From, Subject, Body);
            htmlMessage.IsBodyHtml = IsBodyHtml;

            mySmtpClient = new SmtpClient(Server);
            mySmtpClient.Credentials = CredentialCache.DefaultNetworkCredentials;
            mySmtpClient.Send(htmlMessage);

        }

        void CompareVariables()
        {
            // TODO: Add your code here
            int li_SkibobErrCnt = 4;
            int li_StipedErrCnt = 0;
            string ls_HtmlBody = "";


            if (Dts.Variables.Contains("SKIBOB_ROWCOUNT") == true && Dts.Variables.Contains("STIPED_ROWCOUNT") == true)
            {
                ms_SkibobErrCnt = (string)Dts.Variables["SKIBOB_ROWCOUNT"].Value;
                ms_StipedErrCnt = (string)Dts.Variables["STIPED_ROWCOUNT"].Value;

                li_SkibobErrCnt = Convert.ToInt32(ms_SkibobErrCnt.Trim());
                li_StipedErrCnt = Convert.ToInt32(ms_StipedErrCnt.Trim());

            }

            if (li_SkibobErrCnt != li_StipedErrCnt)
            {
                Dts.TaskResult = (int)ScriptResults.Failure;
                ls_HtmlBody = CreateHtmlBad();
                CreateEmail(ls_HtmlBody);
            }
            else
            {
                Dts.TaskResult = (int)ScriptResults.Success;
                ls_HtmlBody = CreateHtmlGood();
                CreateEmail(ls_HtmlBody);
               
            }

            Dts.TaskResult = (int)ScriptResults.Success;
        
        }
    }
}