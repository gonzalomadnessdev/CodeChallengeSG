namespace CuentaService.Models
{
    public class CuentaMovimiento
    {
        public int Id { get; set; }
        public int CuentaId { get; set; }
        public decimal Importe { get; set; }
        public decimal Saldo { get; set; }
        DateTime FechaHora { get; set; }

    }
}
