using Application.modelo;
using Application.repositorio;
using Application.util;

namespace Application.servicio.impl;

public class ServicioPedidos : IServicioPedidos
{
    private IRepositorioPedido _repositorioPedidos;

    public ServicioPedidos(IRepositorioPedido repositorioPedidos)
    {
        _repositorioPedidos = repositorioPedidos;
    }
    
    public IPedido Agregar(IPedido pedido)
    {
        this._repositorioPedidos.Agregar(pedido);

        return pedido;
    }

    public void Eliminar(IPedido pedido)
    {
        this._repositorioPedidos.Eliminar(pedido);
    }

    public void EliminarPorId(int id)
    {
        this._repositorioPedidos.EliminarPorId(id);
    }

    public Optional<IPedido> ObtenerPorId(int id)
    {
        return this._repositorioPedidos.ObtenerPorId(id);
    }

    public void MostrarTodos()
    {
        Console.WriteLine("     ");
        Console.WriteLine("     ");
        Console.WriteLine("***************************************************");

        Console.WriteLine("     ");
        Console.WriteLine("Pedidos Totales: " + this._repositorioPedidos.ObtenerTodos().Count);
        Console.WriteLine("     ");

        this._repositorioPedidos.ObtenerTodos()
            .ForEach(servicio => Console.WriteLine("Id: " + servicio.IdPedido + " | Cliente: " + servicio.DniCliente + " | Saldo: " + servicio.Saldo + " | Fecha: " + servicio.FechaDelEvento));
        Console.WriteLine("     ");
        Console.WriteLine("***************************************************");
        Console.WriteLine("     ");
    }
    
    public List<IPedido> ObtenerTodos()
    {
        return this._repositorioPedidos.ObtenerTodos();
    }
}