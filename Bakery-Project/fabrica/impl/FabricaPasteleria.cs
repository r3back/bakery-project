using Application.modelo;
using Application.repositorio;
using Application.repositorio.impl;
using Application.servicio;
using Application.servicio.impl;

namespace Application.fabrica.impl;

public class FabricaPasteleria : IFabricaPasteleria
{
    

    public IServicioPasteleria CrearServicioPasteleria()
    {
        IServicio<IPedido, int> pedidosService = GetPedidosService();
        IServicio<ICliente, string> clientesService = GetClientesService();
        IServicio<IPrestacion, int> prestacionesService = GetServicioPrestaciones();

        return new ServicioPasteleria(clientesService, pedidosService, prestacionesService);
    }

    private IServicio<IPedido, int> GetPedidosService()
    {
        IRepositorio<IPedido, int> repositorioPedido = new RepositorioPedido();

        return new ServicioPedidos(repositorioPedido);
    }

    private IServicio<ICliente, string> GetClientesService()
    {
        IRepositorio<ICliente, string> repositorioCliente = new RepositorioCliente();

        return new ServicioClientes(repositorioCliente);
    }
    
    private IServicio<IPrestacion, int> GetServicioPrestaciones()
    {
        IRepositorio<IPrestacion, int> repositorioPrestaciones = new RepositorioPrestacion();

        return new ServicioPrestaciones(repositorioPrestaciones);
    }
}