using Application.modelo;
using Application.util;

namespace Application.paso.cliente.agregar;

public class PasoNombre : IAppPaso<ICliente>
{
    private IAppPaso<ICliente> _siguiente;

    public PasoNombre(IAppPaso<ICliente> siguiente)
    {
        this._siguiente = siguiente;
    }
    
    public ICliente Ejecutar(ICliente cliente)
    {
        string nombre = ConsolaUtil.GetConsoleLine<string>("Ingresa el nombre del cliente: ").ToLower();

        cliente.Nombre = nombre;

        return Optional<IAppPaso<ICliente>>
            .Of(_siguiente)
            .Map(paso => paso.Ejecutar(cliente))
            .OrElse(cliente);
    }
}