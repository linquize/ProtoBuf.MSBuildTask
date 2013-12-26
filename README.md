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

1. Copy `ProtoBuf.MSBuildTask.dll` and `ProtoBuf.MSBuildTask.targets` to the directory of ProtoGen binaries.
   Currently, we require the `ProtoBuf.MSBuildTask` files to be in the directory of ProtoGen binaries.
2. Launch `ProtoBuf.ProjectInserter.WinForms` program.
3. Open project, pick the C# project you wish to enable `ProtoBuf.MSBuildTask`.
4. Initialize project, pick the directory to ProtoGen binaries.
   Please put ProtoGen binaries in a location that is reachable from your repository.
   **Relative path** of the directory to ProtoGen binaries is saved to the project file.
   If ProtoGen binaries are located in another drive, **Absolute** path is saved.
5. Add files, pick one or more files to add.
6. Save project.

If you wish to manually add new `.proto` files to the project in Visual Studio or SharpDevelop,
remember to select `Build Action`: `ProtoBuf` and enter `Custom Tool`: `MSBuild:Compile`.

How to Contribute?
--------------------
Development happens on github. You are welcome to open pull requests or file issues.

License
--------------------
`ProtoBuf.MSBuildTask` is licensed under MIT License.
This means you can use the library from any program, proprietary or open source.
See `License.txt` file for the full license text.
