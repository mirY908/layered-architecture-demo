//namespace DalApi;
//using System.Xml.Linq;

//static class DalConfig
//{
//    internal static string s_dalName;
//    internal static Dictionary<string, string> s_dalPackages;

//    static DalConfig()
//    {
//        //      XElement dalConfig = XElement.Load(@"..\xml\dal-config.xml") ??
//        //throw new DalConfigException("dal-config.xml file is not found");

//        //    XElement dalConfig = XElement.Load(@"xml\dal-config.xml") ??
//        //throw new DalConfigException("dal-config.xml file is not found");

//        XElement dalConfig = XElement.Load(@"..\xml\dal-config.xml");

//        s_dalName =
//           dalConfig.Element("dal")?.Value ?? throw new DalConfigException("<dal> element is missing");

//        var packages = dalConfig.Element("dal-packages")?.Elements() ??
//  throw new DalConfigException("<dal-packages> element is missing");
//        s_dalPackages = packages.ToDictionary(p => "" + p.Name, p => p.Value);
//    }
//}

//[Serializable]
//public class DalConfigException : Exception
//{
//    public DalConfigException(string msg) : base(msg) { }
//    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
//}


using System.Xml.Linq;
using System.IO;

namespace DalApi;

static class DalConfig
{
    internal static string s_dalName;
    internal static Dictionary<string, string> s_dalPackages;

    static DalConfig()
    {
        // 1. מציאת התיקייה המרכזית על ידי טיפוס למעלה עד שמוצאים את תיקיית ה-xml
        string? dir = AppDomain.CurrentDomain.BaseDirectory;
        while (dir != null && !Directory.Exists(Path.Combine(dir, "xml")))
        {
            dir = Directory.GetParent(dir)?.FullName;
        }

        if (dir == null) throw new DalConfigException("xml folder not found in any parent directory!");

        // 2. בניית הנתיב האמיתי לקובץ הקונפיגורציה
        string configPath = Path.Combine(dir, "xml", "dal-config.xml");
        XElement dalConfig = XElement.Load(configPath);

        // 3. חילוץ הנתונים
        s_dalName = dalConfig.Element("dal")?.Value
            ?? throw new DalConfigException("<dal> element is missing");

        var packages = dalConfig.Element("dal-packages")?.Elements()
            ?? throw new DalConfigException("<dal-packages> element is missing");

        s_dalPackages = packages.ToDictionary(p => "" + p.Name, p => p.Value);
    }
}

[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}