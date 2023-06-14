namespace Application.modelo.impl;

public class Servicio : IServicio
{
    private static int _generadorId = 0;
    private string _nombreServicio;
    private string _tipoServicio;
    private double _precio;
    private int _id;

    public Servicio()
    {
        this._id = _generadorId;

        _generadorId++;
    }
    
    public Servicio(string nombreServicio, string tipoServicio, double precio)
    {
        _nombreServicio = nombreServicio;
        _tipoServicio = tipoServicio;
        _precio = precio;
    }

    public string NombreServicio
    {
        get => _nombreServicio;
        set => _nombreServicio = value;
    }

    public string TipoServicio
    {
        get => _tipoServicio;
        set => _tipoServicio = value;
    }
    
    public double Precio
    {
        get => _precio;
        set => _precio = value;
    }
    
    public int Id
    {
        get => _id;
        set => _id = value;
    }
}