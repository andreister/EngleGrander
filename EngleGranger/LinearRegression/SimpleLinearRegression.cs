using System;

namespace EngleGranger.LinearRegression
{
	public class SimpleLinearRegression : IRegression
	{
		/// <summary>
		/// As per http://en.wikipedia.org/wiki/Simple_linear_regression#Fitting_the_regression_line, slope=cov(x,y)/var(x)
		/// </summary>
		public Model Run(TimeSeries timeSeries)
		{
			var means = GetMeans(timeSeries);

			decimal covariance = 0;
			decimal variance = 0;

			var x = 0m;
			var y = 0m;
			foreach (var value in timeSeries.Values) {
				y = value.Item2;
				covariance += (x - means.Item1) * (y - means.Item2);
				variance += (decimal)Math.Pow((double)(x - means.Item1), 2);
				x++;
			}

			var slope = covariance / variance;
			var intercept = means.Item2 - slope * means.Item1;
			return new Model(slope, intercept);
		}

		private static Tuple<decimal, decimal> GetMeans(TimeSeries values)
		{
			var total = 0;
			var xTotal = 0m;
			var yTotal = 0m;
			foreach (var value in values.Values) {
				total++;
				xTotal += (total-1);
				yTotal += value.Item2;
			}

			return Tuple.Create(xTotal/total, yTotal/total);
		}
	}
}
