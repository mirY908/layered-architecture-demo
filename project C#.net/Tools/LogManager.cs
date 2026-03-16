using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class LogManager
    {
        private static string LogDirPath = "Log";
        static int day = DateTime.Now.Day;
        static int month = DateTime.Now.Month;
        static int year = DateTime.Now.Year;
        //ניתוב לתיקיה הנוכחית
        public static string DirPath()
        { return LogDirPath + "/" + month.ToString(); }
        //ניתוב לקובץ הנוכחי
        public static string FilePath()
        { return DirPath() + "/" + day.ToString() + ".txt"; }

        private static void CreateLogFile()
        {
            DirectoryInfo logDir = Directory.CreateDirectory(LogDirPath);

            //בדיקה האם קיימת תיקיה לשנה הנוכחית
            if (!Directory.Exists($@"{logDir.FullName}\{year}"))
            {
                //יוצרים תת תיקיה עבור השנה
                logDir.CreateSubdirectory(year.ToString());
            }

            //בדיקה האם קיימת תיקיה לחודש הנוכחי
            if (!Directory.Exists($@"{logDir.FullName}\{year}\{month}"))
            {
                //יוצרים תת תיקיה עבור השנה
                logDir.CreateSubdirectory($@"{year}\{month}");
            }

            if (!File.Exists($@"{logDir.FullName}\{year}\{month}\{day}.txt"))
            {
                File.Create($@"{logDir.FullName}\{year}\{month}\{day}.txt").Close();
            }
        }


        public static void WriteToLog(string message, string project, string funcName)
        {
            CreateLogFile();
            DirectoryInfo logDir = Directory.CreateDirectory(LogDirPath);
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            string filePath = $@"{logDir.FullName}\{year}\{month}\{day}.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{DateTime.Now}\t{project}.{funcName}:\t{message}");
            }
        }

        //כתיבה לקובץ
        //public static void WriteStart(string projectName,string methodName, string message = null)
        //{
        //    if (LogDirPath + "/" + month.ToString() != DirPath() || DirPath() + "/" + day.ToString() + ".txt" != FilePath())
        //        CreateLogFile();
        //        WriteToLog($"{DateTime.Now}\tStart\t{projectName}\t{methodName}\t{message}");
        //}
        //public static void WriteStart(string projectName, string methodName, string message = null)
        //{
        //    if (LogDirPath + "/" + month.ToString() != DirPath() || DirPath() + "/" + day.ToString() + ".txt" != FilePath())
        //    {
        //        CreateLogFile();
        //    }
        //    WriteToLog($"{DateTime.Now}\tStart\t{projectName}\t{methodName}\t{message}");
        //}

        //public static void WriteEnd(string methodName, string message = null)
        //{
        //    WriteToLog($"{DateTime.Now}\tEnd {methodName}\t{message}");
        //}
        //פונקציה שמוחקת את ה2 החודשים האחרונים ובודקת האם קיימים
        public static void DeleteOldFolder()
        {
            if (!Directory.Exists(DirPath()))
                return;
            string[] nameFolders = Directory.GetDirectories(LogDirPath);

            foreach (string dir in nameFolders)
            {
                string[] dateFolder = dir.Split('/');
                if (dateFolder.Length > 2)
                    continue;
                int year = (int.Parse(dateFolder[0]));
                int month = (int.Parse(dateFolder[1]));
                if (year == DateTime.Now.Year)
                {
                    if (month + 2 < DateTime.Now.Month)
                    {
                        Directory.Delete(dir, true);
                    }
                }
                else
                {
                    if (DateTime.Now.Month == 1)
                    {
                        if (month != 11 && month != 12)
                        {
                            Directory.Delete(dir, true);
                        }
                    }
                    if (DateTime.Now.Month == 2)
                    {
                        if (month != 12)
                        {
                            Directory.Delete(dir, true);
                        }
                    }
                }


            }
        }
    }
}

