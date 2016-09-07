using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MimeHelpers.Tests
{
    public class MimeHelperTests
    {
        private readonly ITestOutputHelper output;

        public MimeHelperTests(ITestOutputHelper outputConsole)
        {
            output = outputConsole;
        }


        [Fact]
        public void TestCreation()
        {
            var mh  = new MimeHelpers();
            foreach (var keyValuePair in mh.ExtMimeDictionary)
            {
                output.WriteLine($"{keyValuePair.Key} ==> {keyValuePair.Value}");
            }
        }


        [Fact]
        public void get_mimetype_for_ext()
        {
            var mh = new MimeHelpers();

            var pdfMime = mh.GetMimeTypeForExtension("pdf");
            var pdfMime2 = mh.GetMimeTypeForExtension(".pdf");
            var html = mh.GetMimeTypeForExtension("html");
            var htm = mh.GetMimeTypeForExtension("htm");

            Assert.Equal(pdfMime,"application/pdf");
            Assert.Equal(pdfMime2, "application/pdf");
            Assert.True(html=="text/html");
            Assert.Equal(html,"text/html");

        }

    }
}
