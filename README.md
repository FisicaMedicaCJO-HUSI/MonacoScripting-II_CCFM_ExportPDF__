# MonacoScripting-II_CCFM_ExportPDF__
 This script EXTRACTPLANPDF automates the process of exporting Monaco plans to PDF and DICOM formats, in the Centro Javeriano de Oncología. 
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
