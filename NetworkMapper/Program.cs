using NetworkMapper.Models;
using NetworkMapper.Scanner;

public class Program
{
    private static DeviceScanner deviceScanner = new DeviceScanner();
    private static List<Device> scannedDevices = new List<Device>();

    public static async Task Main(string[] args)
    {
        string defaultPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NetworkMapper");
        DirectoryInfo di = Directory.CreateDirectory(defaultPath);

        if (!di.Exists)
        {
            Console.WriteLine("Error creating directory. Please check your permissions.");
            return;
        }

        while (true)
        {
            Console.WriteLine("Welcome to Network Scanner");
            Console.WriteLine("1. Scan for devices");
            Console.WriteLine("2. View discovered devices and interfaces");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    scannedDevices = deviceScanner.ScanDevices();
                    Console.WriteLine("Scanning completed.");
                    break;
                case "2":
                    Console.WriteLine("Discovered Devices:");
                    deviceScanner.PrintDeviceInformation(scannedDevices);
                    break;
                case "3":
                    SaveScanResults(defaultPath);
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    private static void SaveScanResults(string outputPath)
    {
        deviceScanner.SaveScanResults(scannedDevices, outputPath);
    }
}