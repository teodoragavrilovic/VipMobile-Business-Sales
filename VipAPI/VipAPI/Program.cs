using AutoMapper;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.Domain;
using System.Text;
using VipAPI.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VipContext>(); 

builder.Services.AddAutoMapper(typeof(Program));

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new VipMapper());
});
IMapper mapper = mappingConfig.CreateMapper();

//ovo je falilo da radii!!!
builder.Services.AddSingleton(mapper);

//ovo dodajem da radi - ovo je kljucno da se doda!!!

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<VipContext>();

builder.Services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<VipContext>();
builder.Services.AddScoped<JwtAuthentication>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = true;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("NemaPristupaBezLozinke"))
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

app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod()
      .WithOrigins("*"));


app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
