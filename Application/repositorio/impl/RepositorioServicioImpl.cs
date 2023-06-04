using Application.model;
using Application.util;

namespace Application.repositorio.impl;

public class RepositorioServicioImpl : IRepositorioServicio
{
    private List<IServicio> _clientes = new List<IServicio>();

    public IServicio Agregar(IServicio servicio)
    {
        _clientes.Add(servicio);

        return servicio;
    }

    public void Eliminar(IServicio servicio)
    {
        _clientes.Remove(servicio);
    }

    public void EliminarPorId(string id)
    {
        var servicio = ObtenerPorId(id);

        if (servicio.HasValue())
        {
            this.Eliminar(servicio.GetValue());
        }
    }

    public Optional<IServicio> ObtenerPorId(string id)
    {
        try
        {
            var servicio = _clientes.Where(s => s.NombreServicio == id);

            return Optional<IServicio>.Of(servicio.First());
        }
        catch (Exception e)
        {
            return Optional<IServicio>.Empty();
        }
    }
    
    public List<IServicio> ObtenerTodos()
    {
        return _clientes;
    }
}