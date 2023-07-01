using Application.modelo;

namespace Application.paso.servicio;

public class ServicioPasos : IAppPasos<IPrestacion>
{
    private IAppPaso<IPrestacion> step;

    public ServicioPasos(IAppPaso<IPrestacion> step)
    {
        this.step = step;
    }
    
    public IPrestacion Ejecutar(IPrestacion dato)
    {
        return step.Ejecutar(dato);
    }

    public void AgregarPasos(List<IAppPaso<IPrestacion>> pasos)
    {
        
    }
}