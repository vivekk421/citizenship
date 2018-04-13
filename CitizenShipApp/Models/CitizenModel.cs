using CitizenDataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CitizenShipWeb.Models
{
    public class CitizenModel
    {
        public string Name { get; set; }
        public string Father_Name { get; set; }
        public string Occupation { get; set; }
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DOB { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Created_Date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Updated_Date { get; set; }
        public int Citizens_ID { get; set; }
        public Nullable<int> Address_Details_ID { get; set; }

        public virtual Address_Details Address_Details { get; set; }

    }
}