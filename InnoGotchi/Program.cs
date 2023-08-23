using InnoGotchi.Core.Entities.ActionFilter;
using InnoGotchi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureCors();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

var app = builder.Build();

app.ConfigureExceptionHandler();

if (app.Environment.IsProduction())
    app.UseHsts();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
