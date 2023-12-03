using InnoGotchi.Core.Entities.ActionFilter;
using InnoGotchi.Extensions;
using InnoGotchi.Infrastructure.Repository.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureCors();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureSwagger();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    dataSeeder.Seed();
}

app.ConfigureExceptionHandler();

if (app.Environment.IsProduction())
    app.UseHsts();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "InnoGotchiAPI v1");
});

app.MapControllers();

app.Run();
