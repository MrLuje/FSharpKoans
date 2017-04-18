// include Fake lib
#r "packages/FAKE.4.57.0/tools/FakeLib.dll"
open Fake
open System

// Properties
setEnvironVar "MSBuild" @"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"

let clearConsole() = Console.Clear()
let MSBuild sln () =
    let buildMode = getBuildParamOrDefault "buildMode" "Debug"
    let setParams defaults =
            { defaults with
                Verbosity = Some MSBuildVerbosity.Quiet
                Targets = ["Build"]
                Properties =
                    [
                        "Optimize", "false"
//                        "DebugSymbols", "True"
                        "Configuration", buildMode
                    ]
                }

    build setParams sln
            |> DoNothing

let MSBuildFake sln () = 
    !! ("/**/*.fsproj")
        -- "FSharpKoans.Test/FSharpKoans.Test.fsproj"
    |> MSBuildDebug "FSharpKoans/bin/debug/" "Build"
    |> ignore
    |> DoNothing

let RunProgram path () =
    fireAndForget(fun p ->
        p.FileName <- path
    )

// Targets
Target "Default" (fun _ ->

    trace ""
    traceLine()
    traceImportant "You can now start editing the first file (AboutAsserts.fs)"
    traceLine()

    use watcher = !! "FSharpKoans/**/*.fs" |> WatchChanges (fun changes -> 
        
        clearConsole()
        |> MSBuildFake "./FSharpKoans.sln"
        |> RunProgram "FSharpKoans/bin/Debug/FSharpKoans.exe"
        
    )

    System.Console.ReadLine() |> ignore //Needed to keep FAKE from exiting
    watcher.Dispose() // Use to stop the watch from elsewhere, ie another task.
)

Target "Build" (fun _ ->
    MSBuild "./FSharpKoans.sln" ()
    |> ignore
)

Target "BuildFake" (fun _ ->
    !! ("/**/*.fsproj")
        -- "FSharpKoans.Test.fsproj"
    |> MSBuildDebug "FSharpKoans/bin/debug/" "Build"
    |> ignore
)


// Dependencies
"Default"
"Build"
"BuildFake"

// start build
RunTargetOrDefault "Default"