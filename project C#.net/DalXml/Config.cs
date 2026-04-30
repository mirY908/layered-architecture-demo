using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    internal static class Config
    {
        private static string fileName = @"..\xml\data-config.xml";
        //private static string fileName = @"xml\dal-config.xml";
        //private static string fileName = @"xml\data-config.xml";
        public static int ProductNum
        {
            get
            {
                XElement root = XElement.Load(fileName);
                int id = int.Parse(root.Element("ProductNum").Value);

                root.Element("ProductNum").Value = (id + 1).ToString();
                root.Save(fileName);

                return id;
            }
        }

        public static int SaleNum
        {
            get
            {
                XElement root = XElement.Load(fileName);
                int id = int.Parse(root.Element("SaleNum").Value);

                root.Element("SaleNum").Value = (id + 1).ToString();
                root.Save(fileName);

                return id;
            }
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Xml.Linq;

//namespace Dal
//{
//    internal static class Config
//    {
//        // המשתנה שיחזיק את הנתיב לתיקיית ה-xml המרכזית
//        private static string s_xmlPath;

//        // המשתנים של ה-Dal (תוודאי שהם קיימים אצלך)
//        private static string s_dalName;
//        private static Dictionary<string, string> s_dalPackages;

//        static Config() // שימי לב ששם הקונסטרקטור חייב להיות שם הקלאס: Config
//        {
//            // 1. מציאת התיקייה המרכזית בצורה דינמית
//            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
//            DirectoryInfo? dir = new DirectoryInfo(baseDir);

//            while (dir != null && !Directory.Exists(Path.Combine(dir.FullName, "xml")))
//            {
//                dir = dir.Parent;
//            }

//            if (dir == null) throw new DirectoryNotFoundException("xml folder not found!");

//            // שומרים את הנתיב לתיקייה המרכזית לשימוש עתידי
//            s_xmlPath = Path.Combine(dir.FullName, "xml");

//            // 2. טעינת קובץ הקונפיגורציה
//            string dalConfigPath = Path.Combine(s_xmlPath, "dal-config.xml");
//            XElement dalConfig = XElement.Load(dalConfigPath);

//            // 3. חילוץ הנתונים
//            s_dalName = dalConfig.Element("dal")?.Value
//                        ?? throw new Exception("<dal> element is missing");

//            var packages = dalConfig.Element("dal-packages")?.Elements()
//                           ?? throw new Exception("<dal-packages> element is missing");

//            s_dalPackages = packages.ToDictionary(p => "" + p.Name, p => p.Value);
//        }

//        public static int ProductNum
//        {
//            get
//            {
//                // משתמשים בנתיב הדינמי שמצאנו
//                string dataConfigPath = Path.Combine(s_xmlPath, "data-config.xml");
//                XElement root = XElement.Load(dataConfigPath);

//                int id = int.Parse(root.Element("ProductNum").Value);
//                root.Element("ProductNum").Value = (id + 1).ToString();
//                root.Save(dataConfigPath);

//                return id;
//            }
//        }

//        public static int SaleNum
//        {
//            get
//            {
//                // משתמשים בנתיב הדינמי שמצאנו
//                string dataConfigPath = Path.Combine(s_xmlPath, "data-config.xml");
//                XElement root = XElement.Load(dataConfigPath);

//                int id = int.Parse(root.Element("SaleNum").Value);
//                root.Element("SaleNum").Value = (id + 1).ToString();
//                root.Save(dataConfigPath);

//                return id;
//            }
//        }
//    }
//}