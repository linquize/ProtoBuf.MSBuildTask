ProtoBuf.MSBuildTask
====================

MSBuild Task for [protobuf-net](https://code.google.com/p/protobuf-net/).

The Modules
--------------------
### ProtoBuf.MSBuildTask
This contains the build task DLL and targets file.

### ProtoBuf.Project
This is a library for manipulating Visual Studio project file with necessary stuff for using `ProtoBuf.MSBuildTask`.

### ProtoBuf.ProjectInserter.WinForms
This is a GUI program that calls the library `ProtoBuf.Project` to manipulate Visual Studio project file.

System Requirement
--------------------
- Visual Studio 2010, 2012 or 2013, Professional or Express.
- .NET 4 Full
- ProtoGen binaries from [protobuf-net](https://code.google.com/p/protobuf-net/), 1.0.0.280

What it Does?
--------------------
### Convert protocol buffer files into code
- Call ProtoGen binaries to convert `.proto` files into a `.cs`

### Build a `ProtoBuf.MSBuildTask` enabled project from 
- Visual Studio
- MSBuild command line
- SharpDevelop, however, without code completion function

How to Use?
--------------------
You are recommended to use our GUI program to manipulate the project file.
It allows you to initialize the project with ProtoBuf MSBuild targets and properties.
It automatically selects the required build action when adding new `.proto` files.

1. Copy `ProtoBuf.MSBuildTask.dll` and `ProtoBuf.MSBuildTask.targets` to your project in a separate directory.
2. Launch `ProtoBuf.ProjectInserter.WinForms` program.
3. Open project, pick the C# project you wish to enable `ProtoBuf.MSBuildTask`.
4. Initialize project, pick the directories to `ProtoBuf.MSBuildTask` and `ProtoGen` binaries respectively.
   Please put `ProtoBuf.MSBuildTask` files and `ProtoGen` binaries in locations that are reachable from your repository.
   **Relative path** of the directories to these files are saved to the project file.
   If these files are located in another drive, **Absolute** path will be saved.
5. Add ProtoBuf files, pick one or more files to add.
6. Save project.

If you wish to manually add new `.proto` files to the project in Visual Studio or SharpDevelop,
remember to select `Build Action`: `ProtoBuf` and enter `Custom Tool`: `MSBuild:Compile`.

Note: Protocol files must reside in project directory or its subdirectories. `ProtoGen` does not support upper level such as `..\x.proto`.

How to Contribute?
--------------------
Development happens on github. You are welcome to open pull requests or file issues.

License
--------------------
`ProtoBuf.MSBuildTask` is licensed under MIT License.
This means you can use the library from any program, proprietary or open source.
See `License.txt` file for the full license text.
