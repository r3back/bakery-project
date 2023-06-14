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
        this._repositorioCliente.ObtenerTodos().ForEach(cliente => Console.WriteLine("Cliente: " + cliente.Nombre));
    }

    public List<ICliente> ObtenerTodos()
    {
        return this._repositorioCliente.ObtenerTodos();
    }
}