namespace Backend.Models
{
    public class ErrorRequest
    {
        // Lista de mediciones proporcionadas en la solicitud.
        // Esta propiedad almacena los datos que se utilizarán para calcular el error.
        // get; set; permite leer y modificar la lista de datos. 
        //   Son algo que se suelen poner para poder manipular la estructura de datos.       
        public List<double> Data { get; set; } = new List<double>();
    }
}