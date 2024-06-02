using DataModel.Dtos;

namespace HappyCompanyWarehouse.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> GetCurrentUserAsync();
        Task SetCurrentUserAsync(UserDto user);
        Task ClearCurrentUserAsync();
        Task<string> GetCurrentUserTokenAsync();
        Task<bool> IsAuthenticatedAsync();
    }
}
