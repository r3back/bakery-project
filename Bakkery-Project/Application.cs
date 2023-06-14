using Application.fabrica;
using Application.fabrica.impl;
using Application.modelo;
using Application.modelo.impl;
using Application.servicio;
using Application.util;

namespace Application;

public class Application
{
    private static readonly IServicioPasteleria Pasteleria = new FabricaPasteleria().CrearServicioPasteleria();
    
    public static void Main(string[] args)
    {
        MenuUtil.MenuPrincipal(Pasteleria);
    }

    // Singleton
    public static IServicioPasteleria ObtenerInstancia()
    {
        return Pasteleria;
    }

    private static Optional<ICliente> PreguntarSiEsCliente()
    {
        string esCliente = ConsolaUtil.GetConsoleLine<string>("Es cliente? Si/No: ").ToLower();

        if (esCliente.Equals("no")) {
            return NewClient();
        }
        
        Optional<ICliente> cliente = GetCliente();

        if (!cliente.HasValue()) {
            Console.WriteLine("Cliente no encontrado con ese id!");
        }
            
        return cliente;
    }

    private static Optional<ICliente> NewClient()
    {
        IServicioClientes clientes = Pasteleria.ObtenerServicioClientes();
        
        Console.WriteLine("Ingrese su datos por favor: ");
        
        string nombre = ConsolaUtil.GetConsoleLine<string>("Nombre: ");
        string apellido = ConsolaUtil.GetConsoleLine<string>("Apellido: ");
        string dni = ConsolaUtil.GetConsoleLine<string>("Dni: ");
        string telefono = ConsolaUtil.GetConsoleLine<string>("Telefono: ");
        string direccion = ConsolaUtil.GetConsoleLine<string>("Direccion: ");
        
        ICliente cliente = new Cliente(nombre, apellido, dni, telefono, direccion);

        return Optional<ICliente>.Of(clientes.Agregar(cliente));
    }

    private static Optional<ICliente> GetCliente(){
        IServicioClientes clientes = Pasteleria.ObtenerServicioClientes();

        string dni = ConsolaUtil.GetConsoleLine<string>("Ingrese su numero de documento: ");
        
        return clientes.ObtenerPorId(dni);
    }


}