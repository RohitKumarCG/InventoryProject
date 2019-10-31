using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Mvc.Models
{
    // Developed by Rohit Kumar (Group 4)
    // Creation Date : 2019/10/24
    // Last Modified Date : 

    public class ProductViewModel
    {
        //Properties
        public System.Guid ProductID { get; set; }

        [Required(ErrorMessage ="Product Name can't be blank")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage ="Product Name should contain alphabets only" )]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product Code can't be blank")]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Product Code should contain alphabets only without spaces")]
        public string ProductCode { get; set; }

        public string ProductType { get; set; }

        [Required(ErrorMessage = "Price can't be blank")]
        [Range(0.99, 100000, ErrorMessage = "Price should be between 0.99 and 100000")]
        public double? ProductUnitPrice { get; set; }
    }
}