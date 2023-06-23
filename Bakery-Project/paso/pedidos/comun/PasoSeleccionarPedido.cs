using Application.modelo;
using Application.util;

namespace Application.paso.pedidos.comun;

public class PasoSeleccionarPedido : IAppPaso<IPedido>
{
    private IAppPaso<IPedido>? _siguiente;

    public PasoSeleccionarPedido(IAppPaso<IPedido>? siguiente)
    {
        this._siguiente = siguiente;
    }
    
    public IPedido Ejecutar(IPedido servicio)
    {
        string opcion = ConsolaUtil.GetConsoleLine<string>("Ingresa el 'id' del pedido, utiliza 'salir' para cancelar la operacion: ").ToLower();

        if (opcion.Equals("salir"))
        {
            return null;
        }
        
        int nombre = Int32.Parse(opcion);
        
        Optional<IPedido> existe = Application.ObtenerInstancia()
            .ObtenerServicioPedidos()
            .ObtenerPorId(nombre);

        if (!existe.HasValue()) {
            Console.WriteLine("[ERROR] No existe un pedido con ese id!");
            
            return this.Ejecutar(servicio);
        } else {
            return this._siguiente.Ejecutar(servicio);
        }
    }
}