﻿using Mine.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models
{
    [TestFixture]
    class ItemModelTests
    {
        [Test]
        public void ItemModel_Constructor_Valid_Default_Shoud_Pass()
        {
            //Arrange

            // Act
            var result = new ItemModel();
            // Reset

            // Assert

            Assert.IsNotNull(result);
        }
    }
}
