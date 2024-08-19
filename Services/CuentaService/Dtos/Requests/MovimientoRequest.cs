using System.ComponentModel.DataAnnotations;

namespace CuentaService.Dtos.Requests
{
    public class MovimientoRequest
    {
        [Required]
        public decimal Importe { get; set; }
    }
}
