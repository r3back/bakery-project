namespace Application.model;

public interface IPedido
{
    public List<IServicio> Servicios { get; }

    public double GastosDeComida { get; set; }

    public string FechaDelEvento { get; set; }

    public string DniCliente { get; set; }

    public int IdPedido { get; }
    
    public double GastoTotal { get; set; }
    
    public double Saldo { get; set; }
        
    public double Seña { get; set; }
}