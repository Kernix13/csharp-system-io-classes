# CSharp System.IO Classes

This is a CSharp app using System.IO app classes to manipulate files and directories. This app creates and deletes files, reads from files, writes to files, and parses data in files.

<!--
    1. repo name: csharp-system-io-classes
    2. About text: A CSharp app that creates, deletes, reads, and writes to files using classes from the .NET System.IO namespace.
    3. Topics: csharp,
-->

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
git https://github.com/Kernix13/csharp-system-io-classes.git SystemIOClasses
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

// Make sure directories exist
bool doesDirectoryExist = Directory.Exists(filePath);

// Create a file
File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");
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
```

<!-- https://jsonplaceholder.typicode.com/ -->
