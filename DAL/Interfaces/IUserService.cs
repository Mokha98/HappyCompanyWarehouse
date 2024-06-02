
using DAL.Entity;
using DataModel.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DAL.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> AddAsync(AppUser appUser);
        Task<AppUser> GetByIdAsync(int id);
        Task<IEnumerable<AppUser>> GetAllAsync();
        Task<AppUser> UpdateAsync(AppUser appUser);
        Task<AppUser> DeleteAsync(int id);
        Task<AppUser> GetLogin(LoginDto loginDto);
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
    }
}
