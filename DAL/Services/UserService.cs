using DAL.Data;
using DAL.Entity;
using DAL.Helper;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;
using DataModel.Dtos;

namespace DAL.Services
{
    public sealed class UserService:IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        // Create
        public async Task<AppUser> AddAsync(AppUser appUser)
        {
            _context.AppUsers.Add(appUser);
            await _context.SaveChangesAsync();
            return appUser;
        }

        // Read
        public async Task<AppUser> GetByIdAsync(int id)
        {
            return await _context.AppUsers
                                 .Include(u => u.RoleType)
                                 .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _context.AppUsers
                                 .Include(u => u.RoleType)
                                 .ToListAsync();
        }

        // Update
        public async Task<AppUser> UpdateAsync(AppUser appUser)
        {
            _context.Entry(appUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return appUser;
        }

        // Delete
        public async Task<AppUser> DeleteAsync(int id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);
            if (appUser != null)
            {
                _context.AppUsers.Remove(appUser);
                await _context.SaveChangesAsync();
            }
            return appUser;
        }

        public async Task<AppUser> GetLogin(LoginDto loginDto)
        {
            var currentUser = await _context.AppUsers.SingleOrDefaultAsync(a => a.Email.Equals(loginDto.Email));

            if (currentUser == null)
            {
                return null;
            }

            bool doesPasswordMatch = DataHelper.doesPasswordMatch(currentUser.PasswordHash, currentUser.PasswordSalt, loginDto.Password);

            if (doesPasswordMatch)
            {
                currentUser.RoleType = await _context.RoleType.FindAsync(currentUser.RoleId);
                return currentUser;
            }

            return null;
        }

        public async Task<bool> ChangePasswordAsync(int userId, string currentPassword,  string newPassword)
        {
            var user = await _context.AppUsers.FindAsync(userId);
            if (user == null)
            {
                return false; // User not found
            }

            // Verify the current password
            if (!DataHelper.doesPasswordMatch(user.PasswordHash, 
                user.PasswordHash, currentPassword))
            {
                return false; // Current password is incorrect
            }

            // Create new password hash and salt
            var newPassHash = DataHelper.GeneratePassHash(newPassword, out byte[] newPassSalt);

            user.PasswordHash = newPassHash;
            user.PasswordSalt = newPassSalt;

            // Update the user
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true; // Password changed successfully
        }

    }
}
