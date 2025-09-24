using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase

    {
        [Test]
        public void GroupModificationTest()
        {
            if (!app.Groups.IsGroupPresent()) 
            {
                GroupData group = new GroupData("Test scoup");
                app.Groups.Create(group);
            }

            GroupData newData = new GroupData("bb");
            newData.Header = "fks";
            newData.Footer = "pqld";

            List<GroupData> oldGroups = GroupData.GetAll(); 
            GroupData oldData = oldGroups[0];

            app.Groups.Modify2(oldData, newData);

            ClassicAssert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll(); 
            oldGroups[0].Name = newData.Name;
            //oldGroups.Sort();
            //newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                ClassicAssert.AreEqual(newData.Name, group.Name); 
                }
            }
        }
    }
}
