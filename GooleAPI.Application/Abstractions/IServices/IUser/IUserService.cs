
using GoogleAPI.Domain.Entities.User;
using GoogleAPI.Domain.Models.User;
using GoogleAPI.Domain.Models.User.CommandModel;
using GoogleAPI.Domain.Models.User.Filters;
using GoogleAPI.Domain.Models.User.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.IUser
{
    public interface IUserService
    {
        Task<bool> Register(UserRegister_VM model); 
        Task<Token> Login(UserLoginCommandModel model);
        Task<bool> DeleteUser(int Id);
        Task<bool> AddUserAddress(AddUserAddressCommandModel model);
        public Task<bool> Update(UserRegister_VM model);
        Task<bool> UpdateRefreshToken(string refreshToken,DateTime accessTokenDate, int refreshTokenLifeTime, User user);
        
        Task<RefreshTokenCommandResponse> RefreshTokenLogin(string RefreshToken);
         Task<List<UserList_VM>> GetUsers(GetUserFilter? model);


    }
}
