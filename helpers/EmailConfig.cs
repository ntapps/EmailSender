using System;
using System.Collections.Generic;

namespace EmailSender.Helpers
{
    public class EmailConfig
    {
        public string ToField { get; }
        public string FromEmail { get; }
        public string FromName { get; }
        public string TemplateId { get; }

        public EmailConfig(Dictionary<string, string> consoleArgs) 
        {
            ToField    = consoleArgs.ContainsKey("to-field") ? consoleArgs["to-field"] : "email";
            FromEmail  = consoleArgs.ContainsKey("from-email") ? consoleArgs["from-email"] : "";
            FromName   = consoleArgs.ContainsKey("from-name") ? consoleArgs["from-name"] : "";
            TemplateId = consoleArgs.ContainsKey("template-id") ? consoleArgs["template-id"] : "";
        }
    }    
}
