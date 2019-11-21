using System.ComponentModel.DataAnnotations;

namespace Inventory.Mvc.Models
{
    // Developed by Rohit Kumar (Group 4)
    // Creation Date : 2019/10/24
    // Last Modified Date : 2019/10/25

    public class RawMaterialViewModel
    {
        //Properties
        public System.Guid RawMaterialID { get; set; }

        [Required(ErrorMessage = "Raw Material Name can't be blank")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Name should contain alphabets only")]
        [MinLength(3, ErrorMessage = "Name should contain atleast 3 alphabets")]
        [MaxLength(30, ErrorMessage = "Name cannot contain more than 30 alphabets")]
        public string RawMaterialName { get; set; }

        [Required(ErrorMessage = "Raw Material Code can't be blank")]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Code should contain alphabets only without spaces")]
        [MinLength(3, ErrorMessage = "Code should contain atleast 3 alphabets")]
        [MaxLength(30, ErrorMessage = "Code cannot contain more than 30 alphabets")]
        public string RawMaterialCode { get; set; }

        [Required(ErrorMessage = "Price can't be blank")]
        [Range(0.99, 100000, ErrorMessage = "Price should be between 0.99 and 100000")]
        public decimal? RawMaterialUnitPrice { get; set; }
    }
}