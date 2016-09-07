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
            foreach (var keyValuePair in mh.ApplicationToMimeTypeDictionary)
            {
                output.WriteLine($"{keyValuePair.Key} ==> {keyValuePair.Value}");
            }
        }
    }
}
