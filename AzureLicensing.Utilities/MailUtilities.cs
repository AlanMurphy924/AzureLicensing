using AzureLicensing;
using ColossusLicensing.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace AzureLicencing.Utilities
{
    public class MailUtilities
    {
        // Create Logger object for log4net
        private static readonly ILog logger = LogManager.GetLogger(typeof(MailUtilities));

        private static SmtpConfigSection instance = null;

        public static SmtpConfigSection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (SmtpConfigSection)WebConfigurationManager.GetSection("smtpConfig");
                }

                return instance;
            }
        }

        private static string CreateSubject(MobileDevice device, int numberOfDevices)
        {
            if (numberOfDevices > device.Company.ColossusMobileLicences)
            {
                return "Colossus mobile licensing exceeded";
            }

            return "Colossus mobile licensing";
        }

        private static string CreateBody(MobileDevice device, string type, int numberOfDevices)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("<b>Device {0}</b><br>", type);
            builder.AppendFormat("<b>Company: {0}</b><br>", device.Company.CompanyName);
            builder.Append("<br>");
            builder.AppendFormat("Date requested: {0} {1}<br>", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
            builder.AppendFormat("Colossus reg. no. {0}<br>", device.Company.ColossusRegNo);
            builder.AppendFormat("Device serial no: {0}<br>", device.SerialNo);
            builder.Append("<br>");
            builder.AppendFormat("Device count: {0}<br>", numberOfDevices);
            builder.AppendFormat("License count: {0}<br>", device.Company.ColossusMobileLicences);

            return builder.ToString();
        }

        // Send email notification.
        public static void SendEmail(int numberOfDevices, MobileDevice mobileDevice, string type)
        {
            logger.Debug("SendMail(LicensingContext, MobileDevice, string) entered ...");

            try
            {
                // Construct the Subject line
                string subject = CreateSubject(mobileDevice, numberOfDevices);

                logger.DebugFormat("Subject : {0}", subject);

                // Construct the email Body
                string body = CreateBody(mobileDevice, type, numberOfDevices);

                // Send email.
                using (MailMessage message = new MailMessage(Instance.Smtp.From, Instance.Smtp.To))
                {
                    message.Subject = subject;
                    message.IsBodyHtml = true;
                    message.Body = body;

                    using (SmtpClient client = new SmtpClient(Instance.Smtp.Server, Instance.Smtp.Port))
                    {
                        // If not using the standard SMTP port then set Network Credentials
                        if (client.Port != 25)
                        {
                            client.UseDefaultCredentials = false;
                            client.Credentials = new NetworkCredential(Instance.Credentials.Username, Instance.Credentials.Password);
                        }

#if ENABLE_EMAIL
                        client.Send(message);
#endif
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Failed to send email", ex);
            }
            finally
            {
                logger.Debug("SendMail(LicensingContext, MobileDevice, string) exited");
            }
        }
    }
}