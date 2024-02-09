namespace GoogleAPI.Domain.Models.Category.Dto
{
    public class CategoryAdd_DTO
    {
        public string? Description { get; set; }


        public string? PhotoUrl { get; set; }
        public bool IsActive { get; set; }

        public int? TopCategoryId { get; set; }

    }
}
