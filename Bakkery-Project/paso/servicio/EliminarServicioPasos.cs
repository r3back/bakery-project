using Application.modelo;

namespace Application.paso.servicio;

public class EliminarServicioPasos : IAppPasos<IServicio>
{
    private IAppPaso<IServicio> primero;

    public EliminarServicioPasos(IAppPaso<IServicio> primero)
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