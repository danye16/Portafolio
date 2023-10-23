using System.Data.SqlClient;
namespace Portafolio.Datos
{
    public class Conexion
    {
        private string PortafolioContext = string.Empty;
        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            PortafolioContext = builder.GetSection("ConnectionStrings:cadenaSql").Value;
        }

        public string getPortafolioContext()
        {
            return PortafolioContext;
        }
    }
}
