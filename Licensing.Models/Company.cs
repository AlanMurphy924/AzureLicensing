using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossusLicensing.Models
{
    /// <summary>
    /// Company that has licensed Colossus mobile devices
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Unique id of the company licensing Colossus
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Name of the company
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Consignor name
        /// </summary>
        public string ConsignorName { get; set; }

        /// <summary>
        /// Consignor addition field 1
        /// </summary>
        public string ConsignorAdd1 { get; set; }

        /// <summary>
        /// Consignor addition field 2
        /// </summary>
        public string ConsignorAdd2 { get; set; }

        /// <summary>
        /// Consignor addition field 3
        /// </summary>
        public string ConsignorAdd3 { get; set; }

        /// <summary>
        /// PIN used by mobile devices to license a new instance
        /// </summary>
        public string Pin { get; set; }

        /// <summary>
        /// Colossus system registration number
        /// </summary>
        public int ColossusRegNo { get; set; }

        /// <summary>
        /// Number of licensed Colossus Destops
        /// </summary>
        public int ColossusDesktopLicences { get; set; }

        /// <summary>
        /// Number of licensed Colossus Mobile Devices
        /// </summary>
        public int ColossusMobileLicences { get; set; }

        /// <summary>
        /// URL of Colossus mobile endpoint. e.g. http://mobile.site.com:8501
        /// </summary>
        public string ColossusMobileUrl { get; set; }
    }
}
