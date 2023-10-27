/*************************************************************************************************************************************
 * This script EXTRACTPLANPDF automates the process of exporting Monaco plans to PDF and DICOM formats, in the Centro Javeriano de Oncología. 
 * 1.This code imports the necessary libraries and creates a class called Program. 
 * The class begins by defining some script variables, which are read from the App.config file and from a pop-up dialog box.
 * The variables used in this script are given via App.config as well as customizable pop-up dialog.
 * 2.Creates a List of strings called destinos and adds the string "MOSAIQ" to it. 
 * This is the destination system where the DICOM files will be exported.
 * 3. Gets the MonacoApplication instance and checks if the ExportPath directory exists ("\\10.160.221.10\mosaiq_data\DB\ESCAN").
 * If it does not exist, the code creates the directory.
 * 4. Exports all customized reports to the ExportPath directory with the name "reporte".
 * 5. The script ends when the code starts the DICOM auto export process with the destinos list and the DicomExportOffsetOption.Continue option.
 *
 *************************************************************************************************************************************/
// Imports the following libraries
using System;
using Elekta.MonacoScripting.API;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Elekta.MonacoScripting.Log;
using Elekta.MonacoScripting.API.DICOMExport;
using Elekta.MonacoScripting.DataType;
using System.Collections.Generic;

namespace ExtractPlanPDF
{
    class Program
    {
        // Step 1: Script variables in App.config ("\\10.160.221.10\mosaiq_data\DB\ESCAN")
        private static string ExportPath = ConfigurationManager.AppSettings["ExportPath"];


        static void Main(string[] args)
        {
            //Step 2: List creation 
            //Creates a new list of strings called "destinos".
            // This will store the destination systems where the DICOM files will be exported.
            List<string> destinos = new List<string>();
            //Step 3: List population 
            //Adds the string "MOSAIQ" to the destinos list. This is the default destination system for DICOM exports.
            destinos.Add("MOSAIQ");
            
            //Step 4: MonacoApplication instance retrieval. This object provides access to the Monaco scripting API.
            try
            {
                MonacoApplication app = MonacoApplication.Instance;
                // Step 5: Directory existence check. This checks if the ExportPath directory exists.
                // If it does not exist, the code creates the directory.
                if (!Directory.Exists(ExportPath))
                {
                    Directory.CreateDirectory(ExportPath);
                }

                //Step 6: Export PDF 
                //Method to export all customized reports to the ExportPath directory with the name "reporte".
                app.ExportAllCustomizedReports("reporte",ExportPath,"");

                //Step 7: DICOM auto-export
                //Method to start the DICOM auto-export process. 
                //The destinos list specifies the destination systems where the DICOM files will be exported. 
                app.StartDICOMAutoExport(destinos,MonacoApplication.DicomExportOffsetOption.Continue);

            }
            //Step 8: Exception handling
            //This will display a message box with the exception message.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception occurred", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

    }
}
