using AtlantidaWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
//using System.Web.Mvc;

namespace AtlantidaWebApi.Controllers
{
    [ApiController]
    public class TarjetaCuentaController : ControllerBase
    {

        private string connectionString = "Server=localhost;Database=atlantida;Trusted_Connection=True;"; // colocar cadena de conexión


        //METODO DE PRUEBA PARA LA CONEXION CON LA BASE DE DATOS POR MEDIO DE UN ENDPOINT

        [HttpPost]
        [Route("api/tarjetas/insertar")]
        [HttpPost]
        public ActionResult InsertarTarjeta([FromBody] TarjetaModel tarjeta)
        {
            if (tarjeta == null)
            {
                return BadRequest("Los datos de la tarjeta son nulos.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Tarjetas (NumeroTarjeta, NombrePropietario, SaldoActual, LimiteCredito, SaldoDisponible)
                             VALUES (@NumeroTarjeta, @NombrePropietario, @SaldoActual, @LimiteCredito, @SaldoDisponible)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NumeroTarjeta", tarjeta.NumeroTarjeta);
                command.Parameters.AddWithValue("@NombrePropietario", tarjeta.NombrePropietario);
                command.Parameters.AddWithValue("@SaldoActual", tarjeta.SaldoActual);
                command.Parameters.AddWithValue("@LimiteCredito", tarjeta.LimiteCredito);
                command.Parameters.AddWithValue("@SaldoDisponible", tarjeta.SaldoDisponible);

                connection.Open();
                command.ExecuteNonQuery();
            }

            return Ok("Tarjeta insertada exitosamente");
        }


        //METODO PARA OBTENER TARJETAS Y RETORNARLAS A LA VISTA DE TARJETAS
        [HttpGet]
        [Route("api/tarjetas")]
        public ActionResult<IEnumerable<TarjetaModel>> ObtenerTarjetas()
        {
            List<TarjetaModel> tarjetas = new List<TarjetaModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Tarjetas";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TarjetaModel tarjeta = new TarjetaModel
                    {
                        NumeroTarjeta = reader["NumeroTarjeta"].ToString(),
                        NombrePropietario = reader["NombrePropietario"].ToString(),
                        SaldoActual = Convert.ToDecimal(reader["SaldoActual"]),
                        LimiteCredito = Convert.ToDecimal(reader["LimiteCredito"]),
                        SaldoDisponible = Convert.ToDecimal(reader["SaldoDisponible"])
                    };

                    tarjetas.Add(tarjeta);
                }

                reader.Close();
            }

            return Ok(tarjetas);
        }

        [HttpPost]
        [Route("api/movimientos/insertar")]
        public ActionResult InsertarMovimiento([FromBody] MovimientoModel movimiento)
        {
            if (movimiento == null)
            {
                return BadRequest("Los datos del movimiento son nulos.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Movimientos (NumeroTarjeta, TipoMovimiento, SaldoMovimiento, FechaMovimiento)
                             VALUES (@NumeroTarjeta, @TipoMovimiento, @SaldoMovimiento, @FechaMovimiento)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NumeroTarjeta", movimiento.NumeroTarjeta);
                command.Parameters.AddWithValue("@TipoMovimiento", movimiento.TipoMovimiento);
                command.Parameters.AddWithValue("@SaldoMovimiento", movimiento.SaldoMovimiento);
                command.Parameters.AddWithValue("@FechaMovimiento", movimiento.FechaMovimiento);

                connection.Open();
                command.ExecuteNonQuery();
            }

            return Ok("Movimiento insertado exitosamente");
        }
    }
}
