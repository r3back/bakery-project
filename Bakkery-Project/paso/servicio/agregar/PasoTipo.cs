using Application.modelo;
using Application.util;

namespace Application.paso.servicio.agregar;

public class PasoTipo : IAppPaso<IServicio>
{
    private IAppPaso<IServicio> _siguiente;

    public PasoTipo(IAppPaso<IServicio> siguiente)
    {
        this._siguiente = siguiente;
    }
    
    public IServicio Ejecutar(IServicio servicio)
    {
        string tipo = ConsolaUtil.GetConsoleLine<string>("Ingresa el tipo del servicio: ").ToLower();

        servicio.TipoServicio = tipo;

        return Optional<IAppPaso<IServicio>>
            .Of(_siguiente)
            .Map(paso => paso.Ejecutar(servicio))
            .OrElse(servicio);
    }
}