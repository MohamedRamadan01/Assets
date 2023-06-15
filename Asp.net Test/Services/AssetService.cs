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
using Assets.Repositories;

namespace Assets.Services
{
    public class AssetService
    {
        private AssetsRepo assetsRepo;
        public AssetService()
        {
            assetsRepo = new AssetsRepo();
        }
        public bool ProcessData(string serverPath)
        {
            DataTable data = GetData(serverPath);
            return SaveData(data);
        }

        public DataTable GetData(string serverPath)
        {
            try
            {
                //GoogleDriveService googleDriveService = new GoogleDriveService();
                //return googleDriveService.GetSpreadSheet(serverPath);

                HelperService helperService = new HelperService();
                return helperService.GetSpreadSheet(serverPath);
            }
            catch
            {
                return new DataTable();
            }
        }
        public bool SaveData(DataTable data)
        {
            try
            {
                List<Asset> Assets = new List<Asset>();
                foreach (DataRow row in data.Rows)
                {

                    int asset = Convert.ToInt32(row["Asset"]);
                    string assetName = row["AssetName"].ToString();
                    int model = Convert.ToInt32(row["Model"]);
                    string vendorName = row["Vendor"].ToString();
                    string description = row["Description"].ToString();

                    if (asset <= 0) continue;

                    Assets.Add(new Asset
                    {
                        AssetId = asset,
                        AssetName = assetName,
                        Model = model,
                        VendorName = vendorName,
                        Description = description
                    });
                }

                return assetsRepo.SaveData(Assets);
            }
            catch
            {
                return false;
            }

        }
        public string GetJsonData()
        {
            var assets = assetsRepo.GetData();
            return JsonConvert.SerializeObject(assets);
        }
    }
}