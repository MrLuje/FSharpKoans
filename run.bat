echo off
cls


.nuget\nuget.exe install "FsharpKoans\packages.config" -OutputDirectory "packages"
if errorlevel 1 (
  exit /b %errorlevel%
)

"packages\FAKE.4.57.0\tools\Fake.exe" tests.fsx
pause