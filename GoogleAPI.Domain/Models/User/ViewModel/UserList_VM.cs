namespace GoogleAPI.Domain.Models.User.ViewModel
{
    public class UserList_VM
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? RoleName { get; set; }
        public bool? SubscribeToPromotions { get; set; }
    }
}
