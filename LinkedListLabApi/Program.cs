using LinkedListLabApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Register all services as Singletons so state persists across HTTP requests
builder.Services.AddSingleton<SinglyLinkedList>();
builder.Services.AddSingleton<DoublyLinkedList>();
builder.Services.AddSingleton<CircularLinkedList>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
