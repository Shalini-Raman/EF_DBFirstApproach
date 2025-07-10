using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EFDBFirstApproachNew.Models
{
    public class categories
    {
        [Key]
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}