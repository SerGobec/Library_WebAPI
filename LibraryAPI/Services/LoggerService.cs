using LibraryAPI.Interfaces;

namespace LibraryAPI.Services
{
    public class LoggerService : IContextLogger
    {
        private readonly string loggerFileWay;
        private object _locker;
        public LoggerService()
        {
            _locker = new object();
            this.loggerFileWay = TryGetSolutionDirectoryInfo().FullName + @"\" + "meta.log";
        }

        public async Task WriteToLog(Microsoft.AspNetCore.Http.HttpContext context)
        {
            await Task.Run(() =>
            {
                lock (_locker)
                {
                    if (!File.Exists(this.loggerFileWay))
                    {
                        FileStream stream = File.Create(this.loggerFileWay);
                        stream.Close();
                    }
                    using (StreamWriter writer = new StreamWriter(this.loggerFileWay, true))
                    {
                        string data = "--------------------";
                        data += "\nDateTime: " + DateTime.Now + "\n\n";
                        data += "Path: " + context.Request.Path;
                        data += "\nMethod: " + context.Request.Method;
                        data += "\n\nHeaders: ";
                        foreach (var kv in context.Request.Headers)
                        {
                            data += "\nKey: " + kv.Key + " - Value: " + kv.Value;
                        }
                        data += "\n\nQuery: ";
                        foreach (var kv in context.Request.Query)
                        {
                            data += "\nKey: " + kv.Key + " - Value: " + kv.Value;
                        }
                        data += "\n--------------------\n";
                        writer.WriteLine(data);
                    }
                };
            }); 
        }

        private static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }
    }
}
