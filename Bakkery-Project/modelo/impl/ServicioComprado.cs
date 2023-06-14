namespace Application.modelo.impl;

public class ServicioComprado : IServicioComprado
{
    private string _nombreServicio;
    private string _tipoServicio;
    private double _precio;
    private int _cantidad;
    private int _id;
    
    
    public ServicioComprado(string nombreServicio, string tipoServicio, double precio, int cantidad)
    {
        this._nombreServicio = nombreServicio;
        this._tipoServicio = tipoServicio;
        this._cantidad = cantidad;
        this._precio = precio;
    }

    public string NombreServicio
    {
        get => this._nombreServicio;
        set => this._nombreServicio = value;
    }

    public string TipoServicio
    {
        get => this._tipoServicio;
        set => this._tipoServicio = value;
    }
    
    public double Precio
    {
        get => this._precio;
        set => this._precio = value;
    }
    
    public int Id
    {
        get => this._id;
        set => this._id = value;
    }
    
    public int Cantidad
    {
        get => this._cantidad;
        set => this._cantidad = value;
    }
}