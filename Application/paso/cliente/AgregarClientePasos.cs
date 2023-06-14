using Application.modelo;

namespace Application.paso.cliente;

public class AgregarClientePasos : IAppPasos<ICliente>
{
    private IAppPaso<ICliente> _primerPaso;

    public AgregarClientePasos(IAppPaso<ICliente> primerPaso)
    {
        this._primerPaso = primerPaso;
    }
    
    public ICliente Ejecutar(ICliente dato)
    {
        return _primerPaso.Ejecutar(dato);
    }

    public void AgregarPasos(List<IAppPaso<ICliente>> pasos)
    {
        
    }
}