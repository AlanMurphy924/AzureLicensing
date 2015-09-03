using AzureLicencing.Utilities;
using AzureLicensing.DAL;
using ColossusLicensing.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace AzureLicensing.Controllers
{
    /// <summary>
    /// License result codes
    /// </summary>
    enum LicenceResultCode
    {
        Success = 0,
        PinIncorrectLength = -2,
        PinNotFound = -3,
        DeviceAlreadyRegistered = -4,
        Unknown = -5
    }

    /// <summary>
    /// Relicense result codes
    /// </summary>
    enum RelicenceResultCode
    {
        Success = 0,
        NotRegistered = -2,
        Unknown = -5
    }

    /// <summary>
    /// Controller for licensing web api methods.
    /// </summary>
    [RoutePrefix("api/Licenses")]
    public class LicensesController : ApiController
    {
        /// <summary>
        /// Create Logger for log4net
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(LicensesController));

        /// <summary>
        /// Create a new instance of the LicensingContext
        /// </summary>
        private LicensingContext db = new LicensingContext();

        // POST: api/Licences/License
        [ResponseType(typeof(LicenseResponse))]
        [Route("License")]
        [HttpPost]
        public IHttpActionResult PostLicense([FromBody] LicenseRequest request)
        {
            logger.Debug("PostLicense(LicenseRequest) entered ...");

            try
            {
                // Validate Company PIN format, if invalid return an error.
                if (request.CompanyPIN.Length != 8)
                {
                    logger.InfoFormat("PIN is incorrect length : {0}, should be 8 characters", request.CompanyPIN.Length);

                    return Ok(new LicenseResponse()
                        {
                            Error = "PIN must be 8 digits",
                            Result = (int)LicenceResultCode.PinIncorrectLength
                        });
                }

                // Attempt to find Company from the PIN.
                Company company = db.Companies.FirstOrDefault(c => c.Pin == request.CompanyPIN);
                
                // If not found return an error.
                if (company == null)
                {
                    logger.InfoFormat("Failed to find Company with PIN : {0}", request.CompanyPIN);

                    return Ok(new LicenseResponse()
                    {
                        Error = "PIN is invalid",
                        Result = (int)LicenceResultCode.PinNotFound
                    });
                }

                // Check if already listed as a device.
                MobileDevice device = db.MobileDevices.FirstOrDefault(d => d.SerialNo == request.SerialNo);

                // If the device exists return error showing already registered
                if (device != null)
                {
                    logger.InfoFormat("Device with Serial # : {0} already registered", request.SerialNo);

                    return Ok(new LicenseResponse()
                    {
                        Error = "Device already registered",
                        Result = (int)LicenceResultCode.DeviceAlreadyRegistered
                    });
                }

                // Create new device.
                device = new MobileDevice()
                {
                    Company = company,
                    SerialNo = request.SerialNo,
                    Created = DateTime.Now,
                    CompanyId = company.CompanyId,
                };

                // Add to the collection of Mobile Devices ...
                device = db.MobileDevices.Add(device);
                db.SaveChanges();

                logger.DebugFormat("New device with Id : {0} created", device.MobileDeviceId);

                // Send email ...
                int numberOfDevices = db.MobileDevices.Count(d => d.CompanyId == device.MobileDeviceId);
                MailUtilities.SendEmail(numberOfDevices, device, "licensed");

                // Return configuration.
                return Ok(new LicenseResponse()
                {
                    Result = (int)LicenceResultCode.Success,
                    DeviceNo = device.MobileDeviceId,
                    Url = device.Company.ColossusMobileUrl,
                    ConsignorName = device.Company.ConsignorName,
                    ConsignorAdd1 = device.Company.ConsignorAdd1,
                    ConsignorAdd2 = device.Company.ConsignorAdd2,
                    ConsignorAdd3 = device.Company.ConsignorAdd3,
                    Error = string.Empty
                });
            }
            catch (Exception ex)
            {
                logger.Error("Error licensing device", ex);

                return Ok(new LicenseResponse()
                    {
                        Result = (int)LicenceResultCode.Unknown,
                        Error = "Unknown Error",
                        Url = string.Empty
                    });
            }
            finally
            {
                logger.Debug("PostLicense(LicenseRequest) exited");
            }
        }

        // POST: api/Licences/Relicense
        [ResponseType(typeof(LicenseResponse))]
        [Route("Relicense")]
        [HttpPost]
        public IHttpActionResult PostRelicense([FromBody] RelicenseRequest request)
        {
            logger.Debug("PostRelicense(ReliscenseRequest) entered ...");

            try
            {
                // Check if already listed as a device.
                MobileDevice device = db.MobileDevices.Include("Company").FirstOrDefault(d => d.SerialNo == request.SerialNo);
                
                if (device == null)
                {
                    logger.InfoFormat("Device with Serial # : {0} not registered", request.SerialNo);

                    return Ok(new LicenseResponse()
                        {
                            Error = "Device not registered",
                            Result = (int)RelicenceResultCode.NotRegistered
                        });
                }

#if ENABLE_EMAIL
                // Send email ...
                MailUtilities.SendEmail(db, device, "relicensed");
#endif

                // Return configuration.
                return Ok(new LicenseResponse()
                    {
                        Result = (int)RelicenceResultCode.Success,
                        DeviceNo = device.MobileDeviceId,
                        Url = device.Company.ColossusMobileUrl,
                        ConsignorName = device.Company.ConsignorName,
                        ConsignorAdd1 = device.Company.ConsignorAdd1,
                        ConsignorAdd2 = device.Company.ConsignorAdd2,
                        ConsignorAdd3 = device.Company.ConsignorAdd3,
                        Error = string.Empty
                    });
            }
            catch (Exception ex)
            {
                logger.Error("Error relicensing device", ex);

                return Ok(new LicenseResponse()
                {
                    Result = (int)RelicenceResultCode.Unknown,
                    Error = "Unknown Error",
                    Url = string.Empty
                });
            }
            finally
            {
                logger.Debug("PostRelicense(ReliscenseRequest) exited");
            }
        }

        bool disposed = false;

        /// <summary>
        /// Override Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            // If already disposed return immediately
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose the LicensingContext
                if (db != null)
                {
                    db.Dispose();
                }
            }

            disposed = true;

            base.Dispose(disposing);
        }
    }
}