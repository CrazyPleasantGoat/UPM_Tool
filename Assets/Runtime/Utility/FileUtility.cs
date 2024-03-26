using System;
using System.IO;
using UnityEngine;

namespace BigDevil.Tool.Runtime
{
    public static class FileUtility
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
                return !string.IsNullOrEmpty(path) && File.Exists(path);
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
                if (string.IsNullOrEmpty(path) || File.Exists(path))
                {
                    return false;
                }

                string directory = Path.GetDirectoryName(path);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.Create(path).Dispose();
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
                if (string.IsNullOrEmpty(srcPath) || string.IsNullOrEmpty(dstPath) || !File.Exists(srcPath))
                {
                    return false;
                }

                File.Move(srcPath, dstPath);
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
        public static bool Copy(string srcPath, string dstPath, bool overWrite = true)
        {
            try
            {
                if (string.IsNullOrEmpty(srcPath) || string.IsNullOrEmpty(dstPath) || !File.Exists(srcPath))
                {
                    return false;
                }

                string directory = Path.GetDirectoryName(dstPath);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.Copy(srcPath, dstPath, overWrite);
                return true;
            } catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }
        }

        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="srcPath">源路径</param>
        /// <param name="dstPath">目标路径</param>
        /// <param name="overWrite">是否覆盖</param>
        /// <returns></returns>
        public static bool Rename(string srcPath, string dstPath, bool overWrite = true)
        {
            try
            {
                if (string.IsNullOrEmpty(srcPath) || string.IsNullOrEmpty(dstPath) || !File.Exists(srcPath))
                {
                    return false;
                }

                if (File.Exists(dstPath))
                {
                    if (!overWrite)
                    {
                        return false;
                    }

                    File.Delete(dstPath);
                }

                FileInfo fileInfo = new FileInfo(srcPath);
                fileInfo.MoveTo(dstPath);
                return true;
            } catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }
        }

        /// <summary>
        /// 写
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static bool Write(string path, string content)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    return false;
                }

                if (!File.Exists(path))
                {
                    string directory = Path.GetDirectoryName(path);
                    if (directory != null && !Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    File.Create(path).Dispose();
                }

                File.WriteAllText(path, content);
                return true;
            } catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }
        }

        /// <summary>
        /// 读
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="isJson">是否是Json文本(如果是会保证内容安全，例如:最低返回“{}”)</param>
        /// <returns></returns>
        public static string Read(string path, bool isJson = false)
        {
            try
            {
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                {
                    return isJson ? "{}" : string.Empty;
                }

                string text = File.ReadAllText(path);
                return !string.IsNullOrEmpty(text) ? text : isJson ? "{}" : string.Empty;
            } catch (Exception e)
            {
                Debug.LogException(e);
                return string.Empty;
            }
        }

        /// <summary>
        /// 写
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static bool WriteBytes(string path, byte[] content)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    return false;
                }

                if (!File.Exists(path))
                {
                    string directory = Path.GetDirectoryName(path);
                    if (directory != null && !Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    File.Create(path).Dispose();
                }

                File.WriteAllBytes(path, content);
                return true;
            } catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }
        }

        /// <summary>
        /// 读
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static byte[] ReadBytes(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                {
                    return Array.Empty<byte>();
                }

                return File.ReadAllBytes(path);
            } catch (Exception e)
            {
                Debug.LogException(e);
                return Array.Empty<byte>();
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
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                {
                    return false;
                }

                File.Delete(path);
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
        public static FileInfo[] GetAllFile(string path, string searchPattern = "*.*", SearchOption option = SearchOption.AllDirectories)
        {
            try
            {
                if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
                {
                    return default;
                }

                DirectoryInfo directory = new DirectoryInfo(path);
                return directory.GetFiles(searchPattern, option);
            } catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }
    }
}