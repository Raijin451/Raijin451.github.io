using System;
using System.IO;

namespace FileManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Management System");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. List files in directory");
                Console.WriteLine("2. Copy file");
                Console.WriteLine("3. Move file");
                Console.WriteLine("4. Delete file");
                Console.WriteLine("5. Exit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ListFiles();
                        break;
                    case "2":
                        CopyFile();
                        break;
                    case "3":
                        MoveFile();
                        break;
                    case "4":
                        DeleteFile();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void ListFiles()
        {
            Console.Write("Enter directory path: ");
            var path = Console.ReadLine() ?? string.Empty;

            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("Directory not found.");
            }
        }

        static void CopyFile()
        {
            Console.Write("Enter source file path: ");
            var source = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter destination path: ");
            var destination = Console.ReadLine() ?? string.Empty;

            try
            {
                File.Copy(source, destination, overwrite: true);
                Console.WriteLine("File copied.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying file: {ex.Message}");
            }
        }

        static void MoveFile()
        {
            Console.Write("Enter source file path: ");
            var source = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter destination path: ");
            var destination = Console.ReadLine() ?? string.Empty;

            try
            {
                File.Move(source, destination);
                Console.WriteLine("File moved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error moving file: {ex.Message}");
            }
        }

        static void DeleteFile()
        {
            Console.Write("Enter file path to delete: ");
            var path = Console.ReadLine() ?? string.Empty;

            try
            {
                File.Delete(path);
                Console.WriteLine("File deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
        }
    }
}
