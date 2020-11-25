using NUnit.Framework;
using System;
using System.Web;
using WSRebels;

namespace UnitTestRebels
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRegisterString()
        {
            //Arrange
            string name = "Luke";
            string planet = "Hoth";

            string ResultEsperado= "rebel Luke on planet Hoth at " +DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //Act
            WSRebels.Register calculator = new WSRebels.Register();
            string Result = calculator.CreateRegisterString(name, planet);
            
            //Assert
            Assert.AreEqual(ResultEsperado, Result);
        }
    }
}