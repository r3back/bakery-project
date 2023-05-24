// 	ID, integer, autoincremental
//	dnicliente, integer
//	fechaeEvento, DateTime
//	costoComida, float
//	Personal_de_Atencion boolean //Se pregunta si quiere personal.
//	Detalle_de_Personal bool //Si quiere incluir personal, se le lista de 0 a 50 personas una cierta cantidad, de 51 a 100 otra cantidad de personal y asi.
//                     		  Ver de hacer 4 o 5 tipos de opciones de personal y guardar esa info
//                            		  
//	Manteleria_Blanca, 	bool //Se pregunta si quiere Manteleria 
//	Detalle_de_Manteleria    Lo mismo que con el personal, ofrecer entre cantidad de personas algunas opciones y guardar esa info.
//	
//	seña,  float //20%
//	saldo, float
//	
//	tomarPedido() 		//Nuevo Pedido. Si tiene mas de 2 pedidos el usuario o la panaderia? Cualquiera sea el caso podemos usar exception para cumplir consigna
//	bajaPedido()
//  	   -Baja por cancelacion (debe abonar) o por realizacion .
//         -Mas de 1 mes de Antelacion,no devolver seña. Si es menos de un mes, paga el servicio completo.
//         -Si llega a la fecha del pedido con saldo es 0 (no se pago), baja. 
//		
//	agregarServicio()	//Agrega servicio a Pedido.
//	borrarServicio() 	//Quita ervicio del Pedido. 
//	registrarPago() 	//suma dinero al saldo
//	registrarSeña() 	//suma la seña 


using System;

namespace Proyecto_Pasteleria_G1
{
	
	public class Pedidos
	{
		public Pedidos()
		{
		}
	}
}
