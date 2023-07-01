using Application.modelo;
using Application.util;

namespace Application.paso.servicio.agregar;

public class PasoPrecio : IAppPaso<IPrestacion>
{
    private IAppPaso<IPrestacion>? _siguiente;

    public PasoPrecio(IAppPaso<IPrestacion>? siguiente)
    {
        this._siguiente = siguiente;
    }
    
    public IPrestacion Ejecutar(IPrestacion prestacion)
    {
        double tipo = ConsolaUtil.GetConsoleLine<double>("Ingresa el precio del servicio: ");

        prestacion.Precio = tipo;

        Application.ObtenerInstancia()
            .ObtenerServicioPrestaciones()
            .Agregar(prestacion);
        
        Console.WriteLine("Servicio agregado correctamente!");

        return Optional<IAppPaso<IPrestacion>>
            .Of(_siguiente)
            .Map(paso => paso.Ejecutar(prestacion))
            .OrElse(prestacion);
    }
}