using Backend.Models;

namespace Backend.Services
{
    public class ErrorCalculator
    {

        public ErrorResult Calculate(List<double> data)
        {
            double average = data.Average();
            double sumatory = data.Sum(target => Math.Pow(target - average, 2));
            double variance = sumatory / (data.Count - 1);
            double standardDeviation = Math.Sqrt(variance);
            double absoluteError = 3 * standardDeviation;

            double lower = average - 3 * standardDeviation;
            double upper = average + 3 * standardDeviation;

            List<double> outliers = new List<double>();

            foreach (double value in data)
            {
                if (value < lower || value > upper)
                {
                    outliers.Add(value);
                }
            }

            return new ErrorResult
            {
                mostProbableValue = Math.Round(average, 2),
                standardDeviation = Math.Round(standardDeviation, 2),
                outliers = outliers,
                variance = Math.Round(variance, 2),
                absoluteError = Math.Round(absoluteError, 2)
            };
        }

    }
}