using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MimeHelpers
{
    public class MimeHelpers
    {
        public IDictionary<string, string> ApplicationToMimeTypeDictionary { get; }

        public IDictionary<string, string> ExtMimeDictionary { get; }


        public MimeHelpers()
        {
            ExtMimeDictionary = GetExtToMime();
            ApplicationToMimeTypeDictionary = GetAppToMime();
        }

        private string[] GetLineValues(string line)
        {
            return line.Split(',').Select(m=>m.Trim('"')).ToArray();
        }


        private IDictionary<string, string> GetExtToMime()
        {
            var d = new Dictionary<string,string>();
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MimeHelpers.csv.extension_mimetype.csv"))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var lineVals = GetLineValues(line);
                    var ext = lineVals[0];
                    var mimeType = lineVals[1];
                    d.Add(ext,mimeType);
                }
            }
            return d;
        }

        private IDictionary<string, string> GetAppToMime()
        {
            var d = new Dictionary<string, string>();
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MimeHelpers.csv.application_mimetype.csv"))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var lineVals = GetLineValues(line);
                    var ext = lineVals[0];
                    var mimeType = lineVals[1];
                    d.Add(ext, mimeType);
                }
            }
            return d;
        }
    }
}
