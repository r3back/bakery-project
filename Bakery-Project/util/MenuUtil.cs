namespace Application.util;

public class MenuUtil
{
    public static void MenuPrincipal()
    {
        MensajesUtil.EnviarMensajeBienvenida();
        
        string opcionMenu = ConsolaUtil.GetConsoleLine<string>("Seleccione una opcion: ");

        if (opcionMenu == null)
        {
            MenuPrincipal();
            return;
        }

        opcionMenu = opcionMenu.ToLower();
        
        switch (opcionMenu)
        {
            case "1":
                PrestacionUtil.MostrarMenuServicios();
                break;
            case "2":
                PedidoUtil.MostrarMenuPedidos();
                break;
            case "3":
                ClienteUtil.MostrarMenuClientes();
                break;
            default:
                MenuPrincipal();
                break;
        }
    }
}