using Application.modelo;
using Application.util;

namespace Application.paso.cliente.agregar;

public class PasoDireccion : IAppPaso<ICliente>
{
    private IAppPaso<ICliente> _siguiente;

    public PasoDireccion(IAppPaso<ICliente> siguiente)
    {
        this._siguiente = siguiente;
    }
    
    public ICliente Ejecutar(ICliente cliente)
    {
        string direccion = ConsolaUtil.GetConsoleLine<string>("Ingresa la direccion del cliente: ").ToLower();

        cliente.Direccion = direccion;

        Application.ObtenerInstancia()
            .ObtenerServicioClientes()
            .Agregar(cliente);
        
        Console.WriteLine("Cliente agregado correctamente!");
        
        return Optional<IAppPaso<ICliente>>
            .Of(_siguiente)
            .Map(paso => paso.Ejecutar(cliente))
            .OrElse(cliente);
    }
}