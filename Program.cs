using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // 1. Folder yaratmaq
        CreateFolder("MyNewFolder");

        // 2. Hal hazirda oldugu directoryni gormek
        ShowCurrentDirectory();

        // 3. Folderi silmek
        DeleteFolder("MyNewFolder");

        // 4.Fayli yaratmaq
        CreateFile("MyNewFile.txt");

        // 5. Fayli silmek
        DeleteFile("MyNewFile.txt");

        // 6. Fayli basqa bir foldere kocurtmek
        MoveFile("MyNewFile.txt", "AnotherFolder");

        // 7. Faylin aina goree axtaris etmek
        SearchFile("MyNewFile.txt");

        // 8. Butun fayllari gostermek
        ListAllFiles();
    }

    static void CreateFolder(string folderName)
    {
        Directory.CreateDirectory(folderName);
        Console.WriteLine($"Folder '{folderName}' created.");
    }

    static void ShowCurrentDirectory()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        Console.WriteLine($"Current Directory: {currentDirectory}");
    }

    static void DeleteFolder(string folderName)
    {
        Directory.Delete(folderName, true);
        Console.WriteLine($"Folder '{folderName}' deleted.");
    }

    static void CreateFile(string fileName)
    {
        File.Create(fileName).Dispose();
        Console.WriteLine($"File '{fileName}' created.");
    }

    static void DeleteFile(string fileName)
    {
        File.Delete(fileName);
        Console.WriteLine($"File '{fileName}' deleted.");
    }

    static void MoveFile(string fileName, string destinationFolder)
    {
        Directory.CreateDirectory(destinationFolder); // kocurulecek unvanda foler yaradiriq
        string destinationPath = Path.Combine(destinationFolder, Path.GetFileName(fileName));
        File.Move(fileName, destinationPath);
        Console.WriteLine($"File '{fileName}' moved to '{destinationFolder}'.");
    }

    static void SearchFile(string fileName)
    {
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), fileName, SearchOption.AllDirectories);
        foreach (string file in files)
        {
            Console.WriteLine($"Found file: {file}");
        }
    }

    static void ListAllFiles()
    {
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories);
        foreach (string file in files)
        {
            Console.WriteLine(file);
        }
    }
}
