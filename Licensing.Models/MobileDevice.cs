using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossusLicensing.Models
{
    public class MobileDevice
    {
        public int MobileDeviceId { get; set; }

        // Serial number of device.
        public string SerialNo { get; set; }

        // When device was first licensed.
        public DateTime Created { get; set; }

        public int CompanyId { get; set; }

        // Company this device used by.
        public virtual Company Company { get; set; }
    }
}
