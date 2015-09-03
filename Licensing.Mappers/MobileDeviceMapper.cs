using ColossusLicensing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AzureLicensing.Mappers
{
    /// <summary>
    /// Maps POCO fields for MobileDevice to column names in database for Entity Framework
    /// </summary>
    public class MobileDeviceMapper : EntityTypeConfiguration<MobileDevice>
    {
        private const string MobileDeviceTable = "MobileDevice";
        private const string MobileDeviceIdColumn = "Id";
        private const string SerialNumberColumn = "SerialNo";
        private const string CreatedColumn = "Created";
        private const string CompanyIdColumn = "CompanyId";

        public MobileDeviceMapper()
        {
            // Map object to the db table
            this.ToTable(MobileDeviceTable);

            // Mapping for MobileDeviceId
            this.Property(c => c.MobileDeviceId).HasColumnName(MobileDeviceIdColumn);
            this.HasKey(c => c.MobileDeviceId);
            this.Property(c => c.MobileDeviceId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.MobileDeviceId).IsRequired();

            // Mapping for SerialNo
            this.Property(c => c.SerialNo).HasColumnName(SerialNumberColumn);
            this.Property(c => c.SerialNo).IsRequired();

            // Mapping for Created
            this.Property(c => c.Created).HasColumnName(CreatedColumn);
            this.Property(c => c.Created).IsRequired();

            // Mapping for CompanyId
            this.Property(c => c.CompanyId).HasColumnName(CompanyIdColumn);
            this.Property(c => c.CompanyId).IsRequired();
        }
    }
}