using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SYNTools.src.util
{
    public static class UConfig
    {
        private static void writeConfig(string name, string value, ref string error)
        {
            string filePath = null;
            try
            {
                filePath = Directory.GetCurrentDirectory() + "/conf.txt";
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return;
            }
            if (!File.Exists(filePath))
            {
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(filePath);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return;
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                    }
                }
            }
            if (File.Exists(filePath))
            {
                string[] lines = null;
                try
                {
                    lines = File.ReadAllLines(filePath);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return;
                }
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Split(':')[0] == name)
                    {
                        lines[i] = lines[i].Split(':')[0] + ':' + value;
                        try
                        {
                            File.WriteAllLines(filePath, lines);
                            return;
                        }
                        catch (Exception ex)
                        {
                            error = ex.Message;
                            return;
                        }
                    }
                }
                string[] newLines = new string[lines.Length + 1];
                for (int i = 0; i < lines.Length; i++)
                {
                    newLines[i] = lines[i];

                }
                newLines[lines.Length] = name + ':' + value;
                try
                {
                    File.WriteAllLines(filePath, newLines);
                    return;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return;
                }
            }
        }

        private static string readConfig(string name,ref string error)
        {
            string filePath = null;
            try
            {
                filePath = Directory.GetCurrentDirectory() + "/conf.txt";
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
            if (File.Exists(filePath))
            {
                string[] lines = null;
                try
                {
                    lines = File.ReadAllLines(filePath);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return null;
                }
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Split(':')[0] == name)
                    {
                        return lines[i].Split(':')[1];
                    }
                }
            }
            return null;
        }
        public static bool writeAll(string comboName,string oldPath,string newPath,string useR,ref string error)
        {
            string filePath = null;
            try
            {
                filePath = Directory.GetCurrentDirectory() + "/conf.txt";
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            if (!File.Exists(filePath))
            {
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(filePath);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                    }
                }
            }
            if (File.Exists(filePath))
            {
                string[] lines = null;
                try
                {
                    lines = File.ReadAllLines(filePath);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i]=="comboName?"+comboName)
                    {
                        return false;
                    }
                }
                string[] newLines = new string[lines.Length + 4];
                for (int i = 0; i < lines.Length; i++)
                {
                    newLines[i] = lines[i];

                }
                newLines[lines.Length] = "comboName" + '?' + comboName;
                newLines[lines.Length + 1] = oldPath;
                newLines[lines.Length + 2] = newPath;
                newLines[lines.Length + 3] = useR;
                try
                {
                    File.WriteAllLines(filePath, newLines);
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
            return false;
        }
        public static string[] readAll(string comboName, ref string error)
        {
            string[] r = null;
            string filePath = null;
            try
            {
                filePath = Directory.GetCurrentDirectory() + "/conf.txt";
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
            if (File.Exists(filePath))
            {
                string[] lines = null;
                try
                {
                    lines = File.ReadAllLines(filePath);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return null;
                }
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i]=="comboName?"+comboName)
                    {
                        r = new string[3];
                        r[0] = lines[i + 1];
                        r[1] = lines[i + 2];
                        r[2] = lines[i + 3];
                        return r;
                    }
                }
            }
            return null;
        }
        public static List<string> readComboName(ref string error)
        {
            List<string> r = new List<string>();
            string filePath = null;
            try
            {
                filePath = Directory.GetCurrentDirectory() + "/conf.txt";
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
            if (File.Exists(filePath))
            {
                string[] lines = null;
                try
                {
                    lines = File.ReadAllLines(filePath);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return null;
                }
                for (int i = 0; i < lines.Length; i=i+4)
                {
                    string temp = lines[i].Split('?')[1];
                    r.Add(temp);
                }
            }
            return r;
        }
        public static bool delete(string comboName,ref string error)
        {
            string filePath = null;
            try
            {
                filePath = Directory.GetCurrentDirectory() + "/conf.txt";
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            if (File.Exists(filePath))
            {
                string[] lines = null;
                try
                {
                    lines = File.ReadAllLines(filePath);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
                for (int i = 0; i < lines.Length; i = i + 4)
                {
                    string temp = lines[i].Split('?')[1];
                    if (temp==comboName)
                    {
                        if (lines.Length==4)
                        {
                            try
                            {
                                File.Delete(filePath);
                                return true;
                            }
                            catch (Exception ex)
                            {
                                error = ex.Message;
                                return false;
                            }
                        }
                        string[] newLines = new string[lines.Length - 4];
                        if (i<lines.Length-4)
                        {
                            for (int ii = 0; ii < i; ii++)
                            {
                                newLines[ii] = lines[ii];
                            }
                            for (int iii = i; iii < newLines.Length; iii++)
                            {
                                newLines[iii] = lines[iii + 4];
                            }
                            try
                            {
                                File.WriteAllLines(filePath, newLines);
                                return true;
                            }
                            catch (Exception ex)
                            {
                                error = ex.Message;
                                return false;
                            }
                        }
                        else
                        {
                            for (int ii = 0; ii < i; ii++)
                            {
                                newLines[ii] = lines[ii];
                            }
                            try
                            {
                                File.WriteAllLines(filePath, newLines);
                                return true;
                            }
                            catch (Exception ex)
                            {
                                error = ex.Message;
                                return false;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
