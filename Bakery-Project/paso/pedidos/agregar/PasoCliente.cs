using Application.modelo;
using Application.modelo.impl;
using Application.paso.cliente;
using Application.paso.cliente.agregar;
using Application.util;

namespace Application.paso.pedidos.agregar;

public class PasoCliente : IAppPaso<IPedido>
{
    private IAppPaso<IPedido>? _siguiente;

    public PasoCliente(IAppPaso<IPedido>? siguiente)
    {
        this._siguiente = siguiente;
    }

    public IPedido Ejecutar(IPedido pedido)
    {
        string dni = ConsolaUtil.GetConsoleLine<string>("Ingresa el dni del cliente: ").ToLower();

        Optional<ICliente> existe = Application.ObtenerInstancia()
            .ObtenerServicioClientes()
            .ObtenerPorId(dni);

        ICliente cliente = null;
        
        if (existe.HasValue())
        {
            cliente = existe.GetValue();
        }
        else
        {
            cliente = RegistrarCliente(dni);
        }

        pedido.DniCliente = cliente.Dni;
        
        return Optional<IAppPaso<IPedido>>
            .Of(_siguiente)
            .Map(paso => paso.Ejecutar(pedido))
            .OrElse(pedido);
    }

    private ICliente RegistrarCliente(string dni)
    {
        Console.WriteLine("[ERROR] No existe un cliente con ese dni, registrelo primero!");

        IAppPaso<ICliente> pasoDireccion = new PasoDireccion(null);
        IAppPaso<ICliente> pasoApellido = new PasoApellido(pasoDireccion);
        IAppPaso<ICliente> pasoNombre = new PasoNombre(pasoApellido);
        ICliente nuevoCliente = new ClientePasos(pasoNombre).Ejecutar(new Cliente());

        nuevoCliente.Dni = dni;

        return nuevoCliente;
    }
}