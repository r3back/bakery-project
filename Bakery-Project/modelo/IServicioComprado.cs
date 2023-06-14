namespace Application.modelo;

public interface IServicioComprado
{
    public int Id { get; set; }
    public string NombreServicio { get; set; }
    public string TipoServicio { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }
}