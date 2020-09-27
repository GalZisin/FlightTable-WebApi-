Project contains:

 FlightTable-WebApi-
.NET core3.1 webApi (Source)

 - Build - Angular10 test app located in wwwroot folder for showing flight table.

 - Publish.rar - publish for installation on IIS 

 - FlightManagementDB.bak file

Installation publish project on IIS:

1. Download  and install .Net Core 3.1 SDK 

https://dotnet.microsoft.com/download/visual-studio-sdks

2. Download and install Hosting Bundle 

https://dotnet.microsoft.com/download/dotnet-core/3.1

3. Restore database from bak file on SQL SERVER (express edition).

4. Put publish folder on its place.

5. Add new no managed code aplicationPool.

6. Create new website on new application pool and Publish folder.
