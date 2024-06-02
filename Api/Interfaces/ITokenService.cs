using DataModel.Dtos;


namespace Api.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(LoginDto loginUser);
    }
}