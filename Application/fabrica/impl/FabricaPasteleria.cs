using Application.repositorio;
using Application.repositorio.impl;
using Application.servicio;
using Application.servicio.impl;

namespace Application.fabrica.impl;

public class FabricaPasteleria : IFabricaPasteleria
{
    public IServicioPasteleria CrearServicioPasteleria()
    {
        IServicioPedidos pedidosService = GetPedidosService();
        IServicioClientes clientesService = GetClientesService();
        IServicioServicios servicioServicios = GetServicioServicios();

        return new ServicioPasteleria(clientesService, pedidosService, servicioServicios);
    }

    private IServicioPedidos GetPedidosService()
    {
        IRepositorioPedido repositorioPedido = new RepositorioPedidoImpl();

        return new ServicioPedidos(repositorioPedido);
    }

    private IServicioClientes GetClientesService()
    {
        IRepositorioCliente repositorioCliente = new RepositorioClienteImpl();

        return new ServicioClientes(repositorioCliente);
    }
    
    private IServicioServicios GetServicioServicios()
    {
        IRepositorioServicio repositorioServicio = new RepositorioServicioImpl();

        return new ServicioServicios(repositorioServicio);
    }
}