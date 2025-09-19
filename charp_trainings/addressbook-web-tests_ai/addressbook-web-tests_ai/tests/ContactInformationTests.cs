using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromFrom = app.Contacts.GetContactInformationFromEditForm(0);

            ClassicAssert.AreEqual(fromTable, fromFrom);
            ClassicAssert.AreEqual(fromTable.Address, fromFrom.Address);
            ClassicAssert.AreEqual(fromTable.AllEmail, fromFrom.AllEmail);
            ClassicAssert.AreEqual(fromTable.AllPhones, fromFrom.AllPhones);
        }
    }
}
