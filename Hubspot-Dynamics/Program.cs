using AutoMapper;
using Hubspot_Dynamics;
using Hubspot_Dynamics.Configurations;
using Hubspot_Dynamics.Repositories;
using Hubspot_Dynamics.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<Context>(x => x.UseSqlServer(connectionString));
builder.Services.Configure<HubspotConfiguration>(builder.Configuration.GetSection("HubspotConfiguration"));
builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<HubspotConfiguration>>().Value);

builder.Services.AddScoped<IHubspotApiRepository, HubspotApiRepository>();
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<IContactsService, ContactsService>();

builder.Services.AddControllers();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
