using Assets.Data;
using Assets.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Assets.Repositories
{
    public class AssetsRepo
    {
        private AssetDbContext AssetDbContext;

        public AssetsRepo()
        {
            AssetDbContext = new AssetDbContext();
        }
        public bool SaveData(List<Asset> data)
        {
            try
            {
                AssetDbContext.Assets.AddRange(data);
                AssetDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<Asset> GetData()
        {
            return AssetDbContext.Assets.ToList();
        }
    }
}