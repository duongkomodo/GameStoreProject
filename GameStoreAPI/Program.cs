using AutoMapper;
using BusinessObject.Models;
using DataAccess.Respository;
using DataAccess.Respository.CategoryRepo;
using DataAccess.Respository.GameKeyRepo;
using DataAccess.Respository.GameRepo;
using DataAccess.Respository.OrderDetailRepo;
using DataAccess.Respository.OrderRepo;
using DataAccess.Respository.UserRepo;
using DataAccess.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using static WebPWrecover.Services.EmailSender;
using WebPWrecover.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors();
builder.Services.AddSwaggerGen(options => {
options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Name = "Authentication",
    Description = "Bearer Authen with JWT token",
    Type = SecuritySchemeType.Http,

}); options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference= new OpenApiReference {
                    Id = "Bearer",
                    Type= ReferenceType.SecurityScheme,
                }
            },
        new List<string>()
        }

    });
});

builder.Services.AddDbContext<GameStoreContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString"));
});
builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;

    options.SignIn.RequireConfirmedEmail = true;

   
}).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<GameStoreContext>()
    .AddDefaultTokenProviders();
//Life cycle DI: AddSingleton(), AddTransient(), AddScope()
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IGameKeyRepository, GameKeyRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IEmailSender, EmailSender>();



builder.Services.AddAutoMapper(typeof(DataAccess.Utility.MapperProfile));

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters =
    new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecureKey"])),

    };
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context => {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
            }
            return Task.CompletedTask;
        }
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();
app.UseAuthentication();


app.MapControllers();

using (var scope = app.Services.CreateScope())
{

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roleValues = Enum.GetValues(typeof(Roles));

    foreach (var role in roleValues)
    {
        if (!await roleManager.RoleExistsAsync(role.ToString()))
        {
            await roleManager.CreateAsync(new IdentityRole(role.ToString()));
        }
    }
}

app.Run();
