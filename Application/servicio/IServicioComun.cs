using Application.util;

namespace Application.servicio;

public interface IServicioComun<T, TE>
{
    public T Agregar(T valor);
    
    public void Eliminar(T valor);

    public void EliminarPorId(TE id);
    
    public Optional<T> ObtenerPorId(TE id);

    public void MostrarTodos();
}