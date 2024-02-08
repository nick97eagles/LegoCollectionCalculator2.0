using System.Net.NetworkInformation;
using LegoCollectionCalculator2._0.Server.Contexts;
using LegoCollectionCalculator2._0.Server.Handlers;
using LegoCollectionCalculator2._0.Server.RqModel;
using LegoCollectionCalculator2._0.Server.RqModels;
using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRequestHandler<CreateUserRqModel, CreateUserRsModel>, CreateUserHandler>();
builder.Services.AddScoped<IRequestHandler<LoginRqModel, LoginRsModel>, LoginHandler>();
builder.Services.AddScoped<IRequestHandler<CreateThemeRqModel, CreateThemeRsModel>, CreateThemeHandler>();
builder.Services.AddScoped<IRequestHandler<GetThemesRqModel, GetThemesRsModel>, GetThemesHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteThemeRqModel, DeleteThemeRsModel>, DeleteThemeHandler>();
builder.Services.AddScoped<IRequestHandler<EditThemeRqModel, EditThemeRsModel>, EditThemeHandler>();
builder.Services.AddScoped<IRequestHandler<AddSetRqModel, AddSetRsModel>, AddSetHandler>();
builder.Services.AddScoped<IRequestHandler<GetSetsRqModel, GetSetsRsModel>, GetSetsHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteSetRqModel, DeleteSetRsModel>, DeleteSetHandler>();

builder.Services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));

builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseSqlServer("data source=Desktop;initial catalog=Lego;trusted_connection=true;TrustServerCertificate=True");
});

builder.Services.AddDbContext<CollectionContext>(options =>
{
    options.UseSqlServer("data source=Desktop;initial catalog=Lego;trusted_connection=true;TrustServerCertificate=True");
});

var app = builder.Build();

app.UseCors("AllowOrigin");
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
