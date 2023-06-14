namespace Application.modelo.impl;

public class Pedido : IPedido
{
    private static int PEDIDO_CONTADOR = 0;
    private List<IServicioComprado> _servicios;
    private DateTime _fechaDelEvento;
    private string _dniCliente;
    private double _gastoTotal;
    private int _idPedido;
    private double _saldo;

    public Pedido()
    {
        this._idPedido = PEDIDO_CONTADOR;
        this._servicios = new List<IServicioComprado>();
        
        PEDIDO_CONTADOR++;
    }
    
    public Pedido(DateTime fechaDelEvento, string dniCliente, double gastoTotal,
                  double saldo)
    {
        _servicios = new List<IServicioComprado>();
        _fechaDelEvento = fechaDelEvento;
        _idPedido = PEDIDO_CONTADOR;
        _gastoTotal = gastoTotal;
        _dniCliente = dniCliente;
        _saldo = saldo;

        PEDIDO_CONTADOR++;
    }

    public List<IServicioComprado> Servicios
    {
        get => _servicios;
    }

    public DateTime FechaDelEvento
    {
        get => _fechaDelEvento;
        set => _fechaDelEvento = value;
    }

    public string DniCliente
    {
        get => _dniCliente;
        set => _dniCliente = value;
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
}