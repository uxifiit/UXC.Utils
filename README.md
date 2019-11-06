# UXC Utilities

This repository contains utility tools for additional processing of recording data from [UXC](https://github.com/uxifiit/UXC). 
See README in each project to find out more information:
* [TimestampCorrection](src/TimestampCorrection) - use to synchronize timestamps in data, especially eye tracking data from UXC.
* [Selector](src/Selector) - use to split large data files.

## How to build

First, install Microsoft Visual Studio 2015 or 2017 or Visual Studio Build Tools.

To build the solution using the Visual Studio: 
1. Open the `UXC.Utils.sln` in Visual Studio.
2. Set up build target to `Release`.
3. Build the solution (default hotkey <kbd>F6</kbd>).

To build the solution using the included batch script: 
1. Download [NuGet Windows Commandline](https://www.nuget.org/downloads), v4.9.x were tested.
2. Create new environment variable named `nuget` with path set to the `nuget.exe` executable, e.g., `C:\Program Files (x86)\NuGet\nuget.exe`.
3. Test the path in a new command line window with `echo %nuget%`.
4. Run the `build.bat` script.

Then, locate the build output in the `/build/Release/` directory.

## Contributing

Use [Issues](issues) to request features, report bugs, or discuss ideas.

## Dependencies

* [UXIsk Filters Framework](https://github.com/uxifiit/Filters)
* [UXIsk Data Serialization Library](https://github.com/uxifiit/UXI.Serialization)
* [CommandLineParser](https://github.com/commandlineparser/commandline)
* [CsvHelper](https://github.com/JoshClose/CsvHelper)
* [Newtonsoft.Json](https://www.newtonsoft.com/json)

## Authors

* Martin Konopka - [@martinkonopka](https://github.com/martinkonopka)

## License

This project is licensed under the 3-Clause BSD License - see the [LICENSE.txt](LICENSE.txt) file for details

Copyright (c) 2019 Martin Konopka and Faculty of Informatics and Information Technologies, Slovak University of Technology in Bratislava.

## Contacts

* UXIsk 
  * User eXperience and Interaction Research Center
  * Faculty of Informatics and Information Technologies, Slovak University of Technology in Bratislava
  * Web: https://www.uxi.sk/
* Martin Konopka
  * E-mail: martin (underscore) konopka (at) stuba (dot) sk
