namespace AtlantidaWebApi.Models
{
    public class MovimientoModel
    {
        public int IdMovimiento { get; set; }
        public string NumeroTarjeta { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal SaldoMovimiento { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}
