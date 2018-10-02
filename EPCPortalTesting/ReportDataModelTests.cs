using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPCPortalWeb;
using EPCPortalWeb.Models;
using System.Collections.Generic;

namespace EPCPortalTesting
{
    [TestClass]
    public class ReportDataModelTests
    {
        ReportDataModel reportDataModel = new ReportDataModel();
        
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsGreaterThanPotential_ForHeating()
        {
            var current = reportDataModel.CurrHeatingCost = 201;
            var potential = reportDataModel.PotentialHeatingCost = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Heating Costs", current, potential);

            Assert.IsNotNull(reportDataModel.Recommendations);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsGreaterThanPotential_ForC02Emissions()
        {
            var current = reportDataModel.CurrC02Emmissions = 25;
            var potential = reportDataModel.PotentialC02Emmissions = 20;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("C02 Emmissions", current, potential);

            Assert.IsNotNull(reportDataModel.Recommendations);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsGreaterThanPotential_ForHotWater()
        {
            var current = reportDataModel.CurrHotWaterCosts = 201;
            var potential = reportDataModel.PotentialHotWaterCosts = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Hot Water", current, potential);

            Assert.IsNotNull(reportDataModel.Recommendations);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsGreaterThanPotential_ForEnergyConsumption()
        {
            var current = reportDataModel.CurrEnergyConsumption = 201;
            var potential = reportDataModel.PotentialEnergyConsumption = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Energy Consumption", current, potential);

            Assert.IsNotNull(reportDataModel.Recommendations);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsGreaterThanPotential_ForLighting()
        {
            var current = reportDataModel.CurrLightingCosts = 201;
            var potential = reportDataModel.PotentialLightingCosts = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Lighting Costs", current, potential);

            Assert.IsNotNull(reportDataModel.Recommendations);
        }

        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsLessThanPotential_ForHeating()
        {
            var current = reportDataModel.CurrHeatingCost = 100;
            var potential = reportDataModel.PotentialHeatingCost = 201;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Heating Costs", current, potential);

            Assert.IsNull(reportDataModel.Recommendations);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsLessThanPotential_ForC02Emissions()
        {
            var current = reportDataModel.CurrC02Emmissions = 10;
            var potential = reportDataModel.PotentialC02Emmissions = 20;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("C02 Emmissions", current, potential);

            Assert.IsNull(reportDataModel.Recommendations);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsLessThanPotential_ForHotWater()
        {
            var current = reportDataModel.CurrHotWaterCosts = 90;
            var potential = reportDataModel.PotentialHotWaterCosts = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Hot Water", current, potential);

            Assert.IsNull(reportDataModel.Recommendations);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsLEssThanPotential_ForEnergyConsumption()
        {
            var current = reportDataModel.CurrEnergyConsumption = 86;
            var potential = reportDataModel.PotentialEnergyConsumption = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Energy Consumption", current, potential);

            Assert.IsNull(reportDataModel.Recommendations);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsLessThanPotential_ForLighting()
        {
            var current = reportDataModel.CurrLightingCosts = 40;
            var potential = reportDataModel.PotentialLightingCosts = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Lighting Costs", current, potential);

            Assert.IsNull(reportDataModel.Recommendations);
        }

        [TestMethod]
        public void CompareCurrentAndPotentialAlphabeticalValues_WhereTripleGlazingIsNotCurrentlyUsed()
        {
            var current = reportDataModel.CurrGlazingType = "Single";
            var potential = reportDataModel.PotentialGlazingType = "Triple";
            reportDataModel.CompareCurrentAndPotentialAlphabeticalValues("Glazing Type", current, potential);

            Assert.IsNotNull(reportDataModel.Recommendations);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialAlphabeticalValues_WhereTripleGlazingIsCurrentlyUsed()
        {
            var current = reportDataModel.CurrGlazingType = "Triple";
            var potential = reportDataModel.PotentialGlazingType = "Triple";
            reportDataModel.CompareCurrentAndPotentialAlphabeticalValues("Glazing Type", current, potential);

            Assert.IsNull(reportDataModel.Recommendations);
        }
    }
}
