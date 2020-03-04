using System;
using System.Collections.Generic;
using System.IO;

namespace EmailSender.Helpers
{
    public class ConsoleUtilities
    {
        public Dictionary<string, string> GetArgs(string [] args) 
        {
            var parsedArgs = new Dictionary<string, string>();
            var counter = 0;
            var flag = "";

            foreach (string arg in args) {
                if (arg.Substring(0, 2) == "--" && flag == "") {
                    flag = arg.Substring(2);
                } else if (flag != "") {
                    parsedArgs[flag] = arg;
                    flag = "";
                } else if (flag == "") {
                    parsedArgs[counter.ToString()] = arg;
                    counter++;
                } else {
                    throw new Exception($"Improperly formed argument \"{arg}\"");
                }
            }

            return parsedArgs;
        }

        public void ValidateArgs(Dictionary<string, string> args) {
            // Verify that input file arg exists
            if (!File.Exists(args["0"])) throw new Exception("First argument must be a valid csv input path.");

            // Sendgrid API Key is required
            if (!args.ContainsKey("api-key")) throw new Exception("'api-key' is required");

            // Make sure from email is set
            if (!args.ContainsKey("from-email")) throw new Exception("'from-email' is required.");
        }
    }
}