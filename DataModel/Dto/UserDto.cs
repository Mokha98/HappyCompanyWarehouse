
namespace DataModel.Dtos
{
    public sealed class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public int RoleType { get; set; }
        public string RoleName { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
    }
}