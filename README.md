# CSharp System.IO Classes

This is a CSharp app using `System.IO` app classes to manipulate files and directories. This app creates and deletes files, reads from files, writes to files, and parses data in files using the `Path`, `Directory`, and `File` classes.

Other classes to add to this project:

- FileStream
- StreamReader
- StreamWriter
- BinaryReader
- BinaryWriter
- DirectoryInfo
- FileInfo

<span aria-hidden="true"><br></span>

## Installation & Usage

1. Clone this repository and switch into project folder

   ```sh
   git clone https://github.com/Kernix13/csharp-system-io-classes.git SystemIOClasses
   cd SystemIOClasses
   ```

2. Run the application

   ```bash
   dotnet run
   ```

3. Build the application

   ```bash
   dotnet build
   ```

### Quick Start

```sh
git clone https://github.com/Kernix13/csharp-system-io-classes.git SystemIOClasses
cd SystemIOClasses
dotnet run
```

<span aria-hidden="true"><br></span>

## Important notes and code

### Files and folders

1. The `System.IO` namespace
2. The `Directory` class contained in the System.IO namespace
   - static methods: creating, moving, & enumerating thru directories
3. The `System.Collections.Generic`: a namespace in .NET that contains classes and interfaces for defining generic collections which allow you to create strongly typed groups of objects, such as lists and dictionaries, which offer better performance and type safety than non-generic collections
   - You need to add it with a `using` statement for Lists and IEnumerable
   - When you wrote `IEnumerable<string>`, that angle-bracket syntax (`<string>`) is called a Generic. It’s basically telling C#, "I want a sequence, but specifically a sequence of strings." Without `System.Collections.Generic`, the computer wouldn't know how to handle that typed list.

#### Classes

- The `Directory` class: often used to list out (or enumerate) directories
  - What is `IEnumerable`
  - `EnumerateDirectories("dirName")`: list the names of all of the folders in a directory
  - `EnumerateFiles("dirName")`: list the names of all of the files in a directory,
  - `SearchOption.AllDirectories`:

```cs
using System.IO;

// Folders/directories
IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories("stores");
foreach (var dir in listOfDirectories) {
    // just outputs dir/foldername
    Console.WriteLine(dir);
}

// Files
IEnumerable<string> files = Directory.EnumerateFiles("stores");
foreach (var file in files) {
    // just outputs dir/filename.ext
    Console.WriteLine(file);
}

// EnumerateDirectories('folder', "pattern", SearchOption.AllDirectories)
// EnumerateFiles('folder', "pattern", SearchOption.AllDirectories)
```

### File paths

.NET provides some built-in constants and utility functions to make it easier to handle file paths.

1. `System.Environment`: A class that provides a static set of tools to retrieve information about and manipulate the current platform and execution environment
   - `System.Environment.SpecialFolder`: enumeration specifies constants to retrieve paths to special system folders
   - `System.Environment.SpecialFolder`: enumeration specifies constants to retrieve paths to special system folders, such as a home directory

#### Classes

- `Directory.GetCurrentDirectory()`: exposes the full path to the current directory - like `Path`, to define and compose file-system paths
- `Path`: located in the System.IO namespace - builds & parses strings, it doesn't care whether things actually exist
  - `Path.DirectorySeparatorChar` field: `\` vs `/` for different OSs
  - `Path.Combine("parent", "child")`
  - `Path.GetExtension("file.ext")`: returns .ext
- `DirectoryInfo(filename)`:
- `FileInfo (filename)`:
- What is `Environment.NewLine`? To put the value on its own line

```cs
// Determine the current directory
Console.WriteLine(Directory.GetCurrentDirectory());

// return the path to the equivalent of the Windows Documents folder, or the user's HOME directory for any operating system
string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
// this is functionally identical:
string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

// Use correct DirectorySeparatorChar
Console.WriteLine($"dirName{Path.DirectorySeparatorChar}subFolderName");

// Path.Combine
Console.WriteLine(Path.Combine("stores", "201")); // outputs: stores/201

// Get file extension of a file
Console.WriteLine(Path.GetExtension("sales.json")); // outputs: .json
var extension = Path.GetExtension(file);

