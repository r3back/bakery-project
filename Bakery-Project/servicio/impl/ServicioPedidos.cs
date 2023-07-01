using Application.modelo;
using Application.repositorio;
using Application.util;

namespace Application.servicio.impl;

public class ServicioPedidos : IServicio<IPedido, int>
{
    private IRepositorio<IPedido, int> _repositorio;

    public ServicioPedidos(IRepositorio<IPedido, int> repositorio)
    {
        _repositorio = repositorio;
    }
    
    public IPedido Agregar(IPedido pedido)
    {
        this._repositorio.Agregar(pedido);

        return pedido;
    }

    public void Eliminar(IPedido pedido)
    {
        this._repositorio.Eliminar(pedido);
    }

    public void EliminarPorId(int id)
    {
        this._repositorio.EliminarPorId(id);
    }

    public Optional<IPedido> ObtenerPorId(int id)
    {
        return this._repositorio.ObtenerPorId(id);
    }

    public void MostrarTodos()
    {
        Console.WriteLine("     ");
        Console.WriteLine("     ");
        Console.WriteLine("***************************************************");

        Console.WriteLine("     ");
        Console.WriteLine("Pedidos Totales: " + this._repositorio.ObtenerTodos().Count);
        Console.WriteLine("     ");

        this._repositorio.ObtenerTodos()
            .ForEach(servicio => Console.WriteLine("Id: " + servicio.IdPedido + " | Cliente: " + servicio.DniCliente + " | Saldo: " + servicio.Saldo + " | Fecha: " + servicio.FechaDelEvento));
        Console.WriteLine("     ");
        Console.WriteLine("***************************************************");
        Console.WriteLine("     ");
    }
    
    public List<IPedido> ObtenerTodos()
    {
        return this._repositorio.ObtenerTodos();
    }
}