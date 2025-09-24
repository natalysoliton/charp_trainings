using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase

    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.IsContactPresent()) 
            {
                ContactData contact = new ContactData("Test Contact");
                app.Contacts.Create(contact);
            }
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove2(toBeRemoved);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            //oldContacts.Sort();
            //newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                ClassicAssert.AreNotEqual(contact.Id, toBeRemoved.Id); 
            }
        }
    }
}

