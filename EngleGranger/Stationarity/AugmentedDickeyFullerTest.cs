namespace EngleGranger.Stationarity
{
	/// <summary>
	/// Augmented Dickey–Fuller test
	/// </summary>
	public class AugmentedDickeyFullerTest : IStationarityTest
	{
		public bool IsStationary(TimeSeries residuals)
		{
			return false;
		}
	}
}
