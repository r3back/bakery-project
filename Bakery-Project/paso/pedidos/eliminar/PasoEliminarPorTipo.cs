using Application.modelo;
using Application.util;

namespace Application.paso.pedidos.eliminar;

public class PasoEliminarPorTipo : IAppPaso<IPedido>
{

    public IPedido Ejecutar(IPedido servicio)
    {
        string opcion = ConsolaUtil.GetConsoleLine<string>("Ingresa el si quieres eliminar el pedido por 'baja' o 'realizado', utiliza 'salir' para cancelar la operacion: ").ToLower();
        
        DateTime fechaObjetivo = servicio.FechaDelEvento;

        DateTime fechaActual = DateTime.Now;

        DateTime fechaDespuesDeUnMes = fechaActual.AddMonths(1);

        // Agrega un mes a la fecha inicial
        
        if (opcion.Equals("baja"))
        {
            Console.WriteLine("Se ha cancelado el pedido correctamente.");

            if (fechaObjetivo >= fechaDespuesDeUnMes)
            {
                Console.WriteLine("El cliente pidio la baja con 1 mes de anticipacion, no debe abonar ningun valor extra y tampoco se le devolvera la seña.");
            }
            else
            {
                Console.WriteLine("El cliente no pidio la baja con 1 mes de anticipacion, debera abonar el total del pedido.");
            }

            return null;
        }
        else if (opcion.Equals("realizado"))
        {

            if (fechaObjetivo == fechaActual)
            {
                return revisarSiHaySaldoPendiente(servicio);
            }
            else
            {
                Console.WriteLine("[ERROR] La fecha de realizacion del pedido todavia no ha pasado.");
                return this.Ejecutar(servicio);
            }

        } else if (opcion.Equals("salir"))
        {
            return null;
        }
        else
        {
            Console.WriteLine("[ERROR] Opcion incorrecta!");
            return this.Ejecutar(servicio);
        }
    }

    private IPedido revisarSiHaySaldoPendiente(IPedido pedido)
    {
        if (pedido.Saldo <= 0)
        {
            Application.ObtenerInstancia().ObtenerServicioPedidos().Eliminar(pedido);
            Console.WriteLine("Se ha borrado el pedido por cancelacion exitosamente!");
            return null;
        }
        else
        {
            Console.WriteLine("[ERROR] El pedido no puedo ser marcado como realizado!");
            Console.WriteLine("Saldo pendiente: " + pedido.Saldo);
            return this.Ejecutar(pedido);
        }
    }
    
}