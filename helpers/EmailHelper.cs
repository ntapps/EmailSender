using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailSender.Helpers
{
    public class EmailHelper
    {
        // Sendgrid API Key
        public string ApiKey = "";

        public async Task<(HttpStatusCode StatusCode, string Content)> SendMessage(dynamic data, EmailConfig config) 
        {
            // Create the email client
            var client = new SendGridClient(ApiKey);

            // Construct the message
            var msg = new SendGridMessage();

            // Set the "To" field, deconstruct if there are many
            var toString = ((IDictionary<String, Object>)data)[config.ToField].ToString();
            var toArray = toString.Split(',');

            foreach (var to in toArray) {
                msg.AddTo(to.Trim());
            }

            // Set the "From" field
            msg.SetFrom(new EmailAddress(config.FromEmail, !string.IsNullOrEmpty(config.FromName) ? config.FromName : null));

            // Set the dynamic template data if one is created
            if (!string.IsNullOrEmpty(config.TemplateId)) {
                msg.SetTemplateId(config.TemplateId);
                msg.SetTemplateData(data);
            }

            // FIRE IN THE HOLE
            var response = await client.SendEmailAsync(msg);
            return (response.StatusCode, await response.Body.ReadAsStringAsync());
        }
    }
}