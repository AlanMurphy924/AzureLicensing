using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossusLicensing.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        // Company name.
        public string CompanyName { get; set; }

        // Consignor name.
        public string ConsignorName { get; set; }

        public string ConsignorAdd1 { get; set; }

        public string ConsignorAdd2 { get; set; }

        public string ConsignorAdd3 { get; set; }

        // Used by the customer to activate new licenses. Min 8 digits.
        public string Pin { get; set; }

        // Colossus system registration number.
        public int ColossusRegNo { get; set; }

        // No of Colossus desktop licenses.
        public int ColossusDesktopLicences { get; set; }

        // No of Colossus mobile licenses.
        public int ColossusMobileLicences { get; set; }

        // URL of Colossus mobile endpoint. e.g. http://mobile.site.com:8500
        public string ColossusMobileUrl { get; set; }

        //public IEnumerable<MobileDevice> MobileDevices { get; set; }
    }
}
