using Application.modelo;
using Application.servicio;
using Application.util;

namespace Application.paso.servicio.listar;

public class PasoListar : IAppPaso<IPrestacion>
{
    public IPrestacion Ejecutar(IPrestacion prestacion)
    {
        IServicioPasteleria pasteleria = Application.ObtenerInstancia();
        
        pasteleria
            .ObtenerServicioPrestaciones()
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
        
        PrestacionUtil.MostrarMenuServicios();
        
        return prestacion;
    }
}