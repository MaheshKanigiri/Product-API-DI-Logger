using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Product_API_DI.DataAccess;
using Product_API_DI.DataAccess.Interfaces;
using Product_API_DI.Repository;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Service for Connection
builder.Services.AddDbContext<ProductdbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add HTTPLogging
//builder.Services.AddHttpLogging(logging =>
//{
//    logging.LoggingFields = HttpLoggingFields.All;

//});


//Add service for Dependency Injection
builder.Services.AddScoped<IProduct, ProductRepository>();


//Add Services for CORS
builder.Services.AddCors(p => p.AddPolicy("angular", build =>
{
    build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
}));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseHttpLogging();   //for HttpLogging
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("angular"); //for Cors

app.Run();
