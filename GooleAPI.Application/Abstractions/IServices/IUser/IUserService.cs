
using GoogleAPI.Domain.Entities.All_Settings;
using GoogleAPI.Domain.Entities.User;
using GoogleAPI.Domain.Models.Address;
using GoogleAPI.Domain.Models.Brand.ViewModel;
using GoogleAPI.Domain.Models.User;
using GoogleAPI.Domain.Models.User.CommandModel;
using GoogleAPI.Domain.Models.User.Filters;
using GoogleAPI.Domain.Models.User.ResponseModel;
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

        #region BASE
        Task<bool> Register(UserRegister_VM model); 
        Task<UserClientInfoResponse> Login(UserLoginCommandModel model);
        Task<bool> DeleteUser(int Id);
         Task<List<UserList_VM>> GetUsers(GetUserFilter? model);

        #endregion
        #region TOKEN

        public Task<bool> Update(UserRegister_VM model);
        Task<bool> UpdateRefreshToken(string refreshToken,DateTime accessTokenDate, int refreshTokenLifeTime, User user);
        
        Task<UserClientInfoResponse> RefreshTokenLogin(string RefreshToken);
        #endregion
        #region AUTH


        Task<bool> AssignRoleToUserAsync(AssignRoleToUserCommandRequest model);
        Task<List<Role_VM>> GetRolesOfUser(int id);
        Task<bool> HasRolePermissionToEndpointAsync(int id, string code);
        #endregion
        #region USER&ADDRES
        Task<AddUserShippingAddress_ResponseModel> AddShippingAddressToUser(AddUserShippingAddressCommandModel model);
        Task<bool> UpdateShippingAddressToUser(AddUserShippingAddressCommandModel model);
      
        Task<bool> DeleteUserShippingAddress(int shippingAddressId);
        Task<List<UserShippingAddress_VM>> GetUserShippingAddresses(int userId);
        Task<List<UserShippingAddress_VM>> GetUserShippingAddresSingle(int userId);

        #endregion
        #region PASSWORD
        Task SendPasswordResetEmail(string email);
        Task<bool> ConfirmPasswordToken(string passwordToken);
        Task<bool> PasswordReset(PasswordRequest_CM model);

        #endregion
        #region mail
        Task<List<MailInfo>> GetMailInfoById(int id);
        Task<bool> AddMailInfo(MailInfo model);
        Task<bool> UpdateMailInfo(MailInfo model);

        Task<bool> DeleteMailInfo(int id);
        #endregion

    }
}
