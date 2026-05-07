using System;
using System.Collections.Generic;
using System.IO;

using System.Text;

using System.Text.Json;
using System.Text.Json.Serialization;

// 1. Determine the current directory
Console.WriteLine($"1. CURRENT DIRECTORY: {Directory.GetCurrentDirectory()}");

// 2. Loop through folders/directories (When I have folders)
// use Directory.EnumerateDirectories(folderName)

// 3. Loop through files 
IEnumerable<string> files = Directory.EnumerateFiles(Directory.GetCurrentDirectory());
Console.WriteLine("3. LOOP THRU FILES & GET FULL FILE PATH:");
foreach (var file in files)
{
    // Outputs full path to a file
    Console.WriteLine(file);
}

Console.WriteLine("------------------");

// 3.2 Slightly different
var files2 = Directory.EnumerateFiles(".", "*.json");
Console.WriteLine("3.2 LOOP THRU FILES & GET FILE NAME (.json files only):");
foreach (var file in files2)
{
    // Just outputs filename plus extension
    Console.WriteLine(file);
}

Console.WriteLine("------------------");

// 4. return the path to the equivalent of the Windows Documents folder
string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
Console.WriteLine($"4. Environment.SpecialFolder.MyDocuments: {docPath}");

// 4.2 This is functionally identical:
string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
Console.WriteLine($"4.2 Environment.SpecialFolder.Personal: {path2}");

Console.WriteLine("------------------");

// 5. Use correct DirectorySeparatorChar
Console.WriteLine($"5. DirectorySeparatorChar: {Path.DirectorySeparatorChar}");

// 6. Use Path.Combine (not sure on what though)

// 7. Get file extension of a file - this only makes sense for a search or for variables that come from another source

Console.WriteLine("------------------");

// 8. FileInfo(fileName)
FileInfo info = new FileInfo("users.json");
Console.WriteLine("8. FileInfo (5 properties):");
Console.WriteLine($"FullName: {info.FullName}\nName: {info.Name}\nDirectory: {info.Directory}\nExtension: {info.Extension}\nCreationTime: {info.CreationTime}");

Console.WriteLine("------------------");

// 9. Create a new folder using Directory.CreateDirectory(folderName)
string currDir = Directory.GetCurrentDirectory();
Directory.CreateDirectory(Path.Combine(currDir, "data"));

// 10. Check if a directory exists using Directory.Exists(folderName)
char sep = Path.DirectorySeparatorChar;
bool doesDirectoryExist = Directory.Exists($"{currDir}{sep}data");
Console.WriteLine("10. Directory.Exists (data folder):");
Console.WriteLine(doesDirectoryExist);

// 11. Create a file using File.WriteAllText(fileName, text)
File.WriteAllText(Path.Combine(currDir, "text.txt"), "Testing File.WriteAllText");

Console.WriteLine("------------------");

// 12. Read data from files using File.ReadAllText(fileName)
string text = File.ReadAllText(Path.Combine(currDir, "text.txt"));
Console.WriteLine("12. File.ReadAllText (text.txt):");
Console.WriteLine(text);

Console.WriteLine("------------------");

// 13. Parse data in files (?)

// 14. Write data to files (Need above I think)

// 15. Append data to files
var appendedText = "Added using File.AppendAllText";

File.AppendAllText(Path.Combine(currDir, "text.txt"), $"{Environment.NewLine}{appendedText}");
// Console.WriteLine(text); // WTF does that not print the new text in the file?
string newText = File.ReadAllText(Path.Combine(currDir, "text.txt"));
Console.WriteLine("15. File.AppendAllText (text.txt):");
Console.WriteLine(newText);
