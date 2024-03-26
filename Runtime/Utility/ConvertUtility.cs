using System;
using System.Globalization;
using UnityEngine;

namespace BigDevil.Tool.Runtime
{
    public static class ConvertUtility
    {
        public static int ToInt(this object value)
        {
            try
            {
                return int.Parse(value.ToString(), CultureInfo.InvariantCulture);
            } catch (Exception e)
            {
                Debug.LogException(e);
                return default;
            }
        }

        public static long ToLong(this object value)
        {
            try
            {
                return long.Parse(value.ToString(), CultureInfo.InvariantCulture);
            } catch (Exception e)
            {
                Debug.LogException(e);
                return default;
            }
        }

        public static bool ToBool(this object value)
        {
            try
            {
                return Convert.ToBoolean(value);
            } catch (Exception e)
            {
                Debug.LogException(e);
                return default;
            }
        }

        public static float ToFloat(this object value)
        {
            try
            {
                return float.Parse(value.ToString(), CultureInfo.InvariantCulture);
            } catch (Exception e)
            {
                Debug.LogException(e);
                return default;
            }
        }

        public static double ToDouble(this object value)
        {
            try
            {
                return double.Parse(value.ToString(), CultureInfo.InvariantCulture);
            } catch (Exception e)
            {
                Debug.LogException(e);
                return default;
            }
        }

        public static decimal ToDecimal(this object value)
        {
            try
            {
                return decimal.Parse(value.ToString(), CultureInfo.InvariantCulture);
            } catch (Exception e)
            {
                Debug.LogException(e);
                return default;
            }
        }

        public static string ToPrecisionString(this decimal value, int precision)
        {
            try
            {
                decimal step = (decimal)Math.Pow(10, precision);
                decimal tmp = Math.Truncate(step * value);
                return (tmp / step).ToString();
            } catch (Exception e)
            {
                Debug.LogException(e);
                return string.Empty;
            }
        }
    }
}