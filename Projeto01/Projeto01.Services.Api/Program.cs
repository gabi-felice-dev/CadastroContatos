using Projeto01.Services.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ApplicationConfig.AddApplicationConfig(builder);
DomainConfig.AddDomainConfig(builder);
RepositoryConfig.AddRepositoryConfig(builder);
CacheConfig.AddCacheConfig(builder);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
