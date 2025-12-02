using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Excel_12 = Microsoft.Office.Interop.Excel;

namespace GainLoss
{
    class cManageExcel_12
    {

   //     public class cManageExcel_12
       // {
        
            public static void ExportDataGridViewTo_Excel12(DataGridView myDataGridView)
            {

                Excel_12.Application oExcel_12 = null;                //Excel_12 Application

                Excel_12.Workbook oBook = null;                       // Excel_12 Workbook

                Excel_12.Sheets oSheetsColl = null;                   // Excel_12 Worksheets collection

                Excel_12.Worksheet oSheet = null;                     // Excel_12 Worksheet

                Excel_12.Range oRange = null;                         // Cell or Range in worksheet

                Object oMissing = System.Reflection.Missing.Value;
                

                // Create an instance of Excel_12.

                oExcel_12 = new Excel_12.Application();

                // Set the UserControl property so Excel_12 won't shut down.

                oExcel_12.UserControl = true;

                // System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
                
                // Add a workbook.

                oBook = oExcel_12.Workbooks.Add(oMissing);
                
                // Get worksheets collection 

                oSheetsColl = oExcel_12.Worksheets;

            //    oSheet.Visible = Excel_12.XlSheetVisibility.xlSheetHidden;

                // Get Worksheet "Sheet1"
                
              oSheet = (Excel_12.Worksheet)oSheetsColl.get_Item("Sheet1");

             // oSheet =  (Excel_12._Worksheet)oSheetsColl.get_Item("Sheet1");

                // Export titles

                for (int j = 0; j < myDataGridView.Columns.Count; j++)
                {

                    oRange = (Excel_12.Range)oSheet.Cells[1, j + 1];

                    oRange.Value2 = myDataGridView.Columns[j].HeaderText;

                }

                // Export data

                for (int i = 0; i <= myDataGridView.Rows.Count - 1; i++)
                {

                    string r = myDataGridView.Rows.Count.ToString();

                    for (int j = 0; j < myDataGridView.Columns.Count; j++)
                    {

                        oRange = (Excel_12.Range)oSheet.Cells[i + 2, j + 1];

                        oRange.Value2 = myDataGridView[j, i].Value;

                    }

                }
           //     oSheet.Visible = Excel_12.XlSheetVisibility.xlSheetHidden;


                // Make Excel_12 visible to the user.

                oExcel_12.Visible = true;


                // Release the variables.

                //oBook.Close(false, oMissing, oMissing);

                //oBook = null;



                //oExcel_12.Quit();

                //oExcel_12 = null;



                //  Collect garbage.

                GC.Collect();

            }




            public static void ExportDataTableTo_Excel12(DataTable myDataTable)
            {

                Excel_12.Application oExcel_12 = null;                //Excel_12 Application

           
  

                Excel_12.Workbook oBook = null;                       // Excel_12 Workbook

                Excel_12.Sheets oSheetsColl = null;                   // Excel_12 Worksheets collection

                Excel_12.Worksheet oSheet = null;                     // Excel_12 Worksheet

                Excel_12.Range oRange = null;                         // Cell or Range in worksheet

                Object oMissing = System.Reflection.Missing.Value;



               

                // Create an instance of Excel_12.

                oExcel_12 = new Excel_12.Application();


                oExcel_12.DisplayAlerts = false;
                oExcel_12.ScreenUpdating = false;
                oExcel_12.Visible = false;
                oExcel_12.UserControl = false;
                oExcel_12.Interactive = false; 
               

                // Set the UserControl property so Excel_12 won't shut down.

           //     oExcel_12.UserControl = true; // turn off!!! no user input.

                // System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");

                // Add a workbook.

                oBook = oExcel_12.Workbooks.Add(oMissing);

                // Get worksheets collection 

                oSheetsColl = oExcel_12.Worksheets;

                //    oSheet.Visible = Excel_12.XlSheetVisibility.xlSheetHidden;

                // Get Worksheet "Sheet1"

                oSheet = (Excel_12.Worksheet)oSheetsColl.get_Item("Sheet1");

                // oSheet =  (Excel_12._Worksheet)oSheetsColl.get_Item("Sheet1");

                // Export titles

                for (int j = 0; j < myDataTable.Columns.Count; j++)
                {

                    oRange = (Excel_12.Range)oSheet.Cells[1, j + 1];

                    oRange.Value2 = myDataTable.Columns[j].ColumnName;

                }

                // Export data

                for (int i = 0; i <= myDataTable.Rows.Count - 1; i++)
                {

                    string r = myDataTable.Rows.Count.ToString();

                    for (int j = 0; j < myDataTable.Columns.Count; j++)
                    {

                        oRange = (Excel_12.Range)oSheet.Cells[i + 2, j + 1];

                        oRange.Value2 = myDataTable.Rows[i][j].ToString();
                            // myDataTable[j, i].Value;

                    }

                }
                //     oSheet.Visible = Excel_12.XlSheetVisibility.xlSheetHidden;


                // Make Excel_12 visible to the user.

            //    oExcel_12.Visible = true;

                MessageBox.Show("Format " + oBook.FileFormat);

                

                // Release the variables.
              
               // Excel_12.xldis
             //   Excel_12.file.exist();
                
    // string Filename,
    //[OptionalAttribute] Object FileFormat,
    //[OptionalAttribute] Object Password,
    //[OptionalAttribute] Object WriteResPassword,
    //[OptionalAttribute] Object ReadOnlyRecommended,
    //[OptionalAttribute] Object CreateBackup,
    //[OptionalAttribute] Object AddToMru,
    //[OptionalAttribute] Object TextCodepage,
    //[OptionalAttribute] Object TextVisualLayout,
    //[OptionalAttribute] Object Local

       //         Excel_12.XlFileFormat.xlExcel8;

//              oBook.SaveAs(@"c:\Temp\nickExceltest.xlsx",Excel_12.XlFileFormat.xlCSV, oMissing,oMissing,false,false,Excel_12.XlSaveAsAccessMode.xlShared,oMissing,oMissing,oMissing,oMissing,oMissing);
                oBook.SaveAs(@"c:\Temp\nickExceltest3.xls", Excel_12.XlFileFormat.xlExcel8, oMissing, oMissing, false, false, Excel_12.XlSaveAsAccessMode.xlShared,Excel_12.XlSaveConflictResolution.xlLocalSessionChanges, oMissing, oMissing, oMissing);

              object paramMissing = Type.Missing;

   //           string paramExportFilePath = @"C:\Temp\Test.pdf";
     //       Excel_12.XlFixedFormatType paramExportFormat = Excel_12.XlFixedFormatType.xlTypePDF;
      //        XlFixedFormatQuality paramExportQuality =
        //          XlFixedFormatQuality.xlQualityStandard;
/*
            Excel_12.XlFileFormat.xlExcel4Workbook;

              bool paramOpenAfterPublish = false;
              bool paramIncludeDocProps = true;
              bool paramIgnorePrintAreas = true;
              object paramFromPage = Type.Missing;
              object paramToPage = Type.Missing;

              // Save it in the target format.
              if (oBook != null)
                  oBook.ExportAsFixedFormat(paramExportFormat,
                      paramExportFilePath, paramExportQuality,
                      paramIncludeDocProps, paramIgnorePrintAreas, paramFromPage,
                      paramToPage, paramOpenAfterPublish,
                      paramMissing);
                */


                oBook.Close(false, oMissing, oMissing);

                oBook = null;



                oExcel_12.Quit();

                oExcel_12 = null;



                //  Collect garbage.

                GC.Collect();

            }

            // Excel classs... 
     }

        //}

 
   
}