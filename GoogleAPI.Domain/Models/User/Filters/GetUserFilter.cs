﻿namespace GoogleAPI.Domain.Models.User.Filters
{
    public class GetUserFilter
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int Count { get; set; }
    }
}
