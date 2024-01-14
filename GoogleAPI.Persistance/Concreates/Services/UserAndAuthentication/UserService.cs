using GoogleAPI.Domain.Entities.User;
using GoogleAPI.Domain.Models.User;
using GoogleAPI.Domain.Models.User.CommandModel;
using GoogleAPI.Domain.Models.User.Filters;
using GoogleAPI.Domain.Models.User.ResponseModel;
using GoogleAPI.Domain.Models.User.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.IAuthentication;
using GooleAPI.Application.Abstractions.IServices.IOrder;
using GooleAPI.Application.Abstractions.IServices.IUser;
using GooleAPI.Application.IRepositories;
using GooleAPI.Application.IRepositories.UserAndCommunication;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ZXing.Aztec.Internal;
using Token = GoogleAPI.Domain.Models.User.Token;

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
        private readonly IEndpointReadRepository _endpointReadRepository;
        private readonly IOrderService _orderService;

        private readonly string ErrorTextBase = "İstek Sırasında Hata Oluştu: ";

        public UserService(
            GooleAPIDbContext context,
            IUserWriteRepository userWriteRepository,
            IUserReadRepository userReadRepository,
            ITokenService tokenService,
            IOrderService orderService,
            IAddressWriteRepository addressWriteRepository,
            IAddressReadRepository addressReadRepository, IEndpointReadRepository err

        )
        {
            _context = context;
            _uw = userWriteRepository;
            _ur = userReadRepository;
            _ts = tokenService;
            _aw = addressWriteRepository;
            _ar = addressReadRepository;
            _endpointReadRepository = err;
            _orderService = orderService;
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

        public async Task<UserClientInfoResponse> Login(UserLoginCommandModel model)
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
                                    UserClientInfoResponse userClientInfoResponse = new UserClientInfoResponse();
                                    userClientInfoResponse.Token = token;
                                    userClientInfoResponse.UserId = user.Id;
                                    userClientInfoResponse.Mail = user.Email;
                                    userClientInfoResponse.BasketId = await _orderService.GetBasket(user.Id);
                                    return userClientInfoResponse;
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
                                    UserClientInfoResponse userClientInfoResponse = new UserClientInfoResponse();
                                    userClientInfoResponse.Token = token;
                                    userClientInfoResponse.UserId = user2.Id;
                                    userClientInfoResponse.Mail = user2.Email;
                                    userClientInfoResponse.BasketId = await _orderService.GetBasket(user2.Id);
                                    return userClientInfoResponse;
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
                User? checkUserById = _context.Users?.FirstOrDefault(u => u.PhoneNumber == model.PhoneNumber);

                User? checkUserByEmail = _context.Users?.FirstOrDefault(u => u.Email == model.Email);
                if (checkUserById != null)
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


                    bool response = await _uw.AddAsync(user);

                    if (response)
                    {
                        User _user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                        if (model.Roles != null)
                        {
                            foreach (var role in model.Roles)
                            {
                                await _context.RoleUsers.AddAsync(new() { UserId = _user.Id, RoleId = role.Id });
                            }
                            _context.SaveChanges();

                        }
                        else
                        {
                            await _context.RoleUsers.AddAsync(new() { UserId = _user.Id, RoleId = 2 }); //Customer
                            _context.SaveChanges();
                        }

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
                User? checkUserById = _context.Users?.FirstOrDefault(u => u.Id == model.Id);

                //User? checkUserByEmail = _context.Users?.FirstOrDefault(u => u.Email == model.Email);
                if (checkUserById != null)
                {


                    checkUserById.FirstName = model.FirstName;
                    checkUserById.LastName = model.LastName;
                    checkUserById.Password = model.Password;
                    checkUserById.PhoneNumber = model.PhoneNumber;
                    checkUserById.Email = model.Email;
                    checkUserById.SubscribeToPromotions = model.SubscribeToPromotions;
                    checkUserById.ShippingAddresses = null;
                    List<RoleUser>? roleUsers = await _context.RoleUsers.Where(ru => ru.UserId == model.Id).ToListAsync();
                    if (roleUsers != null)
                    {

                        _context.RoleUsers.RemoveRange(roleUsers);
                        _context.SaveChanges();

                        foreach (Role_VM role in model.Roles)
                        {
                            RoleUser roleUser = new RoleUser();
                            roleUser.UserId = model.Id;
                            roleUser.RoleId = role.Id;
                            await _context.RoleUsers.AddAsync(roleUser);
                        }
                        _context.SaveChanges();

                    }
                    else
                    {
                        await _context.RoleUsers.AddAsync(new() { RoleId = 2, UserId = model.Id });
                        _context.SaveChanges();
                    }

                    bool response = await _uw.Update(checkUserById);

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

        public async Task<UserClientInfoResponse> RefreshTokenLogin(string RefreshToken)
        {
            RefreshTokenCommandResponse response = new();
            UserClientInfoResponse _response = new();
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
         
                _response.RefreshTokenCommandResponse = response;
                _response.UserId = user.Id;
                _response.Mail = user.Email;
                _response.BasketId = await _orderService.GetBasket(user.Id);
                _response.Token = token;
            }
            else
            {
                response.State = false;
                response.Token = null;
                _response.RefreshTokenCommandResponse = null;
                _response.UserId = user.Id;
                _response.Mail = user.Email;
                _response.BasketId = await _orderService.GetBasket(user.Id);
                _response.Token = null;
            }

            return _response;
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
                RoleName = _context.Roles.FirstOrDefault(r => r.Id == _context.RoleUsers.FirstOrDefault(ru => ru.UserId == u.Id).RoleId)?.RoleName

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

        public async Task<bool> AssignRoleToUserAsync(AssignRoleToUserCommandRequest model)
        {
            User? user = await _ur.GetByIdAsync(model.UserId);
            if (user != null)
            {
                List<RoleUser>? roleUsers = await _context.RoleUsers.Where(ru => ru.UserId == model.UserId).ToListAsync();
                if (roleUsers != null)
                {

                    _context.RoleUsers.RemoveRange(roleUsers);
                    _context.SaveChanges();

                    foreach (Role_VM role in model.Roles)
                    {
                        RoleUser roleUser = new RoleUser();
                        roleUser.UserId = model.UserId;
                        roleUser.RoleId = role.Id;
                        await _context.RoleUsers.AddAsync(roleUser);
                    }
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public async Task<List<Role_VM>> GetRolesOfUser(int id)
        {
            User? user = await _ur.GetByIdAsync(id);
            if (user != null)
            {
                List<RoleUser>? roleUsers = await _context.RoleUsers.Where(ru => ru.UserId == id).ToListAsync();
                if (roleUsers != null)
                {

                    List<Role_VM> roleList = new List<Role_VM>();


                    foreach (RoleUser role in roleUsers)
                    {
                        GoogleAPI.Domain.Entities.User.Role _role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == role.RoleId);
                        Role_VM _role_VM = new Role_VM();
                        _role_VM.Id = _role.Id;
                        _role_VM.RoleName = _role.RoleName;
                        roleList.Add(_role_VM);
                    }

                    return roleList;
                }
            }
            return null;
        }

        public async Task<bool> HasRolePermissionToEndpointAsync(int id, string code)
        {
            var userRoles = await GetRolesOfUser(id);

            if (!userRoles.Any())
                return false;

            Domain.Entities.Endpoint? endpoint = await _endpointReadRepository.Table
                     .Include(e => e.Roles)
                     .FirstOrDefaultAsync(e => e.Code == code);

            if (endpoint == null)
                return false;
            var endpointRoles = endpoint.Roles.Select(r => r.RoleName);


            foreach (var userRole in userRoles)
            {
                foreach (var endpointRole in endpointRoles)
                    if (userRole.RoleName == endpointRole)
                        return true;
            }

            return false;
        }
    }


}
