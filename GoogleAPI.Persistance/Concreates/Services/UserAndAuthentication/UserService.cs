
using GoogleAPI.Domain.Entities.User;
using GoogleAPI.Domain.Models.User;
using GoogleAPI.Domain.Models.User.CommandModel;
using GoogleAPI.Domain.Models.User.Filters;
using GoogleAPI.Domain.Models.User.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.IAuthentication;
using GooleAPI.Application.Abstractions.IServices.IUser;
using GooleAPI.Application.IRepositories.UserAndCommunication;
using Microsoft.EntityFrameworkCore;

namespace GoogleAPI.Persistance.Concreates.Services.UserAndAuthentication
{
    public class UserService : IUserService
    {
        private readonly GooleAPIDbContext _context;
        private readonly IUserWriteRepository _uw;
        private readonly IUserReadRepository _ur;
        private readonly IAddressWriteRepository _aw;
        private readonly IAddressReadRepository _ar;
        private readonly ITokenService _ts;

        private readonly string ErrorTextBase = "İstek Sırasında Hata Oluştu: ";

        public UserService(
            GooleAPIDbContext context,
            IUserWriteRepository userWriteRepository,
            IUserReadRepository userReadRepository,
            ITokenService tokenService,

            IAddressWriteRepository addressWriteRepository,
            IAddressReadRepository addressReadRepository
        )
        {
            _context = context;
            _uw = userWriteRepository;
            _ur = userReadRepository;
            _ts = tokenService;
            _aw = addressWriteRepository;
            _ar = addressReadRepository;
        }
        public async Task<bool> DeleteUser(int Id)
        {
            try
            {
                User user = await _ur.GetByIdAsync(Id);
                bool response = _uw.Remove(user);
                return response;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Token> Login(UserLoginCommandModel model)
        {

            User? user = new User();
            User? user2 = new User();
            try
            {
                user = _context.Users.FirstOrDefault(u => u.PhoneNumber == model.PhoneNumberOrEmail && u.Password == model.Password);

                user2 = _context.Users.FirstOrDefault(u => u.Email == model.PhoneNumberOrEmail && u.Password == model.Password);

                if (user != null || user2 != null)
                {

                    if (user != null)
                    {
                        if (user.Password == model.Password)
                        {
                            Token? token = await _ts.CreateAccsessToken(120, user);
                            if (token.RefreshToken != null)
                            {
                                bool response = await UpdateRefreshToken(token.RefreshToken, token.Expiration, 30, user);

                                if (response)
                                {

                                    return token;
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    else if (user2 != null)
                    {
                        if (user2.Password == model.Password)
                        {
                            Token? token = await _ts.CreateAccsessToken(120, user2);
                            if (token.RefreshToken != null)
                            {
                                bool response = await UpdateRefreshToken(token.RefreshToken, token.Expiration, 30, user2);

                                if (response)
                                {

                                    return token;
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> AddUserAddress(AddUserAddressCommandModel model)
        {
            try
            {
                ShippingAddress address = new();

                address.AddressTitle = model.AddressTitle;
                address.AddressName = model.AddressName;
                address.Country = model.Country;
                address.City = model.City;
                address.District = model.District;
                address.AddressName = model.AddressName;
                address.AddressDescription = model.AddressDescription;
                address.RowGuid = Guid.NewGuid();

                address.CreatedDate = model.CreatedDate;
                address.UpdatedDate = model.UpdatedDate;

                address.UserId = model.UserId;
                bool response = await _aw.AddAsync(address);
                if (response)
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> Register(UserRegister_VM model)
        {
            try
            {
                User? checkUserByPhoneNumber = _context.Users?.FirstOrDefault(u => u.PhoneNumber == model.PhoneNumber);

                User? checkUserByEmail = _context.Users?.FirstOrDefault(u => u.Email == model.Email);
                if (checkUserByPhoneNumber != null)
                {
                    throw new Exception("Bu Telefon Numarasına Ait Kullanıcı Bulunmaktadır");
                }
                else if (checkUserByEmail != null)
                {
                    throw new Exception("Bu Mail Adresine Ait Kullanıcı Bulunmaktadır");
                }
                else
                {
                    User user = new User();

                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Password = model.Password;
                    user.PhoneNumber = model.PhoneNumber;
                    user.Email = model.Email;
                    user.SubscribeToPromotions = model.SubscribeToPromotions;
                    user.ShippingAddresses = null;
                    user.RoleId = model.RoleId;

                    bool response = await _uw.AddAsync(user);
                    if (response)
                    {
                        Token token = await _ts.CreateAccsessToken(120, user);
                        if (token.RefreshToken != null)
                        {
                            await UpdateRefreshToken(token.RefreshToken, token.Expiration, 30, user);

                        }

                    }
                    return response;
                    ;
                }

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<bool> Update(UserRegister_VM model)
        {
            try
            {
                User? checkUserByPhoneNumber = _context.Users?.FirstOrDefault(u => u.Id == model.Id);

                User? checkUserByEmail = _context.Users?.FirstOrDefault(u => u.Email == model.Email);
                if (checkUserByPhoneNumber != null)
                {


                    checkUserByPhoneNumber.FirstName = model.FirstName;
                    checkUserByPhoneNumber.LastName = model.LastName;
                    checkUserByPhoneNumber.Password = model.Password;
                    checkUserByPhoneNumber.PhoneNumber = model.PhoneNumber;
                    checkUserByPhoneNumber.Email = model.Email;
                    checkUserByPhoneNumber.SubscribeToPromotions = model.SubscribeToPromotions;
                    checkUserByPhoneNumber.ShippingAddresses = null;
                    checkUserByPhoneNumber.RoleId = model.RoleId;

                    bool response = await _uw.Update(checkUserByPhoneNumber);

                    return response;

                }

                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;

            }
        }

        public async Task<bool> UpdateRefreshToken(string refreshToken, DateTime accessTokenDate, int refreshTokenLifeTime, User user)
        {

            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddMinutes(refreshTokenLifeTime);
                var isUpdated = await _uw.Update(user);
                if (isUpdated == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<RefreshTokenCommandResponse> RefreshTokenLogin(string RefreshToken)
        {
            RefreshTokenCommandResponse response = new();
            User? user = await _ur.Table.FirstOrDefaultAsync(
                u => u.RefreshToken == RefreshToken
            );
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = await _ts.CreateAccsessToken(120, user);
                if (token.RefreshToken != null)
                    await UpdateRefreshToken(
                        token.RefreshToken, token.Expiration, 30, user
                    );
                response.State = true;
                response.Token = token;
                response.Token.RefreshToken = token.RefreshToken;
            }
            else
            {
                response.State = false;
                response.Token = null;
            }

            return response;
        }

        public async Task<List<UserList_VM>> GetUsers(GetUserFilter? model)
        {
            List<UserList_VM> user_VMs = new List<UserList_VM>();

            List<User> users = new List<User>();

            IQueryable<User> q = _ur.Table.AsQueryable();
            List<Domain.Entities.User.Role> roles = new List<Domain.Entities.User.Role>();
            roles = await _context.Roles.ToListAsync();


            if (!string.IsNullOrEmpty(model.FirstName))
            {
                q = q.Where(u => u.FirstName.Contains(model.FirstName));
            }
            if (!string.IsNullOrEmpty(model.LastName))
            {
                q = q.Where(u => u.LastName.Contains(model.LastName));

            }
            if (model.Id != 0)
            {
                q = q.Where(u => u.Id == model.Id);
            }

            users = await q.ToListAsync();

            user_VMs = users.Select(u => new UserList_VM
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password,
                PhoneNumber = u.PhoneNumber,
                SubscribeToPromotions = u.SubscribeToPromotions,
                RoleName = roles.FirstOrDefault(r => r.Id == u.RoleId).RoleName


            }).Take(model.Count).ToList();




            if (user_VMs != null)
            {
                return user_VMs;

            }
            else
            {
                return null;
            }
        }
    }
}