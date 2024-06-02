using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class WarehouseItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Item Name is required.")]
        [StringLength(100, ErrorMessage = "Item Name cannot be longer than 100 characters.")]
        public string ItemName { get; set; }

        [StringLength(50, ErrorMessage = "SKU Code cannot be longer than 50 characters.")]
        public string SKUCode { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Qty must be at least 1.")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Cost Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cost Price must be greater than 0.")]
        public decimal CostPrice { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "MSRP Price must be greater than 0.")]
        public decimal? MSRPPrice { get; set; }

        [Required]
        public int WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }
    }
}
