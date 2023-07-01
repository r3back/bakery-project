using Application.modelo;
using Application.util;

namespace Application.paso.servicio.eliminar;

public class PasoEliminar : IAppPaso<IPrestacion>
{

    public IPrestacion Ejecutar(IPrestacion prestacion)
    {
        int nombre = ConsolaUtil.GetConsoleLine<int>("Ingresa el id del servicio: ");

        Optional<IPrestacion> existe = Application.ObtenerInstancia()
            .ObtenerServicioPrestaciones()
            .ObtenerPorId(nombre);

        if (!existe.HasValue()) {
            Console.WriteLine("[ERROR] No existe un servicio con ese id!");
            
            return this.Ejecutar(prestacion);
        } else {
            Application.ObtenerInstancia().ObtenerServicioPrestaciones().Eliminar(existe.GetValue());
            
            Console.WriteLine("Servicio eliminado correctamente!");

            return existe.GetValue();
        }
    }
}