namespace CodeHelpers.Time
{
	public interface ITimeProvider
	{
		DateTimeInfo GetDateTime();
		void ClearCache();
		string GetCurrentWeekDayName();
	}
}