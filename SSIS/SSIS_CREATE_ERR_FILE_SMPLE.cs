/*
   Microsoft SQL Server Integration Services Script Task
   Write scripts using Microsoft Visual C# 2008.
   The ScriptMain is the entry point class of the script.
*/

using System;
using System.Data;
using Microsoft.SqlServer.Dts.Runtime;
using System.Windows.Forms;
using System.IO;

namespace ST_f588345066dc4302b6af21111d0a6699.csproj
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

        public void Main()
        {
            // TODO: Add your code here

            CreatErrorFile();
            Dts.TaskResult = (int)ScriptResults.Success;
        }
        void CreatErrorFile()
        {
            string pathString = @"c:\test.txt";
            string fileName = "test.txt";
                        // Delete the file if it exists. 
            if (File.Exists(pathString))
            {
                File.Delete(pathString);
            }

     //       if (!System.IO.File.Exists(pathString))
       //     {
            //    using (System.IO.FileStream fs = System.IO.File.Create(pathString))
              //  {
                    using (StreamWriter outfile = new StreamWriter(pathString))
                    {
                        outfile.WriteLine("nick Error Code 777");
                    }

                   
               // }
         //   }
           // else
          //  {
            //    Console.WriteLine("File \"{0}\" already exists.", fileName);
              //  return;
        //    }

                    return;
        }
    }
}