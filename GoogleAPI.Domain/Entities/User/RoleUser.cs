namespace GoogleAPI.Domain.Entities.User
{
    public class RoleUser
    {
        public int UserId { get; set; }
        public User User { get; set; }



        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
