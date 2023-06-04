using Application.model;
using Application.model.impl;
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
                pasteleria.ObtenerServicioServicios().MostrarTodos();
                
                MostrarIrAtras(pasteleria);
                break;
            case "4":
                MenuUtil.MenuPrincipal(pasteleria);
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
    
    public static void AgregarServicio(IServicioPasteleria pasteleria)
    {
        string nombre = "";
        
        while (true)
        {
            nombre = ConsolaUtil.GetConsoleLine<string>("Ingresa el nombre del servicio: ").ToLower();

            Optional<IServicio> servicio = pasteleria.ObtenerServicioServicios().ObtenerPorId(nombre);

            if (servicio.HasValue()) {
                Console.WriteLine("[ERROR] Ya existe un servicio con ese nombre!");
            } else {
                break;
            }
        }
                
        string tipo = ConsolaUtil.GetConsoleLine<string>("Ingresa el tipo de servicio: ").ToLower();

        IServicio paraAgregar = new Servicio(nombre, tipo);

        pasteleria.ObtenerServicioServicios().Agregar(paraAgregar);
        
        Console.WriteLine("Servicio agregado correctamente!");

        MostrarMenuServicios(pasteleria);
    }
    
    private static void EliminarServicio(IServicioPasteleria pasteleria)
    {
        while (true)
        {
            string nombre = ConsolaUtil.GetConsoleLine<string>("Ingresa el nombre del servicio a eliminar: ").ToLower();

            Optional<IServicio> servicio = pasteleria.ObtenerServicioServicios().ObtenerPorId(nombre);

            if (servicio.HasValue()) {
                pasteleria.ObtenerServicioServicios().Eliminar(servicio.GetValue());
                Console.WriteLine("Servicio eliminado correctamente!");
                break;
            } else {
                Console.WriteLine("[ERROR] No existe un servicio con ese nombre!");
                break;
            }
        }
        
        MostrarMenuServicios(pasteleria);
    }
}