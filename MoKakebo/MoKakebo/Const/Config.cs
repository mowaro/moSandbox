using System.Reflection;
using System.IO;
using System.Text;

namespace MoKakebo.Const {
    public static class Config {
        public static string EXE_PATH = Assembly.GetExecutingAssembly().Location;
        public static string SQLITE_FILENAME = "MokakeboDB.sqlite";
        public static string SQLITE_PATH = Path.Combine(Path.GetDirectoryName(EXE_PATH), SQLITE_FILENAME);
        public static string LOG_FILENAME = "MoKaKe.log";
        public static string LOG_PATH = Path.Combine(Path.GetDirectoryName(EXE_PATH), LOG_FILENAME);
        public static Encoding LOG_ENCODING = Encoding.GetEncoding("UTF-8");
    }
}
