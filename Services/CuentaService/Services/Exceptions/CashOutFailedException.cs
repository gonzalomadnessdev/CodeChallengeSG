namespace CuentaService.Services.Exceptions
{
    public class CashOutFailedException : Exception
    {
        internal string? _message = "Ha ocurrido un error al retirar.";
    }
}