// FileInfo
FileInfo info = new FileInfo(fileName);
// info.FullName
// info.Directory
// info.Extension
// info.CreationTime
```

### Create files and directories

- `Directory` class: also can create, delete, copy, move, & manipulate directories
  - `Directory.CreateDirectory()`: It creates any directories and subdirectories passed to it
  - `Directory.Exists(filePath)`: checks if a directory already exists - returns a boolean
- `File`: does the same as `Directory`
  - `File.WriteAllText()`: takes in a path to the file and the data you want to write to the file. If the file already exists, it's overwritten

```cs
// Create a new folder called newDir inside the 201 folder
// If /stores/201 doesn't already exist, it's created automatically
Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir"));
string currDir = Directory.GetCurrentDirectory();
Directory.CreateDirectory(Path.Combine(currDir, "data"));

// Make sure directories exist
bool doesDirectoryExist = Directory.Exists(filePath);

string sep = Path.DirectorySeparatorChar;
bool doesDirectoryExist = Directory.Exists($"{currDir}{sep}data");
Console.WriteLine(doesDirectoryExist);

// Create a file
File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");

File.WriteAllText(Path.Combine(currDir, "text.txt), "Testing File.WriteAllText"));
```

### Read and write to files

- `File`: does the same as `Directory`
  - `File.ReadAllText()`: Used to read files - The return object is a string
- `Json.NET` library: to parse JSON files with .NET
  - `JsonConvert.DeserializeObject()`:
  - `File.WriteAllText()`: To write data to a file, pass in the data that you want to write
  - `File.AppendAllText()`: by default, creates the file if it doesn't already exist

```cs
// Read data from files
File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");

// Parse data in files:
// TERMINAL NuGet COMMAND: dotnet add package Newtonsoft.Json
using Newtonsoft.Json
var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);
class SalesTotal {
  public double Total { get; set; }
}

// Write data to files
var data = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

File.WriteAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", data.Total.ToString());

// Append data to files
var data = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{data.Total}{Environment.NewLine}");

var appendedText = "Added using File.AppendAllText";

string newTextext = File.AppendAllText(Path.Combine(currDir, "text.txt"), $"{appendedText}{Environment.NewLine}");
Console.WriteLine(newTextext);
```

### Output for most of the above for code in Program.js

```
1. CURRENT DIRECTORY: C:\Users\pc\Documents\WebDev\CodeYou\CSharp\M2\SystemIOClasses
3. LOOP THRU FILES & GET FULL FILE PATH:
C:\Users\pc\Documents\WebDev\CodeYou\CSharp\M2\SystemIOClasses\.gitignore
C:\Users\pc\Documents\WebDev\CodeYou\CSharp\M2\SystemIOClasses\chord-intervals.json
C:\Users\pc\Documents\WebDev\CodeYou\CSharp\M2\SystemIOClasses\notes.md
C:\Users\pc\Documents\WebDev\CodeYou\CSharp\M2\SystemIOClasses\Program.cs
C:\Users\pc\Documents\WebDev\CodeYou\CSharp\M2\SystemIOClasses\README.md
C:\Users\pc\Documents\WebDev\CodeYou\CSharp\M2\SystemIOClasses\SystemIOClasses.csproj
C:\Users\pc\Documents\WebDev\CodeYou\CSharp\M2\SystemIOClasses\SystemIOClasses.slnx
C:\Users\pc\Documents\WebDev\CodeYou\CSharp\M2\SystemIOClasses\text.txt
C:\Users\pc\Documents\WebDev\CodeYou\CSharp\M2\SystemIOClasses\users.json
------------------
3.2 LOOP THRU FILES & GET FILE NAME (.json files only):
.\chord-intervals.json
.\users.json
------------------
4. Environment.SpecialFolder.MyDocuments: C:\Users\pc\Documents
4.2 Environment.SpecialFolder.Personal: C:\Users\pc\Documents
------------------
5. DirectorySeparatorChar: \
------------------
8. FileInfo (5 properties):
FullName: C:\Users\pc\Documents\WebDev\CodeYou\CSharp\M2\SystemIOClasses\users.json
Name: users.json
Directory: C:\Users\pc\Documents\WebDev\CodeYou\CSharp\M2\SystemIOClasses
Extension: .json
CreationTime: 5/6/2026 5:51:38 PM
------------------
10. Directory.Exists (data folder):
True
------------------
12. File.ReadAllText (text.txt):
Testing File.WriteAllText
------------------
15. File.AppendAllText (text.txt):
Testing File.WriteAllText
Added using File.AppendAllText
```

<!-- https://jsonplaceholder.typicode.com/ -->

## Additional notes

> The `Path` and `Directory` classes in .NET provide methods for creating, deleting, moving, and enumerating directories. The `File` class provides methods for performing various file operations such as reading, writing, copying, and deleting files.

1. Construct file and directory paths by using the Path class.
2. Create directories and files by using the Directory and File classes.
3. Enumerate directories and files by using the Directory class.

- Common text file formats: TXT, CSV, JSON, XML
- Path class:
  - Combine
  - GetDirectoryName
  - GetFileName
  - GetFileNameWithoutExtension
  - GetExtension
  - GetFullPath
  - GetTempPath
  - GetTempFileName
- Directory class:
  - CreateDirectory
  - Exists
  - GetCurrentDirectory
  - GetFiles
  - Delete
  - Move
  - EnumerateDirectories
  - EnumerateFiles
  - GetDirectories
  - GetParent
- File class:
  - Exists
  - Create
  - Delete
  - Copy
  - Move
  - ReadAllText
  - WriteAllText
  - AppendText
  - ReadAllLines
  - `WriteAllLines`
  - Open
  - OpenRead
  - OpenWrite
  - OpenText
  - GetAttributes
  - SetAttributes
- Stream: FileStream, MemoryStream, NetworkStream
- StreamReader (IDisposable interface)
  - Read
  - ReadLine
  - ReadToEnd
  - Peek
  - Close
  - Dispose
- StreamWriter (IDisposable interface)
  - Write
  - WriteLine
  - Flush
  - Close
  - Dispose
- StringBuilder (System.Text namespace)
- FileStream
  - Open
  - Create
  - Read, ReadAsync
  - Write, WriteAsync
  - CopyTo, CopyToAsync
  - Seek
  - Length
  - Position
  - CanRead
  - CanWrite
  - CanSeek
  - Flush, FlushAsync
  - Close
  - Dispose
  - FileAccess: Read, Write, or ReadWrite
  - FileShare: None, Read, Write, or ReadWrite
  - FileMode: Append, Create, CreateNew, Open, OpenOrCreate, or Truncate
  - FileOptions: None, Asynchronous, SequentialScan, RandomAccess, or WriteThrough
  - SKIP: BinaryReader and BinaryWriter classes

JSON:

- Serialization is used to convert a C# object into a JSON string
- Deserialization is the reverse process: Convert a JSON string back into a C# object
  - it is particularly useful when working with APIs or external data sources
- `System.Text.Json` namespace
  - JsonSerializer: for **converting**
  - JsonDocument: or **reading and parsing** JSON data without needing to deserialize them
  - JsonElement: for **accessing and manipulating** JSON data
- JsonSerializer
  - Serialize: object -> JSON
  - Deserialize: JSON -> object

```cs
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
}

