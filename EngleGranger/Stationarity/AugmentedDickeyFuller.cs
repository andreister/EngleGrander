using System;

namespace EngleGranger.Stationarity
{
	/// <summary>
	/// Augmented Dickey–Fuller test
	/// </summary>
	public class AugmentedDickeyFuller : IStationarityChecker
	{
		public bool IsStationary(TimeSeries residuals)
		{
			var lag = (int)Math.Truncate(Math.Pow(residuals.Values.Count - 1, (double)1/3)) + 1;
			var diff = residuals.Diff();

			var m = residuals.Values.Count - lag + 1;

			return false;
		}
	}
}
