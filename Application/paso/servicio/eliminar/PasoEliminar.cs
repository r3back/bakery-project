using Application.modelo;
using Application.util;

namespace Application.paso.servicio.eliminar;

public class PasoEliminar : IAppPaso<IServicio>
{

    public IServicio Ejecutar(IServicio servicio)
    {
        int nombre = ConsolaUtil.GetConsoleLine<int>("Ingresa el id del servicio: ");

        Optional<IServicio> existe = Application.ObtenerInstancia()
            .ObtenerServicioServicios()
            .ObtenerPorId(nombre);

        if (!existe.HasValue()) {
            Console.WriteLine("[ERROR] No existe un servicio con ese id!");
            
            return this.Ejecutar(servicio);
        } else {
            Application.ObtenerInstancia().ObtenerServicioServicios().Eliminar(existe.GetValue());
            
            Console.WriteLine("Servicio eliminado correctamente!");

            return existe.GetValue();
        }
    }
}