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
        this._repositorioPedidos.ObtenerTodos().ForEach(pedido => Console.WriteLine("Pedido: " + pedido.IdPedido));
    }
    
    public List<IPedido> ObtenerTodos()
    {
        return this._repositorioPedidos.ObtenerTodos();
    }
}