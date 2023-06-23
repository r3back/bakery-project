using Application.modelo;

namespace Application.paso.servicio;

public class ServicioPasos : IAppPasos<IServicio>
{
    private IAppPaso<IServicio> step;

    public ServicioPasos(IAppPaso<IServicio> step)
    {
        this.step = step;
    }
    
    public IServicio Ejecutar(IServicio dato)
    {
        return step.Ejecutar(dato);
    }

    public void AgregarPasos(List<IAppPaso<IServicio>> pasos)
    {
        
    }
}