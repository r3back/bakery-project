namespace Application.model.impl;

public class Pedido : IPedido
{
    private static int PEDIDO_CONTADOR = 0;
    private List<IServicio> _servicios;
    private double _gastosDeComida;
    private string _fechaDelEvento;
    private string _dniCliente;
    private double _gastoTotal;
    private int _idPedido;
    private double _saldo;
    private double _seña;

    public Pedido(double gastosDeComida, string fechaDelEvento, string dniCliente, double gastoTotal,
                  double saldo, double seña)
    {
        _servicios = new List<IServicio>();
        _gastosDeComida = gastosDeComida;
        _fechaDelEvento = fechaDelEvento;
        _idPedido = PEDIDO_CONTADOR;
        _gastoTotal = gastoTotal;
        _dniCliente = dniCliente;
        _saldo = saldo;
        _seña = seña;

        PEDIDO_CONTADOR++;
    }

    public List<IServicio> Servicios
    {
        get => _servicios;
    }

    public double GastosDeComida
    {
        get => _gastosDeComida;
        set => _gastosDeComida = value;
    }

    public string FechaDelEvento
    {
        get => _fechaDelEvento;
        set => _fechaDelEvento = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DniCliente
    {
        get => _dniCliente;
        set => _dniCliente = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int IdPedido
    {
        get => _idPedido;
    }
    
    public double GastoTotal
    {
        get => _gastoTotal;
        set => _gastoTotal = value;
    }
    
    public double Saldo
    {
        get => _saldo;
        set => _saldo = value;
    }
        
    public double Seña
    {
        get => _seña;
        set => _seña = value;
    }
}