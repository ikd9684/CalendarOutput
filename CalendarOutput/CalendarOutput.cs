using System;

namespace jp._9684.utils
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="date"></param>
    public delegate void CalendarOutputAction(DateTime date);

    /// <summary>
    /// 
    /// </summary>
    public class CalendarOutput
    {
        /// <summary>
        /// 
        /// </summary>
        private DateTime startDate;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        public CalendarOutput(int year, int month)
        {
            this.startDate = new DateTime(year, month, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public void ForEachAtOneMonth(CalendarOutputAction action)
        {
            // 対象月の１日の曜日
            DayOfWeek firstWeekOfMonth = this.startDate.DayOfWeek;
            // 出力する最初（月曜日）の日付
            DateTime firstDateOfWeek = this.startDate.AddDays(0 - (int)firstWeekOfMonth);
            // 翌月の１日
            DateTime firstDateOfNextMonth = this.startDate.AddMonths(1);

            // 出力する最初の日付のコピーを取得
            DateTime date = firstDateOfWeek.AddDays(0);

            while (date.DayOfWeek < firstWeekOfMonth)
            {
                action(date);
                date = date.AddDays(1);
            }
            while (date < firstDateOfNextMonth)
            {
                action(date);
                date = date.AddDays(1);
            }
            while (date.DayOfWeek != DayOfWeek.Sunday)
            {
                action(date);
                date = date.AddDays(1);
            }
        }

    }
}
