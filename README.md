# DoNotSleep
DoNotSleep is a tool, to prevent the computer switch to a power-safe mode, for a short period of time, without changing the global power-settings.

The tool resides in the system-tray. There are some predefined presets, which can be quickly selected to prohibit sleep for short period.


![System Tray](https://github.com/DAVIDSystems/DoNotSleep/blob/master/donotsleep/images/SystmTray.png)

Via the Settings-Menu it is possible to set the ‘do-not-sleep’ period to an exact point in time.

![Settings](https://github.com/DAVIDSystems/DoNotSleep/blob/master/donotsleep/images/settings.png)

It is also possible to awake the computer from sleep at a certain moment.

## CommandLineParameters:
### DoNotSleep.exe Parameter1 [Parameter2]

| Parameter1    | Parameter2  | Description |
| ------------- |:-----------:| -----------:|
| 10MIN         |             | sleep for 10 minutes |
| 30MIN         |             | sleep for 30 minutes |
| 1HOUR         |             | sleep for 1 hours    |
| 2HOUR         |             | sleep for 2 hours    |
| 4HOUR         |             | sleep for 4 hours    |
| 8HOUR         |             | sleep for 12 hours   |
| INFINITE      |             | sleep until 2099     |
| CUSTOM        | Datetime    |i.e “12.01.2020 00:00”	-> until 12.01.2020 00:00 |

* Parameter2 is needed only when Parameter1 => CUSTOM : ! It is a DateTime value and uses CurrentUICulture formats…

# Download Setup
* Right-Click 'Setup' and select 'save link as ...'

[Setup](https://github.com/DAVIDSystems/DoNotSleep/blob/master/donotsleep/Setup/SetupDoNotSleep.exe "Download Setup")


