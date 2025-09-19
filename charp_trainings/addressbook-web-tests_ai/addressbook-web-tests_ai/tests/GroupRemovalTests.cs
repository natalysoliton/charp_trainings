using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.IsGroupPresent()) 
            {
                GroupData group = new GroupData("Test scoup");
                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList(); 

            app.Groups.Remove(0);

            ClassicAssert.AreEqual(oldGroups.Count-+ 1, app.Groups.GetGroupCount()); 

            List<GroupData> newGroups = app.Groups.GetGroupList(); 
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0); 
            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                ClassicAssert.AreNotEqual(group.Id, toBeRemoved.Id); 
            }
        }
    }
}
