using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProductContext>();
    SeedData.Initialize(context);

    var productService = new ProductService(context);
    var orderService = new OrderService(context);
    productService.AddProduct(
        "laptop",
        10.11m,
        1,
        "aaa"
    );
    productService.GetAllProducts();
    productService.GetByCategory("aaa");
    orderService.GetOrderWithDetails();
     orderService.GetPagedOrder(0, 10);
     orderService.GetOrderByCustomerCity("Cairo");


}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();
