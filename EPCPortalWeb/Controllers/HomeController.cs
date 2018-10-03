using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EPCPortalWeb.Models;

namespace EPCPortalWeb.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index(DataHandlerModel dataHandlerModel)
        {
            if (dataHandlerModel.Postcode != null)
            {
               await dataHandlerModel.GetListOfProperties(); 
            }
            
            return View(dataHandlerModel);
        }
        public IActionResult Report()
        {
            ReportDataModel reportDataModel = new ReportDataModel();
            var current = reportDataModel.CurrentC02Emmissions = 12;
            var potential = reportDataModel.PotentialC02Emmissions = 10;

            reportDataModel.CompareCurrentAndPotentialNumericalValues("C02 Emissions", current, potential);
           List<Recommendation> recommendationList = reportDataModel.RecommendationsList;
           
            return View(recommendationList);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
