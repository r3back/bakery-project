using Application.modelo;
using Application.util;

namespace Application.paso.servicio.agregar;

public class PasoNombre : IAppPaso<IPrestacion>
{
    private IAppPaso<IPrestacion>? _siguiente;

    public PasoNombre(IAppPaso<IPrestacion>? siguiente)
    {
        this._siguiente = siguiente;
    }
    
    public IPrestacion Ejecutar(IPrestacion prestacion)
    {
        string nombre = ConsolaUtil.GetConsoleLine<string>("Ingresa el nombre del servicio: ").ToLower();

        prestacion.NombreServicio = nombre;

        return Optional<IAppPaso<IPrestacion>>
            .Of(_siguiente)
            .Map(paso => paso.Ejecutar(prestacion))
            .OrElse(prestacion);
        
    }
}