using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MarlonPolanco_COVID19Report.Models;
using MarlonPolanco_COVID19Report.BL;
using System.Threading.Tasks;

namespace MarlonPolanco_COVID19Report.Controllers
{
    public class Covid19ReportController : Controller
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                RootRegion pRegions = new RootRegion();

                pRegions = await (new Operations()).GetRegios();

                List<SelectListItem> list = new List<SelectListItem>();
                pRegions.data.ForEach(item =>
                {
                    list.Add(new SelectListItem() { Text = item.name, Value = item.iso });
                });

                ViewBag.RegionsCombo = list.OrderBy(p => p.Text);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
            }

            return View();
        }

        public async Task<ActionResult> IndexTable(string pShow, string pIso)
        {
            List<ResponseReport> pResponseReport = new List<ResponseReport>();

            try
            {
                Root pRoot = new Root();
                
                pRoot = await (new Operations()).GetCOVIDReport();

                //GET report data
                if (pIso == "0")
                {
                    //Query for regions
                    ViewBag.IsRegion = "YES";
                    pResponseReport = pRoot.data.GroupBy(p => p.region.iso).Select(item => new ResponseReport
                    {
                        Regions = item.FirstOrDefault().region.name,
                        Cases = item.Sum(p => p.confirmed),
                        Deaths = item.Sum(p => p.deaths)

                    }).OrderByDescending(p => p.Cases).Take(int.Parse(pShow)).ToList();
                }
                else
                {
                    //Query for provinces
                    ViewBag.IsRegion = "NO";
                    pResponseReport = pRoot.data.Where(p => p.region.iso == pIso).Select(item => new ResponseReport
                    {
                        Regions = item.region.province,
                        Cases = item.confirmed,
                        Deaths = item.deaths

                    }).OrderByDescending(p => p.Cases).Take(int.Parse(pShow)).ToList();
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
            }

            return PartialView(pResponseReport);
        }
    }
}