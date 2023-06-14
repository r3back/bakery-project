using Application.modelo;
using Application.modelo.impl;
using Application.paso;
using Application.paso.cliente;
using Application.paso.cliente.agregar;
using Application.paso.cliente.eliminar;
using Application.paso.cliente.listar;
using Application.servicio;

namespace Application.util;

public class ClienteUtil
{
    public static void MostrarMenuClientes(IServicioPasteleria pasteleria)
    {
        MensajesUtil.EnviarMensajeServicios();
        
        string opcionMenu = ConsolaUtil.GetConsoleLine<string>("Seleccione una opcion: ").ToLower();

        switch (opcionMenu)
        {
            case "1":
                AgregarCliente(pasteleria);
                break;
            case "2":
                EliminarCliente(pasteleria);
                break;
            case "3":
                MostrarClientes(pasteleria);
                break;
            case "4":
                MenuUtil.MenuPrincipal(pasteleria);
                break;
            default:
                break;
        }
    }

    private static void MostrarClientes(IServicioPasteleria pasteleria)
    {
        IAppPaso<ICliente> pasoListar = new PasoListar();
        IAppPasos<ICliente> pasos = new ListarClientePasos(pasoListar);
        pasos.Ejecutar(null);
        
        MostrarMenuClientes(pasteleria);
    }
    
    public static void AgregarCliente(IServicioPasteleria pasteleria)
    {
        IAppPaso<ICliente> pasoDireccion = new PasoDireccion(null);
        IAppPaso<ICliente> pasoApellido = new PasoApellido(pasoDireccion);
        IAppPaso<ICliente> pasoNombre = new PasoNombre(pasoApellido);
        IAppPaso<ICliente> pasoDni = new PasoDni(pasoNombre);
        IAppPasos<ICliente> pasos = new AgregarClientePasos(pasoDni);

        pasos.Ejecutar(new Cliente());
        
        MostrarMenuClientes(pasteleria);
    }
    
    private static void EliminarCliente(IServicioPasteleria pasteleria)
    {
        IAppPaso<ICliente> pasoEliminar = new PasoEliminar();
        IAppPasos<ICliente> pasos = new EliminarClientePasos(pasoEliminar);

        pasos.Ejecutar(null);
        
        MostrarMenuClientes(pasteleria);
    }
}