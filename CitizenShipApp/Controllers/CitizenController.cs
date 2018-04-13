using BAL;
using CitizenDataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CitizenShipApp.Controllers
{
    public class CitizenController : Controller
    {
        Business business = null;


        public ActionResult AddNewCitizen()
        {
            return View("FillCitizenData", new CitizenShipWeb.Models.CitizenModel());
        }

        public ActionResult EditCitizen(int Citizen_ID)
        {
            business = new Business();
            Citizen citizen = business.GetCitizenById(Citizen_ID);
            CitizenShipWeb.Models.CitizenModel citizenModel = new CitizenShipWeb.Models.CitizenModel();

            return View("FillCitizenData", citizen);
        }

        public ActionResult DeleteCitizen(int Citizen_ID)
        {
            business = new Business();
            business.DeleteCitizenById(Citizen_ID);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveCitizens(Citizen citizen)
        {
            business = new Business();
            if (citizen.Citizens_ID == 0)
            {
                //Insert.
                business.InsertCitizenData(citizen);
            }
            else
            {
                //Update
                business.UpdateCitizenData(citizen);
            }
            return RedirectToAction("Index");
        }

        //----------------------------------------------
        //---------------------------------------

        // GRID
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCitizensdata()
        {
            business = new Business();
            List<Citizen> citizens = new List<Citizen>();
            citizens = business.GetAllCitizens();

            Data data = new Data();
            data.status = "success";
            data.total = citizens.Count;
            data.records = citizens;
            return new JsonResult() { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        internal class Data
        {
            public string status { get; set; } // Status of operation
            public int total { get; set; } // total number of records
            public List<Citizen> records { get; set; } //records
        }

    }
}