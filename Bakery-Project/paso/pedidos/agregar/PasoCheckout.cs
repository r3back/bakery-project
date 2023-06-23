using System.Globalization;
using Application.modelo;
using Application.modelo.impl;
using Application.paso.cliente;
using Application.paso.cliente.agregar;
using Application.util;

namespace Application.paso.pedidos.agregar;

public class PasoCheckout : IAppPaso<IPedido>
{
    private static readonly string FormatoFecha = "dd/MM/YYYY";
    private static readonly int MaximosPedidosPorDia = 2;
    private static readonly string FormatoArg = "es-AR";
    private IAppPaso<IPedido>? _siguiente;

    public PasoCheckout(IAppPaso<IPedido>? siguiente)
    {
        this._siguiente = siguiente;
    }

    public IPedido Ejecutar(IPedido pedido)
    {
        double total = ObtenerTotal(pedido);

        pedido.GastoTotal = total;

        double seña = CalcularSeña(total);

        pedido.Saldo = total - seña;
        
        Console.WriteLine("***************************************************");
        Console.WriteLine("Pedido Realizado Exitosamente!");
        Console.WriteLine("Id del pedido: " + pedido.IdPedido);
        Console.WriteLine("Gastos Totales: " + pedido.GastoTotal + "$");
        Console.WriteLine("Importe de Seña: " + seña + "$");
        Console.WriteLine("Saldo remanente: " + pedido.Saldo + "$");
        Console.WriteLine("Fecha: " + pedido.FechaDelEvento);

        Console.WriteLine("***************************************************");

        Application.ObtenerInstancia()
            .ObtenerServicioPedidos()
            .Agregar(pedido);
        
        return Optional<IAppPaso<IPedido>>
            .Of(_siguiente)
            .Map(paso => paso.Ejecutar(pedido))
            .OrElse(pedido);
    }

    private double CalcularSeña(double total)
    {
        return (20 * total) / 100;
    }

    private double ObtenerTotal(IPedido pedido)
    {
        double total = 0;

        foreach (IServicioComprado comprado in pedido.Servicios)
        {
            total += comprado.Precio * Convert.ToDouble(comprado.Cantidad);
        }

        return total;
    }
}