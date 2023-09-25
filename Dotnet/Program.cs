using Entity;
using repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200/").AllowAnyHeader().AllowAnyOrigin();
        }
    );
});

builder.Services.AddDbContext<dbContex>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IloginRepository, LoginRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
