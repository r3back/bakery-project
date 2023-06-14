namespace Application.modelo;

public interface IServicio
{
    public int Id { get; set; }
    public string NombreServicio { get; set; }
    public string TipoServicio { get; set; }
    public double Precio { get; set; }
}