using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;
using System.Web.UI;
using OfficeOpenXml;
using System.Runtime.InteropServices.ComTypes;
using Google.Apis.Auth.OAuth2.Flows;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Assets.Models;
using System.Data.Entity;
using Assets.Data;
using Newtonsoft.Json;
using System.Linq;

namespace Assets.Services
{
    public class GoogleDriveService
    {
        public DataTable GetSpreadSheet(string serverPath)
        {
            string[] Scopes = { DriveService.Scope.Drive };
            string FilePath = Path.Combine(serverPath, "ClientSecret.json");
            var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);


            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.FromStream(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(Path.Combine(serverPath, "Tokens"), true)).Result;


            // Create Drive API service
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Drive Integration",
            });


            // Set the file ID of the spreadsheet to import
            string fileId = "17DdPK2SDWcsR_VeQwc6Ny9CkH-Eodlkk";

            // Request the spreadsheet data
            var request = service.Files.Export(fileId, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            var streamContent = request.ExecuteAsStream();
            var requestFiles = service.Files.List();

            // Load the spreadsheet data into a DataTable
            DataTable dataTable = new DataTable();

            using (var package = new ExcelPackage(streamContent))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                // Loop through rows and columns to populate the DataTable
                foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.Columns])
                {
                    dataTable.Columns.Add(firstRowCell.Text);
                }

                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                {
                    DataRow dataRow = dataTable.Rows.Add();
                    for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                    {
                        dataRow[col - 1] = worksheet.Cells[row, col].Text;
                    }
                }
            }

            return dataTable;
        }
    }
}