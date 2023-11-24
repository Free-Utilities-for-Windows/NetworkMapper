# Network Scanner

Network Scanner is a console application that scans for devices on your network and saves the results to a text file.

## Features

- Scans for devices on your network
- Prints discovered devices and their interfaces
- Saves scan results to a text file

## Usage

1. Open a command prompt as administrator.
2. Navigate to the directory containing the utility.
3. Run the utility as a command-line argument. For example:

    ```
    .\NetworkMapper.exe
    ```
4. Choose one of the following options:
   - `1. Scan for devices`: Scans for devices on your network.
   - `2. View discovered devices and interfaces`: Prints the discovered devices and their interfaces.
   - `3. Exit`: Saves the scan results to a text file and exits the program.

## Classes

- `Device`: Represents a device on your network.
- `IpConfiguration`: Represents the IP configuration of a device.
- `DeviceScanner`: Contains methods for scanning for devices and saving the results.

## Author

Bohdan Harabadzhyu

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

[MIT](https://choosealicense.com/licenses/mit/)
