using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Full Name cannot be longer than 100 characters.")]
        public string FullName { get; set; }
        [Required]
        public Byte[] PasswordHash { get; set; }
        [Required]
        public Byte[] PasswordSalt { get; set; }
       
        [Required]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public RoleType RoleType { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
