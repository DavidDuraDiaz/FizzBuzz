using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FizzBuzzCore
{
    public class FileGenerator
    {
        public static async Task PersistToFile(List<string> lines)
        {
            string path = @"C:\FizzBuzz\Persist\";
            string fullFilePath = path + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (var streamWriter = new StreamWriter(fullFilePath, true))
            {
                await streamWriter.WriteLineAsync("Sequence written on: " + DateTime.Now.ToString("yyyyMMdd-HHmmss"));

                foreach (var line in lines)
                {
                    await streamWriter.WriteLineAsync(line);
                }
            }
        }
    }
}
