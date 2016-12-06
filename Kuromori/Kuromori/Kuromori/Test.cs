using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kuromori.DataAdapters;
using NUnit.Framework;
using NUnit.Compatibility;

namespace Kuromori
{
    [TestFixture]
    class Test
    {
        [Test]
        public void test()
        { 
            Assert.Pass(EventAdapter.ConvertDate("09 08 2015"));
        }
    }
}
