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
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsGreaterThanPotential_ForHeating_RecommendationsListNotNull()
        {
            var current = reportDataModel.CurrentHeatingCost = 201;
            var potential = reportDataModel.PotentialHeatingCost = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Heating Costs", current, potential);

            Assert.IsNotNull(reportDataModel.RecommendationsList);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsGreaterThanPotential_ForC02Emissions_RecommendationsListNotNull()
        {
            var current = reportDataModel.CurrentC02Emmissions = 25;
            var potential = reportDataModel.PotentialC02Emmissions = 20;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("C02 Emmissions", current, potential);

            Assert.IsNotNull(reportDataModel.RecommendationsList);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsGreaterThanPotential_ForHotWater_RecommendationsListNotNull()
        {
            var current = reportDataModel.CurrentHotWaterCosts = 201;
            var potential = reportDataModel.PotentialHotWaterCosts = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Hot Water", current, potential);

            Assert.IsNotNull(reportDataModel.RecommendationsList);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsGreaterThanPotential_ForEnergyConsumption_RecommendationsListNotNull()
        {
            var current = reportDataModel.CurrentEnergyConsumption = 201;
            var potential = reportDataModel.PotentialEnergyConsumption = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Energy Consumption", current, potential);

            Assert.IsNotNull(reportDataModel.RecommendationsList);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsGreaterThanPotential_ForLighting_RecommendationsListNotNull()
        {
            var current = reportDataModel.CurrentLightingCosts = 201;
            var potential = reportDataModel.PotentialLightingCosts = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Lighting Costs", current, potential);

            Assert.IsNotNull(reportDataModel.RecommendationsList);
        }

        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsLessThanPotential_ForHeating_RecommendationsListNull()
        {
            var current = reportDataModel.CurrentHeatingCost = 100;
            var potential = reportDataModel.PotentialHeatingCost = 201;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Heating Costs", current, potential);

            Assert.IsNull(reportDataModel.RecommendationsList);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsLessThanPotential_ForC02Emissions_RecommendationsListNull()
        {
            var current = reportDataModel.CurrentC02Emmissions = 10;
            var potential = reportDataModel.PotentialC02Emmissions = 20;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("C02 Emmissions", current, potential);

            Assert.IsNull(reportDataModel.RecommendationsList);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsLessThanPotential_ForHotWater_RecommendationsListNull()
        {
            var current = reportDataModel.CurrentHotWaterCosts = 90;
            var potential = reportDataModel.PotentialHotWaterCosts = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Hot Water", current, potential);

            Assert.IsNull(reportDataModel.RecommendationsList);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsLEssThanPotential_ForEnergyConsumption_RecommendationsListNull()
        {
            var current = reportDataModel.CurrentEnergyConsumption = 86;
            var potential = reportDataModel.PotentialEnergyConsumption = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Energy Consumption", current, potential);

            Assert.IsNull(reportDataModel.RecommendationsList);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialNumericalValues_WhereCurrentIsLessThanPotential_ForLighting_RecommendationsListNull()
        {
            var current = reportDataModel.CurrentLightingCosts = 40;
            var potential = reportDataModel.PotentialLightingCosts = 100;
            reportDataModel.CompareCurrentAndPotentialNumericalValues("Lighting Costs", current, potential);

            Assert.IsNull(reportDataModel.RecommendationsList);
        }

        [TestMethod]
        public void CompareCurrentAndPotentialAlphabeticalValues_WhereTripleGlazingIsNotCurrentlyUsed_RecommendationsListNotNull()
        {
            var current = reportDataModel.CurrentGlazingType = "Single";
            var potential = reportDataModel.PotentialGlazingType = "Triple";
            reportDataModel.CompareCurrentAndPotentialAlphabeticalValues("Glazing Type", current, potential);

            Assert.IsNotNull(reportDataModel.RecommendationsList);
        }
        [TestMethod]
        public void CompareCurrentAndPotentialAlphabeticalValues_WhereTripleGlazingIsCurrentlyUsed_RecommendationsListNull()
        {
            var current = reportDataModel.CurrentGlazingType = "Triple";
            var potential = reportDataModel.PotentialGlazingType = "Triple";
            reportDataModel.CompareCurrentAndPotentialAlphabeticalValues("Glazing Type", current, potential);

            Assert.IsNull(reportDataModel.RecommendationsList);
        }
    }
}
