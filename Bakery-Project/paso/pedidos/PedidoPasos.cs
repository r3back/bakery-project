using Application.modelo;

namespace Application.paso.pedidos;

public class PedidoPasos : IAppPasos<IPedido>
{
    private IAppPaso<IPedido> step;

    public PedidoPasos(IAppPaso<IPedido> step)
    {
        this.step = step;
    }
    
    public IPedido Ejecutar(IPedido dato)
    {
        return step.Ejecutar(dato);
    }

    public void AgregarPasos(List<IAppPaso<IPedido>> pasos)
    {
        
    }
}