namespace Application.modelo;

public interface IPedido
{
    public List<IServicioComprado> Servicios { get; }
    
    public DateTime FechaDelEvento { get; set; }

    public string DniCliente { get; set; }

    public int IdPedido { get; }
    
    public double GastoTotal { get; set; }
    
    public double Saldo { get; set; }
}