using Application.modelo;
using Application.repositorio;
using Application.util;

namespace Application.servicio.impl;

public class ServicioPrestaciones : IServicio<IPrestacion, int>
{
    private IRepositorio<IPrestacion, int> _repositorio;

    public ServicioPrestaciones(IRepositorio<IPrestacion, int> repositorio)
    {
        _repositorio = repositorio;
    }
    
    public IPrestacion Agregar(IPrestacion prestacion)
    {
        this._repositorio.Agregar(prestacion);

        return prestacion;
    }

    public void Eliminar(IPrestacion prestacion)
    {
        this._repositorio.Eliminar(prestacion);
    }

    public void EliminarPorId(int id)
    {
        this._repositorio.EliminarPorId(id);
    }

    public Optional<IPrestacion> ObtenerPorId(int id)
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
    
    public List<IPrestacion> ObtenerTodos()
    {
        return this._repositorio.ObtenerTodos();
    }
}