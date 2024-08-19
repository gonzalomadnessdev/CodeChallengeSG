using AuthService.Repositories;
using CuentaService.Models;
using CuentaService.Repositories;
using CuentaService.Services.Exceptions;
using System.Transactions;

namespace CuentaService.Services
{
    public class CuentasMovimientosService : ICuentasMovimientosService
    {
        private ICuentaRepository _cuentaRepository;
        private ICuentaMovimientoRepository _cuentaMovimientoRepository;
        public CuentasMovimientosService(ICuentaRepository cuentaRepository, ICuentaMovimientoRepository cuuentaMovimientoRepository)
        {
            _cuentaRepository = cuentaRepository;
            _cuentaMovimientoRepository = cuuentaMovimientoRepository;
        }

        public async Task CashIn(int id, decimal importe)
        {
            try
            {
                if(importe <= 0)
                {
                    throw new Exception("Importe incorrecto.");
                }

                var cuenta = await _cuentaRepository.GetAsync(id);
                if (cuenta == null)
                {
                    throw new Exception("Cuenta no encontrada.");
                }

                decimal nuevoSaldo = cuenta.Saldo + importe;

                var result = await _cuentaMovimientoRepository.Crear(new CuentaMovimiento { CuentaId = id, Importe = importe, Saldo = nuevoSaldo });

                if (!result)
                {
                    throw new Exception("Error al crear movimiento.");
                }

            }
            catch
            {
                throw new CashInFailedException();
            }

        }

        public async Task CashOut(int id, decimal importe)
        {
            try
            {
                if (importe <= 0)
                {
                    throw new Exception("Importe incorrecto.");
                }

                var cuenta = await _cuentaRepository.GetAsync(id);
                if (cuenta == null)
                {
                    throw new Exception("Cuenta no encontrada.");
                }

                if (importe > cuenta.Saldo)
                {
                    throw new Exception("Saldo insuficiente.");
                }

                decimal nuevoSaldo = cuenta.Saldo - importe;

                var result = await _cuentaMovimientoRepository.Crear(new CuentaMovimiento { CuentaId = id, Importe = (-1 * importe), Saldo = nuevoSaldo });

                if (!result)
                {
                    throw new Exception("Error al crear movimiento.");
                }

            }
            catch
            {
                throw new CashOutFailedException();
            }

        }


    }
}
