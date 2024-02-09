using GoogleAPI.Domain.Models.User.ViewModel;

namespace GoogleAPI.Domain.Models.User
{
    public class UserRegister_VM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool? SubscribeToPromotions { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public List<Role_VM>? Roles { get; set; }
        //public UserCommunicationInfo_VM UserCommunicationInfo { get; set; }

    }
}
