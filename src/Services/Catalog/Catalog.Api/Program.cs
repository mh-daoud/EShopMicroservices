var builder = WebApplication.CreateBuilder(args);

//Add services to the container DI
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(config =>
{
    config.Connection(builder.Configuration.GetConnectionString("Database")!);
    //config.AutoCreateSchemaObjects =  this good for development, it will create any missing schema if not found, but in prod it is risky
}).UseLightweightSessions();
var app = builder.Build();

//Configure HTTP request pipeline 
app.MapCarter();

app.Run();
