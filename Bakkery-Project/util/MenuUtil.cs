using Application.modelo;
using Application.servicio;

namespace Application.util;

public class MenuUtil
{
    public static void MenuPrincipal(IServicioPasteleria pasteleria)
    {
        MensajesUtil.EnviarMensajeBienvenida();
        
        string opcionMenu = ConsolaUtil.GetConsoleLine<string>("Seleccione una opcion: ").ToLower();
        
        switch (opcionMenu)
        {
            case "1":
                ServicioUtil.MostrarMenuServicios(pasteleria);
                break;
            case "2":
                
                break;
            case "3":
                break;
            default:
                break;
        }
        
        //Optional<ICliente> cliente = Optional<ICliente>.Empty();

        //while (!cliente.HasValue())
        //{
        //    cliente = PreguntarSiEsCliente(pasteleria);
        //}
    }
}