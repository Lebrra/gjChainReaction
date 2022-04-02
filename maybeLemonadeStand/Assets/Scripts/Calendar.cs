using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Calendar
{
    // day 1 = April 1st

    public static Date GetDate(int day)
    {
        Date date = new Date();

        var monthAndDay = GetMonthAndDay(day);
        date.month = monthAndDay.Item1;
        date.day = monthAndDay.Item2;
        date.season = GetSeason(date.month);
        date.year = (day / 365) + 1;
        date.weekday = GetWeekday(day);

        return date;
    }

    public static Season GetSeason(int day)
    {
        return GetSeason(GetMonthAndDay(day).Item1);
    }

    public static Season GetSeason(Month month)
    {
        if (month == Month.December || month == Month.January || month == Month.February) return Season.Winter;
        else if (month == Month.March || month == Month.April || month == Month.May) return Season.Spring;
        else if (month == Month.June || month == Month.July || month == Month.August) return Season.Summer;
        else if (month == Month.September || month == Month.October || month == Month.November) return Season.Fall;
        else return Season.Spring;
    }

    public static (Month, int) GetMonthAndDay(int day)
    {
        Month month = Month.April;
        int dayProgress = ProgressMonth(month, day);
        while(day != dayProgress)
        {
            //Debug.Log(month + " - " + day + " - " + dayProgress);
            month = GetNextMonth(month);
            day = dayProgress;
            dayProgress = ProgressMonth(month, day);
        }
        return (month, dayProgress);
    }

    public static Weekday GetWeekday(int day)
    {
        int weekdayNum = day % 7;

        switch (weekdayNum)
        {
            case 1: return Weekday.Friday;
            case 2: return Weekday.Saturday;
            case 3: return Weekday.Sunday;
            case 4: return Weekday.Monday;
            case 5: return Weekday.Tuesday;
            case 6: return Weekday.Wednesday;
            default: return Weekday.Thursday;
        }
    }

    /// <summary>
    /// If the same number is returned, don't progress month
    /// </summary>
    static int ProgressMonth(Month month, int day)
    {
        switch (month)
        {
            case Month.February:    // 28
                if (day > 28) return day - 28;
                else return day;


            case Month.April:       // 30
                if (day > 30) return day - 30;
                else return day;
            case Month.June:
                if (day > 30) return day - 30;
                else return day;
            case Month.September:
                if (day > 30) return day - 30;
                else return day;
            case Month.November:
                if (day > 30) return day - 30;
                else return day;


            default:                // 31
                if (day > 31) return day - 31;
                else return day;
        }

        return -7;
    }

    static Month GetNextMonth(Month month)
    {
        switch (month)
        {
            case Month.January:
                return Month.February;
            case Month.February:
                return Month.March;
            case Month.March:
                return Month.April;
            case Month.April:
                return Month.May;
            case Month.May:
                return Month.June;
            case Month.June:
                return Month.July;
            case Month.July:
                return Month.August;
            case Month.August:
                return Month.September;
            case Month.September:
                return Month.October;
            case Month.October:
                return Month.November;
            case Month.November:
                return Month.December;
            case Month.December:
                return Month.January;

            default:
                return Month.April;
        }
    }

    public static string DateToString(Date date)
    {
        return date.weekday + " - " + date.month + " " + date.day + ", year " + date.year + " (" + date.season + ")";
    }
}

public enum Season
{
    Spring,
    Summer,
    Fall,
    Winter
}

public enum Month
{
    January,        // 31
    February,       // 28
    March,          // 31
    April,          // 30
    May,            // 31
    June,           // 30
    July,           // 31
    August,         // 31
    September,      // 30
    October,        // 31
    November,       // 30
    December        // 31
}

public enum Weekday
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public struct Date
{
    public Month month;
    public int day;
    public int year;

    public Weekday weekday;
    public Season season;
}