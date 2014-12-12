using EngleGranger.LinearRegression;
using NUnit.Framework;

namespace EngleGranger.Tests.LinearRegression
{
	[TestFixture]
	public class SimpleLinearRegressionTests
	{
		private const decimal Intercept = 6.2m;
		private const decimal Slope = 1.4m;

		[Test]
		public void ExactSlopeAndIntercept()
		{
			var timeSeries = Helper.CreateTimeSeries(Intercept, Slope);

			var regression = new SimpleLinearRegression();
			var model = regression.Run(timeSeries);

			Assert.That(model.Intercept, Is.EqualTo(Intercept), "Incorrect intercept");
			Assert.That(model.Slope, Is.EqualTo(Slope), "Incorrect slope");
		}
		
		[Test]
		public void NoisedSlopeAndIntercept()
		{
			var timeSeries = Helper.CreateTimeSeries(Intercept, Slope, true);

			var solver = new SimpleLinearRegression();
			var model = solver.Run(timeSeries);

			Assert.That(model.Intercept, Is.EqualTo(Intercept).Within(0.01), "Incorrect intercept");
			Assert.That(model.Slope, Is.EqualTo(Slope).Within(0.01), "Incorrect slope");
		}
	}
}
