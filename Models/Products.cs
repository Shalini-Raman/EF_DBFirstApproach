using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EFDBFirstApproachNew.Models
{
    [Table("Products",Schema ="dbo")]
    public class Products
    {
        [Key]
        [Display(Name ="Product ID")]
        public long ProductID { get; set; }
        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }
        [Display(Name = "Product Price")]
        [Required]
        public Nullable<decimal> Price { get; set; }
        [Column("DateOfPurchase", TypeName = "datetime")]
        [Display(Name = "Date Of Purchase")]
        public Nullable<System.DateTime> DOP { get; set; }
        public string AvailabilityStatus { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> active { get; set; }
        public string Photo { get; set; }

        public Nullable<decimal> ProductQuantity { get; set; }
        public Nullable<decimal> Quantity { get; set; }

        public Nullable<int> AllowedInBilling { get; set; }
        public virtual Brands Brand { get; set; }
        public virtual categories category { get; set; }
    }
}