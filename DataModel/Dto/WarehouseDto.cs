
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Dto
{
    public sealed class WarehouseDto
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

    }
}
