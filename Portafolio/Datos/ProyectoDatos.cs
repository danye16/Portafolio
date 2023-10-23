using Portafolio.Models;
using System.Data.SqlClient;
using System.Data;

namespace Portafolio.Datos
{
    public class ProyectoDatos
    {
        public List<ProyectoModel> Lista()
        {
            //crear una lista vacia
            var oLista = new List<ProyectoModel>();
            // crear una instancia de la clase conexion
            var cn = new Conexion();
            //utilizar using para establecer la cadena de conexion
            using (var conexion = new SqlConnection(cn.getPortafolioContext()))
            {
                //abrir la conexion
                conexion.Open();
                //Comando a ejecutar
                SqlCommand cmd = new SqlCommand("sp_ListarProyecto", conexion);
                //decir el tipo de comando
                cmd.CommandType = CommandType.StoredProcedure;
                //Leer el resultado de la ejecucion del procedimiento almacenado
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //una ves se esten leyendo tambien los guardaremos en la lista
                        oLista.Add(new ProyectoModel()
                        { //se utilizan las propiedades de la clase
                            IdProyecto = Convert.ToInt32(dr["IdProyecto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Lenguaje = dr["Lenguaje"].ToString(),

                            Descripcion = dr["Descripcion"].ToString(),
                            Link = dr["Link"].ToString(),


                        });
                    }
                }
            }
            return oLista;
        }

        public ProyectoModel ConsultarProyecto(int IdProyecto)
        {
            var oInstalacion = new ProyectoModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getPortafolioContext()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscarProyeco", conexion);
                cmd.Parameters.AddWithValue("IdProyecto", IdProyecto);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oInstalacion.IdProyecto = Convert.ToInt32(dr["IdProyecto"]);
                        oInstalacion.Nombre = dr["Nombre"].ToString();
                        oInstalacion.Lenguaje = dr["Lenguaje"].ToString();
                        oInstalacion.Descripcion = dr["Descripcion"].ToString();
                        oInstalacion.Link = dr["Link"].ToString();
                    }
                }
            }
            return oInstalacion;
        }


        public bool GuardarProyecto(ProyectoModel model)
        {
            //creo una variable boolean
            bool respuesta;
            try
            {
                var cn = new Conexion();
                //utlizar la cadena para establecer la cadena de conexion
                using (var conexion = new SqlConnection(cn.getPortafolioContext()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarProyecto", conexion);
                    //enviado un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Lenguaje", model.Lenguaje);
                    cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
                    cmd.Parameters.AddWithValue("Link", model.Link);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //ejecutar el procedimiento almacennado
                    cmd.ExecuteNonQuery();
                }
                //si no ocurre un error la variable respuesta sera true
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool EditarProyecto(ProyectoModel model)
        {
            //creo una variable boolean
            bool respuesta;
            try
            {
                var cn = new Conexion();
                //utlizar la cadena para establecer la cadena de conexion
                using (var conexion = new SqlConnection(cn.getPortafolioContext()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarProyecto", conexion);
                    //enviado un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("idProyecto", model.IdProyecto);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Lenguaje", model.Lenguaje);
                    cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);

                    cmd.Parameters.AddWithValue("Link", model.Link);

                    cmd.CommandType = CommandType.StoredProcedure;
                    //ejecutar el procedimiento almacennado
                    cmd.ExecuteNonQuery();
                }
                //si no ocurre un error la variable respuesta sera true
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool EliminarProyecto(int IdProyecto)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getPortafolioContext()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarProyecto", conexion);
                    cmd.Parameters.AddWithValue("IdProyecto", IdProyecto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
