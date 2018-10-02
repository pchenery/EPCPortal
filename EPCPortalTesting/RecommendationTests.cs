using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPCPortalWeb;
using EPCPortalWeb.Models;
using System.Collections.Generic;

namespace EPCPortalTesting
{
    [TestClass]
    public class RecommendationTests
    { 
        [TestMethod]
        public void GetItemCost_WhenItemNameIsHeatingCosts()
        {
            Recommendation recommendation = new Recommendation("Heating Costs");
            Assert.AreEqual(1000.00, recommendation.ItemCost);
        }
        [TestMethod]
        public void GetItemCost_WhenItemNameIsC02Emissions()
        {
            Recommendation recommendation = new Recommendation("C02 Emissions");
            Assert.AreEqual(250.00, recommendation.ItemCost);
        }
        [TestMethod]
        public void GetItemCost_WhenItemNameIsHotWater()
        {
            Recommendation recommendation = new Recommendation("Hot Water");
            Assert.AreEqual(300.00, recommendation.ItemCost);
        }
        [TestMethod]
        public void GetItemCost_WhenItemNameIsEnergyConsumption()
        {
            Recommendation recommendation = new Recommendation("Energy Consumption");
            Assert.AreEqual(200.00, recommendation.ItemCost);
        }
        [TestMethod]
        public void GetItemCost_WhenItemNameIsLightingCosts()
        {
            Recommendation recommendation = new Recommendation("Lighting Costs");
            Assert.AreEqual(50.00, recommendation.ItemCost);
        }
        [TestMethod]
        public void GetItemCost_WhenItemNameIsGlazingType()
        {
            Recommendation recommendation = new Recommendation("Glazing Type");
            Assert.AreEqual(100.00, recommendation.ItemCost);
        }
    }
}
