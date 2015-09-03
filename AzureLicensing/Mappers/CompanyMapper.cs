using ColossusLicensing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AzureLicensing.Mappers
{
    public class CompanyMapper : EntityTypeConfiguration<Company>
    {
        public CompanyMapper()
        {
            // Map object to the db table
            this.ToTable("Company");

            // Mapping for the CompanyId
            this.Property(c => c.CompanyId).HasColumnName("Id");
            this.HasKey(c => c.CompanyId);
            this.Property(c => c.CompanyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.CompanyId).IsRequired();

            // Mapping for the CompanyName
            this.Property(c => c.CompanyName).HasColumnName("CompanyName");
            this.Property(c => c.CompanyName).IsRequired();

            // Mapping for ConsignorName
            this.Property(c => c.ConsignorName).HasColumnName("ConsignorName");
            this.Property(c => c.ConsignorName).IsRequired();

            // Mapping for ConsignorAdd1
            this.Property(c => c.ConsignorAdd1).HasColumnName("ConsignorAdd1");
            this.Property(c => c.ConsignorAdd1).IsRequired();

            // Mapping for ConsignorAdd2
            this.Property(c => c.ConsignorAdd2).HasColumnName("ConsignorAdd2");
            this.Property(c => c.ConsignorAdd2).IsRequired();

            // Mapping for ConsignorAdd13
            this.Property(c => c.ConsignorAdd3).HasColumnName("ConsignorAdd3");
            this.Property(c => c.ConsignorAdd3).IsRequired();

            // Mapping for PIN
            this.Property(c => c.Pin).HasColumnName("Pin");
            this.Property(c => c.Pin).IsRequired();
            //this.Property(c => c.Pin).HasMaxLength(8);

            // Mapping for ColossusRegNo
            this.Property(c => c.ColossusRegNo).HasColumnName("ColossusRegNo");
            this.Property(c => c.ColossusRegNo).IsRequired();

            // Mapping for ColossusDesktopLicenses
            this.Property(c => c.ColossusDesktopLicences).HasColumnName("ColossusDesktopLicences");
            this.Property(c => c.ColossusDesktopLicences).IsRequired();

            // Mapping for ColossusMobileLicenses
            this.Property(c => c.ColossusMobileLicences).HasColumnName("ColossusMobileLicences");
            this.Property(c => c.ColossusMobileLicences).IsRequired();

            // Mapping for ColossusMobileUrl
            this.Property(c => c.ColossusMobileUrl).HasColumnName("ColossusMobileUrl");
            this.Property(c => c.ColossusMobileUrl).IsRequired();
        }
    }
}