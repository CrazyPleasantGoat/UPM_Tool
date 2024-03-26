using System;

namespace BigDevil.Tool.Runtime
{
    public class MiscUtility
    {
        /// <summary>
        /// 获取唯一id
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetUid(object obj = null)
        {
            return null != obj ? obj.GetHashCode().ToString() : Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 获取大小
        /// </summary>
        /// <param name="byteSize"></param>
        /// <returns></returns>
        public static string GetByteSize(ulong byteSize)
        {
            const double num = 1024;
            if (byteSize < num)
            {
                return byteSize + "B";
            }

            if (byteSize < Math.Pow(num, 2))
            {
                return (byteSize / num).ToString("f2") + "K";
            }

            if (byteSize < Math.Pow(num, 3))
            {
                return (byteSize / Math.Pow(num, 2)).ToString("f2") + "M";
            }

            if (byteSize < Math.Pow(num, 4))
            {
                return (byteSize / Math.Pow(num, 3)).ToString("f2") + "G";
            }

            return (byteSize / Math.Pow(num, 4)).ToString("f2") + "T";
        }
    }
}