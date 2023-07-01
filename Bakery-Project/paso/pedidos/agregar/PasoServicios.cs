using Application.modelo;
using Application.modelo.impl;
using Application.paso.cliente;
using Application.paso.cliente.agregar;
using Application.util;

namespace Application.paso.pedidos.agregar;

public class PasoServicios : IAppPaso<IPedido>
{
    private IAppPaso<IPedido>? _siguiente;

    public PasoServicios(IAppPaso<IPedido>? siguiente)
    {
        this._siguiente = siguiente;
    }

    public IPedido Ejecutar(IPedido pedido)
    {
        List<IPrestacion> servicios = Application.ObtenerInstancia().ObtenerServicioPrestaciones().ObtenerTodos();

        MostrarServicios(servicios);

        if (servicios.Count >= 1)
        {
            MostrarServiciosComprados(pedido.Servicios);
        }

        string id = ConsolaUtil.GetConsoleLine<string>("Ingresa el id a agregar o ingrese listo para terminar: ").ToLower();

        if (id.Equals("listo"))
        {
            return Optional<IAppPaso<IPedido>>
                .Of(_siguiente)
                .Map(paso => paso.Ejecutar(pedido))
                .OrElse(pedido);
        }
        else
        {
            IPrestacion? servicio = ObtenerServicio(id);
            
            if (servicio != null)
            {
                int cantidad = ConsolaUtil.GetConsoleLine<int>("Ingresa el la cantidad del servicio elegido: ");

                IServicioComprado comprado = new ServicioComprado(servicio.NombreServicio, servicio.TipoServicio, servicio.Precio, cantidad);
                
                pedido.Servicios.Add(comprado);
            }
        }

        return this.Ejecutar(pedido);
    }

    private IPrestacion? ObtenerServicio(string idStr)
    {
        try
        {
            int id = int.Parse(idStr);
        
            Optional<IPrestacion> existe = Application.ObtenerInstancia()
                .ObtenerServicioPrestaciones()
                .ObtenerPorId(id);

            return existe.GetValue();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    private void MostrarServicios(List<IPrestacion> servicios)
    {
        Console.WriteLine("***************************************************");

        Console.WriteLine("Servicios Disponibles:");

        if (servicios.Count == 0)
        {
            Console.WriteLine("- No hay servicios disponibles para agregar.");
            return;
        }
        
        servicios.ForEach(servicio => Console.WriteLine("- Id: " + servicio.Id +  " | Nombre: " +  servicio.NombreServicio + " | Tipo: " + servicio.TipoServicio + " | Precio: " + servicio.Precio));
        Console.WriteLine("***************************************************");
        Console.WriteLine(" ");
    }
    
    private void MostrarServiciosComprados(List<IServicioComprado> servicios)
    {
        if (servicios.Count <= 0)
        {
            return;
        }

        Console.WriteLine("Servicios en el pedido:");

        servicios.ForEach(servicio => Console.WriteLine("- Id: " + servicio.Id +  " | Nombre: " +  servicio.NombreServicio + " | Tipo: " + servicio.TipoServicio + " | Cantidad: X" + servicio.Cantidad));
        Console.WriteLine("***************************************************");
        Console.WriteLine(" ");

    }
}