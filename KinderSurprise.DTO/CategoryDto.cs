namespace KinderSurprise.DTO
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public CategoryDto(int categoryId, string name, string desc)
        {
            CategoryId = categoryId;
            CategoryName = name;
            Description = desc;
        }
    }
}
