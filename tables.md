# Tables of used vs unused methods by lesson

This file has all the classes, methods, and properties mentioned in week 5 of module 2.

I have a "Found in" column in some tables with the intention of making a note of which week and lesson the method can be found in. But that may get crowded as some were used in many lessons.

The used classes, methods, & properties are in tables, but I put the unused methods as list items because there were too many of them.

I also added a "ALSO USED" list for othings used in the exercises/examples.

NOTE: `-- Term` means "Term" is a method or property for the item above it.

## 1. Work with files and directories in a .NET app

### Path class

| Used (5 + 1)                | Found in: |
| :-------------------------- | :-------- |
| Combine                     |           |
| GetDirectoryName            |           |
| GetFileNameWithoutExtension |           |
| GetExtension                |           |
| DirectorySeparatorChar      |           |

ALSO USED:

- Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

NOT USED (4):

- GetFileName, GetFullPath, GetTempPath, GetTempFileName

. . . . . . . . . . . . . .

### Directory class

| Used (6 + 1)         | Found in: |
| :------------------- | :-------- |
| Exists               |           |
| CreateDirectory      |           |
| GetCurrentDirectory  |           |
| GetFiles             |           |
| EnumerateFiles       |           |
| EnumerateDirectories | M2-W5 L1  |

ALSO USED:

- SearchOption.AllDirectories (Directory.EnumerateFiles)

NOT USED (4):

- Delete, Move, GetDirectories, GetParent

. . . . . . . . . . . . . .

### File class

| Used (8)        | Found in: |
| :-------------- | :-------- |
| WriteAllText    |           |
| ReadAllText     |           |
| ReadAllLines    |           |
| AppendAllText   |           |
| Copy            |           |
| Move            |           |
| Delete          |           |
| `WriteAllLines` |           |

NOT USED (11):

- Exists, Create, AppendText, ReadAllBytes, WriteAllBytes, Open, OpenRead, OpenWrite, OpenText, GetAttributes, SetAttributes

. . . . . . . . . . . . . .

### FileInfo class

| Used (5)        | Found in: |
| :-------------- | :-------- |
| new FileInfo    |           |
| -- FullName     |           |
| -- Directory    |           |
| -- Extension    |           |
| -- CreationTime |           |

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

......................................................................

## 2. Get started with file input and output

> See above for: `Path`, `Directory`, and `File`

This section has: Stream, StreamReader, StreamWriter, & FileStream

### StreamReader class

| Used (3)              |
| :-------------------- |
| new StreamReader      |
| -- ReadLine           |
|                       |
| IDisposable interface |

NOT USED (5):

- Read, ReadToEnd, Peek, Close, Dispose

. . . . . . . . . . . . . .

### StreamWriter class

| Used (3)              |
| :-------------------- |
| new StreamWriter      |
| -- WriteLine          |
| -- ReadLine           |
|                       |
| IDisposable interface |

NOT USED (4):

- Write, Flush, Close, Dispose

. . . . . . . . . . . . . .

### StringBuilder class (System.Text namespace)

| Used (2)          |
| :---------------- |
| new StringBuilder |
| -- AppendLine     |

. . . . . . . . . . . . . .

### FileStream class

| Used (14)       |
| :-------------- |
| new FileStream  |
| -- Write        |
| -- Flush        |
| -- Seek         |
| -- Read         |
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

> See above for: `Path`, `Directory`, and `File`

This section has: Serialize, Deserialize, & JsonSerializerOptions

### JsonSerializer class

| Used (2)                 |
| :----------------------- |
| Serialize                |
| Deserialize              |
| `Deserialize<type>(str)` |

. . . . . . . . . . . . . .

### JsonSerializerOptions class/thing ✅

| Used (6)                  |
| :------------------------ |
| WriteIndented             |
| ReferenceHandler          |
| ReferenceHandler.Preserve |
| [JsonIgnore]              |
| DefaultIgnoreCondition    |
| IncludeFields             |

ALSO USED (7):

- `ReferenceHandler.Preserve`
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

- DTO?

......................................................................

| Used | Not Used |
| :--- | :------- |
| 67   | 76       |
