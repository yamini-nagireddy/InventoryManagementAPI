using Microsoft.EntityFrameworkCore;
using InventoryAPI.Persistence.Contexts;
using InventoryAPI.Persistence.Repositories;
using InventoryAPI.Domain.Repositories;
using InventoryAPI.Domain.Services;
using InventoryAPI.Services;
using InventoryAPI.Mapping;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("inventory-api-in-memory"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
// builder.Services.AddAutoMapper(typeof(Program), typeof(ModelToResourceProfile));
AutoMapper.IMapper mapper = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile<ModelToResourceProfile>();
    cfg.AddProfile<ResourceToModelProfile>();
}).CreateMapper();
builder.Services.AddSingleton(mapper);
// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.Run();
