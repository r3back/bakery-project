using Application.modelo;
using Application.servicio;
using Application.util;

namespace Application.paso.servicio.listar;

public class PasoListar : IAppPaso<IServicio>
{
    public IServicio Ejecutar(IServicio servicio)
    {
        IServicioPasteleria pasteleria = Application.ObtenerInstancia();
        
        pasteleria
            .ObtenerServicioServicios()
            .MostrarTodos();

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
        
        ServicioUtil.MostrarMenuServicios();
        
        return servicio;
    }
}