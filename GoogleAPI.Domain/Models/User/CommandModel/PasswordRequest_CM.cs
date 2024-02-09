namespace GoogleAPI.Domain.Models.User.CommandModel
{
    public class PasswordRequest_CM
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
        public int UserId { get; set; }
        public string PasswordToken { get; set; }

    }
}
