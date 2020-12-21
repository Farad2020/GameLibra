using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLibra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibra.Models.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void GameTest()
        {
            var game = new Game();
            if (game == null)
                Assert.Fail();
        }
    }

    [TestClass()]
    public class DeveloperTests
    {
        [TestMethod()]
        public void DeveloperTest()
        {
            var dev = new Developer();
            if (dev == null)
                Assert.Fail();
        }
    }
    

    [TestClass()]
    public class GenreTests
    {
        [TestMethod()]
        public void GenreTest()
        {
            var genre = new Genre();
            if (genre == null)
                Assert.Fail();
        }
    }

    [TestClass()]
    public class LibraryTests
    {
        [TestMethod()]
        public void LibraryTest()
        {
            var library = new Library();
            if (library == null)
                Assert.Fail();
        }
    }

    
    [TestClass()]
    public class PublisherTests
    {
        [TestMethod()]
        public void PublisherTest()
        {
            var publisher = new Publisher();
            if (publisher == null)
                Assert.Fail();
        }
    }


    [TestClass()]
    public class Games_and_GenresTests
    {
        [TestMethod()]
        public void Games_and_GenresTest()
        {
            var games_and_genres = new Games_and_Genres();
            if (games_and_genres == null)
                Assert.Fail();
        }
    }
    

    [TestClass()]
    public class Games_and_ImagesTests
    {
        [TestMethod()]
        public void Games_and_ImagesTest()
        {
            var games_and_images = new Games_and_Images();
            if (games_and_images == null)
                Assert.Fail();
        }
    }

    [TestClass()]
    public class Games_and_TrailersTests
    {
        [TestMethod()]
        public void Games_and_TrailersTest()
        {
            var games_and_trailers = new Games_and_Trailers();
            if (games_and_trailers == null)
                Assert.Fail();
        }
    }

    [TestClass()]
    public class Games_and_LibrariesTests
    {
        [TestMethod()]
        public void Games_and_LibrariesTest()
        {
            var games_and_libraries = new Games_and_Libraries();
            if (games_and_libraries == null)
                Assert.Fail();
        }
    }

    

    [TestClass()]
    public class PublishersTests
    {
        [TestMethod()]
        public void PublishersTest()
        {
            var publishers = new Publisher();
            if (publishers == null)
                Assert.Fail();
        }
    }
}