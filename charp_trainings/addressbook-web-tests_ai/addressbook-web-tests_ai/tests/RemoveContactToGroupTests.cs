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
            
            List<GroupData> allGroups = GroupData.GetAll();
            if (allGroups.Count == 0)
            {
                GroupData newGroup = new GroupData("TestGroup");
                app.Groups.Create(newGroup);
                allGroups = GroupData.GetAll();
            }

            
            List<ContactData> allContacts = ContactData.GetAll();
            if (allContacts.Count == 0)
            {
                ContactData newContact = new ContactData("Test", "Contact");
                app.Contacts.Create(newContact);
                allContacts = ContactData.GetAll();
            }

            
            GroupData targetGroup = null;
            ContactData targetContact = null;

            foreach (GroupData group in allGroups)
            {
                List<ContactData> contactsInGroup = group.GetContacts();   
                if (contactsInGroup.Count > 0)                              
                {
                    targetGroup = group;                                    
                    targetContact = contactsInGroup.First();               
                    break;
                }
            }

            
            if (targetGroup == null)
            {
                targetGroup = allGroups.First();                            
                targetContact = allContacts.First();                        

                app.Contacts.AddContactToGroup(targetContact, targetGroup);  
            }

            List<ContactData> oldList = targetGroup.GetContacts();


            app.Contacts.RemoveContactFromGroup(targetContact, targetGroup);

  
            List<ContactData> newList = targetGroup.GetContacts();  
            oldList.Remove(targetContact);                          
            oldList.Sort();                                        
            newList.Sort();                                         
            ClassicAssert.AreEqual(oldList, newList);               
        }
    }
}
