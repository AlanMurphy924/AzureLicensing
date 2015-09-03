using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossusLicensing.Models
{
    /// <summary>
    /// The fields represented by a Mobile Device
    /// e.g. a phone/tablet computer.
    /// </summary>
    public class MobileDevice
    {
        /// <summary>
        /// The unique id of the Mobile Device
        /// </summary>
        public int MobileDeviceId { get; set; }

        /// <summary>
        /// Serial No of the device
        /// </summary>
        public string SerialNo { get; set; }

        /// <summary>
        /// The date and time when the device was first licensed.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The id of the company to which the device is licensed.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Company that the device is licensed to.
        /// </summary>
        public virtual Company Company { get; set; }
    }
}
