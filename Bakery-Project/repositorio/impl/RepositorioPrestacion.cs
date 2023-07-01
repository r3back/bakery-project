using Application.modelo;
using Application.util;

namespace Application.repositorio.impl;

public class RepositorioPrestacion : IRepositorio<IPrestacion, int>
{
    private List<IPrestacion> _servicios = new List<IPrestacion>();

    public IPrestacion Agregar(IPrestacion prestacion)
    {
        _servicios.Add(prestacion);

        return prestacion;
    }

    public void Eliminar(IPrestacion prestacion)
    {
        _servicios.Remove(prestacion);
    }

    public void EliminarPorId(int id)
    {
        var servicio = ObtenerPorId(id);

        if (servicio.HasValue())
        {
            this.Eliminar(servicio.GetValue());
        }
    }

    public Optional<IPrestacion> ObtenerPorId(int id)
    {
        try
        {
            var servicio = _servicios.Where(s => s.Id == id);

            return Optional<IPrestacion>.Of(servicio.First());
        }
        catch (Exception e)
        {
            return Optional<IPrestacion>.Empty();
        }
    }
    
    public List<IPrestacion> ObtenerTodos()
    {
        return _servicios;
    }
}