using DAL.Entity;
using System.Security.Cryptography;
using System.Text;

namespace DAL.Helper
{
    public static class DataHelper
    {
        public static Byte[] GeneratePassHash(string password, out Byte[] salt)
        {

            using var hmac = new HMACSHA512();

            Byte[] hashedPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            salt = hmac.Key;

            return hashedPass;
        }

        public static bool doesPasswordMatch(byte[] userPass, byte[] userSalt, string inputPass)
        {

            if (string.IsNullOrWhiteSpace(inputPass))
            {
                return false;
            }
           

            using var hmac = new HMACSHA512(userSalt);

            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(inputPass));

            int passHashLength = passwordHash.Length;

            for (int i = 0; i < passHashLength; i++)
            {
                if (passwordHash[i] != userPass[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static IEnumerable<RoleType> GetRoleTypes()
        {

            List<RoleType> roles =
            [
                new RoleType { Id = 1, Name = "Admin" },
                new RoleType { Id = 2, Name = "Management" },
                new RoleType { Id = 3, Name = "Auditor" },
            ];

            return roles;
        }

        public static IEnumerable<Country> GetCountries()
        {

            List<Country> countries =
            [
                new Country { Id = 1, Name = "Jordan" },
                new Country { Id = 2, Name = "Palestine" },
                new Country { Id = 3, Name = "Egypt" },
                new Country { Id = 4, Name = "UAE" },
                new Country { Id = 5, Name = "Saudi Arabia" },
            ];

            return countries;
        }

        public static AppUser GetDefaultUser()
        {

            string password = "P@ssw0rd";

            Byte[] hashedPass = GeneratePassHash(password, out Byte[] salt);

            var user = new AppUser
            {
                Id = 1,
                Email = "admin@happywarehouse.com",
                PasswordHash = hashedPass,
                PasswordSalt = salt,
                FullName = "Admin User",
                IsActive = true,
                RoleId = 1,

            };


            return user;
        }
    }
}
