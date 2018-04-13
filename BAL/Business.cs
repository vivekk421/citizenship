using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenDataAccessLayer.Entity;

namespace BAL
{
    public class Business
    {
        CitizenShipEntities db = null;

        public Business()
        {
            db = new CitizenShipEntities();
        }

        //public List<Address_Details> GetAllAddress()
        //{
        //    return db.Address_Details.ToList();
        //}

        public List<Citizen> GetAllCitizens()
        {
            return db.Citizens.ToList();
        }

        //public void InsertAddressData(Address_Details Add_details)
        //{
        //    db.Address_Details.Add(Add_details);
        //    db.SaveChanges();
        //}

        public void InsertCitizenData(Citizen citizen)
        {
            citizen.Created_Date = DateTime.Now;
            citizen.Updated_Date = DateTime.Now;
            db.Citizens.Add(citizen);
            db.SaveChanges();
        }

        public Citizen GetCitizenById(int id)
        {
            Citizen citizen = db.Citizens.FirstOrDefault(d => d.Citizens_ID == id);
            return citizen;
        }

        public void DeleteCitizenById(int id)
        {
            Citizen citizen = db.Citizens.FirstOrDefault(d => d.Citizens_ID == id);
            db.Citizens.Remove(citizen);
            db.SaveChanges();
        }

        public void UpdateCitizenData(Citizen citizen)
        {
            var oldcitizen = db.Citizens.FirstOrDefault(d => d.Citizens_ID == citizen.Citizens_ID);
            
            oldcitizen.Name = citizen.Name;
            oldcitizen.Occupation = citizen.Occupation;
            oldcitizen.Father_Name = citizen.Father_Name;
            oldcitizen.DOB = citizen.DOB;
            oldcitizen.Updated_Date = DateTime.Now;
            oldcitizen.Address_Details.Address_Line1 = citizen.Address_Details.Address_Line1;
            oldcitizen.Address_Details.Address_Line2 = citizen.Address_Details.Address_Line2;
            oldcitizen.Address_Details.City = citizen.Address_Details.City;
            oldcitizen.Address_Details.Country = citizen.Address_Details.Country;
            oldcitizen.Address_Details.Pin_Code = citizen.Address_Details.Pin_Code;
            db.SaveChanges();
        }


        //public Address_Details GetAddress(Int32? id)
        //{
        //    Address_Details address = db.Address_Details.Find(id);
        //    return address;
        //}

        //public void UpdateAddress(Address_Details Add_details)
        //{
        //    var oldAddressdtls = db.Address_Details.FirstOrDefault(d => d.Address_Details_ID == Add_details.Address_Details_ID);
        //    oldAddressdtls.Address_Line1 = Add_details.Address_Line1;
        //    oldAddressdtls.Address_Line2 = Add_details.Address_Line2;
        //    oldAddressdtls.City = Add_details.City;
        //    oldAddressdtls.Pin_Code = Add_details.Pin_Code;
        //    oldAddressdtls.Updated_Date = DateTime.Now;
        //    oldAddressdtls.Country = Add_details.Country;
        //    db.SaveChanges();
        //}
    }
}