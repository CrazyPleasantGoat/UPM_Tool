using System;
using System.Globalization;

namespace BigDevil.Tool.Runtime
{
    public class TimeUtility
    {
        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <param name="isUtc">是否是Utc</param>
        /// <param name="isMilliSecond">是否是毫秒</param>
        /// <returns></returns>
        public static long GetTimeStamp(bool isUtc = true, bool isMilliSecond = false)
        {
            if (isUtc)
            {
                return isMilliSecond ? DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() : DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            }

            return isMilliSecond ? DateTimeOffset.Now.ToUnixTimeMilliseconds() : DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        /// <summary>
        /// 获当前取时间
        /// </summary>
        /// <param name="format">格式</param>
        /// <param name="isUtc">是否是Utc</param>
        /// <returns></returns>
        public static string GetTime(string format = "yyyy-MM-dd HH:mm:ss", bool isUtc = true)
        {
            return isUtc ? DateTime.UtcNow.ToString(format) : DateTime.Now.ToString(format);
        }

        /// <summary>
        /// 时间转时间戳
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="isMilliSecond">是否是毫秒</param>
        /// <returns></returns>
        public static long TimeToTimeStamp(string time, bool isMilliSecond = false)
        {
            DateTime dateTime = DateTime.Parse(time);
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
            return isMilliSecond ? dateTimeOffset.ToUnixTimeMilliseconds() : dateTimeOffset.ToUnixTimeSeconds();
        }

        /// <summary>
        /// 时间戳转时间
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="format">格式</param>
        /// /// <param name="isMilliSecond">是否是毫秒</param>
        /// <returns></returns>
        public static string TimeStampToTime(long timeStamp, string format = "yyyy-MM-dd HH:mm:ss", bool isMilliSecond = false)
        {
            DateTime initTime = new DateTime(1970, 1, 1);
            DateTime time = isMilliSecond ? initTime.AddMilliseconds(timeStamp) : initTime.AddSeconds(timeStamp);
            return time.ToString(format);
        }

        /// <summary>
        /// UTC时间转本地时间
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static string UTCTimeToLocalTime(string time, string format = "yyyy-MM-dd HH:mm:ss")
        {
            string[] strs = { "yyyy-MM-ddTHH:mm:ss.fZ", "yyyy-MM-ddTHH:mm:ss.ffZ", "yyyy-MM-ddTHH:mm:ss.fffZ" };
            DateTime dateTime = DateTime.ParseExact(time, strs, CultureInfo.InvariantCulture);
            return dateTime.ToString(format);
        }

        /// <summary>
        /// 时间戳转时长(天，小时，分，秒)
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="day">天</param>
        /// <param name="hour">小时</param>
        /// <param name="minute">分</param>
        /// <param name="second">秒</param>
        /// <param name="isMilliSecond">是否是毫秒</param>
        /// <returns></returns>
        public static string TimeStampToDHMS(long timeStamp, string day = "天", string hour = "时", string minute = "分", string second = "秒", bool isMilliSecond = false)
        {
            TimeSpan time = isMilliSecond ? new TimeSpan(0, 0, 0, 0, (int)timeStamp) : new TimeSpan(0, 0, 0, (int)timeStamp);
            return $"{time.Days}{day}{time.Hours}{hour}{time.Minutes}{minute}{time.Seconds}{second}";
        }

        /// <summary>
        /// 时间戳转时长(小时，分，秒)
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <param name="hour">小时</param>
        /// <param name="minute">分</param>
        /// <param name="second">秒</param>
        /// <param name="isMilliSecond">是否是毫秒</param>
        /// <returns></returns>
        public static string TimeStampToHMS(long timeStamp, string hour = ":", string minute = ":", string second = "", bool isMilliSecond = false)
        {
            TimeSpan time = isMilliSecond ? new TimeSpan(0, 0, 0, 0, (int)timeStamp) : new TimeSpan(0, 0, 0, (int)timeStamp);
            return (time.Days * 24 + time.Hours).ToString().PadLeft(2, '0') + hour + time.ToString($@"mm\{minute}ss{second}");
        }

        /// <summary>
        /// 获取当天时刻(例如:2024年1月12号的第11小时)
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="isMilliSecond">是否是毫秒</param>
        /// <returns></returns>
        public static long GetThatDayH(long timeStamp, bool isMilliSecond = false)
        {
            TimeSpan time = isMilliSecond ? new TimeSpan(0, 0, 0, 0, (int)timeStamp) : new TimeSpan(0, 0, 0, (int)timeStamp);
            return time.Hours;
        }

        /// <summary>
        /// 获取当天时刻(例如:2024年1月12号的第350分钟)
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="isMilliSecond">是否是毫秒</param>
        /// <returns></returns>
        public static long GetTimeOfDayM(long timeStamp, bool isMilliSecond = false)
        {
            TimeSpan time = isMilliSecond ? new TimeSpan(0, 0, 0, 0, (int)timeStamp) : new TimeSpan(0, 0, 0, (int)timeStamp);
            return time.Hours * 60 + time.Minutes;
        }

        /// <summary>
        /// 获取当天时刻(例如:2024年1月12号的第350秒)
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="isMilliSecond">是否是毫秒</param>
        /// <returns></returns>
        public static long GetTimeOfDayS(long timeStamp, bool isMilliSecond = false)
        {
            TimeSpan time = isMilliSecond ? new TimeSpan(0, 0, 0, 0, (int)timeStamp) : new TimeSpan(0, 0, 0, (int)timeStamp);
            return time.Hours * 60 * 60 + time.Minutes * 60 + time.Seconds;
        }

        /// <summary>
        /// 获取当天时刻(例如:2024年1月12号的第13小时30分40秒)
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="isMilliSecond">是否是毫秒</param>
        /// <returns></returns>
        public static (int, int, int) GetThatDayHMS(long timeStamp, bool isMilliSecond = false)
        {
            TimeSpan time = isMilliSecond ? new TimeSpan(0, 0, 0, 0, (int)timeStamp) : new TimeSpan(0, 0, 0, (int)timeStamp);
            return (time.Hours, time.Minutes, time.Seconds);
        }

        /// <summary>
        /// 获得时隔天数
        /// </summary>
        /// <param name="startTimeStamp">开始时间戳</param>
        /// <param name="endTimeStamp">结束时间戳</param>
        /// <param name="isMilliSecond">是否是毫秒</param>
        /// <returns></returns>
        public static double GetDayOffset(long startTimeStamp, long endTimeStamp, bool isMilliSecond = false)
        {
            TimeSpan startTimeSpan = isMilliSecond ? new TimeSpan(0, 0, 0, 0, (int)startTimeStamp) : new TimeSpan(0, 0, 0, (int)startTimeStamp);
            TimeSpan endTimeSpan = isMilliSecond ? new TimeSpan(0, 0, 0, 0, (int)endTimeStamp) : new TimeSpan(0, 0, 0, (int)endTimeStamp);
            TimeSpan offsetTimeSpan = endTimeSpan - startTimeSpan;
            return offsetTimeSpan.TotalDays;
        }

        /// <summary>
        /// 获得时隔小时
        /// </summary>
        /// <param name="startTimeStamp">开始时间戳</param>
        /// <param name="endTimeStamp">结束时间戳</param>
        /// <param name="isMilliSecond">是否是毫秒</param>
        /// <returns></returns>
        public static double GetHourOffset(long startTimeStamp, long endTimeStamp, bool isMilliSecond = false)
        {
            TimeSpan startTimeSpan = isMilliSecond ? new TimeSpan(0, 0, 0, 0, (int)startTimeStamp) : new TimeSpan(0, 0, 0, (int)startTimeStamp);
            TimeSpan endTimeSpan = isMilliSecond ? new TimeSpan(0, 0, 0, 0, (int)endTimeStamp) : new TimeSpan(0, 0, 0, (int)endTimeStamp);
            TimeSpan offsetTimeSpan = endTimeSpan - startTimeSpan;
            return offsetTimeSpan.TotalHours;
        }

        /// <summary>
        /// 获得时隔分钟
        /// </summary>
        /// <param name="startTimeStamp">开始时间戳</param>
        /// <param name="endTimeStamp">结束时间戳</param>
        /// <param name="isMilliSecond">是否是毫秒</param>
        /// <returns></returns>
        public static double GetMinuteOffset(long startTimeStamp, long endTimeStamp, bool isMilliSecond = false)
        {
            TimeSpan startTimeSpan = isMilliSecond ? new TimeSpan(0, 0, 0, 0, (int)startTimeStamp) : new TimeSpan(0, 0, 0, (int)startTimeStamp);
            TimeSpan endTimeSpan = isMilliSecond ? new TimeSpan(0, 0, 0, 0, (int)endTimeStamp) : new TimeSpan(0, 0, 0, (int)endTimeStamp);
            TimeSpan offsetTimeSpan = endTimeSpan - startTimeSpan;
            return offsetTimeSpan.TotalMinutes;
        }

        /// <summary>
        /// 获得时隔秒
        /// </summary>
        /// <param name="startTimeStamp">开始时间戳</param>
        /// <param name="endTimeStamp">结束时间戳</param>
        /// <param name="isMilliSecond">是否是毫秒</param>
        /// <returns></returns>
        public static double GetSecondOffset(long startTimeStamp, long endTimeStamp, bool isMilliSecond = false)
        {
            DateTime initTime = new DateTime(1970, 1, 1);
            DateTime startTime = isMilliSecond ? initTime.AddMilliseconds(startTimeStamp) : initTime.AddSeconds(startTimeStamp);
            DateTime endTime = isMilliSecond ? initTime.AddMilliseconds(endTimeStamp) : initTime.AddSeconds(endTimeStamp);
            TimeSpan timeSpan = endTime.Subtract(startTime);
            return timeSpan.TotalSeconds;
        }
    }
}