using System;
using System.Collections.Generic;

namespace EngleGranger.Tests
{
	internal static class Helper
	{
		private static readonly Random _random = new Random(123);

		internal static TimeSeries CreateTimeSeries()
		{
			var today = DateTime.Today;
			return new TimeSeries(new Dictionary<DateTime, decimal> {
				{today,				(decimal) _random.NextDouble()},
				{today.AddDays(1),	(decimal) _random.NextDouble()},
				{today.AddDays(2),	(decimal) _random.NextDouble()},
				{today.AddDays(3),	(decimal) _random.NextDouble()},
				{today.AddDays(4),	(decimal) _random.NextDouble()},
				{today.AddDays(5),	(decimal) _random.NextDouble()},
			});
		}

		internal static TimeSeries CreateTimeSeries(decimal intercept, decimal slope, bool noise = false)
		{
			var today = DateTime.Today;
			return new TimeSeries(new Dictionary<DateTime, decimal> {
				{today,				GetValue(0, intercept, slope, noise)},
				{today.AddDays(1),	GetValue(1, intercept, slope, noise)},
				{today.AddDays(2),	GetValue(2, intercept, slope, noise)},
				{today.AddDays(3),	GetValue(3, intercept, slope, noise)},
				{today.AddDays(4),	GetValue(4, intercept, slope, noise)},
				{today.AddDays(5),	GetValue(5, intercept, slope, noise)},
			});
		}

		private static decimal GetValue(int x, decimal intercept, decimal slope, bool noise = false)
		{
			var y = intercept + x * slope;
			if (noise)
			{
				y += ((decimal)_random.Next(-10, 10)) / 1000;
			}
			return y;
		}
	}
}
