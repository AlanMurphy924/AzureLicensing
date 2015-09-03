using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossusLicensing.Models
{
    /// <summary>
    /// Structure of object that will be deserialised from JSON
    /// and is passed in a call to the license REST POST.
    /// </summary>
    public class LicenseRequest
    {
        /// <summary>
        /// Serial number of the calling device
        /// i.e. the IMEI
        /// </summary>
        public string SerialNo { get; set; }

        /// <summary>
        /// PIN number that identifies the company that owns the
        /// calling device
        /// </summary>
        public string CompanyPIN { get; set; }
    }
}
