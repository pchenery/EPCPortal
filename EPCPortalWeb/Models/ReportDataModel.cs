using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPCPortalWeb.Models
{
    public class ReportDataModel
    {
        // class to structure data returned from the API into usable items for properties and methods

        public double CurrHeatingCost { get; set; }
        public double CurrC02Emmissions { get; set; }
        public double CurrHotWaterCosts { get; set; }
        public double CurrEnergyConsumption { get; set; }
        public double CurrLightingCosts { get; set; }
        public string CurrGlazingType { get; set; }

        public double PotentialHeatingCost { get; set; }
        public double PotentialC02Emmissions { get; set; }
        public double PotentialHotWaterCosts { get; set; }
        public double PotentialEnergyConsumption { get; set; }
        public double PotentialLightingCosts { get; set; }
        public string PotentialGlazingType { get; set; }

        public Dictionary<string,double> Recommendations { get; set; }

        public ReportDataModel()
        {
        }

        public void CompareCurrentAndPotentialAlphabeticalValues (string itemName, string currentValue, string potentialValue)
        {
            if (currentValue != potentialValue)
            {
                double potentialSavings = 0.00;
                AddToRecommendations(itemName, potentialSavings);

            }
        }
        public void CompareCurrentAndPotentialNumericalValues(string itemName, double currentValue, double potentialValue)
        {
            if (currentValue > potentialValue)
            {
                double potentialSavings = GetPotentialSavings(currentValue,potentialValue);
                AddToRecommendations(itemName,potentialSavings);
            }
        }

        private void AddToRecommendations(string itemName, double potentialSavings)
        {
            Dictionary<string, double> recommendations = new Dictionary<string, double>();
            recommendations.Add(itemName, potentialSavings);
            Recommendations = recommendations;
        }

        private double GetPotentialSavings(double currentValue, double potentialValue)
        {
            double potentialSavings = 0;
            potentialSavings = currentValue - potentialValue;
            return potentialSavings;
        }


    }
}
