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


        public string GetMimeTypeForExtension(string extension)
        {
            var s = Path.GetExtension(extension);
            if (s != null) extension = s.TrimStart('.');
            return ExtMimeDictionary[extension];
        }

        public string GetMimeTypeForApplication(string application)
        {
            var mime =
                ApplicationToMimeTypeDictionary.Keys.FirstOrDefault(m => m.ToLower().Contains(application));

            return mime;
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
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var lineVals = GetLineValues(line);
                        var ext = lineVals[0];
                        var mimeType = lineVals[1];

                        if (!d.ContainsKey(ext))
                            d.Add(ext, mimeType);
                    }
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
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var lineVals = GetLineValues(line);
                        var ext = lineVals[0];
                        var mimeType = lineVals[1];

                        if (!d.ContainsKey(ext))
                            d.Add(ext, mimeType);
                    }
                }
            }
            return d;
        }
    }
}
