namespace MyApi.Products;

public class Product
{
   // public ChiaveComplessa Id { get; set; } = new();
    public int Id{ get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}

public class ChiaveComplessa {
    public int Id1 { get; set; }
    public int Id2 { get; set; }
    public int Id3 { get; set; }


}
