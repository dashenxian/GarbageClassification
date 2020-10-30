using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GarbageClassification
{
    public class FileHelper
    {
        /// <summary>
        /// 根路径
        /// </summary>
        public string BasePath => Environment.CurrentDirectory;
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="avatar">文件</param>
        /// <param name="reDir">相对路径,首尾不含\</param>
        /// <returns></returns>
        public async Task<string> WriteFile(IFormFile avatar, string reDir)
        {
            string reName = Guid.NewGuid() + Path.GetExtension(avatar.FileName);
            string dir = GetDirPath(reDir);
            string path = $"{dir}\\{reName}";
            Stream stream = avatar.OpenReadStream();
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await avatar.CopyToAsync(fileStream);
            }
            return $"{reDir}/{reName}";
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="reFilePath">文件相对路径</param>
        /// <returns></returns>
        public async Task DeleteFile(string reFilePath)
        {
            string filePath = $"{BasePath}/{reFilePath}";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        /// <summary>
        /// 相对文件路径转绝对路径
        /// </summary>
        /// <param name="reDir">相对路径</param>
        /// <returns></returns>
        public string GetFilePath(string reFilePath)
        {
            string dir = $"{BasePath}/{reFilePath}";
    
            return Path.GetFullPath(dir);
        }
        /// <summary>
        /// 相对目录路径转绝对路径
        /// </summary>
        /// <param name="reDir">相对路径</param>
        /// <returns></returns>
        public string GetDirPath(string reDir)
        {
            string dir = $"{BasePath}/{reDir}";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return Path.GetFullPath(dir);
        }
    }
}
