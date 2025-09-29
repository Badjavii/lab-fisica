using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers
{

    // Aqui estamos definiendo un controlador de errores que hereda de ControllerBase.
    // La clase ControllerBase proporciona funcionalidades básicas para manejar solicitudes HTTP.
    // El atributo [ApiController] indica que este controlador se utiliza en una API web.
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        // Inyectamos el servicio ErrorCalculator a través del constructor.
        private readonly ErrorCalculator _calculator;

        // Constructor que recibe una instancia de ErrorCalculator.
        // Esto permite que el controlador utilice los métodos definidos en ErrorCalculator.
        // El constructor inicializa el campo _calculator con la instancia proporcionada.
        public ErrorController()
        {
            _calculator = new ErrorCalculator();
        }

        // Definimos una acción HTTP POST que recibe un objeto Measurement en el cuerpo de la solicitud.
        // El atributo [HttpPost] indica que este método maneja solicitudes POST.
        // El atributo [FromBody] indica que el parámetro request se obtiene del cuerpo de la solicitud HTTP.
        // Este metodo se llama CalculateError y devuelve un ActionResult de tipo ErrorResult.
        [HttpPost]
        public ActionResult<ErrorResult> CalculateError([FromBody] ErrorRequest request)
        {

            // Validamos que el objeto request no sea nulo y que contenga datos.
            if (request == null || request.Data == null || request.Data.Count == 0)
            {
                return BadRequest("No se proporcionaron datos de medición.");
            }

            // Llamamos al método CalculateError del servicio ErrorCalculator para calcular el error.
            // Pasamos los datos de medición recibidos en la solicitud.
            var resultado = _calculator.Calculate(request.Data);
            // Devolvemos el resultado envuelto en un ActionResult.
            return Ok(resultado);
        }

    }

}