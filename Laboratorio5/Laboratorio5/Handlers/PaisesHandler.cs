using Laboratorio5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace Laboratorio5.Handlers
{
    public class PaisesHandler
    {
        private SqlConnection conexion;
        private string rutaConexion;
        public PaisesHandler()
        {
            var builder = WebApplication.CreateBuilder();
            rutaConexion = builder.Configuration.GetConnectionString("PaisesContext");
            conexion = new SqlConnection(rutaConexion);
        }
        private DataTable CrearTablaConsulta(string consulta)
        {
            SqlCommand comandoParaConsulta = new SqlCommand(consulta, conexion);
            SqlDataAdapter adaptadorParaTabla = new
            SqlDataAdapter(comandoParaConsulta);
            DataTable consultaFormatoTabla = new DataTable();
            conexion.Open();
            adaptadorParaTabla.Fill(consultaFormatoTabla);
            conexion.Close();
            return consultaFormatoTabla;
        }
        public List<PaisModel> ObtenerPaises()
        {
            List<PaisModel> paises = new List<PaisModel>();
            string consulta = "SELECT * FROM dbo.Pais ";
            DataTable tablaResultado = CrearTablaConsulta(consulta);
            foreach (DataRow columna in tablaResultado.Rows)
            {
                paises.Add(
                new PaisModel
                {
                    Id = Convert.ToInt32(columna["Id"]),
                    Nombre = Convert.ToString(columna["Nombre"]),
                    Idioma = Convert.ToString(columna["Idioma"]),
                    Continente = Convert.ToString(columna["Continente"]),
                });
            }
            return paises;
        }
        public bool CrearPais(PaisModel pais) //se necesita tener la consulta parametrizada
        {
            var consulta = @"INSERT INTO [dbo].[Pais] ([Nombre],[Idioma] ,[Continente])
                            VALUES(@Nombre, @Idioma, @Continente) ";
            var comandoParaConsulta = new SqlCommand(consulta, conexion);
            
            comandoParaConsulta.Parameters.AddWithValue("@Nombre", pais.Nombre);
            comandoParaConsulta.Parameters.AddWithValue("@Idioma", pais.Idioma);
            comandoParaConsulta.Parameters.AddWithValue("@Continente", pais.Continente);
            //encargados de transferir los valores que se indiquen al respectivo parámetro
            conexion.Open();
            /*etorna un 0 cuando algo a nivel de SQL al ejecutar la consulta falla y
            un número mayor que cero cuando se modificó una tupla correctamente*/
            bool exito = comandoParaConsulta.ExecuteNonQuery() >= 1; //se ejecuta el query
            conexion.Close();
            return exito;
        }
        public bool EditarPais(PaisModel pais) //se necesita tener la consulta parametrizada
        {
            var consulta = @"UPDATE [dbo].[Pais] SET Nombre = @Nombre, 
                                Idioma = @Idioma, 
                                Continente = @Continente 
                                WHERE Id=@Id ";
            var comandoParaConsulta = new SqlCommand(consulta, conexion);

            comandoParaConsulta.Parameters.AddWithValue("@Nombre", pais.Nombre);
            comandoParaConsulta.Parameters.AddWithValue("@Idioma", pais.Idioma);
            comandoParaConsulta.Parameters.AddWithValue("@Continente", pais.Continente);
            comandoParaConsulta.Parameters.AddWithValue("@Id", pais.Id);
            //encargados de transferir los valores que se indiquen al respectivo parámetro
            conexion.Open();
            /*etorna un 0 cuando algo a nivel de SQL al ejecutar la consulta falla y
            un número mayor que cero cuando se modificó una tupla correctamente*/
            bool exito = comandoParaConsulta.ExecuteNonQuery() >= 1; //se ejecuta el query
            conexion.Close();
            return exito;
        }
        public bool BorrarPais(PaisModel pais) //se necesita tener la consulta parametrizada
        {
            var consulta = @"Delete [dbo].[pais] where Id = @id";
            var comandoParaConsulta = new SqlCommand(consulta, conexion);
            comandoParaConsulta.Parameters.AddWithValue("@Id", pais.Id);
            //encargados de transferir los valores que se indiquen al respectivo parámetro
            conexion.Open();
            /*etorna un 0 cuando algo a nivel de SQL al ejecutar la consulta falla y
            un número mayor que cero cuando se modificó una tupla correctamente*/
            bool exito = comandoParaConsulta.ExecuteNonQuery() >= 1; //se ejecuta el query
            conexion.Close();
            return exito;
        }
    }
}