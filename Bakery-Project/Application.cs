using Application.fabrica.impl;
using Application.servicio;
using Application.util;

namespace Application;

public class Application
{
    private static readonly IServicioPasteleria Pasteleria = new FabricaPasteleria().CrearServicioPasteleria();
    
    public static void Main(string[] args)
    {
        MenuUtil.MenuPrincipal();
    }

    // Singleton
    public static IServicioPasteleria ObtenerInstancia()
    {
        return Pasteleria;
    }
}