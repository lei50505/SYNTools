using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace SYNTools.src.util
{
    public static class UFile
    {
        public static string getDriverName(string path,ref string error)
        {
            string driver = null;
            try
            {
                driver = path.Substring(0, 1);
                return driver;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }
        public static string getLastDir(string path)
        {
            string[] dirs = null;
            dirs = path.Split('\\');
            return dirs[dirs.Length-1];
        }
        private static void getFiles(string path, ref List<string> files, ref List<string> errors)
        {
            string[] fs = null;
            try
            {
                fs = Directory.GetFiles(path);
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                return;
            }
            foreach (string f in fs)
            {
                files.Add(f);
            }
            string[] ds = null;
            try
            {
                ds = Directory.GetDirectories(path);
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                return;
            }
            foreach (string d in ds)
            {
                getFiles(d, ref files, ref errors);
            }
        }
        public static List<string> getFiles(string path,ref List<string> errors)
        {
            List<string> files = new List<string>();
            List<string> referrors = new List<string>();
            getFiles(path, ref files, ref referrors);
            if (referrors.Count!=0)
            {
                for (int i = 0; i < referrors.Count; i++)
                {
                    errors.Add(referrors[i]);
                }
                return new List<string>();
            }
            else
            {
                return files;
            }
        }
        private static void getDirs(string path, ref List<string> dirs, ref List<string> errors)
        {
            string[] ds = null;
            try
            {
                ds = Directory.GetDirectories(path);
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                return;
            }
            foreach (string d in ds)
            {
                getDirs(d, ref dirs, ref errors);
                dirs.Add(d);
            }
        }
        public static List<string> getDirs(string path, ref List<string> errors)
        {
            List<string> dirs = new List<string>();
            List<string> referrors = new List<string>();
            getDirs(path, ref dirs, ref referrors);
            if (referrors.Count!=0)
            {
                for (int i = 0; i < referrors.Count; i++)
                {
                    errors.Add(referrors[i]);
                }
                return new List<string>();
            }
            else
            {
                return dirs;
            }
        }
        public static bool copyDir(string oldDir, string oldPath, string newPath,ref List<string> errors)
        {
            try
            {
                string newDir = newPath + oldDir.Substring(oldPath.Length);
                if (!Directory.Exists(newDir))
                {
                    Directory.CreateDirectory(newDir);
                    return true;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }
            return false;
        }
        private static bool compareFiles(string oldFile, string newFile)
        {
            int oldYear = File.GetLastWriteTime(oldFile).Year;
            int newYear = File.GetLastWriteTime(newFile).Year;
            int oldMonth = File.GetLastWriteTime(oldFile).Month;
            int newMonth = File.GetLastWriteTime(newFile).Month;
            int oldDay = File.GetLastWriteTime(oldFile).Day;
            int newDay = File.GetLastWriteTime(newFile).Day;
            int oldHour = File.GetLastWriteTime(oldFile).Hour;
            int newHour = File.GetLastWriteTime(newFile).Hour;
            int oldMinute = File.GetLastWriteTime(oldFile).Minute;
            int newMinute = File.GetLastWriteTime(newFile).Minute;
            int oldSecond = File.GetLastWriteTime(oldFile).Second;
            int newSecond = File.GetLastWriteTime(newFile).Second;
            int oldTime = oldSecond + (oldMinute * 60) + (oldHour * 60 * 60) + (oldDay * 24 * 60 * 60);
            int newTime = newSecond + (newMinute * 60) + (newHour * 60 * 60) + (newDay * 24 * 60 * 60);
            int time = oldTime - newTime;
            if (oldYear == newYear)
            {
                if (oldMonth == newMonth)
                {
                    if (time > -5 && time < 5)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private static long getFileSize(string file)
        {
            long fileSize = 0;
            FileInfo fileInfo = new FileInfo(file);
            fileSize = fileInfo.Length;
            return fileSize;
        }
        
        public static bool copyFile(string oldFile,string oldPath,string newPath,ref List<string> errors)
        {
            string newFile = newPath + oldFile.Substring(oldPath.Length);
            if (File.Exists(newFile))
            {
                if (!(compareFiles(oldFile, newFile) && getFileSize(oldFile) == getFileSize(newFile)))
                {
                    try
                    {
                        FileSystem.DeleteFile(newFile, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        File.Copy(oldFile, newFile, true);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        errors.Add(ex.Message);
                    }
                }
            }
            else
            {
                try
                {
                    File.Copy(oldFile, newFile, true);
                    return true;
                }
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                }
            }
            return false;
        }
        public static bool delFile(string newFile, string oldPath, string newPath, ref List<string> errors)
        {
            try
            {
                string oldFile = oldPath + newFile.Substring(newPath.Length);
                if (!File.Exists(oldFile))
                {
                    FileSystem.DeleteFile(newFile, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    File.Delete(newFile);
                    return true;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }
            return false;
        }
        public static bool delDir(string newDir, string oldPath, string newPath, ref List<string> errors)
        {
            try
            {
                string oldDir = oldPath + newDir.Substring(newPath.Length);
                if (!Directory.Exists(oldDir))
                {
                    FileSystem.DeleteDirectory(newDir, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    return true;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }
            return false;
        }
    
    }
}
