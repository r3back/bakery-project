using Application.modelo;
using Application.servicio;
using Application.util;

namespace Application.paso.cliente.listar;

public class PasoListar : IAppPaso<ICliente>
{
    public ICliente Ejecutar(ICliente servicio)
    {
        IServicioPasteleria pasteleria = Application.ObtenerInstancia();
        
        pasteleria
            .ObtenerServicioClientes()
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
        
        ClienteUtil.MostrarMenuClientes(pasteleria);
        
        return servicio;
    }
}