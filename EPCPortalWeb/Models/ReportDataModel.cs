using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPCPortalWeb.Models
{
    public class ReportDataModel
    {
        // class to structure data returned from the API into usable items for properties and methods

        public double CurrentHeatingCost { get; set; }
        public double CurrentC02Emmissions { get; set; }
        public double CurrentHotWaterCosts { get; set; }
        public double CurrentEnergyConsumption { get; set; }
        public double CurrentLightingCosts { get; set; }
        public string CurrentGlazingType { get; set; }

        public double PotentialHeatingCost { get; set; }
        public double PotentialC02Emmissions { get; set; }
        public double PotentialHotWaterCosts { get; set; }
        public double PotentialEnergyConsumption { get; set; }
        public double PotentialLightingCosts { get; set; }
        public string PotentialGlazingType { get; set; }

        public List<Recommendation> RecommendationsList { get; set; }
        

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
            Recommendation recommendation = new Recommendation(itemName);
            recommendation.ItemName = itemName;
            recommendation.PotentialSaving = potentialSavings;
            
        }

        private double GetPotentialSavings(double currentValue, double potentialValue)
        {
            double potentialSavings = 0;
            potentialSavings = currentValue - potentialValue;
            return potentialSavings;
        }


    }
}
