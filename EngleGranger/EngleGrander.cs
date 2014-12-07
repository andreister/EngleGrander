using EngleGranger.LinearRegression;
using EngleGranger.Stationarity;

namespace EngleGranger
{
	public class EngleGrander
	{
		private readonly IRegression _regression;
		private readonly IStationarityTest _stationarityTest;

		public EngleGrander(IRegression regression = null, IStationarityTest stationarityTest = null)
		{
			_regression = regression ?? new SimpleLinearRegression();
			_stationarityTest = stationarityTest ?? new AugmentedDickeyFullerTest();
		}

		public bool IsCointegrated(TimeSeries a, TimeSeries b)
		{
			var model = _regression.Run(a - b);
			return _stationarityTest.IsStationary(model.Residuals);
		}
	}
}
