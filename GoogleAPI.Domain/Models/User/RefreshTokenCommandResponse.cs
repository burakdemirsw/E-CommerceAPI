namespace GoogleAPI.Domain.Models.User
{
    public class RefreshTokenCommandResponse
    {
        public bool? State { get; set; }

        public Token? Token { get; set; }
    }
    public class RefreshTokenCommandModel
    {
        public string? RefreshToken { get; set; }
    }
}
