namespace GoogleAPI.Domain.Models.User.CommandModel
{
    public class UserLoginCommandModel
    {

        public string PhoneNumberOrEmail { get; set; }
        public string Password { get; set; }
    }
}
