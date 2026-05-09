# Tables of used vs unused methods by lesson for Module 2 Week 5

This file has all the classes, methods, and properties mentioned in week 5 of module 2.

I have a "Found in" column in some tables with the intention of making a note of which week and lesson the method can be found in. But that may get crowded as some were used in many lessons.

The used classes, methods, & properties are in tables, but I put the unused methods as list items because there were too many of them.

I also added a "ALSO USED" list for othings used in the exercises/examples.

NOTE: `-- Term` means "Term" is a method or property for the item above it.

## 1. Work with files and directories in a .NET app

### Path class

[Path class](https://learn.microsoft.com/en-us/dotnet/api/system.io.path?view=net-10.0): a static utility class in the `System.IO` namespace used to perform operations on strings that represent file or directory paths. You do not need to create an instance of the Path class; you call its methods directly (e.g., `Path.Combine(...)`)

| Used (5 + 1)                     | Use (Y/N/M) |
| :------------------------------- | :---------: |
| Combine(folder, subFolder, file) |      Y      |
| GetDirectoryName(string)         |      Y      |
| DirectorySeparatorChar           |      Y      |
| GetExtension(string)             |      M      |
| GetFileNameWithoutExtension      |      N      |

ALSO USED:

- SKIP: Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

NOT USED (4):

- GetFileName, GetFullPath, GetTempPath, GetTempFileName
  - The first 2 may be useful

```cs
// Path.Combine(folder, subFolder, file);
using System;
using System.IO;

string directoryPath = @"C:\ExampleDirectory";
        string fileName = "example.txt";

// Combine directory and file name to create a full path
string fullPath = Path.Combine(directoryPath, fileName);
Console.WriteLine("Full Path: " + fullPath);
```

. . . . . . . . . . . . . .

### Directory class

[Directory class](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory?view=net-10.0): found in the `System.IO` namespace, provides static methods for creating, moving, and enumerating through **directories** and **subdirectories**. You don't need to create an instance (object) to use its methods.

| Used (6 + 1)          | Use (Y/N/M) |
| :-------------------- | :---------: |
| Exists(path)          |      Y      |
| CreateDirectory(path) |      Y      |
| GetCurrentDirectory   |      Y      |
| GetFiles(path)        |      Y      |
| EnumerateFiles        |      Y      |
| EnumerateDirectories  |   N or M    |

ALSO USED:

- SearchOption.AllDirectories (Directory.EnumerateFiles)
  - Do you just add it as an argument?
  - I won't have nested folders so skip for now.

NOT USED (4):

- Delete: This may be useful
- Move: Skip
- GetDirectories: This may be useful
- GetParent: This may be useful

```cs
using System;
using System.IO;

string directoryPath = @"C:\ExampleDirectory";

// Create a new directory
Directory.CreateDirectory(directoryPath);

// Check if the directory exists
if (Directory.Exists(directoryPath)) {
    Console.WriteLine("Directory exists.");

    // Enumerate files in the directory
    foreach (string file in Directory.EnumerateFiles(directoryPath)) {
        Console.WriteLine(file);
    }
} else {
    Console.WriteLine("Directory does not exist.");
}
```

. . . . . . . . . . . . . .

### File class

[File class](https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-10.0): the `System.IO.File` class is a static class used for common operations like creating, copying, deleting, and reading from files.

| Used (8)                      | Use (Y/N/M) |
| :---------------------------- | :---------: |
| ReadAllText(path)             |      Y      |
| WriteAllText(path, contents)  |      Y      |
| AppendAllText(path, contents) |      Y      |
| `WriteAllLines`               |      Y      |
| ReadAllLines                  |      M      |
| Copy(source, destination)     |      M      |
| Delete(path)                  |      M      |
| Move(source, destination)     |      N      |

NOT USED (11):

- Exists(path): This may be useful
- Skip for now: Create, AppendText, ReadAllBytes, WriteAllBytes, Open, OpenRead, OpenWrite, OpenText, GetAttributes, SetAttributes

. . . . . . . . . . . . . .

### FileInfo class

[FileInfo class](https://learn.microsoft.com/en-us/dotnet/api/system.io.fileinfo?view=net-10.0): Use for operations such as copying, moving, renaming, creating, opening, deleting, and appending to files. It provides the same functionality as the static File class but you have more control on read/write operations on files by writing code manually for reading or writing bytes from a file.

| Used (5)        | Use (Y/N/M) |
| :-------------- | :---------: |
| new FileInfo    |      Y      |
| -- Extension    |      Y      |
| -- CreationTime |      M      |
| -- FullName     |      N      |
| -- Directory    |      N      |

- I need the "useful" methods to use as opposed to the information-only methods/properties in the table above.

. . . . . . . . . . . . . .

OTHER C# METHODS & KEYWORDS USED:

- foreach (Directory.GetDirectories & Directory.GetFiles, Directory.EnumerateDirectories, Directory.EnumerateFiles)
- GetLength (for loop)
- double.Parse
- IEnumerable
- new List
- EndsWith
- Add
- Environment.NewLine
- String.Empty

```cs
using System;
using System.IO;

string filePath = @"C:\ExampleFile.txt";

// Create a new file and write text to it
File.WriteAllText(filePath, "Hello, World!");

// Read the text from the file
string text = File.ReadAllText(filePath);
Console.WriteLine(text);
```

```cs
using System;
using System.IO;

string directoryPath = @"C:\ExampleDirectory";
string fileName = "example.txt";
string filePath = Path.Combine(directoryPath, fileName);

// Create a new directory
Directory.CreateDirectory(directoryPath);

// Create a new file and write text to it
File.WriteAllText(filePath, "Hello, World!");

// Read the text from the file
string text = File.ReadAllText(filePath);
Console.WriteLine(text);
```

......................................................................

## 2. Get started with file input and output

> See above for: `Path`, `Directory`, and `File` usage

This section has: StreamReader, StreamWriter, StringBuilder, & FileStream

### StreamReader class

[StreamReader class](https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-10.0): a specialized tool in the `System.IO` namespace used to read characters from a byte stream, such as a text file. It translates bytes into readable text using a specific encoding, defaulting to `UTF-8`:

- Specifically designed for reading _standard text files_ and _character input_
- Automatically handles character decoding, allowing you to specify different formats like ASCII or Unicode if needed
- It reads data in small chunks (buffers) from large files, which prevents memory strain and improves application performance
- Skip code for CSV files unless I use .csv rather than .json

| Used (3)              |
| :-------------------- |
| new StreamReader      |
| -- ReadLine()         |
|                       |
| IDisposable interface |

NOT USED (5):

- Read(): This may be useful
- ReadToEnd(): This may be useful
- Skip: Peek, Close, Dispose

. . . . . . . . . . . . . .

### StreamWriter class

[StreamWriter class](https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-10.0): is a part of the System.IO namespace designed for writing characters to a stream (like a file) in a specific encoding. It is a standard tool for creating or modifying text files because it simplifies the process of converting strings into the bytes required by the underlying file system.

- Encodings: Defaults to UTF-8
- Buffering: Internally buffers data to optimize performance

| Used (3)              |
| :-------------------- |
| new StreamWriter      |
| -- WriteLine          |
| -- ReadLine           |
|                       |
| IDisposable interface |

NOT USED (4):

- Maybe: Write, Flush
- Skip if you use `using`: Close, Dispose

. . . . . . . . . . . . . .

### StringBuilder class (System.Text namespace)

> SKIP: For performance reasons only?

[StringBuilder class](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-10.0): from the `System.Text` namespace, is a mutable sequence of characters. Unlike the standard `string` type, which is immutable, `StringBuilder` allows you to modify content directly within its internal buffer. This makes it significantly more efficient for performance-heavy tasks like building large strings in a loop.

| Used (2)          |
| :---------------- |
| new StringBuilder |
| -- AppendLine     |

. . . . . . . . . . . . . .

### FileStream class 🚫

> SKIP: I do not see a use for this in my deliverable or project

[FileStream class](https://learn.microsoft.com/en-us/dotnet/api/system.io.filestream?view=net-10.0): provides a stream for file operations, allowing you to read from and write to files at a byte level. It is ideal _for handling binary data or large files_ where performance and direct control are necessary.

| Used (14)       |
| :-------------- |
| new FileStream  |
| -- Read         |
| -- Write        |
| -- Seek         |
| -- Flush        |
|                 |
| FileMode        |
| -- OpenOrCreate |
| -- Open         |
| -- Create       |
|                 |
| FileAccess      |
| -- Write        |
| -- Read         |
|                 |
| FileShare       |
| -- None         |

ALSO USED (4):

- System.Text.Encoding.UTF8.GetBytes (FileStream)
- System.Text.Encoding.UTF8.GetString (FileStream)
- new UTF8Encoding(true).GetBytes (?)
- new UTF8Encoding(true) (?)

NOT USED (34):

- Open, Create, Read, ReadAsync, WriteAsync, CopyTo, CopyToAsync, Length, Position, CanRead, CanWrite, CanSeek, FlushAsync, Close, Dispose, FileAccess: ReadWrite, FileShare: None, Read, Write, or ReadWrite, FileMode: Append, Create, CreateNew, or Truncate, FileOptions: None, Asynchronous, SequentialScan, RandomAccess, or WriteThrough, System.Text.Encoding.UTF8.GetBytes

CLASSES NOT USED IN THIS MODULE:

- DirectoryInfo, Stream (FileStream, MemoryStream, NetworkStream)
- SKIP: BinaryReader & BinaryWriter (Write)

OTHER C# METHODS & KEYWORDS USED:

- while loop (StreamReader: every time)
- foreach (StringBuilder, StreamWriter)
- Split
- `new List<type>`
- ToString
- Environment.NewLine?
- StringSplitOptions.RemoveEmptyEntries?

......................................................................

## 3. Store and retrieve JSON files

> See above for: `Path`, `Directory`, and `File` usage

This section has: Serialize, Deserialize, & JsonSerializerOptions

### JsonSerializer class

[JsonSerializer class](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer?view=net-10.0): is a static class provided by the System.Text.Json namespace...for converting .NET objects into JSON strings (serialization) and converting JSON strings back into .NET objects (deserialization).

| Used (2)                  | Lesson |
| :------------------------ | :----: |
| Serialize                 |   3    |
| Deserialize               |   3    |
| `Deserialize<type>(str)`  |   3    |
| File.WriteAllText         |   1    |
| Path.Combine              |   1    |
| Path.GetDirectoryName     |   1    |
| Directory.Exists          |   1    |
| Directory.CreateDirectory |   1    |

- `using System.Text.Json;`
- Serialization: the process of converting the state of an object (the values of its properties) into a form that can be stored or transmitted - no information about an object's associated methods
- The `Serialize` method takes an object as input and returns a JSON string
- The `Deserialize` method is used to convert a JSON string back into a C# object
- The `File.WriteAllText` method can be used to write the JSON string to a file
- `[JsonRequired]`: used for `Deserialize` for any property that is required
- SKIP: initialized properties syntax
- Why does the `Deserialize` object always have an if/else block following it?

```cs
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Employee {
    [JsonRequired] // Add for Deserialize
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
}

// In Program.cs
// Serialize example
var customer = new Employee { Name = "Anette Thomsen", Age = 30, Address = "123 Main St" };
string jsonString = JsonSerializer.Serialize(customer);
// Save the JSON to a file:
File.WriteAllText("employee.json", jsonString);

// Deserialize example
string jsonString2 = @"{""Name"":""Anette Thomsen"",""Age"":30,""Address"":""123 Main St""}";
var customer2 = JsonSerializer.Deserialize<Employee>(jsonString2);
// If dealing with an array: JsonSerializer.Deserialize<type>(obj[i]);

if (customer2 != null) {
    Console.WriteLine($"Name: {customer2.Name}, Age: {customer2.Age}, Address: {customer2.Address}");
} else {
    Console.WriteLine("Deserialization failed.");
}

/* The steps needed to store the JSON objects */
// Construct a file path where the serialized objects (JSON string) can be stored
// Do I need the 2nd argument?
string someJsonFilePath = Path.Combine("folderName", "subFolderName", "someName" + ".json");

// Create the parent directory for the serialized transactions file
var directoryPath = Path.GetDirectoryName(someJsonFilePath);
//  I am confused by this code block:
if (directoryPath != null && !Directory.Exists(directoryPath)) {
    Directory.CreateDirectory(directoryPath);
}

// Store the serialized JSON string to a file
File.WriteAllText(someJsonFilePath, jsonString);
// Why not just follow the process for File.WriteAllText above here?
```

. . . . . . . . . . . . . .

### JsonSerializerOptions class 🚫

> Skip this class for my deliverable - have only simple classes with public properties and no initialization!

[JsonSerializerOptions class](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions?view=net-10.0): is a class in the `System.Text.Json` namespace that allows you to customize how objects are converted to and from JSON.

| Used (6)                  |
| :------------------------ |
| **WriteIndented**         |
| ReferenceHandler          |
| ReferenceHandler.Preserve |
| [JsonIgnore]              |
| DefaultIgnoreCondition    |
| IncludeFields             |

ALSO USED (7):

- `ReferenceHandler.Preserve` - skip ReferenceHandler because it is only used with complex objects which I will not be using.
- Condition = JsonIgnoreCondition.WhenWritingDefault
- Condition = JsonIgnoreCondition.Never
- Condition = JsonIgnoreCondition.WhenWritingNull
- JsonIgnoreCondition.WhenWritingDefault
- IgnoreReadOnlyProperties
- PreferredObjectCreationHandling = JsonObjectCreationHandling.Populate

NOT USED (14):

- PropertyNameCaseInsensitive | AllowTrailingCommas | IgnoreNullValues | Encoder | IgnoreReadOnlyProperties | WhenWritingNull | WhenWritingDefault | RespectRequiredConstructorParameters | PreferredObjectCreationHandling | Converters | DefaultBufferSize | AllowOutOfOrderMetadataProperties | NumberHandling | MaxDepth

. . . . . . . . . . . . . .

OTHER C# METHODS & KEYWORDS USED:

- DateOnly
- ElementAt
- Transaction?
- TimeOnly
- Guid
- ex.Message
- Split
- IsNullOrEmpty
- throw new Exception
- throw new ArgumentException
- `IEnumerable<Type> `
- ToString
- Add
- DateTime.Now
- Find

CLASSES NOT USED IN THIS MODULE:

- JsonDocument
- JsonElement

Questions

- DTO? SKIP - this is also for large &/or complex objects

......................................................................

| Used | Not Used |
| :--- | :------- |
| 67   | 76       |
