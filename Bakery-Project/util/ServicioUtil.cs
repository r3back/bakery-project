using Application.modelo;
using Application.modelo.impl;
using Application.paso;
using Application.paso.servicio.agregar;
using Application.paso.servicio.eliminar;
using Application.paso.servicio;
using Application.paso.servicio.listar;

namespace Application.util;

public class ServicioUtil
{
    public static void MostrarMenuServicios()
    {
        MensajesUtil.EnviarMensajeServicios();
        
        string opcionMenu = ConsolaUtil.GetConsoleLine<string>("Seleccione una opcion: ").ToLower();
        
        switch (opcionMenu)
        {
            case "1":
                AgregarServicio();
                break;
            case "2":
                EliminarServicio();
                break;
            case "3":
                MostrarServicios();
                break;
            case "4":
                MenuUtil.MenuPrincipal();
                break;
            default:
                break;
        }
    }

    private static void MostrarServicios()
    {
        IAppPaso<IServicio> pasoListar = new PasoListar();

        IAppPasos<IServicio> pasos = new ServicioPasos(pasoListar);

        pasos.Ejecutar(null);
        
        MostrarMenuServicios();
    }
    
    public static void AgregarServicio()
    {
        IAppPaso<IServicio> pasoPrecio = new PasoPrecio(null);
        IAppPaso<IServicio> pasoTipo = new PasoTipo(pasoPrecio);
        IAppPaso<IServicio> pasoNombre = new PasoNombre(pasoTipo);
        
        IAppPasos<IServicio> pasos = new ServicioPasos(pasoNombre);

        pasos.Ejecutar(new Servicio());
        
        MostrarMenuServicios();
    }
    
    private static void EliminarServicio()
    {
        IAppPaso<IServicio> pasoEliminar = new PasoEliminar();

        IAppPasos<IServicio> pasos = new ServicioPasos(pasoEliminar);

        pasos.Ejecutar(null);
        
        MostrarMenuServicios();
    }
}