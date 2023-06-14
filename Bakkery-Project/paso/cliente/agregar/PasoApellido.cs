using Application.modelo;
using Application.util;

namespace Application.paso.cliente.agregar;

public class PasoApellido : IAppPaso<ICliente>
{
    private IAppPaso<ICliente> _siguiente;

    public PasoApellido(IAppPaso<ICliente> siguiente)
    {
        this._siguiente = siguiente;
    }
    
    public ICliente Ejecutar(ICliente cliente)
    {
        string apellido = ConsolaUtil.GetConsoleLine<string>("Ingresa el apellido del cliente: ").ToLower();

        cliente.Apellido = apellido;

        return Optional<IAppPaso<ICliente>>
            .Of(_siguiente)
            .Map(paso => paso.Ejecutar(cliente))
            .OrElse(cliente);
    }
}