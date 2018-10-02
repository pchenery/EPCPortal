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
        public IActionResult Index(DataHandlerModel dataHandlerModel)
        {
            string postcode = dataHandlerModel.Postcode;
            int houseNumber = dataHandlerModel.HouseNumber;
            return View();
        }

        public IActionResult Report(ReportDataModel reportDataModel)
        {
            List<Recommendation> recommendationList = reportDataModel.RecommendationsList;
            //API Call
            reportDataModel.RecommendationsList = new List<Recommendation>();
            //foreach (var item in //apicallreturn)
            //{
            //    recommendationList.Add(item);
            //}
            return View(recommendationList);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
