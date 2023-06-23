using System.Globalization;
using Application.modelo;
using Application.modelo.impl;
using Application.paso.cliente;
using Application.paso.cliente.agregar;
using Application.util;

namespace Application.paso.pedidos.agregar;

public class PasoFecha : IAppPaso<IPedido>
{
    private static readonly string FormatoFecha = "dd/MM/yyyy";
    private static readonly int MaximosPedidosPorDia = 2;
    private static readonly string FormatoArg = "es-AR";
    private IAppPaso<IPedido>? _siguiente;

    public PasoFecha(IAppPaso<IPedido>? siguiente)
    {
        this._siguiente = siguiente;
    }

    public IPedido Ejecutar(IPedido pedido)
    {
        int dia = ConsolaUtil.GetConsoleLine<int>("Ingresa el numero de dia para realizar el pedido: ");
        int mes = ConsolaUtil.GetConsoleLine<int>("Ingresa el numero de mes para realizar el pedido: ");
        int año = ConsolaUtil.GetConsoleLine<int>("Ingresa el año para realizar el pedido: ");

        string antesDelDia = dia > 9 ? "" : "0";
        string antesDelMes = mes > 9 ? "" : "0";

        string formatted = antesDelDia + dia + "/" + antesDelMes + mes + "/" + año;

        DateTime fecha = DateTime.ParseExact(formatted, FormatoFecha, new CultureInfo(FormatoArg));
        
        var existe = Application.ObtenerInstancia()
            .ObtenerServicioPedidos()
            .ObtenerTodos()
            .Where(p => p.FechaDelEvento == fecha);

        if (existe.Count() >= MaximosPedidosPorDia)
        {
            Console.WriteLine("[ERROR] Ya existen dos pedidos para esa fecha!");

            return this.Ejecutar(pedido);
        }
        else
        {
            pedido.FechaDelEvento = fecha;
        
            return Optional<IAppPaso<IPedido>>
                .Of(_siguiente)
                .Map(paso => paso.Ejecutar(pedido))
                .OrElse(pedido);
        }
    }
}