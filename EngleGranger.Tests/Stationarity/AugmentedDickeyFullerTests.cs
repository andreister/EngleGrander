using EngleGranger.Stationarity;
using NUnit.Framework;

namespace EngleGranger.Tests.Stationarity
{
	[TestFixture]
	public class AugmentedDickeyFullerTests
	{
		[Test]
		public void PredictsStationarity()
		{
			var series = Helper.CreateTimeSeries();

			var checker = new AugmentedDickeyFuller();
			var result = checker.IsStationary(series);

			Assert.That(result, Is.False, "Random series is not stationary");
		}
	}
}
