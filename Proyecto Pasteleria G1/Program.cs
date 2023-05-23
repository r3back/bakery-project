/*

Proyecto 2:
En una panadería y confitería se tienen almacenados los pedidos de servicios de catering para
cumpleaños de 15, casamientos, bautismos, etc.. De los pedidos se almacena: el número de pedido
(código que genera el sistema), el dni del cliente, fecha del evento, el detalle de gastos de comida,
mozos, mantelería, bebidas, costo total, seña (20% del total) y saldo. De cada cliente que contrata un
servicio se registra su nombre y apellido, dni, teléfono y dirección. Un cliente puede tener más de un
pedido registrado. De cada servicio ofrecido se almacena nombre del servicio, tipo de servicio
(comida, bebida, personal de atención, blanco y mantelería), descripción (detalle de lo que incluye el
servicio), costo individual.
Se deberá desarrollar una aplicación, utilizando las clases que considere necesarias, que resuelva las
funcionalidades que se muestran en el siguiente menú:
a- Agregar un servicio
b- Eliminar un servicio.
c- Tomar un pedido. El cliente puede incluir en su pedido un solo servicio o varios. Si el cliente
ya existe, solo se registra el pedido. Si es cliente nuevo, debe agregarse a la base de datos de
clientes. La confitería toma hasta 2 pedidos para la misma fecha. En caso de que ya tenga los
2 pedidos registrados, se levanta una excepción indicando lo ocurrido.
d- Registrar el pago de un cliente. El cliente puede abonar una parte y achicar el saldo de un
pedido o abonar el total adeudado. Se debe ingresar el número del pedido y monto a
abonar.
e- Dar de baja un pedido. Considerar 2 casos: baja por solicitud del cliente o baja por
realización del pedido.
I. En caso que el cliente solicite la cancelación con más de un mes de anticipación
a la fecha del servicio, no se le reintegra la seña. En otro caso, el cliente debe
abonar el servicio completo.
II. Si la fecha actual coincide con la fecha de realización del pedido y el saldo es 0,
se borra el pedido.
f- Listado de clientes
g- Listado de pedidos

Preguntas:
1- Cerrar bien a que llama servicio o pedido...porque el enunciado parece mezclar los conceptos
2- Quien no pude tener mas de 2 pedidos...el cliente o la panaderia?


//	Esta es la clase principal, la clase Program solo instancia la clase Pasteleria y llama a los procedimiento/funciones
	La profesora me dijo que lo hagamos asi, las clases primitivas no hacen mucho bussiness, eso lo hace Pasteleria. 
	
- 	Clase Pasteleria  
			listarPedidos()	      	//Lista de Pedidos
			listarServiciosPedido() //Lista de Servicios del Pedido
			listaClientes()			//Lista Clientes			
		

-	Clase Servicios
			tipodeServicio, integer, //[Comida,Bebida,Personal de Atencion,Blanco y Manteleria]
			descripcion, string
			costo, float
			cantidad, integer;						
			
			
-	Clase Pedidos
  			ID, integer, autoincremental
			dnicliente, integer
			fechaeEvento, DateTime
			costoComida, float

			Personal_de_Atencion boolean //Se pregunta si quiere personal.
			Detalle_de_Personal bool //Si quiere incluir personal, se le lista de 0 a 50 personas una cierta cantidad, de 51 a 100 otra cantidad de personal y asi.
                             		  Ver de hacer 4 o 5 tipos de opciones de personal y guardar esa info
                             		  
			Manteleria_Blanca, 	bool //Se pregunta si quiere Manteleria 
			Detalle_de_Manteleria    Lo mismo que con el personal, ofrecer entre cantidad de personas algunas opciones y guardar esa info.
			
			seña, float //20%
			saldo, float
			
			tomarPedido() 		//Nuevo Pedido. Si tiene mas de 2 pedidos el usuario o la panaderia? Cualquiera sea el caso podemos usar exception para cumplir consigna
			bajaPedido()
            	-Baja por cancelacion (debe abonar) o por realizacion .
            	-Mas de 1 mes de Antelacion,no devolver seña. Si es menos de un mes, paga el servicio completo.
            	-Si llega a la fecha del pedido con saldo es 0 (no se pago), baja. 
			
			agregarServicio()	//Agrega servicio a Pedido.
			borrarServicio() 	//Quita ervicio del Pedido. 
			registrarPago() 	//suma dinero al saldo
			registrarSeña() 	//suma la seña 
					
			
-	Clase Clientes
			nombre, string
			apellido, string
			dni, integer
			telefono, integer
			direccion, string	
			
			AgregarCliente()	//nuevo cliente
			borrarCliente()		//Borra cliente, si es que esta vacio (usar exception si tiene pedidos para cumplir)
			
			
			

			
 
 */

