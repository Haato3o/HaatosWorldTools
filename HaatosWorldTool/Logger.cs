using System;
using System.Collections.ObjectModel;

namespace HaatosWorldTool
{
    public class Logger
    {

        public static ObservableCollection<string> Logs = new ObservableCollection<string>();

        public static void WriteLine(object line)
        {
            string formatted = $"[{DateTime.Now:T}] {line}";
            Logs.Add(formatted);
        }
    }
}
