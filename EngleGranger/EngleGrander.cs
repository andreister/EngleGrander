using EngleGranger.LinearRegression;
using EngleGranger.Stationarity;

namespace EngleGranger
{
	public class EngleGrander
	{
		private readonly IRegression _regression;
		private readonly IStationarityChecker _stationarityChecker;

		public EngleGrander(IRegression regression = null, IStationarityChecker checker = null)
		{
			_regression = regression ?? new SimpleLinearRegression();
			_stationarityChecker = checker ?? new AugmentedDickeyFuller();
		}

		public bool IsCointegrated(TimeSeries a, TimeSeries b)
		{
			var model = _regression.Run(a - b);
			return _stationarityChecker.IsStationary(model.Residuals);
		}
	}
}
