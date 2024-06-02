using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public sealed class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
