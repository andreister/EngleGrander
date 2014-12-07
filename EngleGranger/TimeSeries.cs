using System;
using System.Collections.Generic;
using System.Linq;

namespace EngleGranger
{
	public class TimeSeries : IEnumerable<KeyValuePair<DateTime, decimal>>
	{
		public IDictionary<DateTime, decimal> Values { get; private set; }

		public TimeSeries(IDictionary<DateTime, decimal> values)
		{
			Values = values;
		}

		public decimal this[DateTime date]
		{
			get { return Values[date]; }
		} 

		public IEnumerator<KeyValuePair<DateTime, decimal>> GetEnumerator()
		{
			return Values.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public static TimeSeries operator -(TimeSeries a, TimeSeries b)
		{
			var result = a.ToDictionary(x => x.Key, x => a[x.Key] - b[x.Key]);
			return new TimeSeries(result);
		}
	}
}
