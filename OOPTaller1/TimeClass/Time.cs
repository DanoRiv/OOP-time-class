namespace TimeClass;

public class Time
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

    public Time()
    {
        _hour = 0;
        _minute = 0;
        _second = 0;
        _millisecond = 0;
    }

    public Time(int hour)
    {
        _hour = ValidateHour(hour);
    }

    public Time(int hour, int minute)
    {
        _hour = ValidateHour(hour);
        _minute = ValidateMinute(minute);
    }

    public Time(int hour, int minute, int second)
    {
        _hour = ValidateHour(hour);
        _minute = ValidateMinute(minute);
        _second = ValidateSecond(second);
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        _hour = ValidateHour(hour);
        _minute = ValidateMinute(minute);
        _second = ValidateSecond(second);
        _millisecond = ValidateMillisecond(millisecond);
    }

    public int Hour
    {
        get => _hour;
        set => _hour = ValidateHour(value);
    }

    public int Minute
    {
        get => _minute;
        set => _minute = ValidateMinute(value);
    }

    public int Second
    {
        get => _second;
        set => _second = ValidateSecond(value);
    }

    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidateMillisecond(value);
    }


    private int ValidateHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentException($"The hour: {hour}, is not valid");
        }
        return hour;
    }

    private int ValidateMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentException($"The minute: {minute}, is not valid");
        }
        return minute;
    }

    private int ValidateSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new ArgumentException($"The second: {second}, is not valid");
        }
        return second;
    }

    private int ValidateMillisecond(int milllisecond)
    {
        if (milllisecond < 0 || milllisecond > 999)
        {
            throw new ArgumentException($"The milllisecond: {milllisecond}, is not valid");
        }
        return milllisecond;
    }

    public override string ToString()
    {
        string meridiemIndicator = _hour < 12 ? "AM" : "PM";
        int hour = _hour > 12 ? _hour - 12 : _hour;
        return $"{hour:D2}:{_minute:D2}:{_second:D2}:{_millisecond:D3} {meridiemIndicator}";
    }

    public int ToMinutes()
    {
        return _hour * 60 + _minute;
    }

    public int ToSeconds()
    {
        return _hour * 3600 + _minute * 60 + _second;
    }

    public int ToMilliseconds()
    {
        return _hour * 3600000 + _minute * 60000 + _second * 1000 + _millisecond;
    }

    public Time Add(Time time)
    {
        int totalHours = _hour + time.Hour;
        int totalMinutes = _minute + time.Minute;
        int totalSeconds = _second + time.Second;
        int totalMilliseconds = _millisecond + time.Millisecond;

        totalSeconds += totalMilliseconds / 1000;
        totalMilliseconds %= 1000;

        totalMinutes += totalSeconds / 60;
        totalSeconds %= 60;

        totalHours += totalMinutes / 60;
        totalMinutes %= 60;

        totalHours %= 24;

        return new Time(totalHours, totalMinutes, totalSeconds, totalMilliseconds);

    }

    public bool IsOtherDay(Time time)
    {
        int totalHours = _hour + time.Hour;
        int totalMinutes = _minute + time.Minute;
        int totalSeconds = _second + time.Second;
        int totalMilliseconds = _millisecond + time.Millisecond;

        totalSeconds += totalMilliseconds / 1000;
        totalMilliseconds %= 1000;

        totalMinutes += totalSeconds / 60;
        totalSeconds %= 60;

        totalHours += totalMinutes / 60;
        totalMinutes %= 60;

        return totalHours >= 24;
    }
}