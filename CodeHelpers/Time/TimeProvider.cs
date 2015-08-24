using System;
using System.Globalization;

namespace CodeHelpers.Time
{
	public class TimeProvider : ITimeProvider
	{
		private readonly CultureInfo timeCulture;

		public TimeProvider()
			: this(CultureInfo.GetCultureInfo("en-US"))
		{
		}

		public TimeProvider(CultureInfo timeCulture)
		{
			this.timeCulture = timeCulture;
		}

		public DateTimeInfo GetDateTime()
		{
			ClearCache();
			
			return new DateTimeInfo(DateTime.Now, DateTime.UtcNow);
		}

		public void ClearCache()
		{
			CultureInfo.CurrentCulture.ClearCachedData();
		}

		public string GetCurrentWeekDayName()
		{
			var dateTimeInfo = GetDateTime();
			var weekDay = this.timeCulture.DateTimeFormat.DayNames[(int)this.timeCulture.Calendar.GetDayOfWeek(dateTimeInfo.Local)];

			return weekDay;
		}
	}
}
