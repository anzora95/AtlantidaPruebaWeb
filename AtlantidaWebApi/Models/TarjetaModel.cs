namespace AtlantidaWebApi.Models
{
    public class TarjetaModel
    {
        public string NumeroTarjeta { get; set; }
        public string NombrePropietario { get; set; }
        public decimal SaldoActual { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal SaldoDisponible { get; set; }
    }
}
