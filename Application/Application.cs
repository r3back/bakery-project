using Application.factory;
using Application.factory.impl;
using Application.model;
using Application.model.impl;
using Application.service;
using Application.util;

namespace Application;

public class Application
{
    public static void Main(String[] args)
    {
        IFabricaServicio fabrica = new FabricaServicio();

        IServicioPasteleria pasteleria = fabrica.CrearServicioPasteleria();
        
        MensajesUtil.EnviarMensajeBienvenida();
        
        Optional<ICliente> cliente = Optional<ICliente>.Empty();

        while (!cliente.HasValue())
        {
            cliente = PreguntarSiEsCliente(pasteleria);
        }
    }

    public static Optional<ICliente> PreguntarSiEsCliente(IServicioPasteleria pasteleria)
    {
        string esCliente = GetConsoleLine<string>("Es cliente? Si/No: ").ToLower();

        if (esCliente.Equals("no")) {
            return NewClient(pasteleria);
        }
        
        Optional<ICliente> cliente = GetCliente(pasteleria);

        if (!cliente.HasValue()) {
            Console.WriteLine("Cliente no encontrado con ese id!");
        }
            
        return cliente;
    }
    
    public static Optional<ICliente> NewClient(IServicioPasteleria pasteleria)
    {
        IServicioClientes clientes = pasteleria.ObtenerServicioClientes();
        
        Console.WriteLine("Ingrese su datos por favor: ");
        
        string nombre = GetConsoleLine<string>("Nombre: ");
        string apellido = GetConsoleLine<string>("Apellido: ");
        string dni = GetConsoleLine<string>("Dni: ");
        string telefono = GetConsoleLine<string>("Telefono: ");
        string direccion = GetConsoleLine<string>("Direccion: ");
        
        ICliente cliente = new Cliente(nombre, apellido, dni, telefono, direccion);

        return Optional<ICliente>.Of(clientes.Agregar(cliente));
    }
    
    public static Optional<ICliente> GetCliente(IServicioPasteleria pasteleria){
        IServicioClientes clientes = pasteleria.ObtenerServicioClientes();

        string dni = GetConsoleLine<string>("Ingrese su numero de documento: ");
        
        return clientes.ObtenerPorId(dni);
    }

    private static T GetConsoleLine<T>(string message)
    {
        Console.WriteLine(message);

        string lineaDeConsola = Console.ReadLine();
        
        if (typeof(T) == typeof(int))
        {
            return (T) (object) Int64.Parse(lineaDeConsola);
        }
        else
        {
            return (T) (object) lineaDeConsola;
        }
    }
}