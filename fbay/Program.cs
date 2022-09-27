using fbay.Data;
using fbay.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("OpenCorsPolicy", opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});



builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer("name=ConnectionStrings:Default"));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAdvertisementRepo, AdvertisementRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("OpenCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
