namespace EngleGranger.Stationarity
{
	public interface IStationarityTest
	{
		bool IsStationary(TimeSeries residuals);
	}
}
