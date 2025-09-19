using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{

    [TestFixture]
    public class Tests : AuthTestBase
    {
        [Test]
        public void Test()
        {
            app.Navigator.GoToHomePage();
            app.Contacts.InitDetails(0);

            string text = app.Contacts.Test1();
            string searchWord = "Home";
            ClassicAssert.IsTrue(text.Contains(searchWord));
        }
    }
}
