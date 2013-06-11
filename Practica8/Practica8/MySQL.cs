using System;
using MySql.Data.MySqlClient;

namespace Practica8
{
	public class MySQL
	{
		protected MySqlConnection myConnection;
		public MySQL ()
		{
		}
		
		protected void abrirConexion(){
			string connectionString =
				    "Server=Navisoud;" +
					"Database=videojuegos;" +
					"User ID=root;" +
					"Password=208081433;" +
					"Pooling=false;";
			this.myConnection = new MySqlConnection(connectionString);
			this.myConnection.Open();
		}
		
		protected void cerrarConexion(){
			this.myConnection.Close();
			this.myConnection = null;
		}
	}
}