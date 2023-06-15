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
using Assets.Services;

namespace Assets
{
    public partial class _Default : Page
    {
        private AssetService assetService;
        protected void Page_Load(object sender, EventArgs e)
        {
            assetService = new AssetService();
        }

        protected void GetData_Click(object sender, EventArgs e)
        {
            assetService.ProcessData(Server.MapPath("~"));
        }

        protected string GetAssetsJson()
        {
            return assetService.GetJsonData();
        }
    }
}
