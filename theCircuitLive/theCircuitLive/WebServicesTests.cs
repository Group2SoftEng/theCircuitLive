using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace theCircuitLive
{
    
    [TestFixture]
    class WebServicesTests
    {
        
        [Test]
        public void TestJson()
        {
            Assert.Ignore(ConnectionManager.Jsonget().Result);
            
        }
    }
}
