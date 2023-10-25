using Portafolio.Models;
using System.Data.SqlClient;
using System.Data;

namespace Portafolio.Datos
{
    public class PersonalDatos
    {
        public List<PersonalModel> Lista()
        {
            //crear una lista vacia
            var oLista = new List<PersonalModel>();
            // crear una instancia de la clase conexion
            var cn = new Conexion();
            //utilizar using para establecer la cadena de conexion
            using (var conexion = new SqlConnection(cn.getPortafolioContext()))
            {
                //abrir la conexion
                conexion.Open();
                //Comando a ejecutar
                SqlCommand cmd = new SqlCommand("sp_ListarPersonal", conexion);
                //decir el tipo de comando
                cmd.CommandType = CommandType.StoredProcedure;
                //Leer el resultado de la ejecucion del procedimiento almacenado
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //una ves se esten leyendo tambien los guardaremos en la lista
                        oLista.Add(new PersonalModel()
                        { //se utilizan las propiedades de la clase
                            Nombre = dr["Nombre"].ToString(),

                            Descripcion = dr["Descripcion"].ToString(),
                            Edad = dr["Edad"].ToString(),
							Correo = dr["Correo"].ToString(),
							Telefono = dr["Telefono"].ToString(),
							Direccion = dr["Direccion"].ToString(),



						});
                    }
                }
            }
            return oLista;
        }

        public PersonalModel ConsultarPersonal(string Nombre)
        {
            var oInstalacion = new PersonalModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getPortafolioContext()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscarPersonal", conexion);
                cmd.Parameters.AddWithValue("Nombre", Nombre);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oInstalacion.Nombre = dr["Nombre"].ToString();
                        oInstalacion.Descripcion = dr["Descripcion"].ToString();
                        oInstalacion.Edad = dr["Edad"].ToString();
						oInstalacion.Correo = dr["Correo"].ToString();
						oInstalacion.Telefono = dr["Telefono"].ToString();
						oInstalacion.Direccion = dr["Direccion"].ToString();

					}
				}
            }
            return oInstalacion;
        }
    }
}
