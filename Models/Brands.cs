using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EFDBFirstApproachNew.Models
{
    public class Brands
    {
         [Key]
        public long BrandID { get; set; }
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
    }
}