using System;
using System.IO;
using UnityEngine;

namespace BigDevil.Tool.Runtime
{
    public static class DirectoryUtility
    {
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static bool Exists(string path)
        {
            try
            {
                return !string.IsNullOrEmpty(path) && Directory.Exists(path);
            } catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static bool Create(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path) || Directory.Exists(path))
                {
                    return false;
                }

                Directory.CreateDirectory(path);
                return true;
            } catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }
        }

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="srcPath">源路径</param>
        /// <param name="dstPath">目标路径</param>
        /// <returns></returns>
        public static bool Move(string srcPath, string dstPath)
        {
            try
            {
                if (string.IsNullOrEmpty(srcPath) || string.IsNullOrEmpty(dstPath) || !Directory.Exists(srcPath))
                {
                    return false;
                }

                Directory.Move(srcPath, dstPath);
                return true;
            } catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }
        }

        /// <summary>
        /// 拷贝
        /// </summary>
        /// <param name="srcPath">源路径</param>
        /// <param name="dstPath">目标路径</param>
        /// <param name="overWrite">是否覆盖</param>
        /// <returns></returns>
        public static bool Copy(string srcPath, string dstPath, bool overWrite = false)
        {
            try
            {
                if (string.IsNullOrEmpty(srcPath) || string.IsNullOrEmpty(dstPath))
                {
                    return false;
                }

                srcPath = srcPath.EndsWith(@"\") ? srcPath : srcPath + @"\";
                dstPath = dstPath.EndsWith(@"\") ? dstPath : dstPath + @"\";
                if (!Directory.Exists(srcPath))
                {
                    return false;
                }

                if (!Directory.Exists(dstPath))
                {
                    Directory.CreateDirectory(dstPath);
                }

                foreach (string file in Directory.GetFiles(srcPath))
                {
                    FileInfo flInfo = new FileInfo(file);
                    flInfo.CopyTo(dstPath + flInfo.Name, overWrite);
                }

                foreach (string dir in Directory.GetDirectories(srcPath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);
                    Copy(dir, dstPath + dirInfo.Name, overWrite);
                }

                return true;
            } catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }
        }

        /// <summary>
        /// 清理
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static bool Clear(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
                {
                    return false;
                }

                foreach (string item in Directory.GetFileSystemEntries(path))
                {
                    if (File.Exists(item))
                    {
                        File.Delete(item);
                    } else
                    {
                        Clear(item);
                    }
                }

                Directory.Delete(path);
                return true;
            } catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="isUnity">是否是Unity路径(如果是会自动删除.meta文件)</param>
        /// <returns></returns>
        public static bool Delete(string path, bool isUnity = false)
        {
            try
            {
                if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
                {
                    return false;
                }

                Directory.Delete(path, true);
                if (isUnity)
                {
                    File.Delete(path + ".meta");
                }

                return true;
            } catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }
        }

        /// <summary>
        /// 获取目录下的所有文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="searchPattern">文件格式</param>
        /// <param name="option">模式</param>
        /// <returns></returns>
        public static DirectoryInfo[] GetAllDirectory(string path, string searchPattern = "*.*", SearchOption option = SearchOption.AllDirectories)
        {
            try
            {
                if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
                {
                    return default;
                }

                DirectoryInfo directory = new DirectoryInfo(path);
                return directory.GetDirectories(searchPattern, option);
            } catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }
    }
}