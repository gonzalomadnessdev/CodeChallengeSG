namespace CuentaService.Models
{
    public class CuentaMovimiento
    {
        public int Id { get; }
        public int CuentaId { get; set; }
        public decimal Importe { get; set; }
        public decimal Saldo { get; }
        public DateTime FechaHora { get; }

    }
}