// In Program.cs
// Serialize
var customer = new Employee { Name = "Anette Thomsen", Age = 30, Address = "123 Main St" };
string jsonString = JsonSerializer.Serialize(customer);
Console.WriteLine(jsonString);
// Output: {"Name":"Anette Thomsen","Age":30,"Address":"123 Main St"}

// Deserialize
string jsonString2 = @"{""Name"":""Anette Thomsen"",""Age"":30,""Address"":""123 Main St""}";
var customer = JsonSerializer.Deserialize<Employee>(jsonString2);
if (customer != null)
{
    Console.WriteLine($"Name: {customer.Name}, Age: {customer.Age}, Address: {customer.Address}");
}
else
{
    Console.WriteLine("Deserialization failed.");
}
// Output: Name: Anette Thomsen, Age: 30, Address: 123 Main St
```

- JsonSerializerOptions
  - DefaultIgnoreCondition
  - WriteIndented
  - IncludeFields
  - PropertyNameCaseInsensitive
  - AllowTrailingCommas
  - IgnoreNullValues
  - Encoder
  - IgnoreReadOnlyProperties
  - WhenWritingNull
  - WhenWritingDefault
  - RespectRequiredConstructorParameters
  - PreferredObjectCreationHandling
  - Converters
  - DefaultBufferSize
  - AllowOutOfOrderMetadataProperties
  - NumberHandling
- `[JsonIgnore]`: specify conditional exclusion via `Condition` property
  - [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  - [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
  - [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
- DefaultIgnoreCondition (?)
- `required` modifier = `[JsonRequired]`
- `JsonSerializer.Deserialize(<objType>jsonString`
- JsonRequiredAttribute?
- JsonPropertyInfo.IsRequired?
- JsonObjectCreationHandling
  - Replace
  - Populate
- JsonObjectCreationHandlingAttribute

> WTF? Why have options on what to serialize/deserialize?

> STOPPED: Manage serialization and deserialization of complex objects
