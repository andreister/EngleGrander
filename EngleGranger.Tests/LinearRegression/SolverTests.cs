using System;
using EngleGranger.LinearRegression;
using NUnit.Framework;

namespace EngleGranger.Tests.LinearRegression
{
	[TestFixture]
	public class SolverTests
	{
		private readonly Random _random = new Random();

		[Test]
		public void ExactSlopeAndIntercept()
		{
			var intercept = 6.2m;
			var slope = 1.4m;
			var timeSeries = CreateTimeSeries(intercept, slope);

			var solver = new SimpleLinearRegression();
			var model = solver.Run(timeSeries);

			Assert.That(model.Slope, Is.EqualTo(slope), "Incorrect slope");
			Assert.That(model.Intercept, Is.EqualTo(intercept), "Incorrect intercept");
		}
		
		[Test]
		public void NoiseSlopeAndIntercept()
		{
			var slope = 1.4m;
			var intercept = 6.2m;
			var timeSeries = CreateTimeSeries(intercept, slope, true);

			var solver = new SimpleLinearRegression();
			var model = solver.Run(timeSeries);

			Assert.That(model.Slope, Is.EqualTo(slope).Within(0.01), "Incorrect slope");
			Assert.That(model.Intercept, Is.EqualTo(intercept).Within(0.01), "Incorrect intercept");
		}

		private TimeSeries CreateTimeSeries(decimal intercept, decimal slope, bool noise = false)
		{
			return new TimeSeries(new[] {
				CreateDataPoint(0, intercept, slope, noise),
				CreateDataPoint(1, intercept, slope, noise),
				CreateDataPoint(2, intercept, slope, noise),
				CreateDataPoint(3, intercept, slope, noise),
				CreateDataPoint(4, intercept, slope, noise),
				CreateDataPoint(5, intercept, slope, noise)
			});
		}

		private Tuple<DateTime, decimal> CreateDataPoint(int days, decimal intercept, decimal slope, bool noise = false)
		{
			var x = DateTime.Today.AddDays(days);
			var y = intercept + days*slope;
			if (noise) {
				y += ((decimal)_random.Next(-10, 10))/1000;
			}
			return Tuple.Create(x, y);
		}
	}
}
