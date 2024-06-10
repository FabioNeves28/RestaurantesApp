using Microsoft.EntityFrameworkCore;
using RestauranteApp.Application.Interfaces.Cliente;
using RestauranteApp.Application.Interfaces.Funcionario;
using RestauranteApp.Application.Interfaces.Pedido;
using RestauranteApp.Application.Repositories.Cliente;
using RestauranteApp.Application.Repositories.Funcionario;
using RestauranteApp.Application.Repositories.Pedido;
using RestaurantesApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RestaurantesContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionariosRepository>();
builder.Services.AddScoped<IPedidosRepository, PedidosRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
