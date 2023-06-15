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

namespace Assets.Services
{
    public class HelperService
    {
        public DataTable GetSpreadSheet(string serverPath)
        {
            string filePath = Path.Combine(serverPath, "Assets.xlsx");  
            DataTable sheet1 = new DataTable("Excel Sheet");
            OleDbConnectionStringBuilder csbuilder = new OleDbConnectionStringBuilder();
            csbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            csbuilder.DataSource = filePath;
            csbuilder.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES");
            string selectSql = @"SELECT * FROM [Sheet1$]";
            using (OleDbConnection connection = new OleDbConnection(csbuilder.ConnectionString))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    connection.Open();
                    adapter.Fill(sheet1);
                }
            }
            return sheet1;
        }
    }
}