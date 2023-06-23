using Application.modelo;
using Application.util;

namespace Application.paso.pedidos.abonar;

public class PasoAbonarPedido : IAppPaso<IPedido>
{
    public IPedido Ejecutar(IPedido servicio)
    {

        Console.WriteLine("Pedido " + servicio.Saldo);
        if (servicio.Saldo >= 1)
        {
            Console.WriteLine("El saldo restante es " + servicio.Saldo);
            double cantidad = ConsolaUtil.GetConsoleLine<double>("Ingrese la cantidad que desea abonar:");

            double vuelto = Math.Max(cantidad, servicio.Saldo) - Math.Min(cantidad, servicio.Saldo);
            
            servicio.Saldo = Math.Max(servicio.Saldo - cantidad, 0);
            
            Console.WriteLine("El nuevo saldo restante es " + servicio.Saldo);

            if (vuelto > 0)
            {
                Console.WriteLine("Se te ha dado de vuelto " + vuelto);
            }

            return null;
        }
        else
        {
            Console.WriteLine("El pedido se encuentra abonado completamente!");
            return null;
        }
    }
}