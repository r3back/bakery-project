using Application.util;
namespace Application.repositorio;

public interface IRepositorio<T, TE>
{
    public List<T> ObtenerTodos();

    public T Agregar(T cliente);
    
    public void Eliminar(T cliente);

    public void EliminarPorId(TE id);
    
    public Optional<T> ObtenerPorId(TE id);
}