using Application.modelo;
using Application.util;

namespace Application.paso.cliente.agregar;

public class PasoDni : IAppPaso<ICliente>
{
    private IAppPaso<ICliente>? _siguiente;

    public PasoDni(IAppPaso<ICliente>? siguiente)
    {
        this._siguiente = siguiente;
    }
    
    public ICliente Ejecutar(ICliente cliente)
    {
        string dni = ConsolaUtil.GetConsoleLine<string>("Ingresa el dni del cliente: ").ToLower();

        Optional<ICliente> existe = Application.ObtenerInstancia()
            .ObtenerServicioClientes()
            .ObtenerPorId(dni);

        if (existe.HasValue()) {
            Console.WriteLine("[ERROR] Ya existe un cliente con ese dni!");
            
            return this.Ejecutar(cliente);
        } else {
            cliente.Dni = dni;

            return Optional<IAppPaso<ICliente>>
                .Of(_siguiente)
                .Map(paso => paso.Ejecutar(cliente))
                .OrElse(cliente);
        }
    }
}