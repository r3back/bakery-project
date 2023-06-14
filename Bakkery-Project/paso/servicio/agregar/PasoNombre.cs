using Application.modelo;
using Application.util;

namespace Application.paso.servicio.agregar;

public class PasoNombre : IAppPaso<IServicio>
{
    private IAppPaso<IServicio>? _siguiente;

    public PasoNombre(IAppPaso<IServicio>? siguiente)
    {
        this._siguiente = siguiente;
    }
    
    public IServicio Ejecutar(IServicio servicio)
    {
        string nombre = ConsolaUtil.GetConsoleLine<string>("Ingresa el nombre del servicio: ").ToLower();

        servicio.NombreServicio = nombre;

        return Optional<IAppPaso<IServicio>>
            .Of(_siguiente)
            .Map(paso => paso.Ejecutar(servicio))
            .OrElse(servicio);
        
    }
}