using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossusLicensing.Models
{
    public class LicenseResponse
    {
        public int Result { get; set; }
        public string Error { get; set; }
        public int DeviceNo { get; set; }
        public string Url { get; set; }
        public string ConsignorName { get; set; }
        public string ConsignorAdd1 { get; set; }
        public string ConsignorAdd2 { get; set; }
        public string ConsignorAdd3 { get; set; }
    }
}
