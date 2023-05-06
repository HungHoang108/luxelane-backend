using System.Text;
using System.Text.Json.Serialization;
using Luxelane.Middlewares;
using Luxelane.Authorizatioin;
using Luxelane.Db;
using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Repositories.AddressRepo;
using Luxelane.Repositories.BaseRepo;
using Luxelane.Repositories.CategoryRepo;
using Luxelane.Repositories.OrderProductRepo;
using Luxelane.Repositories.OrderRepo;
using Luxelane.Repositories.ProductRepo;
using Luxelane.Services.AddressService;
using Luxelane.Services.BaseService;
using Luxelane.Services.CategoryService;
using Luxelane.Services.OrderProductService;
using Luxelane.Services.OrderService;
using Luxelane.Services.ProductService;
using Luxelane.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using static Luxelane.DTOs.AddressDto;
using static Luxelane.DTOs.CategoryDto;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        // Fix the JSON cycle issue
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(conn));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Authetication
builder.Services
    .AddIdentity<User, IdentityRole<int>>(options =>
    {
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<DataContext>();

//Validate token
builder.Services
    .AddAuthentication(option =>
    {
        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
        };
    });

// Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("JustAdmin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("AdminOrOwner", policy => policy.AddRequirements(new SameUserIdRequirement()));
});

builder.Services.AddTransient<IAuthorizationHandler, SameUserIdHandler>();

builder.Services
    .AddScoped<IBaseService<Product, ProductCreateDto, ProductReadDto, ProductUpdateDto>, BaseService<Product, ProductCreateDto, ProductReadDto, ProductUpdateDto>>()
    .AddScoped<IProductRepo, ProductRepo>()
    .AddScoped<IBaseRepo<Product>, BaseRepo<Product>>()
    .AddScoped<IProductService, ProductService>()

    .AddScoped<IBaseService<Address, AddressCreateDto, AddressReadDto, AddressUpdateDto>, BaseService<Address, AddressCreateDto, AddressReadDto, AddressUpdateDto>>()
    .AddScoped<IAddressRepo, AddressRepo>()
    .AddScoped<IBaseRepo<Address>, BaseRepo<Address>>()
    .AddScoped<IAddressService, AddressService>()

    .AddScoped<IBaseService<Category, CategoryCreateDto, CategoryReadDto, CategoryUpdateDto>, BaseService<Category, CategoryCreateDto, CategoryReadDto, CategoryUpdateDto>>()
    .AddScoped<ICategoryRepo, CategoryRepo>()
    .AddScoped<IBaseRepo<Category>, BaseRepo<Category>>()
    .AddScoped<ICategoryService, CategoryService>()

    .AddScoped<IBaseService<Order, OrderCreateDto, OrderReadDto, OrderUpdateDto>, BaseService<Order, OrderCreateDto, OrderReadDto, OrderUpdateDto>>()
    .AddScoped<IOrderRepo, OrderRepo>()
    .AddScoped<IBaseRepo<Order>, BaseRepo<Order>>()
    .AddScoped<IOrderService, OrderService>()

    .AddScoped<IBaseService<OrderProduct, OrderProductCreateDto, OrderProductReadDto, OrderProductUpdateDto>, BaseService<OrderProduct, OrderProductCreateDto, OrderProductReadDto, OrderProductUpdateDto>>()
    .AddScoped<IOrderProductRepo, OrderProductRepo>()
    .AddScoped<IBaseRepo<OrderProduct>, BaseRepo<OrderProduct>>()
    .AddScoped<IOrderProductService, OrderProductService>()

    .AddScoped<IUserService, UserService>()
    .AddScoped<ITokenService, JwtTokenService>();

builder.Services.AddTransient<ErrorHandlerMiddleware>();

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());

});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EF_API v1"));
}
// default, no below code
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EF_API v1"));
}
var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.UseHttpsRedirection();
app.UseRouting();

app.UseMiddleware<ErrorHandlerMiddleware>();


// app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
