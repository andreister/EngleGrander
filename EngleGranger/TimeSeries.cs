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
			Values = (values != null) ? new SortedDictionary<DateTime, decimal>(values) : new SortedDictionary<DateTime, decimal>();
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

		public TimeSeries Diff()
		{
			var result = new TimeSeries(null);

			var previous = decimal.MinValue;
			foreach (var pair in this) {
				var current = pair.Value;
				if (previous == decimal.MinValue) {
					//we're at start
					previous = current;
					continue;
				}
				
				result.Values.Add(pair.Key, current - previous);
				previous = current;
			}

			return result;
		}
	}
}
