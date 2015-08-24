using System;

namespace CodeHelpers.Time
{
	public class DateTimeInfo
	{
		public DateTimeInfo(DateTime dateTimeLocal, DateTime dateTimeUtc)
		{
			this.Local = dateTimeLocal;
			this.Utc = dateTimeUtc;
		}

		public DateTime Utc { get; private set; }
		public DateTime Local { get; private set; }
	}
}