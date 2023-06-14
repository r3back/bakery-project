namespace Application.servicio;

public interface IServicioPasteleria
{
    IServicioClientes ObtenerServicioClientes();
    
    IServicioPedidos ObtenerServicioPedidos();
    
    IServicioServicios ObtenerServicioServicios();
}