using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.User.ResponseModel
{
    public class UserClientInfoResponse
    {
        public Token Token { get; set; } //access ve refresh token bunun içinde 
        public int UserId { get; set; }
        public string Mail { get; set; }
        public int? BasketId { get; set; }
        public RefreshTokenCommandResponse? RefreshTokenCommandModel { get; set; }
    }
}
