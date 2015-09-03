using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossusLicensing.Models
{
    /// <summary>
    /// Response object to license and relicense requests
    /// that is serialised to JSON.
    /// </summary>
    public class LicenseResponse
    {
        /// <summary>
        /// Result value returned by license/relicense request 
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// Error message - empty string unless Rsult is non-zero
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// PK value of the MobileDevice
        /// </summary>
        public int DeviceNo { get; set; }

        /// <summary>
        /// URL of the Colossus Server application.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Consignor Name
        /// </summary>
        public string ConsignorName { get; set; }

        /// <summary>
        /// Consignor Additional Field 1
        /// </summary>
        public string ConsignorAdd1 { get; set; }

        /// <summary>
        /// Consignor Additional Field 2
        /// </summary>
        public string ConsignorAdd2 { get; set; }

        /// <summary>
        /// Consignor Additional Field 3
        /// </summary>
        public string ConsignorAdd3 { get; set; }
    }
}
