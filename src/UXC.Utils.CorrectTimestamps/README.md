# CorrectTimestamps

This tool corrects timestamps in data by aligning them to other reference timestamps.
It can be used to correct UXC generated timestamps in gaze data based on the timestamps given by the eye tracker.

Each sample of gaze data recorded with UXC contains 2 different timestamps, one originated from the eye tracker, another from the UXC app (see [wikipage for UXC Eye Tracker device](https://github.com/uxifiit/UXC/wiki/Eye-Tracker-Device):
* `TrackerTicks` (microseconds) - timestamp set by the eye tracker when the gaze data was processed, and
* `Timestamp` (DateTime) - timestamp set by the UXC when the gaze data event was received from the tracker.

Consecutive events may have same `Timestamp` value assigned by the UXC, if data were throttled by the eye tracker client. If this timestamp is used for further data processing, e.g., fixation filtering, the result will be inherently incorrect.
However, values in `TrackerTicks` are correctly spaced in time by the eye tracker, although they originate from an arbitrary point in time (not exactly 01/01/1970 epoch).

The *CorrectTimestamps* tool computes minimum difference between ticks in `TrackerTicks` and `Timestamp` and recalculates `Timestamp` values from the `TrackerTicks` by adding the mininum difference.
Statistics of changes made are written to the log file.

## Usage

To correct gaze data in JSON file from UXC, launch the program with the following command line arguments. Note, the character `^` only breaks up a long Windows command line for readability:

```
CorrectTimestamps.exe ET_data.json ^
--format JSON ^
--timestamp-field Timestamp ^
--timestamp-format date ^
--reference-timestamp-field TrackerTicks ^
--reference-timestamp-format ticks:us
--log-format CSV ^
--log ET_data.log.csv ^
--output ET_data.fixed.json ^
```

Description of used parameters:
* `ET_data.json` - path to the input file with array of UXC GazeData objects; if omitted, the standard input stream is used.
* `--format` - format of the input data, can be omitted if the file with `.json` or `.csv` extension is used; it is required when data is read from the standard input stream.
* `--timestamp-field` - name of the attribute with timestamps to correct.
* `--timestamp-format` - format of timestamps in the target timestamp attribute, see [Timestamp formats in the UXIsk Filters Framework](https://github.com/uxifiit/Filters#timestamp-formats) for supported values. 
* `--reference-timestamp-field` - name of the attribute with reference timestamps to use for correction.
* `--reference-timestamp-format` - similar to `--timestamp-format` but for reference timestamps. 
* `--log-format` - format of the log output, either CSV or JSON, can be omitted if the log file is set with these extensions.
* `--log` - path to the log file, if omitted, the standard error stream is used.
* `--output` - path to the output file in the same format as input (set with `--format`).

Use `--help` option to see all available options.


## Authors

* Martin Konopka - [@martinkonopka](https://github.com/martinkonopka)

## License

This project is licensed under the 3-Clause BSD License - see the [LICENSE.txt](..\..\LICENSE.txt) file for details

Copyright (c) 2019 Martin Konopka and Faculty of Informatics and Information Technologies, Slovak University of Technology in Bratislava.

## Contacts

* UXIsk 
  * User eXperience and Interaction Research Center
  * Faculty of Informatics and Information Technologies, Slovak University of Technology in Bratislava
  * Web: https://www.uxi.sk/
* Martin Konopka
  * E-mail: martin (underscore) konopka (at) stuba (dot) sk
