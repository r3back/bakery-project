using Application.modelo;

namespace Application.paso.servicio;

public class ListarServicioPasos : IAppPasos<IServicio>
{
    private IAppPaso<IServicio> primero;

    public ListarServicioPasos(IAppPaso<IServicio> primero)
    {
        this.primero = primero;
    }
    
    public IServicio Ejecutar(IServicio dato)
    {
        return this.primero.Ejecutar(dato);
    }

    public void AgregarPasos(List<IAppPaso<IServicio>> pasos)
    {
        
    }
}