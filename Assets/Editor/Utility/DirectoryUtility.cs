using System.IO;
using UnityEditor;
using UnityEngine;

namespace BigDevil.Tools.Editor
{
    public class DirectoryUtility
    {
        /// <summary>
        /// 获取目标所在目录
        /// </summary>
        /// <param name="targetName">目标文件名</param>
        /// <param name="suffix">文件名后缀</param>
        /// <returns></returns>
        public static string GetTargetDirectory(string targetName, string suffix)
        {
            string[] guids = AssetDatabase.FindAssets(targetName);
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                if (Path.GetExtension(path) == suffix)
                {
                    return Path.GetDirectoryName(path);
                }
            }

            Debug.LogError($"文件[{targetName}{suffix}]不存在");
            return string.Empty;
        }
    }
}