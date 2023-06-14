using Application.modelo;
using Application.util;

namespace Application.paso.servicio.agregar;

public class PasoPrecio : IAppPaso<IServicio>
{
    private IAppPaso<IServicio>? _siguiente;

    public PasoPrecio(IAppPaso<IServicio>? siguiente)
    {
        this._siguiente = siguiente;
    }
    
    public IServicio Ejecutar(IServicio servicio)
    {
        double tipo = ConsolaUtil.GetConsoleLine<double>("Ingresa el precio del servicio: ");

        servicio.Precio = tipo;

        Application.ObtenerInstancia()
            .ObtenerServicioServicios()
            .Agregar(servicio);
        
        Console.WriteLine("Servicio agregado correctamente!");

        return Optional<IAppPaso<IServicio>>
            .Of(_siguiente)
            .Map(paso => paso.Ejecutar(servicio))
            .OrElse(servicio);
    }
}