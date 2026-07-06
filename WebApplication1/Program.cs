using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Context;
using WebApplication1.Extensions;
using WebApplication1.interfaces;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Shared.Mapping;
using WebApplication1.Shared.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<jwtcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection("AppSettings"));

builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("JWT"));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Register ASP.NET Core Identity.
// The implementation is moved to IdentityExtensions.cs
// to keep Program.cs clean and separate the Identity configuration
// from the application startup code.
builder.Services.AddIdentityConfiguration();
// Configure JWT Authentication.
// Instead of writing the full AddAuthentication()
// and AddJwtBearer() configuration here,
// it has been extracted into AuthenticationExtensions.cs
// to improve readability and maintainability.
builder.Services.AddJwtAuthentication(builder.Configuration);
// Register custom Authorization policies.
// The policy configuration (e.g., CanManageProducts)
// is implemented inside AuthorizationExtensions.cs
// to keep authorization logic in one place.
builder.Services.AddCustomAuthorization();
// Configure Cross-Origin Resource Sharing (CORS).
// All CORS policies (Development & Production)
// are defined inside CorsExtensions.cs
// to avoid cluttering Program.cs.
builder.Services.AddCorsConfiguration();
// Configure Swagger/OpenAPI.
// The JWT security definition and Swagger configuration
// have been moved to SwaggerExtensions.cs
// so Program.cs only contains high-level startup configuration.
builder.Services.AddSwaggerDocumentation();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Seed the database with the required roles and
// a default admin user during application startup.
// The seeding logic is implemented in SeedExtensions.cs
// to separate initialization logic from Program.cs.
await app.SeedRolesAndAdminAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseCors(app.Environment.IsDevelopment()
    ? "Development"
    : "Production");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();