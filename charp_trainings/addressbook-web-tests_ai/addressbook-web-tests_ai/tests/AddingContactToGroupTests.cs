using Google.Protobuf.WellKnownTypes;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
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
                                                                
                   List<ContactData> contactsNotInGroup = allContacts          
                                       .Except(contactsInGroup)                                
                                          .ToList();

                  if (contactsNotInGroup.Count > 0)                          
                      {

                          targetGroup = group;
                          targetContact = contactsNotInGroup.First();
                         break;
                       }
            }

                  if (targetGroup == null)                                                   
                        {
                             GroupData newGroup = new GroupData("NewGroupForTest");
                             app.Groups.Create(newGroup);
                             targetGroup = GroupData.GetAll().First(g => g.Name == newGroup.Name);   
                             targetContact = allContacts.First();                                    
                        }


                    List<ContactData> oldList = targetGroup.GetContacts();
                    app.Contacts.AddContactToGroup(targetContact, targetGroup);

                    List<ContactData> newList = targetGroup.GetContacts();      
                    oldList.Add(targetContact);                                 
                    oldList.Sort();                                             
                    newList.Sort();                                             
                    
            
            ClassicAssert.AreEqual(oldList, newList);                  
        }
    }
}
