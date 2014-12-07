using System;

namespace EngleGranger.LinearRegression
{
	/// <summary>
	/// Simple linear regression, as per http://en.wikipedia.org/wiki/Simple_linear_regression#Fitting_the_regression_line.
	/// Slope=cov(x,y)/var(x)
	/// </summary>
	public class SimpleLinearRegression : IRegression
	{
		public Model Run(TimeSeries timeSeries)
		{
			var means = GetMeans(timeSeries);

			decimal covariance = 0;
			decimal variance = 0;

			var x = 0m;
			var y = 0m;
			foreach (var pair in timeSeries.Values) {
				y = pair.Value;
				covariance += (x - means.Item1) * (y - means.Item2);
				variance += (decimal)Math.Pow((double)(x - means.Item1), 2);
				x++;
			}

			var slope = covariance / variance;
			var intercept = means.Item2 - slope * means.Item1;
			return new Model(slope, intercept);
		}

		private static Tuple<decimal, decimal> GetMeans(TimeSeries timeSeries)
		{
			var total = 0;
			var xTotal = 0m;
			var yTotal = 0m;
			foreach (var value in timeSeries.Values) {
				total++;
				xTotal += (total-1);
				yTotal += value.Value;
			}

			return Tuple.Create(xTotal/total, yTotal/total);
		}
	}
}
