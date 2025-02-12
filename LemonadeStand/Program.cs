using AutoMapper;
using LemonadeStand.Abstractions.Extensions;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using LemonadeStand.Controllers;
using LemonadeStand.Data;
using LemonadeStand.Data.Repositories;
using LemonadeStand.Graphql.Mutations;
using LemonadeStand.Graphql.Queries;
using LemonadeStand.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var env = builder.Environment;

configuration.AddJsonFile("appsettings.json", false, true);
configuration.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

// Add services to the containers
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(config =>
  {
      config.SwaggerDoc("v1", new OpenApiInfo() { Title = "Lemonade Stand API", Version = "v1" });
  });

#region AutoMapper
var autoMapperconfiguration = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<LineItem, LemonadeStand.Abstractions.Entities.LineItem>()
        //.ForMember(x => x.ProductId, opt => opt.MapFrom(x => x.ProductId))
        .ReverseMap();
    cfg.CreateMap<LemonadeType, LemonadeStand.Abstractions.Entities.LemonadeType>()
        .ReverseMap();
    cfg.CreateMap<Size, LemonadeStand.Abstractions.Entities.Size>()
        .ReverseMap();
    cfg.CreateMap<Order, LemonadeStand.Abstractions.Entities.Order>()
        //.ForMember(x => x.LineItems, opt => opt.Ignore())
        .ReverseMap();
    cfg.CreateMap<Product, LemonadeStand.Abstractions.Entities.Product>()
        .ForMember(x => x.LemonadeTypes, opt => opt.MapFrom(src => src.LemonadeType))
        .ForMember(x => x.Sizes, opt => opt.MapFrom(src => src.Size))
        .ReverseMap();
    cfg.CreateMap<LemonadeStand.Abstractions.Models.ProductMutation, LemonadeStand.Abstractions.Entities.Product>()
        .ReverseMap();
});
IMapper mapper = autoMapperconfiguration.CreateMapper();
services.AddSingleton(mapper);
#endregion

#region Databse Configuration
services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetSection("Database:local").Value), ServiceLifetime.Transient);
#endregion

#region Scopes
services.AddScoped<ILemonadeTypeController, LemonadeTypeController>();
services.AddScoped<ISizeController, SizeController>();
services.AddScoped<IOrderController, OrderController>();
services.AddScoped<IProductController, ProductController>();
services.AddScoped<ILineItemService, LineItemService>();
services.AddScoped<ILemonadeTypeService, LemonadeTypeService>();
services.AddScoped<ISizeService, SizeService>();
services.AddScoped<IOrderService, OrderService>();
services.AddScoped<IProductService, ProductService>();
services.AddScoped<ILineItemRepository, LineItemRepository>();
services.AddScoped<ILemonadeTypeRepository, LemonadeTypeRepository>();
services.AddScoped<ISizeRepository, SizeRepository>();
services.AddScoped<IOrderRepository, OrderRepository>();
services.AddScoped<IProductRepository, ProductRepository>();
#endregion

#region Graphql
services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddMutationType(d => d.Name("Mutation"))
    .AddType<LemonadeTypeMutation>()
    .AddType<OrderMutation>()
    .AddType<SizeMutation>()
    .AddType<LemonadeStand.Graphql.Mutations.ProductMutation>()
    .AddType<LemonadeTypeQuery>()
    .AddType<ProductQuery>()
    .AddType<OrderQuery>()
    .AddType<SizeQuery>();
#endregion

#region CORS
services.AddCors(options =>
{
    options.AddPolicy(name: "CustomPolicy",
    policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsEnvironment("Local") || app.Environment.IsEnvironment("Development"))
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("/swagger/v1/swagger.json", "Lemonade Stand API");
    });
}

#region migrations
services.AddRunMigrationsExtensions(app, configuration);
#endregion


//app.UseHttpsRedirection();

app.UseCors("CustomPolicy");

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();