using System;
using System.Collections;


namespace Proyecto_Pasteleria_G1
{
	class Program
	{
		
		//LLena de Clientes el la lista
		public static void LLenarClientes(Pasteleria P){
			
			P.listaClientes.Add(new Cliente("Roberto","Fernandez" ,123, 6543215,"Morena 5268"));
			P.listaClientes.Add(new Cliente("Diego"  ,"Perez"     ,456, 5245434,"Bahia 8856 "));
			P.listaClientes.Add(new Cliente("Laura"  ,"Gonzales"  ,789, 6548795,"Av. Colon 456"));
			P.listaClientes.Add(new Cliente("Alicia" ,"Sanchez"   ,111, 6548762,"11 y 6 numero 1987"));
					
		}
				
		public static void MostrarMarquesina(){
		
			Console.WriteLine("");
			Console.WriteLine("			***************************************************");
			Console.WriteLine("			*                                                 *");			
			Console.WriteLine("			*        Panaderias y Confiterias Carlitos        *");
			Console.WriteLine("			*                                                 *");			
			Console.WriteLine("			***************************************************");
			Console.WriteLine("		 	Servicios de Catering, Bebidas, Personal de Atencion" + "\r\n" + "					y Manteleria/Blanca");
			Console.WriteLine("");
						
		}
	    
		public static Cliente NewClient(Pasteleria P){		
			
			Cliente C;
			
			Console.WriteLine("Ingrese su datos por favor: ");
	    	Console.Write ("Nombre: ");	   string  _nombre    = Console.ReadLine();
	    	Console.Write ("Apellido: ");  string  _apellido  = Console.ReadLine();
	    	Console.Write ("DNI: ");       int     _dni       = Convert.ToInt32(Console.ReadLine());
	    	Console.Write ("Telefono: ");  int     _telefono  = Convert.ToInt32(Console.ReadLine());
	    	Console.Write ("Direccion: "); string  _direccion = Console.ReadLine();
	    			
	    	C = new Cliente(_nombre,_apellido,_dni,_telefono,_direccion);
	    	P.listaClientes.Add(C);
	    	return(C);
			
		}
		
		public static Cliente GetCliente(Pasteleria P){			   			
				Console.WriteLine("Ingrese su numero de documento: ");
				var dni = Console.ReadLine();				
				return P.listaClientes.Find(item => item.Dni == Convert.ToInt32(dni));
		}
		
		public static void Main(string[] args)
		{	
			var LaPasteleria = new Pasteleria();	
			string esCliente;
			Cliente ClienteActivo;
			
			LLenarClientes(LaPasteleria);
			
			MostrarMarquesina();
						
			Console.Write("Es cliente? Si/No: ");
			esCliente = Console.ReadLine();
			
			//aca podemos agregar una exception para que cache si no escribe Si/No, que vuelva a preguntar o diga opcion incorrecta y vuelva a preguntar
			if (esCliente == "No") {
				ClienteActivo = NewClient(LaPasteleria);
			} else {
				ClienteActivo = GetCliente(LaPasteleria);				
	        };		
			
			Console.WriteLine("");	
			Console.WriteLine("Hola "+ ClienteActivo.Nombre+ ", seleccione una opcion: ");
			
			
			
			//Saraza para ver como fluye el sistema.
			Console.WriteLine("");
			Console.WriteLine("1- Nuevo Pedido");
			Console.WriteLine("2- Cancelar Pedido");
			Console.WriteLine("");
			Console.WriteLine("9- Salir del Sistema");
			Console.WriteLine("");
			
			Console.ReadKey(true);
			Console.WriteLine("Hasta luego "+ ClienteActivo.Nombre+ ", que tenga un buen dia!");
			Console.ReadKey(true);
			
			//Saraza para ver como fluye el sistema.
		}
	}
}