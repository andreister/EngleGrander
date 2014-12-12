namespace EngleGranger.Stationarity
{
	public interface IStationarityChecker
	{
		bool IsStationary(TimeSeries residuals);
	}
}
