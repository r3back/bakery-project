using Application.model;
using Application.repositorio;
using Application.util;

namespace Application.servicio.impl;

public class ServicioServicios : IServicioServicios
{
    private IRepositorioServicio _repositorioPedidos;

    public ServicioServicios(IRepositorioServicio repositorioPedidos)
    {
        _repositorioPedidos = repositorioPedidos;
    }
    
    public IServicio Agregar(IServicio servicio)
    {
        this._repositorioPedidos.Agregar(servicio);

        return servicio;
    }

    public void Eliminar(IServicio servicio)
    {
        this._repositorioPedidos.Eliminar(servicio);
    }

    public void EliminarPorId(string id)
    {
        this._repositorioPedidos.EliminarPorId(id);
    }

    public Optional<IServicio> ObtenerPorId(string id)
    {
        return this._repositorioPedidos.ObtenerPorId(id);
    }

    public void MostrarTodos()
    {
        Console.WriteLine("***************************************************");

        Console.WriteLine("     ");
        Console.WriteLine("Hay un Total de " + this._repositorioPedidos.ObtenerTodos().Count+ " Servicios");
        Console.WriteLine("     ");

        this._repositorioPedidos.ObtenerTodos().ForEach(servicio => Console.WriteLine("Nombre: " + servicio.NombreServicio + " | Tipo: " + servicio.TipoServicio));
        Console.WriteLine("     ");
        Console.WriteLine("***************************************************");
    }
}