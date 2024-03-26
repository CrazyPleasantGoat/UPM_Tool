using System.IO;
using UnityEngine;

namespace BigDevil.Tool.Runtime
{
    public static class PathUtility
    {
        /// <summary>
        /// 工程目录
        /// </summary>
        public static string ProjectDir => Directory.GetParent(Application.dataPath).FullName;

        /// <summary>
        /// 缓存数据目录
        /// </summary>
        public static string CacheDataDir
        {
            get
            {
                string path;
                switch (Application.platform)
                {
                    case RuntimePlatform.WindowsEditor or RuntimePlatform.WindowsPlayer:
                        path = Path.Combine(ProjectDir, "CacheData");
                        break;
                    case RuntimePlatform.OSXEditor or RuntimePlatform.OSXPlayer:
                        path = Path.Combine(ProjectDir, "CacheData");
                        break;
                    default:
                        path = Path.Combine(Application.persistentDataPath, "CacheData");
                        break;
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        /// <summary>
        /// AssetBundle目录
        /// </summary>
        public static string AssetBundleDir
        {
            get
            {
                string path = Path.Combine(CacheDataDir, "AssetBundle");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        /// <summary>
        /// 安装包目录
        /// </summary>
        public static string PackageDir
        {
            get
            {
                string path = Path.Combine(CacheDataDir, "Package");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        /// <summary>
        /// 玩家数据目录
        /// </summary>
        public static string UserDataDir
        {
            get
            {
                string path = Path.Combine(CacheDataDir, "UserData");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        /// <summary>
        /// 配置目录
        /// </summary>
        public static string ConfigDir
        {
            get
            {
                string path = Path.Combine(CacheDataDir, "Config");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        /// <summary>
        /// 图片目录
        /// </summary>
        public static string ImageDir
        {
            get
            {
                string path = Path.Combine(CacheDataDir, "Image");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        /// <summary>
        /// 音频目录
        /// </summary>
        public static string AudioDir
        {
            get
            {
                string path = Path.Combine(CacheDataDir, "Audio");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        /// <summary>
        /// 视频目录
        /// </summary>
        public static string VideoDir
        {
            get
            {
                string path = Path.Combine(CacheDataDir, "Video");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        /// <summary>
        /// 其他目录
        /// </summary>
        public static string OtherDir
        {
            get
            {
                string path = Path.Combine(CacheDataDir, "Other");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        /// <summary>
        /// 转Web路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string WebPath(this string path)
        {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor or RuntimePlatform.WindowsPlayer:
                    return Path.GetFullPath(path);
                case RuntimePlatform.OSXEditor or RuntimePlatform.OSXPlayer or RuntimePlatform.IPhonePlayer:
                    return $"file://{path}";
                default:
                    return path;
            }
        }

        /// <summary>
        /// 格式化路径(\转/)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string FormatPath(this string path)
        {
            return path.Replace("\\", "/");
        }
    }
}