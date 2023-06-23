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
    public static void MostrarMenuClientes()
    {
        MensajesUtil.EnviarMensajeClientes();
        
        string opcionMenu = ConsolaUtil.GetConsoleLine<string>("Seleccione una opcion: ").ToLower();

        IServicioPasteleria pasteleria = Application.ObtenerInstancia();

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
                MenuUtil.MenuPrincipal();
                break;
            default:
                break;
        }
    }

    private static void MostrarClientes(IServicioPasteleria pasteleria)
    {
        IAppPaso<ICliente> pasoListar = new PasoListar();
        IAppPasos<ICliente> pasos = new ClientePasos(pasoListar);
        pasos.Ejecutar(null);
        
        MostrarMenuClientes();
    }
    
    public static void AgregarCliente(IServicioPasteleria pasteleria)
    {
        IAppPaso<ICliente> pasoDireccion = new PasoDireccion(null);
        IAppPaso<ICliente> pasoApellido = new PasoApellido(pasoDireccion);
        IAppPaso<ICliente> pasoNombre = new PasoNombre(pasoApellido);
        IAppPaso<ICliente> pasoDni = new PasoDni(pasoNombre);
        IAppPasos<ICliente> pasos = new ClientePasos(pasoDni);

        pasos.Ejecutar(new Cliente());
        
        MostrarMenuClientes();
    }
    
    private static void EliminarCliente(IServicioPasteleria pasteleria)
    {
        IAppPaso<ICliente> pasoEliminar = new PasoEliminar();
        IAppPasos<ICliente> pasos = new ClientePasos(pasoEliminar);

        pasos.Ejecutar(null);
        
        MostrarMenuClientes();
    }
}