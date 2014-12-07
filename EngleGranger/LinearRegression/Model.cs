namespace EngleGranger.LinearRegression
{
	public class Model
	{
		public decimal Slope { get; private set; }
		public decimal Intercept { get; private set; }
		public TimeSeries Residuals { get; set; }

		internal Model(decimal slope, decimal intercept)
		{
			Slope = slope;
			Intercept = intercept;
		}
	}
}