# UXC Utilities

This repository contains utility tools for additional processing of data from UXC:
* [Selector](tree/master/src/Selector) - for splitting large data files.
* [TimestampCorrection](tree/master/src/TimestampCorrection) - for synchronizing timestamps in data.

See README of each project to find out more information:

## How to build

Prerequisities: 
* Visual Studio 2015 or 2017, or Visual Studio Build Tools
* For building from the command line, create an environment variable leading to the NuGet CLI executable `nuget.exe` with name `nuget`.

Build steps:
* Clone the repository, use the `master` branch
* Run the `build.bat`.
* The built executables are located in project's `bin/Release` directories.

## Contributing

Use [Issues](issues) to request features, report bugs, or discuss ideas.

## Dependencies

* [UXI.Filters](https://github.com/uxifiit/Filters)
* [UXI.Serialization](https://github.com/uxifiit/UXI.Serialization)
* [CommandLineParser](https://github.com/commandlineparser/commandline)
* [CsvHelper](https://github.com/JoshClose/CsvHelper)
* [Newtonsoft.Json](https://www.newtonsoft.com/json)

## Authors

* Martin Konopka - [@martinkonopka](https://github.com/martinkonopka)

## License

This project is licensed under the MIT License - see the [LICENSE.txt](LICENSE.txt) file for details

## Contacts

* UXIsk 
  * User eXperience and Interaction Research Center
  * Faculty of Informatics and Information Technologies, Slovak University of Technology in Bratislava
  * Web: https://www.uxi.sk/
* Martin Konopka
  * E-mail: martin (underscore) konopka (at) stuba (dot) sk
