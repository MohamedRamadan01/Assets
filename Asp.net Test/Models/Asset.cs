using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assets.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }

        public string AssetName { get; set; }

        public int Model { get; set; }

        public string VendorName { get; set; }

        public string Description { get; set; }
    }
}