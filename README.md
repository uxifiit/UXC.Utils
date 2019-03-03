# UXC.Utils

###### Utility and support tools for UXC.


## TimestampCorrection

This tool corrects timestamped data by other reference timestamp.
It can be used to correct UXC generated timestamps in gaze data based on the timestamps given by the eye tracker.

Each gaze data recorded with UXC contains two separate timestamps (see [wikipage for UXC Eye Tracker device](https://github.com/uxifiit/uxc/wiki):
* `TrackerTicks` (microseconds) - timestamp set by the eye tracker when the gaze data was processed, and
* `Timestamp` (DateTime) - timestamp set by the UXC when the gaze data event was received from the tracker.

Consecutive events can have same `Timestamp` value assigned by the UXC, because data could have been throttled by the eye tracker. If this timestamp is used for further data processing, e.g., fixation filtering, the result will be inherently incorrect.
Values in `TrackerTicks` are correctly spaced in time by the eye tracker, but we often do not know the start timestamp they are relative to.

`TimestampCorrection` can be used to compute minimum difference between ticks in `TrackerTicks` and `Timestamp` and recalculate `Timestamp` values from the `TrackerTicks` by adding the mininum difference.
Statistics of changes made are written to the log file.

### Usage example

To correct gaze data in JSON file from UXC, launch the program with the following command line arguments to set:
* input file with UXC gaze data to `ET_data.json` file in `JSON` format,
* output data to `ET_data.fixed.json` file in `JSON` format, 
* write log to `ET_data.log.csv` file in `CSV` format,
* field for the target timestamps to correct is in data with name `Timestamp` and format `date`,
* field for the reference timestamps used for correction is in data with name `TrackerTicks` and format `ticks:us` (microseconds).

```
TimestampCorrection.exe ET_data.json ^
--format JSON ^
--output ET_data.fixed.json ^
--output-format JSON ^
--log-format CSV ^
--log ET_data.log.csv ^
--timestamp-field Timestamp ^
--timestamp-format date ^
--reference-timestamp-field TrackerTicks ^
--reference-timestamp-format ticks:us
```

Note, the character `^` only breaks up long Windows command line on multiple lines for readability.


## How to build

Prerequisities: 
* Visual Studio 2015 or 2017, or Visual Studio Build Tools
* For building from the command line, create an environment variable leading to the NuGet CLI executable `nuget.exe` with name `nuget`.

Build steps:
* Clone the repository, use the `master` branch
* Run the `build.bat` with VS 2015 installed or `build.2017.bat` with VS 2017.
* The built executables are located in project's `bin/Release` directories.

## Contributing

Use [Issues](issues) to request features, report bugs, or discuss ideas.

## Dependencies

* [UXI.Libs](https://github.com/uxifiit/UXI.Libs)
* [UXI.GazeToolkit](https://github.com/uxifiit/UXI.GazeToolkit/)
* [CsvHelper](https://github.com/JoshClose/CsvHelper)
* [CommandLineParser](https://github.com/commandlineparser/commandline)
* [Newtonsoft.Json](https://www.newtonsoft.com/json)
* and others

## Authors

* Martin Konopka - [@martinkonopka](https://github.com/martinkonopka)

## License

This project is licensed under the MIT License - see the [LICENSE.txt](LICENSE.txt) file for details

## Contacts

* UXIsk 
  * User eXperience and Interaction Research Center, Faculty of Informatics and Information Technologies, Slovak University of Technology in Bratislava
  * Web: https://www.uxi.sk/
* Martin Konopka
  * E-mail: martin (underscore) konopka (at) stuba (dot) sk
