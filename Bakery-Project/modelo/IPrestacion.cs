namespace Application.modelo;

public interface IPrestacion
{
    public int Id { get; set; }
    public string NombreServicio { get; set; }
    public string TipoServicio { get; set; }
    public double Precio { get; set; }
}