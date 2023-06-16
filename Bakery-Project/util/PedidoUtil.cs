using Application.modelo;
using Application.modelo.impl;
using Application.paso;
using Application.paso.cliente;
using Application.paso.cliente.agregar;
using Application.paso.pedidos;
using Application.paso.pedidos.agregar;
using Application.paso.pedidos.eliminar;
using Application.paso.servicio;
using Application.servicio;

namespace Application.util;

public class PedidoUtil
{
    public static void MostrarMenuServicios(IServicioPasteleria pasteleria)
    {
        MensajesUtil.EnviarMensajePedidos();
        
        string opcionMenu = ConsolaUtil.GetConsoleLine<string>("Seleccione una opcion: ").ToLower();

        switch (opcionMenu)
        {
            case "1":
                AgregarPedido(pasteleria);
                break;
            case "2":
                EliminarServicio(pasteleria);
                break;
            case "3":
                pasteleria.ObtenerServicioPedidos().MostrarTodos();
                
                MostrarIrAtras(pasteleria);
                break;
            case "4":
                MenuUtil.MenuPrincipal();
                break;
            default:
                break;
        }
    }

    private static void MostrarIrAtras(IServicioPasteleria pasteleria)
    {
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
        MostrarMenuServicios(pasteleria);
    }
    
    public static void AgregarPedido(IServicioPasteleria pasteleria)
    {
        IAppPaso<IPedido> pasoCheckout = new PasoCheckout(null);
        IAppPaso<IPedido> pasoFecha = new PasoFecha(pasoCheckout);
        IAppPaso<IPedido> pasoServicios = new PasoServicios(pasoFecha);
        IAppPaso<IPedido> pasoCliente = new PasoCliente(pasoServicios);
        IAppPasos<IPedido> pasos = new AgregarPedidoPasos(pasoCliente);

        pasos.Ejecutar(new Pedido());
        
        MostrarMenuServicios(pasteleria);
    }
    
    private static void EliminarServicio(IServicioPasteleria pasteleria)
    {
        IAppPaso<IPedido> pasoCliente = new PasoEliminar();
        IAppPasos<IPedido> pasos = new AgregarPedidoPasos(pasoCliente);

        pasos.Ejecutar(new Pedido());
        
        MostrarMenuServicios(pasteleria);
    }
}