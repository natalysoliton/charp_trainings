using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase

    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contacts.IsContactPresent()) 
            {
                ContactData contact = new ContactData("Test Contact");
                app.Contacts.Create(contact);
            }


            ContactData newData = new ContactData("Тест");
            newData.LastName = "Тестовов";

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0]; 

            app.Contacts.Modify2(oldData, newData);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            //oldContacts.Sort();
            //newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    ClassicAssert.AreEqual(newData.FirstName, contact.FirstName);
                    ClassicAssert.AreEqual(newData.LastName, contact.LastName);
                }
            }
        }
    }
}
