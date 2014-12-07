using System;
using System.Collections.Generic;
using EngleGranger.LinearRegression;
using NUnit.Framework;

namespace EngleGranger.Tests.LinearRegression
{
	[TestFixture]
	public class SimpleLinearRegressionTests
	{
		private readonly Random _random = new Random();

		[Test]
		public void ExactSlopeAndIntercept()
		{
			var intercept = 6.2m;
			var slope = 1.4m;
			var timeSeries = CreateTimeSeries(intercept, slope);

			var regression = new SimpleLinearRegression();
			var model = regression.Run(timeSeries);

			Assert.That(model.Slope, Is.EqualTo(slope), "Incorrect slope");
			Assert.That(model.Intercept, Is.EqualTo(intercept), "Incorrect intercept");
		}
		
		[Test]
		public void NoisedSlopeAndIntercept()
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
			var today = DateTime.Today;
			return new TimeSeries(new Dictionary<DateTime, decimal> {
				{today,				GetValue(0, intercept, slope, noise)},
				{today.AddDays(1),	GetValue(1, intercept, slope, noise)},
				{today.AddDays(2),	GetValue(2, intercept, slope, noise)},
				{today.AddDays(3),	GetValue(3, intercept, slope, noise)},
				{today.AddDays(4),	GetValue(4, intercept, slope, noise)},
				{today.AddDays(5),	GetValue(5, intercept, slope, noise)},
			});
		}

		private decimal GetValue(int x, decimal intercept, decimal slope, bool noise = false)
		{
			var y = intercept + x*slope;
			if (noise) {
				y += ((decimal)_random.Next(-10, 10))/1000;
			}
			return y;
		}
	}
}
