using System;
using System.Diagnostics;

namespace jp._9684.utils
{
    public class CalendarOutputExample
    {
        static void Main(string[] args)
        {
            int targetYear;
            int targetMonth;
            if (args.Length == 2)
            {
                targetYear = int.Parse(args[0]);
                targetMonth = int.Parse(args[1]);
            }
            else
            {
                targetYear = DateTime.Now.Year;
                targetMonth = DateTime.Now.Month;
            }
            CalendarOutput cout = new CalendarOutput(targetYear, targetMonth);

            WriteLine("");
            WriteLine(string.Format("{0} / {1}", targetYear, targetMonth));
            WriteLine("_Sun______Mon______Tue______Wed______Thu______Fri______Sat_");

            cout.ForEachAtOneMonth((date) =>
            {
                string dd = string.Format("{0, 2}", date.Day);

                if (date.Month == targetMonth)
                {
                    Write(string.Format("[ {0} ]", dd));
                }
                else
                {
                    Write(string.Format("  {0}  ", dd));
                }

                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    WriteLine("");
                }
                else
                {
                    Write("   ");
                }
            });
            WriteLine("");
        }

        private static void WriteLine(object value)
        {
            Write(value);
            Write(Environment.NewLine);
        }
        private static void Write(object value)
        {
            Console.Write(value);
#if DEBUG
            Debug.Write(value);
#endif
        }
    }
}
