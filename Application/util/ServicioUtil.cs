using Application.modelo;
using Application.modelo.impl;
using Application.paso;
using Application.paso.servicio.agregar;
using Application.paso.servicio.eliminar;
using Application.paso.servicio;
using Application.paso.servicio.listar;
using Application.servicio;

namespace Application.util;

public class ServicioUtil
{
    public static void MostrarMenuServicios(IServicioPasteleria pasteleria)
    {
        MensajesUtil.EnviarMensajeServicios();
        
        string opcionMenu = ConsolaUtil.GetConsoleLine<string>("Seleccione una opcion: ").ToLower();

        switch (opcionMenu)
        {
            case "1":
                AgregarServicio(pasteleria);
                break;
            case "2":
                EliminarServicio(pasteleria);
                break;
            case "3":
                MostrarServicios(pasteleria);
                break;
            case "4":
                MenuUtil.MenuPrincipal(pasteleria);
                break;
            default:
                break;
        }
    }

    private static void MostrarServicios(IServicioPasteleria pasteleria)
    {
        IAppPaso<IServicio> pasoListar = new PasoListar();

        IAppPasos<IServicio> pasos = new ListarServicioPasos(pasoListar);

        pasos.Ejecutar(null);
        
        MostrarMenuServicios(pasteleria);
    }
    
    public static void AgregarServicio(IServicioPasteleria pasteleria)
    {
        IAppPaso<IServicio> pasoPrecio = new PasoPrecio(null);
        IAppPaso<IServicio> pasoTipo = new PasoTipo(pasoPrecio);
        IAppPaso<IServicio> pasoNombre = new PasoNombre(pasoTipo);
        
        IAppPasos<IServicio> pasos = new AgregarServicioPasos(pasoNombre);

        pasos.Ejecutar(new Servicio());
        
        MostrarMenuServicios(pasteleria);
    }
    
    private static void EliminarServicio(IServicioPasteleria pasteleria)
    {
        IAppPaso<IServicio> pasoEliminar = new PasoEliminar();

        IAppPasos<IServicio> pasos = new EliminarServicioPasos(pasoEliminar);

        pasos.Ejecutar(null);
        
        MostrarMenuServicios(pasteleria);
    }
}