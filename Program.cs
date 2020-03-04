using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmailSender.Helpers;

namespace EmailSender
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize Helpers
            var fileHelper       = new FileHelper();
            var consoleUtilities = new ConsoleUtilities();
            var emailHelper      = new EmailHelper();

            // Get Console args
            var parsedArgs = consoleUtilities.GetArgs(args);

            // Validate all console inputs
            consoleUtilities.ValidateArgs(parsedArgs);

            // Get the data from the CSV
            var allLines = fileHelper.GetAllLines(parsedArgs["0"]);

            // Set email configuration data
            var emailConfig = new EmailConfig(parsedArgs);      

            // Set output path for log
            var outPath = parsedArgs.ContainsKey("out-path") ? parsedArgs["out-path"] : $"./logs/log_{DateTime.Now.ToString("yyyyMMdd-HHmmss")}.txt";

            // Set the Sendgrid API Key
            emailHelper.ApiKey = parsedArgs["api-key"];           

            // Output args
            Console.WriteLine($@"Input Path : ""{parsedArgs["0"]}""");
            Console.WriteLine($@"Output Path: ""{outPath}""");
            Console.WriteLine($@"To Field   : ""{emailConfig.ToField}""");
            Console.WriteLine($@"Template ID: ""{emailConfig.TemplateId}""");

            foreach (var line in allLines) {
                // Send email
                (HttpStatusCode StatusCode, string Content) response = await emailHelper.SendMessage(line, emailConfig);

                // Log results
                fileHelper.WriteLog(outPath, line.email, $"Code: {((int)response.StatusCode).ToString()}, Content: \"{response.Content}\"");
            }
        }
    }
}
