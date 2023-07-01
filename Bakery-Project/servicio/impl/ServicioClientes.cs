using Application.modelo;
using Application.repositorio;
using Application.util;

namespace Application.servicio.impl;

public class ServicioClientes : IServicio<ICliente, string>
{
    private IRepositorio<ICliente, string> _repositorio;

    public ServicioClientes(IRepositorio<ICliente, string> repositorio)
    {
        this._repositorio = repositorio;
    }

    public ICliente Agregar(ICliente cliente)
    {
        this._repositorio.Agregar(cliente);
        
        return cliente;
    }

    public void Eliminar(ICliente cliente)
    {
        this._repositorio.Eliminar(cliente);
    }

    public void EliminarPorId(string id)
    {
        this._repositorio.EliminarPorId(id);
    }

    public Optional<ICliente> ObtenerPorId(string id)
    {
        return this._repositorio.ObtenerPorId(id);
    }
    

    public void MostrarTodos()
    {
        Console.WriteLine("     ");
        Console.WriteLine("     ");
        Console.WriteLine("***************************************************");

        Console.WriteLine("     ");
        Console.WriteLine("Clientes Totales: " + this._repositorio.ObtenerTodos().Count);
        Console.WriteLine("     ");

        this._repositorio.ObtenerTodos()
            .ForEach(cliente => Console.WriteLine("Id: " + cliente.Dni + " | Nombre: " + cliente.Nombre + " | Apellido: " + cliente.Apellido));
        Console.WriteLine("     ");
        Console.WriteLine("***************************************************");
        Console.WriteLine("     ");
    }
    
    public List<ICliente> ObtenerTodos()
    {
        return this._repositorio.ObtenerTodos();
    }
}