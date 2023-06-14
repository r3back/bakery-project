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
        Console.WriteLine("Servicios Disponibles:");
        MostrarServicios(Application.ObtenerInstancia().ObtenerServicioServicios().ObtenerTodos());
        Console.WriteLine("Servicios En el pedido:");
        MostrarServiciosComprados(pedido.Servicios);
        Console.WriteLine("***************************************************");

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
            IServicio? servicio = ObtenerServicio(id);
            
            if (servicio != null)
            {
                int cantidad = ConsolaUtil.GetConsoleLine<int>("Ingresa el la cantidad del servicio elegido: ");

                IServicioComprado comprado = new ServicioComprado(servicio.NombreServicio, servicio.TipoServicio, servicio.Precio, cantidad);
                
                pedido.Servicios.Add(comprado);
            }
        }

        return this.Ejecutar(pedido);
    }

    private IServicio? ObtenerServicio(string idStr)
    {
        try
        {
            int id = int.Parse(idStr);
        
            Optional<IServicio> existe = Application.ObtenerInstancia()
                .ObtenerServicioServicios()
                .ObtenerPorId(id);

            return existe.GetValue();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    private void MostrarServicios(List<IServicio> servicios)
    {
        Console.WriteLine("***************************************************");
        servicios.ForEach(servicio => Console.WriteLine("- Id: " + servicio.Id +  " | Nombre: " +  servicio.NombreServicio + " | Tipo: " + servicio.TipoServicio + " | Precio: " + servicio.Precio));
    }
    
    private void MostrarServiciosComprados(List<IServicioComprado> servicios)
    {
        Console.WriteLine("***************************************************");
        servicios.ForEach(servicio => Console.WriteLine("- Id: " + servicio.Id +  " | Nombre: " +  servicio.NombreServicio + " | Tipo: " + servicio.TipoServicio + " | X" + servicio.Cantidad));
    }
}