using Application.modelo;
using Application.modelo.impl;
using Application.paso;
using Application.paso.cliente;
using Application.paso.cliente.agregar;
using Application.paso.pedidos;
using Application.paso.pedidos.abonar;
using Application.paso.pedidos.agregar;
using Application.paso.pedidos.comun;
using Application.paso.pedidos.eliminar;
using Application.paso.servicio;
using Application.servicio;

namespace Application.util;

public class PedidoUtil
{
    public static void MostrarMenuPedidos()
    {
        MensajesUtil.EnviarMensajePedidos();
        
        string opcionMenu = ConsolaUtil.GetConsoleLine<string>("Seleccione una opcion: ").ToLower();

        IServicioPasteleria pasteleria = Application.ObtenerInstancia();

        switch (opcionMenu)
        {
            case "1":
                AgregarPedido();
                break;
            case "2":
                EliminarServicio();
                break;
            case "3":
                pasteleria.ObtenerServicioPedidos().MostrarTodos();
                
                MostrarIrAtras();
                break;
            case "4":
                AbonarSaldo();
                break;
            case "5":
                MenuUtil.MenuPrincipal();
                break;
            default:
                break;
        }
    }

    private static void MostrarIrAtras()
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
        MostrarMenuPedidos();
    }
    
    public static void AbonarSaldo()
    {
        IAppPaso<IPedido> abonar = new PasoAbonarPedido();
        IAppPaso<IPedido> seleccionar = new PasoSeleccionarPedido(abonar);
        IAppPasos<IPedido> pasos = new PedidoPasos(seleccionar);

        pasos.Ejecutar(new Pedido());
        
        MostrarMenuPedidos();
    }
    
    public static void AgregarPedido()
    {
        IAppPaso<IPedido> pasoCheckout = new PasoCheckout(null);
        IAppPaso<IPedido> pasoFecha = new PasoFecha(pasoCheckout);
        IAppPaso<IPedido> pasoServicios = new PasoServicios(pasoFecha);
        IAppPaso<IPedido> pasoCliente = new PasoCliente(pasoServicios);
        IAppPasos<IPedido> pasos = new PedidoPasos(pasoCliente);

        pasos.Ejecutar(new Pedido());
        
        MostrarMenuPedidos();
    }
    
    private static void EliminarServicio()
    {        

        IAppPaso<IPedido> pasoTipo = new PasoEliminarPorTipo();
        IAppPaso<IPedido> pasoSeleccionarId = new PasoSeleccionarPedido(pasoTipo);
        IAppPasos<IPedido> pasos = new PedidoPasos(pasoSeleccionarId);

        pasos.Ejecutar(new Pedido());
        
        MostrarMenuPedidos();
    }
}