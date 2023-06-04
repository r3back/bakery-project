using Application.fabrica;
using Application.fabrica.impl;
using Application.model;
using Application.model.impl;
using Application.servicio;
using Application.util;

namespace Application;

public class Application
{
    public static void Main(String[] args)
    {
        IFabricaServicio fabrica = new FabricaServicio();

        IServicioPasteleria pasteleria = fabrica.CrearServicioPasteleria();
        
        MenuUtil.MenuPrincipal(pasteleria);
    }


    private static Optional<ICliente> PreguntarSiEsCliente(IServicioPasteleria pasteleria)
    {
        string esCliente = ConsolaUtil.GetConsoleLine<string>("Es cliente? Si/No: ").ToLower();

        if (esCliente.Equals("no")) {
            return NewClient(pasteleria);
        }
        
        Optional<ICliente> cliente = GetCliente(pasteleria);

        if (!cliente.HasValue()) {
            Console.WriteLine("Cliente no encontrado con ese id!");
        }
            
        return cliente;
    }

    private static Optional<ICliente> NewClient(IServicioPasteleria pasteleria)
    {
        IServicioClientes clientes = pasteleria.ObtenerServicioClientes();
        
        Console.WriteLine("Ingrese su datos por favor: ");
        
        string nombre = ConsolaUtil.GetConsoleLine<string>("Nombre: ");
        string apellido = ConsolaUtil.GetConsoleLine<string>("Apellido: ");
        string dni = ConsolaUtil.GetConsoleLine<string>("Dni: ");
        string telefono = ConsolaUtil.GetConsoleLine<string>("Telefono: ");
        string direccion = ConsolaUtil.GetConsoleLine<string>("Direccion: ");
        
        ICliente cliente = new Cliente(nombre, apellido, dni, telefono, direccion);

        return Optional<ICliente>.Of(clientes.Agregar(cliente));
    }

    private static Optional<ICliente> GetCliente(IServicioPasteleria pasteleria){
        IServicioClientes clientes = pasteleria.ObtenerServicioClientes();

        string dni = ConsolaUtil.GetConsoleLine<string>("Ingrese su numero de documento: ");
        
        return clientes.ObtenerPorId(dni);
    }


}