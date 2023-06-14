using Application.modelo;
using Application.util;

namespace Application.paso.cliente.agregar;

public class PasoTelefono : IAppPaso<ICliente>
{
    private IAppPaso<ICliente> _siguiente;

    public PasoTelefono(IAppPaso<ICliente> siguiente)
    {
        this._siguiente = siguiente;
    }
    
    public ICliente Ejecutar(ICliente cliente)
    {
        string telefono = ConsolaUtil.GetConsoleLine<string>("Ingresa el telefono del cliente: ").ToLower();

        cliente.Telefono = telefono;

        return Optional<IAppPaso<ICliente>>
            .Of(_siguiente)
            .Map(paso => paso.Ejecutar(cliente))
            .OrElse(cliente);
    }
}