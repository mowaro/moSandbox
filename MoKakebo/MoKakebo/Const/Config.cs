using System.Reflection;
using System.IO;

namespace MoKakebo.Const {
    public static class Config {
        public static string EXE_PATH = Assembly.GetExecutingAssembly().Location;
        public static string SQLITE_FILENAME = "MokakeboDB.sqlite";
        public static string SQLITE_PATH = Path.Combine(Path.GetDirectoryName(EXE_PATH), SQLITE_FILENAME);
    }
}
