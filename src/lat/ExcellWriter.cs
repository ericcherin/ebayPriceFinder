using lat.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lat
{
    public static class ExcellWriter
    {
        public static string directory = "C:\\Users\\echerin\\Desktop\\";
        public static string defaultFileName = "test1.xlsx";
        public static void save(SafeItemList safeItems, string output)
        {

        }

        public static void test()
        {
            // Set the file name and get the output directory
            var fileName = directory + defaultFileName;
           

            // Create the file using the FileInfo object
            var file = new FileInfo( fileName);
            if (file.Exists)
            {
                file.Delete();
            }
            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
              
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sales list");


                worksheet.Cells[1, 1].Value = "Company name";
                worksheet.Cells[1, 2].Value = "Address";
                worksheet.Cells[1, 3].Value = "Status (unstyled)";

                // Add the second row of header data
                worksheet.Cells[2, 1].Value = "Vehicle registration plate";
                worksheet.Cells[2, 2].Value = "Vehicle brand";

                // Keep track of the row that we're on, but start with four to skip the header

                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();
                worksheet.Column(3).AutoFit();

                // save our new workbook and we are done!
                package.Save();
    
            }

        }

        public static void testRead()
        {

            var fileName = directory + "test2.xlsx";


            var file = new FileInfo(fileName);
 
            using (var package = new ExcelPackage(file))
            {

                // save our new workbook and we are done!


                ExcelWorksheet worksheet = package.Workbook.Worksheets.First();

                string createText = worksheet.Cells[2, 1].Value + " " +  worksheet.Cells[1, 2].Value  ;
                System.IO.File.WriteAllText("C:\\Users\\echerin\\Desktop\\tes1.txt", createText);
            }

        }

    }
    }

