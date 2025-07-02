using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class Calendar
{
    public DateTime CalendarDate { get; set; }

    public byte DayOfMonthNum { get; set; }

    public string DaySuffix { get; set; } = null!;

    public string DayOfWeekName { get; set; } = null!;

    public byte DayOfWeekNum { get; set; }

    public byte DayOfWeekInMonthNum { get; set; }

    public short DayOfYearNum { get; set; }

    public bool IsWeekend { get; set; }

    public byte WeekOfYearNum { get; set; }

    public byte ISOWeekOfYearNum { get; set; }

    public DateTime FirstDateOfWeek { get; set; }

    public DateTime LastDateOfWeek { get; set; }

    public byte WeekOfMonthNum { get; set; }

    public byte MonthOfTheYearNum { get; set; }

    public string MonthOfYearName { get; set; } = null!;

    public DateTime FirstDateOfMonth { get; set; }

    public DateTime LastDateOfMonth { get; set; }

    public DateTime FirstDateOfNextMonth { get; set; }

    public DateTime LastDateOfNextMonth { get; set; }

    public byte QuarterNum { get; set; }

    public DateTime FirstDateOfQuarter { get; set; }

    public DateTime LastDateOfQuarter { get; set; }

    public short? CalendarYear { get; set; }

    public short? ISOCalendarYearValue { get; set; }

    public DateTime FirstDateOfYear { get; set; }

    public DateTime LastDateOfYear { get; set; }

    public bool IsLeapYear { get; set; }

    public bool Has53Weeks { get; set; }

    public bool Has53ISOWeeks { get; set; }

    public bool IsIMMDate { get; set; }
}
