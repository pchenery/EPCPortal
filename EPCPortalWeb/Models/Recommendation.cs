using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPCPortalWeb.Models
{
    public class Recommendation
    {
        public string ItemName { get; set; }
        public double PotentialSaving { get; set; }
        public double ItemCost { get; set; }

        public Recommendation(string itemName)
        {
            ItemName = itemName;

            switch (itemName)
            {
                case "Heating Costs":
                    ItemCost = 1000.00;
                    break;
                case "C02 Emissions":
                    ItemCost = 250.00;
                    break;
                case "Hot Water":
                    ItemCost = 300.00;
                    break;
                case "Energy Consumption":
                    ItemCost = 200.00;
                    break;
                case "Lighting Costs":
                    ItemCost = 50.00;
                    break;
                default:
                    ItemCost = 100.00;
                    break;
            }
        }
    }
}
