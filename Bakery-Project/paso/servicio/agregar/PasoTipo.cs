using Application.modelo;
using Application.util;

namespace Application.paso.servicio.agregar;

public class PasoTipo : IAppPaso<IPrestacion>
{
    private IAppPaso<IPrestacion> _siguiente;

    public PasoTipo(IAppPaso<IPrestacion> siguiente)
    {
        this._siguiente = siguiente;
    }
    
    public IPrestacion Ejecutar(IPrestacion prestacion)
    {
        string tipo = ConsolaUtil.GetConsoleLine<string>("Ingresa el tipo del servicio: ").ToLower();

        prestacion.TipoServicio = tipo;

        return Optional<IAppPaso<IPrestacion>>
            .Of(_siguiente)
            .Map(paso => paso.Ejecutar(prestacion))
            .OrElse(prestacion);
    }
}