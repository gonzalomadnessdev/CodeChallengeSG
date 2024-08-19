namespace CuentaService.Services.Exceptions
{
    public class CashInFailedException : Exception
    {
        internal string? _message = "Ha ocurrido un error al depositar.";
    }
}
