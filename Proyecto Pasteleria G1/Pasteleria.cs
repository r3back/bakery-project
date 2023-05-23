/*
 * Created by SharpDevelop.
 * User: Hugo Delgadin
 * Date: 5/21/2023
 * Time: 8:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;



namespace Proyecto_Pasteleria_G1
{
	
	public class Pasteleria
	{
		public List<Cliente> 	listaClientes 	= new List<Cliente>();
		public List<Pedidos> 	listaPedidos 	= new List<Pedidos>();
		
		//Esto al ser algo fijo, podriamos no hacer una lista, sino que la clase tenga ya todo declarado y que solo sea agregar el "servicio" elegido directo al pedido.
		//public List<Servicios>  listaServicios = new List<Servicios>();
		
		public Pasteleria()
		{
		}
	}
}
