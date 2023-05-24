
//	Esta es la clase principal, la clase Program solo instancia la clase Pasteleria y llama a los procedimiento/funciones
//  La profesora me dijo que lo hagamos asi, las clases primitivas no hacen mucho bussiness, eso lo hace Pasteleria. 


//listarPedidos()	       //Lista de Pedidos
//listarServiciosPedido()  //Lista de Servicios del Pedido
//listaClientes()		   //Lista Clientes			

using System;
using System.Collections.Generic;

namespace Proyecto_Pasteleria_G1
{
	
	public class Pasteleria
	{
		public List<Cliente> listaClientes 	= new List<Cliente>();
		public List<Pedidos> listaPedidos 	= new List<Pedidos>();
		
		//Esto al ser algo fijo, podriamos no hacer una lista, sino que la clase tenga ya todo declarado y que solo sea agregar el "servicio" elegido directo al pedido.
		//public List<Servicios>  listaServicios = new List<Servicios>();
		
		public Pasteleria()
		{
		}
	}
}
