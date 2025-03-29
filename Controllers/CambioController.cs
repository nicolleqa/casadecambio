using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using casadecambio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace casadecambio.Controllers
{
    public class CambioController : Controller
    {
        private readonly ILogger<CambioController> _logger;

        public CambioController(ILogger<CambioController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConvertirMoneda(Cambio cambio)
        {
          _logger.LogInformation("TIPO ORIGEN: {0}, TIPO DESTINO: {1}, MONTO ORIGEN: {2}", cambio.TipoMonedaOrigen, cambio.TipoMonedaDestino, cambio.MontoOrigen);
          if (ModelState.IsValid)
          {
              _logger.LogInformation("Model is valid. Starting conversion.");
              string mensaje = "";
              decimal montoDestino = 0;
              try
              {
                montoDestino = cambio.Convertir();
                _logger.LogInformation("Conversion result: {0}", montoDestino);
                ViewData["MontoDestino"] = montoDestino;
              }
              catch (Exception)
              {
                  mensaje = "Error al procesar la solicitud";
              }

              ViewData["Mensaje"] = mensaje;
          }
          return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}