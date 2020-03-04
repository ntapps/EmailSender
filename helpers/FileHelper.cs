using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Threading.Tasks;
using CsvHelper;

namespace EmailSender.Helpers
{
    public class FileHelper
    {
        public List<dynamic> GetAllLines(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
                var records = csv.GetRecords<dynamic>();
                return records.ToList();
            }
        }

        public void WriteLog(string path, string email, string log)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"Email(s): \"{email}\", Log: \"{log}\"");
            }
        }
    }
}