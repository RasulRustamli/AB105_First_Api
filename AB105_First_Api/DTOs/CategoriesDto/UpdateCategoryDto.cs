namespace AB105_First_Api.DTOs.CategoriesDto
{
    public record UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
