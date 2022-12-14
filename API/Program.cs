var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddConfigureCors();

builder.Services.AddApplicationServices(builder.Configuration);

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

app.UseCors(CorsConstants.CorsPolicyName);

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
try
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ActivitatyDbContext>();
    await dbContext.Database.MigrateAsync();
    await Seed.SeedActivities(dbContext);
}
catch (Exception ex)
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error ocurred during migrations");
}

await app.RunAsync();
