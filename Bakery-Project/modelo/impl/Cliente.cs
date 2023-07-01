namespace Application.modelo.impl;

public class Cliente : ICliente
{
    private string _direccion;
    private string _telefono;
    private string _apellido;
    private string _nombre;
    private string _dni;

    public string Direccion
    {
        get => _direccion;
        set => _direccion = value;
    }

    public string Telefono
    {
        get => _telefono;
        set => _telefono = value;
    }

    public string Apellido
    {
        get => _apellido;
        set => _apellido = value;
    }

    public string Nombre
    {
        get => _nombre;
        set => _nombre = value;
    }

    public string Dni
    {
        get => _dni;
        set => _dni = value;
    }
}