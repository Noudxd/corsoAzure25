namespace MyApi.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Category { get; set; }
    }
}
