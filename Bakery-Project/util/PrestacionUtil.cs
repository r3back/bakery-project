using Application.modelo;
using Application.modelo.impl;
using Application.paso;
using Application.paso.servicio.agregar;
using Application.paso.servicio.eliminar;
using Application.paso.servicio;
using Application.paso.servicio.listar;

namespace Application.util;

public class PrestacionUtil
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
        IAppPaso<IPrestacion> pasoListar = new PasoListar();

        IAppPasos<IPrestacion> pasos = new ServicioPasos(pasoListar);

        pasos.Ejecutar(null);
        
        MostrarMenuServicios();
    }
    
    public static void AgregarServicio()
    {
        IAppPaso<IPrestacion> pasoPrecio = new PasoPrecio(null);
        IAppPaso<IPrestacion> pasoTipo = new PasoTipo(pasoPrecio);
        IAppPaso<IPrestacion> pasoNombre = new PasoNombre(pasoTipo);
        
        IAppPasos<IPrestacion> pasos = new ServicioPasos(pasoNombre);

        pasos.Ejecutar(new Prestacion());
        
        MostrarMenuServicios();
    }
    
    private static void EliminarServicio()
    {
        IAppPaso<IPrestacion> pasoEliminar = new PasoEliminar();

        IAppPasos<IPrestacion> pasos = new ServicioPasos(pasoEliminar);

        pasos.Ejecutar(null);
        
        MostrarMenuServicios();
    }
}