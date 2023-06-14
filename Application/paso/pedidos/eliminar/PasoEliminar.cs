using Application.modelo;
using Application.util;

namespace Application.paso.pedidos.eliminar;

public class PasoEliminar : IAppPaso<IPedido>
{

    public IPedido Ejecutar(IPedido servicio)
    {
        int nombre = ConsolaUtil.GetConsoleLine<int>("Ingresa el id del pedido: ");

        Optional<IPedido> existe = Application.ObtenerInstancia()
            .ObtenerServicioPedidos()
            .ObtenerPorId(nombre);

        if (!existe.HasValue()) {
            Console.WriteLine("[ERROR] No existe un pedido con ese id!");
            
            return this.Ejecutar(servicio);
        } else {
            Application.ObtenerInstancia().ObtenerServicioPedidos().Eliminar(existe.GetValue());
            
            Console.WriteLine("Pedido eliminado correctamente!");

            return existe.GetValue();
        }
    }
}