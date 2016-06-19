using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MvcPL.Infrastructure
{
    public static class ImageHelper
    {
        public static string SaveFileToDisk(HttpPostedFileBase img, string mapPath)
        {
            Directory.CreateDirectory(mapPath + "/UserContent/");
            var ext = "." + img.FileName.Split('.').Last();
            var name = Guid.NewGuid().ToString() + ext;
            var fName = mapPath + "UserContent\\" + name;
            img.SaveAs(fName);
            return name;
        }

        public static void RemoveFileFromDisk(string mapPath, string path)
        {
            if (string.IsNullOrEmpty(path))
                return;
            var fullPath = mapPath + "/UserContent/" + path;
            File.Delete(fullPath);
        }

        public static string SaveTitleImgToDisk(HttpPostedFileBase img, string mapPath)
        {
            Directory.CreateDirectory(mapPath + "/ArticlesContent/");
            var ext = "." + img.FileName.Split('.').Last();
            var name = Guid.NewGuid().ToString() + ext;
            var fName = mapPath + "ArticlesContent\\" + name;
            img.SaveAs(fName);
            return name;
        }

        public static void RemoveTitleImgFromDisk(string mapPath, string path)
        {
            if (string.IsNullOrEmpty(path))
                return;
            var fullPath = mapPath + "/ArticlesContent/" + path;
            File.Delete(fullPath);
        }
    }
}