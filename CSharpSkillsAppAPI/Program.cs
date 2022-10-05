using DBContextSkillsDB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SkillDBContext>( options => { 
        options.UseSqlServer( builder.Configuration.GetConnectionString("Default"));
});

/*var allowOrigins = "_allowOrigins";
builder.Services.AddCors(options =>
    options.AddPolicy(name: allowOrigins,
        builder =>
        {
            //allowOrigins.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
            builder.WithOrigins("http://localhost/*", "https://localhost/*").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            //allowOrigins.WithHeaders();
        });
});*/


var allowOrigins = "_allowOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost/*", "https://localhost/*").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
