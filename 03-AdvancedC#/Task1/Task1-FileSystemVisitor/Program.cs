using System;
using System.IO;
using Task1_FileSystemVisitor;

class Program
{
    static void Main(string[] args)
    {
        Func<FileSystemInfo, bool> filter = fileSystemInfo =>
            fileSystemInfo is FileInfo file && file.Extension == ".txt";

       var visitor = new FileSystemVisitorApp(@"C:\Users\lotus_biswas\Documents\net-mentoring-program\03-AdvancedC#\TestFolder", filter);

        visitor.SearchStarted += (sender, e) => Console.WriteLine("Search started.");
        visitor.SearchFinished += (sender, e) =>
        {
            if (e.AbortSearch)
            {
                Console.WriteLine("Search was aborted due to finding f2.txt.");
            }
            else
            {
                Console.WriteLine("Search finished.");
            }
        };

        visitor.FileFound += (sender, e) => Console.WriteLine($"File found: {e.FileSystemInfo.FullName}");
        visitor.DirectoryFound += (sender, e) => Console.WriteLine($"Directory found: {e.FileSystemInfo.FullName}");
        visitor.FilteredFileFound += (sender, e) => Console.WriteLine($"Filtered file: {e.FileSystemInfo.FullName}, Excluded: {e.Exclude}");
        visitor.FilteredDirectoryFound += (sender, e) => Console.WriteLine($"Filtered directory: {e.FileSystemInfo.FullName}, Excluded: {e.Exclude}");

        foreach (var item in visitor.Traverse())
        {
            Console.WriteLine(item.FullName);
        }
    }
}
