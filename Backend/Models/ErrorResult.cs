namespace Backend.Models
{
    public class ErrorResult
    {

        // Valor más probable calculado a partir de los datos.
        public double mostProbableValue { get; set; }
        // Desviación estándar de los datos.
        public double standardDeviation { get; set; }
        // Lista de valores atípicos identificados en los datos.
        public List<double> outliers { get; set; } = new List<double>();
        // Varianza de los datos.
        public double variance { get; set; }
        // Error absoluto calculado a partir de los datos.
        public double absoluteError { get; set; }

        public string note
        {
            get
            {
                return "Los valores atípicos son aquellos que se encuentran fuera del rango de 3 desviaciones estándar desde el valor más probable.";
            }
        }

    }
}