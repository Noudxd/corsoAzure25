using MyApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.RegisterHttpServices();
builder.Services.RegisterServices();

var app = builder.Build();

app.UseMiddleware<GobalExceptionMiddleware>();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler(); //utilizza le eccezioni di log solo in ambiente di sviluppo
}

app.RegisterToDoItemsEndpoints(); 

app.MapGet("/products", async (NorthwindContext con) => {
    var data = 
    await con.Products
    .Select(p => new ProductDTO
    {
         Id = p.ProductId,
         Name = p.ProductName,
         Category = p.Category.CategoryName
    })
    .ToListAsync();
    return Results.Ok(data);
});



app.UseHttpsRedirection();
app.Run();

