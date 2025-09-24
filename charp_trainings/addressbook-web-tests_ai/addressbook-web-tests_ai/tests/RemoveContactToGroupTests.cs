using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];            
            List<ContactData> oldList = group.GetContacts();     
            ContactData contact = oldList[0];                   

            app.Contacts.RemoveContactFromGroup(contact, group);  

            List<ContactData> newList = group.GetContacts();    
            oldList.Remove(contact);                            
            newList.Sort();                                    
            oldList.Sort();                                     
            ClassicAssert.AreEqual(oldList, newList);           
        }
    }
}