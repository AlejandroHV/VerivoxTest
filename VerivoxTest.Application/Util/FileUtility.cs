using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VerivoxTest.Application.Util
{
    public static class FileUtility
    {

        public static string ReadFileData(string filePath)
        {
            var fileData = string.Empty;
            try
            {
                using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    var buffer = new byte[fileStream.Length];
                    fileStream.Read(buffer, 0, buffer.Length);
                    fileData = Encoding.UTF8.GetString(buffer);

                }
            }
            catch (Exception )
            {

                throw;
            }
           

            if (fileData == null)
                throw new Exception("Could not read the data source");

            return fileData;

        }

    }
}
