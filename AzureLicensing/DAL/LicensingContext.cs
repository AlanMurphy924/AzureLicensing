using AzureLicensing.Mappers;
using ColossusLicensing.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AzureLicensing.DAL
{
    public class LicensingContext : DbContext
    {
        public LicensingContext()
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompanyMapper());
            modelBuilder.Configurations.Add(new MobileDeviceMapper());

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<ColossusLicensing.Models.MobileDevice> MobileDevices { get; set; }

        public System.Data.Entity.DbSet<ColossusLicensing.Models.Company> Companies { get; set; }
    }
}