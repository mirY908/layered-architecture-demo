////using DalApi;
////using Do;
////using System.Xml.Serialization;

////namespace Dal
////{
////    internal class CustemerImplementation : ICustomer
////    {
////        //string path = @"..\xml\custemers.xml";
////        //string path = @"xml\custemers.xml";

////        string path = @"..\xml\custemers.xml";


////        private List<Custemer> Load()
////        {
////            if (!File.Exists(path)) return new List<Custemer>();
////            XmlSerializer serializer = new XmlSerializer(typeof(List<Custemer>));
////            using (FileStream stream = new FileStream(path, FileMode.Open))
////            {
////                return (List<Custemer>)serializer.Deserialize(stream)!;
////            }
////        }
////        private void Save(List<Custemer> list)
////        {
////            XmlSerializer serializer = new XmlSerializer(typeof(List<Custemer>));
////            using (FileStream stream = new FileStream(path, FileMode.Create))
////            {
////                serializer.Serialize(stream, list);
////            }
////        }

////        public int Create(Custemer item)
////        {
////            var list = Load();
////            list.Add(item);
////            Save(list);
////            return item.CustemerId;
////        }

////        public List<Custemer> ReadAll(Func<Custemer, bool>? filter = null)
////        {
////            var list = Load();
////            return filter == null ? list : list.Where(filter).ToList();
////        }

////        public Custemer? Read(int id) => Load().FirstOrDefault(c => c.CustemerId == id);

////        public Custemer? Read(Func<Custemer, bool>? filter) => Load().FirstOrDefault(filter!);

////        public void Update(Custemer item)
////        {
////            var list = Load();
////            int index = list.FindIndex(c => c.CustemerId == item.CustemerId);
////            if (index == -1) return;
////            list[index] = item;
////            Save(list);
////        }

////        public void Delete(int id)
////        {
////            var list = Load();
////            list.RemoveAll(c => c.CustemerId == id);
////            Save(list);
////        }
////    }
////}





//using DalApi;
//using Do;
//using System.Xml.Serialization;
//using System.IO;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Dal
//{
//    internal class CustemerImplementation : ICustomer
//    {
//        // פונקציה פרטית שמוצאת את הנתיב הנכון לתיקיית ה-xml ולוקחת את קובץ הלקוחות
//        private string GetFilePath()
//        {
//            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
//            DirectoryInfo? dir = new DirectoryInfo(baseDir);

//            // מטפסים למעלה עד שמוצאים את תיקיית ה-xml המרכזית
//            while (dir != null && !Directory.Exists(Path.Combine(dir.FullName, "xml")))
//            {
//                dir = dir.Parent;
//            }

//            if (dir == null) throw new DirectoryNotFoundException("xml folder not found!");

//            return Path.Combine(dir.FullName, "xml", "custemers.xml");
//        }

//        private List<Custemer> Load()
//        {
//            string path = GetFilePath(); // מקבלים את הנתיב הדינמי
//            if (!File.Exists(path)) return new List<Custemer>();

//            XmlSerializer serializer = new XmlSerializer(typeof(List<Custemer>));
//            using (FileStream stream = new FileStream(path, FileMode.Open))
//            {
//                return (List<Custemer>)serializer.Deserialize(stream)!;
//            }
//        }

//        private void Save(List<Custemer> list)
//        {
//            string path = GetFilePath(); // מקבלים את הנתיב הדינמי
//            XmlSerializer serializer = new XmlSerializer(typeof(List<Custemer>));
//            using (FileStream stream = new FileStream(path, FileMode.Create))
//            {
//                serializer.Serialize(stream, list);
//            }
//        }

//        public int Create(Custemer item)
//        {
//            var list = Load();
//            list.Add(item);
//            Save(list);
//            return item.CustemerId;
//        }

//        public List<Custemer> ReadAll(Func<Custemer, bool>? filter = null)
//        {
//            var list = Load();
//            return filter == null ? list : list.Where(filter).ToList();
//        }

//        public Custemer? Read(int id) => Load().FirstOrDefault(c => c.CustemerId == id);

//        public Custemer? Read(Func<Custemer, bool>? filter) => Load().FirstOrDefault(filter!);

//        public void Update(Custemer item)
//        {
//            var list = Load();
//            int index = list.FindIndex(c => c.CustemerId == item.CustemerId);
//            if (index == -1) return;
//            list[index] = item;
//            Save(list);
//        }

//        public void Delete(int id)
//        {
//            var list = Load();
//            list.RemoveAll(c => c.CustemerId == id);
//            Save(list);
//        }
//    }
//}

using DalApi;
using Do;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal
{
    internal class CustemerImplementation : ICustomer
    {
        // מאחר וכל הפרויקטים רצים מתיקיית ה-bin המשותפת, 
        // הקוד מחפש את תיקיית ה-xml שנמצאת באותה רמה או רמה אחת מעל
        readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\xml\custemers.xml");

        private List<Custemer> Load()
        {
            if (!File.Exists(path)) return new List<Custemer>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Custemer>));
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return (List<Custemer>)serializer.Deserialize(stream)!;
            }
        }

        private void Save(List<Custemer> list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Custemer>));
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(stream, list);
            }
        }

        public int Create(Custemer item)
        {
            var list = Load();
            list.Add(item);
            Save(list);
            return item.CustemerId;
        }

        public List<Custemer> ReadAll(Func<Custemer, bool>? filter = null)
        {
            var list = Load();
            return filter == null ? list : list.Where(filter).ToList();
        }

        public Custemer? Read(int id) => Load().FirstOrDefault(c => c.CustemerId == id);

        public Custemer? Read(Func<Custemer, bool>? filter) => Load().FirstOrDefault(filter!);

        public void Update(Custemer item)
        {
            var list = Load();
            int index = list.FindIndex(c => c.CustemerId == item.CustemerId);
            if (index == -1) return;
            list[index] = item;
            Save(list);
        }

        public void Delete(int id)
        {
            var list = Load();
            list.RemoveAll(c => c.CustemerId == id);
            Save(list);
        }
    }
}