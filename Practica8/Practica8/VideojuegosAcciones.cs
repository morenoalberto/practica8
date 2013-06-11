using System;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Practica8
{
	public class VideojuegosAcciones : MySQL
	{
		public VideojuegosAcciones ()
		{
		}
		public ArrayList obtenerTodos(){
			this.abrirConexion();
			MySqlCommand myCommand = new MySqlCommand(this.querySelect(),
			                                                            this.myConnection);
			MySqlDataReader myReader = myCommand.ExecuteReader();	
			
			ArrayList videojuegos = new ArrayList();
			while (myReader.Read()){
				Videojuegos videojuego = new Videojuegos();
				videojuego.ID = myReader["ID"].ToString();
				videojuego.nombre = myReader["nombre"].ToString();
				videojuego.anio = myReader["año"].ToString();
				videojuegos.Add(videojuego);
			}
			
			myReader.Close();
			myReader = null;
			myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
			return videojuegos;
		}

	
		private string querySelect(){
			return "SELECT * " +
				"FROM videojuegos";
		}
	}
}

