using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public sealed class Warehouse
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Warehouse Name is required.")]
        [StringLength(100, ErrorMessage = "Warehouse Name cannot be longer than 100 characters.")]
        public string WarehouseName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
        public string City { get; set; }

        [Required]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        public ICollection<WarehouseItem> WarehouseItems { get; set; }


    }
}
