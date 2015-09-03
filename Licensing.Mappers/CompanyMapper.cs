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
    /// Maps POCO fields for Company to column names in database for Entity Framework
    /// </summary>
    public class CompanyMapper : EntityTypeConfiguration<Company>
    {
        private const string CompanyTable = "Company";
        private const string CompanyIdColumn = "Id";
        private const string CompanyNameColumn = "CompanyName";
        private const string ConsignorNameColumn = "ConsignorName";
        private const string ConsignorAdditionalField1Column = "ConsignorAdd1";
        private const string ConsignorAdditionalField2Column = "ConsignorAdd2";
        private const string ConsignorAdditionalField3Column = "ConsignorAdd3";
        private const string PinColumn = "Pin";
        private const string ColossusRegistrationNumberColumn = "ColossusRegNo";
        private const string ColossusDesktopLicensesColumn = "ColossusDesktopLicenses";
        private const string ColossusMobileLicensesColumn = "ColossusMobileLicenses";
        private const string ColossusMobileUrlColumn = "ColossusMobileUrl";
            
        public CompanyMapper()
        {
            // Map object to the db table
            this.ToTable(CompanyTable);

            // Mapping for the CompanyId
            this.Property(c => c.CompanyId).HasColumnName(CompanyIdColumn);
            this.HasKey(c => c.CompanyId);
            this.Property(c => c.CompanyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.CompanyId).IsRequired();

            // Mapping for the CompanyName
            this.Property(c => c.CompanyName).HasColumnName(CompanyNameColumn);
            this.Property(c => c.CompanyName).IsRequired();

            // Mapping for ConsignorName
            this.Property(c => c.ConsignorName).HasColumnName(ConsignorNameColumn);
            this.Property(c => c.ConsignorName).IsRequired();

            // Mapping for ConsignorAdd1
            this.Property(c => c.ConsignorAdd1).HasColumnName(ConsignorAdditionalField1Column);
            this.Property(c => c.ConsignorAdd1).IsRequired();

            // Mapping for ConsignorAdd2
            this.Property(c => c.ConsignorAdd2).HasColumnName(ConsignorAdditionalField2Column);
            this.Property(c => c.ConsignorAdd2).IsRequired();

            // Mapping for ConsignorAdd13
            this.Property(c => c.ConsignorAdd3).HasColumnName(ConsignorAdditionalField3Column);
            this.Property(c => c.ConsignorAdd3).IsRequired();

            // Mapping for PIN
            this.Property(c => c.Pin).HasColumnName(PinColumn);
            this.Property(c => c.Pin).IsRequired();
            //this.Property(c => c.Pin).HasMaxLength(8);

            // Mapping for ColossusRegNo
            this.Property(c => c.ColossusRegNo).HasColumnName(ColossusRegistrationNumberColumn);
            this.Property(c => c.ColossusRegNo).IsRequired();

            // Mapping for ColossusDesktopLicenses
            this.Property(c => c.ColossusDesktopLicences).HasColumnName(ColossusDesktopLicensesColumn);
            this.Property(c => c.ColossusDesktopLicences).IsRequired();

            // Mapping for ColossusMobileLicenses
            this.Property(c => c.ColossusMobileLicences).HasColumnName(ColossusMobileLicensesColumn);
            this.Property(c => c.ColossusMobileLicences).IsRequired();

            // Mapping for ColossusMobileUrl
            this.Property(c => c.ColossusMobileUrl).HasColumnName(ColossusMobileUrlColumn);
            this.Property(c => c.ColossusMobileUrl).IsRequired();
        }
    }
}