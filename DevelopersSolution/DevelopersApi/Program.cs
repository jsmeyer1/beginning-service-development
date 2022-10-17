var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// everything above this line is configuring the internal of our application
var app = builder.Build();
// everything after this line is configuring the app pipeline (middleware)
// that means this is the stuff that handles HTTP request and responses

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// this happens before the application is running
app.MapControllers();

// GET /on-call-developer (create an instance of the DevelopController and call the GenOnCallDeveloper mothod)

// This is the thing that runs our service. It is a blocking call. It will start up and stay here until
// the application is shut down
Console.WriteLine("About the run the application");
app.Run();
Console.WriteLine("The application is done. Finished. This application is no more.");
