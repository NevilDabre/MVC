//<!-- Neville Dabre & Moonsun Choi-->

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingMall.Models
{
    public class ShoppingCart
    {
        public int id { get; set; }
        
        public int shirt { get; set; }
        
        public int watch { get; set; }
       
        public int camera { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int phoneNumber { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string address { get; set; }

        [Required]
        public string postalCode { get; set; }
        [Required]
        public string provience { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double deliveryCost { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double total { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double tax { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double finalCost { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime deliveryDate { get; set; }
    }


}