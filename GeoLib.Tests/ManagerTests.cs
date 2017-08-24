using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoLib.Data;
using GeoLib.Contracts;
using GeoLib.Services;

namespace GeoLib.Tests
{
  [TestClass]
  public class ManagerTests
  {
    [TestMethod]
    public void test_zip_code_retrieval()
    {
      Mock<IZipCodeRepository> mockZipCodeRepository = new Mock<IZipCodeRepository>();

      ZipCode zipCode = new ZipCode()
      {
        City = "Portland",
        State = new State() { Abbreviation = "OR"},
        Zip = "97035"
      };

      mockZipCodeRepository.Setup(obj => obj.GetByZip("97035")).Returns(zipCode);

      IGeoService geoService = new GeoManager(mockZipCodeRepository.Object);

      ZipCodeData data = geoService.GetZipInfo("97035");

      Assert.IsTrue(data.City.ToUpper() == "PORTLAND");
      Assert.IsTrue(data.State == "OR");
    }
  }
}
