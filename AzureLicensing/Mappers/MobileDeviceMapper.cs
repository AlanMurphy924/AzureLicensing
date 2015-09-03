using ColossusLicensing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AzureLicensing.Mappers
{
    public class MobileDeviceMapper : EntityTypeConfiguration<MobileDevice>
    {
        public MobileDeviceMapper()
        {
            // Map object to the db table
            this.ToTable("MobileDevice");

            // Mapping for MobileDeviceId
            this.Property(c => c.MobileDeviceId).HasColumnName("Id");
            this.HasKey(c => c.MobileDeviceId);
            this.Property(c => c.MobileDeviceId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.MobileDeviceId).IsRequired();

            // Mapping for SerialNo
            this.Property(c => c.SerialNo).HasColumnName("SerialNo");
            this.Property(c => c.SerialNo).IsRequired();

            // Mapping for Created
            this.Property(c => c.Created).HasColumnName("Created");
            this.Property(c => c.Created).IsRequired();

            // Mapping for CompanyId
            this.Property(c => c.CompanyId).HasColumnName("CompanyId");
            this.Property(c => c.CompanyId).IsRequired();
        }
    }
}