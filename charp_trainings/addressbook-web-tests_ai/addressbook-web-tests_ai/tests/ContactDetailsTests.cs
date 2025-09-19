using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDetailsTests : AuthTestBase
    {
        [Test]
        public void ContactDetailsTest()
        {
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(0);
            ContactData fromFrom = app.Contacts.GetContactInformationFromEditForm(0);

            ClassicAssert.AreEqual(fromDetails.AllNames, fromFrom.AllNames);
            ClassicAssert.AreEqual(fromDetails.TextInDetails, fromFrom.TextInDetails);
        }
    }
}
