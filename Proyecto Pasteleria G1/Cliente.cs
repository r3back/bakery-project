
using System;

namespace Proyecto_Pasteleria_G1
{
 	
	public class Cliente
	{
		public string  nombre;
		public string Nombre {
			get {
				return nombre;
			}
		}		

		private string  apellido;

		public string Apellido {
			get {
				return apellido;
			}
		}

		private int dni;
		public int Dni {
			get {
				return dni;
			}
		}

//ID
		private int telefono;
		public int Telefono {
			get {
				return telefono;
			}
		}

		private string  direccion;
		public string Direccion {
			get {
				return direccion;
			}
		}
			
		public Cliente(string paramNombre, string paramApellido, int paramDni, int paramTelefono, string paramDireccion)
		{
			nombre	  = paramNombre;
			apellido  = paramApellido;			
			dni	 	  = paramDni;
			telefono  = paramTelefono;			
			direccion = paramDireccion;						
		}
		
		
		
	}
}
