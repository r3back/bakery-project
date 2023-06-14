using Application.modelo;
using Application.util;

namespace Application.repositorio.impl;

public class RepositorioServicioImpl : IRepositorioServicio
{
    private List<IServicio> _servicios = new List<IServicio>();

    public IServicio Agregar(IServicio servicio)
    {
        _servicios.Add(servicio);

        return servicio;
    }

    public void Eliminar(IServicio servicio)
    {
        _servicios.Remove(servicio);
    }

    public void EliminarPorId(int id)
    {
        var servicio = ObtenerPorId(id);

        if (servicio.HasValue())
        {
            this.Eliminar(servicio.GetValue());
        }
    }

    public Optional<IServicio> ObtenerPorId(int id)
    {
        try
        {
            var servicio = _servicios.Where(s => s.Id == id);

            return Optional<IServicio>.Of(servicio.First());
        }
        catch (Exception e)
        {
            return Optional<IServicio>.Empty();
        }
    }
    
    public List<IServicio> ObtenerTodos()
    {
        return _servicios;
    }
}