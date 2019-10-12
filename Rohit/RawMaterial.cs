using System;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.Entities
{
    // Developed by Rohit
    /// <summary>
    /// Interface for RawMaterial Entity
    /// </summary>
    public interface IRawMaterial
    {
        Guid RawMaterialID { get; set; }
        string RawMaterialName { get; set; }
        string RawMaterialCode { get; set; }
        double RawMaterialPrice { get; set; }
        DateTime CreationDateTime { get; set; }
        DateTime LastModifiedDateTime { get; set; }
    }

    /// <summary>
    /// Represents RawMaterial
    /// </summary>
    public class RawMaterial : IRawMaterial
    {
        /* Auto-Implemented Properties */
        [Required("Raw Material ID can't be blank.")]
        public Guid RawMaterialID { get; set; }

        [Required("Raw Material Name can't be blank.")]
        [RegExp(@"^(\w{2,30})$", "Raw Material Name should contain only 2 to 30 characters.")]
        public string RawMaterialName { get; set; }

        [Required("Raw Material Code can't be blank.")]
        [RegExp(@"^(\w{2,5})$", "Raw Material Code should contain only 2 to 5 characters.")]
        public string RawMaterialCode { get; set; }

        public double RawMaterialPrice { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }


        /* Constructor to initialize with default values */
        public RawMaterial()
        {
            RawMaterialID = default(Guid);
            RawMaterialName = string.Empty;
            RawMaterialCode = string.Empty;
            RawMaterialPrice = default(double);
            CreationDateTime = default(DateTime);
            LastModifiedDateTime = default(DateTime);
        }
    }
}