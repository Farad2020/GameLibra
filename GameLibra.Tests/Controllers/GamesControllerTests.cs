﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLibra.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibra.Models;

namespace GameLibra.Controllers.Tests
{
    [TestClass()]
    public class GamesControllerTests
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [TestMethod()]
        public void IndexTest()
        {
            // Arrange
            GamesController controller = new GamesController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Arrange
            GamesController controller = new GamesController();

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            GamesController controller = new GamesController();

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTest1()
        {
            // Arrange
            GamesController controller = new GamesController();

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EditTest()
        {
            // Arrange
            GamesController controller = new GamesController();

            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EditTest1()
        {
            // Arrange
            GamesController controller = new GamesController();

            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            GamesController controller = new GamesController();

            // Act
            var result = controller.Delete(0);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            // Arrange
            GamesController controller = new GamesController();

            // Act
            var result = controller.DeleteConfirmed(0);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}