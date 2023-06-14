using Application.modelo;
using Application.util;

namespace Application.paso.cliente.eliminar;

public class PasoEliminar : IAppPaso<ICliente>
{
    public ICliente Ejecutar(ICliente servicio)
    {
        string nombre = ConsolaUtil.GetConsoleLine<string>("Ingresa el dni del cliente: ").ToLower();

        Optional<ICliente> existe = Application.ObtenerInstancia()
            .ObtenerServicioClientes()
            .ObtenerPorId(nombre);

        if (!existe.HasValue()) {
            Console.WriteLine("[ERROR] No existe un cliente con ese dni!");
            
            return this.Ejecutar(servicio);
        } else {
            Application.ObtenerInstancia().ObtenerServicioClientes().Eliminar(existe.GetValue());
            
            Console.WriteLine("Cliente eliminado correctamente!");

            return existe.GetValue();
        }
    }
}