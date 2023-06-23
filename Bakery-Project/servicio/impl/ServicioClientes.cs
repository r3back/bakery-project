using Application.modelo;
using Application.repositorio;
using Application.util;

namespace Application.servicio.impl;

public class ServicioClientes : IServicioClientes
{
    private IRepositorioCliente _repositorioCliente;

    public ServicioClientes(IRepositorioCliente repositorioCliente)
    {
        _repositorioCliente = repositorioCliente;
    }

    public ICliente Agregar(ICliente cliente)
    {
        this._repositorioCliente.Agregar(cliente);
        
        return cliente;
    }

    public void Eliminar(ICliente cliente)
    {
        this._repositorioCliente.Eliminar(cliente);
    }

    public void EliminarPorId(string id)
    {
        this._repositorioCliente.EliminarPorId(id);
    }

    public Optional<ICliente> ObtenerPorId(string id)
    {
        return this._repositorioCliente.ObtenerPorId(id);
    }
    

    public void MostrarTodos()
    {
        Console.WriteLine("     ");
        Console.WriteLine("     ");
        Console.WriteLine("***************************************************");

        Console.WriteLine("     ");
        Console.WriteLine("Clientes Totales: " + this._repositorioCliente.ObtenerTodos().Count);
        Console.WriteLine("     ");

        this._repositorioCliente.ObtenerTodos()
            .ForEach(cliente => Console.WriteLine("Id: " + cliente.Dni + " | Nombre: " + cliente.Nombre + " | Apellido: " + cliente.Apellido));
        Console.WriteLine("     ");
        Console.WriteLine("***************************************************");
        Console.WriteLine("     ");
    }
    
    public List<ICliente> ObtenerTodos()
    {
        return this._repositorioCliente.ObtenerTodos();
    }
}