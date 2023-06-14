using Application.modelo;
using Application.servicio;
using Application.util;

namespace Application.paso.pedidos.listar;

public class PasoListar : IAppPaso<IPedido>
{
    public IPedido Ejecutar(IPedido servicio)
    {
        IServicioPasteleria pasteleria = Application.ObtenerInstancia();
        
        pasteleria
            .ObtenerServicioPedidos()
            .MostrarTodos();

        string atras = "";

        while (atras != "1")
        {        
            atras = ConsolaUtil.GetConsoleLine<string>("1) Volver atras").ToLower();

            Console.WriteLine("Seleccione una opcion:");
            
            if (atras != "1")
            {
                Console.WriteLine("[ERROR] Opcion Invalida!");
            }
        }
        
        PedidoUtil.MostrarMenuServicios(pasteleria);
        
        return servicio;
    }
}