using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Models
{
    public class BrandsDatabaseSettings : IBrandsDatabaseSettings
    {
        public string BrandsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBrandsDatabaseSettings
    {
        string BrandsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
