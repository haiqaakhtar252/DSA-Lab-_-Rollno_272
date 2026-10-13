using DSALabsWeek01Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register all services
builder.Services.AddSingleton<FactorialService>();
builder.Services.AddSingleton<MultiplicationService>();
builder.Services.AddSingleton<TimingService>();
builder.Services.AddSingleton<BigOAnalysisService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
