using AutoMapper;
using DataAccessLayer.UnitOfWork;
using Model;

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

app.MapControllers();

app.Run();
