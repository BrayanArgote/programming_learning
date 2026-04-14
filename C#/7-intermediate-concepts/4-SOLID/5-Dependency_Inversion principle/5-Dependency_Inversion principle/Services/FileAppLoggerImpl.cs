using _5_Dependency_Inversion_principle.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _5_Dependency_Inversion_principle.Services
{
    public class FileAppLoggerImpl : IAppLogger, IAppLogReader
    { 
        public bool Add(int? userId, string action, string level)
        {
            if (string.IsNullOrEmpty(action) || string.IsNullOrEmpty(level) || action.Length > 50 || level.Length > 50) { return false; }

            if (!File.Exists("Logs.txt"))
            {
                File.WriteAllText("Logs.txt", "ID - USER ID -- ACTION -- LEVEL -- DATE\n\n");
            }

            int id = File.ReadLines("Logs.txt").Count() - 1;  // first line is to subject and second line is empty
            DateTime timestamp = DateTime.Now;

            using (StreamWriter w = new StreamWriter("Logs.txt", append: true))
            {
                w.WriteLine($"{id} -- {userId} -- {action} -- {level} -- {timestamp}");
            }
                return true;
        }

        public List<Log> GetAll()
        {
            var listLogs = new List<Log>();

            if (!File.Exists("Logs.txt")) { return listLogs; }

            var lines = File.ReadAllLines("Logs.txt").Skip(2);

            foreach(var item in lines)
            {
                var line = item.Split("--");
                listLogs.Add(
                    new Log
                    {
                        Id = int.Parse(line[0].Trim()),
                        UserId = int.TryParse(line[1].Trim(), out int uId) ? uId : null,
                        Action = line[2].Trim(),
                        Level = line[3].Trim(),
                        Timestamp = DateTime.Parse(line[4].Trim())
                    });
            }

            return listLogs;
        }
    }
}
