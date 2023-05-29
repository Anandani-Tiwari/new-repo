using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace EFDBFirstApproachExample.Models
{
    [Table("Products",Schema ="dbo")]
    public class Product
    {
        [Key]
        [Display(Name = "Product Id")]
        public long ProductId { get; set; }
        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }
        [Display(Name = " Brand Id")]
        [Required]
        public Nullable<int> BrandId { get; set; }
        [Display(Name = " Category Id")]
        [Required]
        public Nullable<int> CategoryId { get; set; }
        [Column("DateOfPurchase",TypeName="datetime")]
        [Display(Name = "Date Of Purchase")]
        [Required]

        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        [Display(Name = "Availability Status ")]
        public string AvailabilityStatus { get; set; }
        [Display(Name = "Price")]
        [Required]
        public Nullable<decimal> Price { get; set; }
        
        public Nullable<decimal> Quantity { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public string Photo { get; set; }

    }
}