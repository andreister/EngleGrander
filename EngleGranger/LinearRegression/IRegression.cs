namespace EngleGranger.LinearRegression
{
	public interface IRegression
	{
		Model Run(TimeSeries values);
	}
}