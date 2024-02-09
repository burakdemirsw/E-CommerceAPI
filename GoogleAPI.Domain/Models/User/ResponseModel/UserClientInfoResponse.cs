namespace GoogleAPI.Domain.Models.User.ResponseModel
{
    public class UserClientInfoResponse
    {
        public Token Token { get; set; } //access ve refresh token bunun içinde 
        public int UserId { get; set; }
        public string Mail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public int? BasketId { get; set; }
        public RefreshTokenCommandResponse? RefreshTokenCommandResponse { get; set; }
    }
}
