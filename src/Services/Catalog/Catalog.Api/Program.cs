var builder = WebApplication.CreateBuilder(args);

//Add services to the container DI
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

//Configure HTTP request pipeline 
app.MapCarter();

app.Run();
