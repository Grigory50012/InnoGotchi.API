using InnoGotchi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureCors();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.ConfigureExceptionHandler();

if (app.Environment.IsProduction())
    app.UseHsts();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
