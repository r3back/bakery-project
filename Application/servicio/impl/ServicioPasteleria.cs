namespace Application.servicio.impl;

public class ServicioPasteleria :  IServicioPasteleria
{
    private IServicioServicios _servicioServicios;
    private IServicioClientes _servicioClientes;
    private IServicioPedidos _servicioPedidos;

    public ServicioPasteleria(IServicioClientes servicioClientes, IServicioPedidos servicioPedidos, IServicioServicios servicioServicios)
    {
        _servicioServicios = servicioServicios;
        _servicioClientes = servicioClientes;
        _servicioPedidos = servicioPedidos;
    }
    
    public IServicioServicios ObtenerServicioServicios()
    {
        return _servicioServicios;
    }
    
    public IServicioClientes ObtenerServicioClientes()
    {
        return _servicioClientes;
    }

    public IServicioPedidos ObtenerServicioPedidos()
    {
        return _servicioPedidos;
    }
}