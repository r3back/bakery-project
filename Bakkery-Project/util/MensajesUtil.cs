namespace Application.util;

public class MensajesUtil
{
    public static void EnviarMensajeBienvenida()
    {
        List<string> mensaje = ObtenerMensajeBienvenida();
        
        EnviarMensaje(mensaje);
    }
    
    public static void EnviarMensajeServicios()
    {
        List<string> mensaje = ObtenerMenuServicios();
        
        EnviarMensaje(mensaje);
    }
    
    public static void EnviarMensajePedidos()
    {
        List<string> mensaje = ObtenerMenuPedidos();
        
        EnviarMensaje(mensaje);
    }


    private static void EnviarMensaje(List<string> mensaje)
    {
        mensaje.ForEach(line => Console.WriteLine(line));
    }
    
    private static List<string> ObtenerMensajeBienvenida()
    {
        return new List<string>() {
            "",
            "			***************************************************",
            "			*                                                 *",
            "			*        Panaderias y Confiterias Carlitos        *",
            "			*                                                 *",
            "			***************************************************",
            "		 	",
            "Seleccione una opcion a gestionar: ",
            "           ",
            "1) Servicios",
            "2) Pedidos",
            "3) Clientes"
        };
    }
    
    private static List<string> ObtenerMenuServicios()
    {
        return new List<string>() {
            "",
            "			***************************************************",
            "			*                                                 *",
            "			*               Gestion de Servicios              *",
            "			*                                                 *",
            "			***************************************************",
            "		 	",
            "Seleccione una opcion: ",
            "           ",
            "1) Agregar Servicio",
            "2) Eliminar Servicio",
            "3) Listar Servicios",
            "4) Volver Atras"
        };
    }
    
    private static List<string> ObtenerMenuPedidos()
    {
        return new List<string>() {
            "",
            "			**************************************************",
            "			*                                                *",
            "			*               Gestion de Pedidos               *",
            "			*                                                *",
            "			**************************************************",
            "		 	",
            "Seleccione una opcion: ",
            "           ",
            "1) Tomar Pedido",
            "2) Eliminar Pedido",
            "3) Listar Pedidos",
            "4) Volver Atras"
        };
    }
}