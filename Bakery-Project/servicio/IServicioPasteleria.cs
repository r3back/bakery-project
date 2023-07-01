using Application.modelo;

namespace Application.servicio;

public interface IServicioPasteleria
{
    IServicio<ICliente, string> ObtenerServicioClientes();
    
    IServicio<IPedido, int> ObtenerServicioPedidos();
    
    IServicio<IPrestacion, int> ObtenerServicioPrestaciones();
}