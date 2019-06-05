using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoAPI;
using DemoAPI.Controllers;
using DemoAPI.Models;

namespace DemoAPI.Tests.Controllers
{
    [TestClass]
    public class ContactsControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ContactsController controller = new ContactsController();

            // Act
            List<Contact> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 1);
            Assert.IsTrue(result.Where(x => x.FirstName == "No Contacts Available").Count() == 1);
           
        }

    }
}
