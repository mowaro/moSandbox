using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MoKakebo.Const;
using System.Reflection;
using System.Data.SQLite;

namespace MoKakebo.Framework.Utility {
    static class LogUtility {
        public static void Print(string message) {
            MethodBase callerMethod = new StackFrame(1).GetMethod();

            File.AppendAllText(Config.LOG_PATH, BuildLogLine(callerMethod, message), Config.LOG_ENCODING);
        }

        public static void Print(Exception ex) {
            List<string> list = new List<string>();
            BuildExceptionLogLines(list, ex);

            File.AppendAllLines(Config.LOG_PATH, list, Config.LOG_ENCODING);
        }

        public static void Print(SQLiteCommand cmd) {
            MethodBase callerMethod = new StackFrame(1).GetMethod();

            StringBuilder message = new StringBuilder();
            message.AppendLine("\r\n\t[Excute SQL]: ");
            foreach(string sqlLine in cmd.CommandText.Split(new string[] {"\r\n"}, StringSplitOptions.None)) {
                message.AppendLine($"\t\t\t{sqlLine}");
            }
            message.Append("\t[Parameters]: ");
            foreach(SQLiteParameter prm in cmd.Parameters) {
                message.Append($"{prm.ParameterName}={prm.Value?.ToString()}, ");
            }

            File.AppendAllText(Config.LOG_PATH, BuildLogLine(callerMethod, message.ToString()), Config.LOG_ENCODING);
        }

        private static void BuildExceptionLogLines(List<string> list, Exception ex) {
            list.Add(BuildLogLine(ex.TargetSite, ex.Message));

            if(ex.InnerException != null) {
                BuildExceptionLogLines(list, ex.InnerException);
            }
        }

        private static string BuildLogLine(MethodBase method, string message) {
            StringBuilder printLineBuilder = new StringBuilder();

            printLineBuilder.Append(DateTime.Now.ToString("yyyyMMdd hh:mm:ss.fff")).Append(" ");
            printLineBuilder.Append(method.ReflectedType.FullName).Append(" ");
            printLineBuilder.Append(method.Name).Append(" ");
            printLineBuilder.Append(message).Append(" ");

            return printLineBuilder.Append("\r\n").ToString();
        }
    }
}
