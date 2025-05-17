using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Trelite.Business.Common;
using Trelite.Data.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>(options=>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BaseConnection"));
});
var conn = builder.Configuration.GetConnectionString("BaseConnection");
builder.Services.AddAuthentication(Constants.AuthenticationScheme)
.AddJwtBearer

// (options=>
// {
//     var config = builder.Configuration;
//     // options.Toke = new TokenValidationParameters();
// });
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
