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
    public class PublishersControllerTests
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [TestMethod()]
        public void IndexTest()
        {
            // Arrange
            PublishersController controller = new PublishersController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Arrange
            PublishersController controller = new PublishersController();

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            PublishersController controller = new PublishersController();

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTest1()
        {
            // Arrange
            PublishersController controller = new PublishersController();

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EditTest()
        {
            // Arrange
            PublishersController controller = new PublishersController();

            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EditTest1()
        {
            // Arrange
            PublishersController controller = new PublishersController();

            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            PublishersController controller = new PublishersController();

            // Act
            var result = controller.Delete(0);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            // Arrange
            PublishersController controller = new PublishersController();

            // Act
            var result = controller.DeleteConfirmed(0);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}