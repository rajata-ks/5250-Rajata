using Mine.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models
{
    [TestFixture]
    public class HomeMenuItemTests
    {
        private MenuItemType ID;

        [Test]
        public void HomeMenuItem_Constructor_Valid_Default_Shoud_Pass()
        {
            //Arrange

            // Act
            var result = new HomeMenuItem();
            // Reset

            // Assert

            Assert.IsNotNull(result);
        }

        [Test]
        public void HomeMenuItem_Set_Get_Valid_Default_Shoud_Pass()
        {
            //Arrange

            // Act
            var result = new HomeMenuItem();
         
            result.Id = ID;
            result.Title = "Title";
        
            // Reset

            // Assert

           
            Assert.AreEqual(ID, result.Id);
            Assert.AreEqual("Title", result.Title);
         
        }

        
    }
}
