using Application.modelo;
using Application.repositorio;
using Application.util;

namespace Application.servicio.impl;

public class ServicioServicios : IServicioServicios
{
    private IRepositorioServicio _repositorio;

    public ServicioServicios(IRepositorioServicio repositorio)
    {
        _repositorio = repositorio;
    }
    
    public IServicio Agregar(IServicio servicio)
    {
        this._repositorio.Agregar(servicio);

        return servicio;
    }

    public void Eliminar(IServicio servicio)
    {
        this._repositorio.Eliminar(servicio);
    }

    public void EliminarPorId(int id)
    {
        this._repositorio.EliminarPorId(id);
    }

    public Optional<IServicio> ObtenerPorId(int id)
    {
        return this._repositorio.ObtenerPorId(id);
    }

    public void MostrarTodos()
    {
        Console.WriteLine("     ");
        Console.WriteLine("     ");
        Console.WriteLine("***************************************************");

        Console.WriteLine("     ");
        Console.WriteLine("Servicios Totales: " + this._repositorio.ObtenerTodos().Count);
        Console.WriteLine("     ");

        this._repositorio.ObtenerTodos().ForEach(servicio => Console.WriteLine("Nombre: " + servicio.NombreServicio + " | Tipo: " + servicio.TipoServicio));
        Console.WriteLine("     ");
        Console.WriteLine("***************************************************");
        Console.WriteLine("     ");
    }
    
    public List<IServicio> ObtenerTodos()
    {
        return this._repositorio.ObtenerTodos();
    }
}