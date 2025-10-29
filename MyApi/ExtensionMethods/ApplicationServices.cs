namespace MyApi.ExtensionMethods;

public static class ApplicationServices
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddScoped<ITodoItems, MockItems>();
        services.AddScoped<IProducts, ProductsService>();
        services.AddDbContext<NorthwindContext>(
             x => x.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True;Encrypt=True"));
    }
}
