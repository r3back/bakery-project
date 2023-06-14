namespace Application.paso;

public interface IAppPasos<T>
{
    public T Ejecutar(T? dato);
    
    public void AgregarPasos(List<IAppPaso<T>> pasos);
}