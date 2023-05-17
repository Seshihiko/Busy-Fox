using System;

namespace Architecture
{
    public static class TimeConverter
    {
        public static string Convert(float value)
        {
            TimeSpan _time = TimeSpan.FromSeconds(value);
            return $"{_time.Minutes.ToString("00")}:{_time.Seconds.ToString("00")}:{_time.Milliseconds.ToString("000")}";
        }
    }
}