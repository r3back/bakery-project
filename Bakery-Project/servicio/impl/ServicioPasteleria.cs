using Application.modelo;

namespace Application.servicio.impl;

public class ServicioPasteleria :  IServicioPasteleria
{
    private IServicio<IPrestacion, int> _servicioPrestaciones;
    private IServicio<ICliente, string> _servicioClientes;
    private IServicio<IPedido, int> _servicioPedidos;

    public ServicioPasteleria(IServicio<ICliente, string> servicioClientes, IServicio<IPedido, int> servicioPedidos, 
                              IServicio<IPrestacion, int> servicioPrestaciones)
    {
        _servicioPrestaciones = servicioPrestaciones;
        _servicioClientes = servicioClientes;
        _servicioPedidos = servicioPedidos;
    }
    
    public IServicio<IPrestacion, int> ObtenerServicioPrestaciones()
    {
        return _servicioPrestaciones;
    }
    
    public IServicio<ICliente, string> ObtenerServicioClientes()
    {
        return _servicioClientes;
    }

    public IServicio<IPedido, int> ObtenerServicioPedidos()
    {
        return _servicioPedidos;
    }
}