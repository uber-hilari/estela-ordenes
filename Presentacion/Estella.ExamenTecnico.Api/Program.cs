using Estela.ExamenTecnico.Aplicacion;
using Estela.ExamenTecnico.DataAccess;
using Estella.ExamenTecnico.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg =>
{
    cfg.AgregarAplicacion();
    cfg.AgregarDataAccess();
});

builder.Services.AgregarAplicacion();
builder.Services.AgregarDataAccess();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalErrorMiddleware>();

app.Run();
