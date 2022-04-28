using System;
using System.IO;
using System.Text;

namespace Question1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Put the directory path here
            SearchDirectory(@"E:\Personal\Movie");
        }

        public static void SearchDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("There is no such directory exist!");
                return;
            }

            // Getting all files under this directory.
            var files = Directory.GetFiles(directoryPath);

            // showing file name 
            foreach (var filePath in files)
            {
                Console.WriteLine("File ditected : " + Path.GetFileName(filePath));
            }

            // Getting all subdirectories under this directory
            var subDirectories = Directory.GetDirectories(directoryPath);

            // Making recursive call into subdirectories of this directory
            foreach (string subdirectory in subDirectories)
            {
                SearchDirectory(subdirectory);
            }

        }
    }
}
