using System.ComponentModel.DataAnnotations;

namespace DataModel.Dtos
{
    public sealed class LoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
