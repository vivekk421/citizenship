using BAL;
using CitizenDataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CitizenShipWeb.Controllers
{
    public class AddressDtlController : Controller
    {
        Business business = new Business();
        // GET: AddressDtl
        public ActionResult Index()
        {
            List<Address_Details> address = new List<Address_Details>();
            address = business.GetAllAddress();
            return View(address);
        }

        public ActionResult AddAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAddress(Address_Details add_Details)
        {
            business.InsertAddressData(add_Details);
            return View();
        }

        public ActionResult EditAddress(Int32? Address_ID)
        {
            if (Address_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address_Details info = business.GetAddress(Address_ID);
            if (info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }


        public ActionResult UpdateAddressDtls(Address_Details addres_Dtls)
        {
            business.UpdateAddress(addres_Dtls);
            return RedirectToAction("Index", "Employee");
        }

    }
}