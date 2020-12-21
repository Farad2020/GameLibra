using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class DevelopersControllerTests
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [TestMethod()]
        public void IndexTest()
        {
            // Arrange
            DevelopersController controller = new DevelopersController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Arrange
            DevelopersController controller = new DevelopersController();

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            DevelopersController controller = new DevelopersController();

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTest1()
        {
            // Arrange
            DevelopersController controller = new DevelopersController();

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EditTest()
        {
            // Arrange
            DevelopersController controller = new DevelopersController();

            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EditTest1()
        {
            // Arrange
            DevelopersController controller = new DevelopersController();

            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            DevelopersController controller = new DevelopersController();

            // Act
            var result = controller.Delete(0);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            // Arrange
            DevelopersController controller = new DevelopersController();

            // Act
            var result = controller.DeleteConfirmed(0);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}