using System;
using System.Collections.Generic;
using System.IO;

// 1. Determine the current directory
Console.WriteLine(Directory.GetCurrentDirectory());

// 2. Loop through folders/directories (When I have folders)
// use Directory.EnumerateDirectories(folderName)

// 3. Loop through files 
IEnumerable<string> files = Directory.EnumerateFiles(Directory.GetCurrentDirectory());
// foreach (var file in files)
// {
//     // Outputs full path to a file
//     Console.WriteLine(file);
// }

Console.WriteLine("------------------");

// 3.2 Slightly different
var files2 = Directory.EnumerateFiles(".", "*.json");
foreach (var file in files2)
{
    // Just outputs filename plus extension
    Console.WriteLine(file);
}

Console.WriteLine("------------------");

// 4. return the path to the equivalent of the Windows Documents folder
string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
// Console.WriteLine(docPath);

// 4.2 This is functionally identical:
string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
// Console.WriteLine(path2);

Console.WriteLine("------------------");

// 5. Use correct DirectorySeparatorChar
Console.WriteLine($"The correct directory separator on my machine is: {Path.DirectorySeparatorChar}");

// 6. Use Path.Combine (not sure on what though)

// 7. Get file extension of a file - this only makes sense for a search or for variables that come from another source

Console.WriteLine("------------------");

// 8. FileInfo(fileName)
FileInfo info = new FileInfo("users.json");
// Console.WriteLine($"{info.FullName}\n{info.Name}\n{info.Directory}\n{info.Extension}\n{info.CreationTime}");

// 9. Create a new folder using Directory.CreateDirectory(folderName)
string currDir = Directory.GetCurrentDirectory();
Directory.CreateDirectory(Path.Combine(currDir, "data"));

// 10. Check if a directory exists using Directory.Exists(folderName)
char sep = Path.DirectorySeparatorChar;
bool doesDirectoryExist = Directory.Exists($"{currDir}{sep}data");
Console.WriteLine(doesDirectoryExist);

// 11. Create a file using File.WriteAllText(fileName, text)

// 12. Read data from files using File.ReadAllText(fileName)

// 13. Parse data in files

// 14. Write data to files

// 15. Append data to files