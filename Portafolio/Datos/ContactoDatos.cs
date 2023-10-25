using Portafolio.Models;
using System.Data.SqlClient;
using System.Data;

namespace Portafolio.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Lista()
        {
            //crear una lista vacia
            var oLista = new List<ContactoModel>();
            // crear una instancia de la clase conexion
            var cn = new Conexion();
            //utilizar using para establecer la cadena de conexion
            using (var conexion = new SqlConnection(cn.getPortafolioContext()))
            {
                //abrir la conexion
                conexion.Open();
                //Comando a ejecutar
                SqlCommand cmd = new SqlCommand("sp_ListarContacto", conexion);
                //decir el tipo de comando
                cmd.CommandType = CommandType.StoredProcedure;
                //Leer el resultado de la ejecucion del procedimiento almacenado
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //una ves se esten leyendo tambien los guardaremos en la lista
                        oLista.Add(new ContactoModel()
                        { //se utilizan las propiedades de la clase
                            Correo = dr["Correo"].ToString(),

                            Telefono= dr["Telefono"].ToString(),


                        });
                    }
                }
            }
            return oLista;
        }

        public ContactoModel ConsultarContacto(string Nombre)
        {
            var oInstalacion = new ContactoModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getPortafolioContext()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscarContacto", conexion);
                cmd.Parameters.AddWithValue("Nombre", Nombre);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oInstalacion.Correo = dr["Correo"].ToString();
                        oInstalacion.Telefono = dr["Telefono"].ToString();
                    }
                }
            }
            return oInstalacion;
        }
    }
}
