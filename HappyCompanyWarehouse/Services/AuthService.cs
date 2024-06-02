using Blazored.LocalStorage;
using DataModel.Dtos;
using HappyCompanyWarehouse.Interfaces;

namespace HappyCompanyWarehouse.Services
{
    public sealed class AuthService : IAuthService
    {
        private readonly ILocalStorageService _localStorage;

        public AuthService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<UserDto> GetCurrentUserAsync()
        {
            return await _localStorage.GetItemAsync<UserDto>("user");
        }

        public async Task<string> GetCurrentUserTokenAsync()
        {
            var user =  await _localStorage.GetItemAsync<UserDto>("user");
            if (user == null)
            {
                return null;
            }

            return user.Token;
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            string token = await GetCurrentUserTokenAsync();
            return token != null;
        }

        public async Task SetCurrentUserAsync(UserDto user)
        {
            await _localStorage.SetItemAsync("user", user);
        }

        public async Task ClearCurrentUserAsync()
        {
            await _localStorage.RemoveItemAsync("user");
        }
    }
}
