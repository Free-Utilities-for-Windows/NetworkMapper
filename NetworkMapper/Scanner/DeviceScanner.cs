using System.Net.NetworkInformation;
using System.Net.Sockets;
using NetworkMapper.Models;

namespace NetworkMapper.Scanner;

class DeviceScanner
{
    public List<Device> ScanDevices()
    {
        List<Device> devices = new List<Device>();

        try
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Tunnel &&
                    networkInterface.Description != "Teredo Tunneling Pseudo-Interface")
                {
                    Device device = new Device();
                    
                    device.Name = networkInterface.Name;
                    device.Type = networkInterface.NetworkInterfaceType.ToString();
                    device.Description = networkInterface.Description;
                    device.Speed = networkInterface.Speed;
                    device.OperationalStatus = networkInterface.OperationalStatus.ToString();
                    device.SupportsMulticast = networkInterface.SupportsMulticast;

                    byte[] macBytes = networkInterface.GetPhysicalAddress()?.GetAddressBytes();

                    if (macBytes != null && macBytes.Length == 6)
                    {
                        string macAddress = string.Join(":", macBytes.Select(b => b.ToString("X2")));
                        device.MacAddress = macAddress;
                    }
                    else
                    {
                        device.MacAddress = "00:00:00:00:00:00";
                    }

                    IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
                    foreach (UnicastIPAddressInformation ipInfo in ipProperties.UnicastAddresses)
                    {
                        if (ipInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            IpConfiguration ipConfig = new IpConfiguration
                            {
                                Address = ipInfo.Address.ToString(),
                                SubnetMask = ipInfo.IPv4Mask.ToString()
                            };

                            device.GlobalDeviceIp = ipConfig;
                        }
                    }

                    devices.Add(device);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error scanning devices: {ex.Message}");
        }

        return devices;
    }

    public void PrintDeviceInformation(List<Device> scannedDevices)
    {
        foreach (Device device in scannedDevices)
        {
            Console.WriteLine(GetDeviceInformation(device));
            Console.WriteLine(GetIpInformation(device.GlobalDeviceIp));
            Console.WriteLine($"Speed: {device.Speed}");
            Console.WriteLine($"Operational Status: {device.OperationalStatus}");
            Console.WriteLine($"Supports Multicast: {device.SupportsMulticast}");
            Console.WriteLine("-------------------------------------------");
        }
    }

    public void SaveScanResults(List<Device> scannedDevices, string outputPath)
    {
        try
        {
            string defaultFilename = $"Scan_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string newOutputPath = Path.Combine(outputPath, defaultFilename);

            using (StreamWriter writer = new StreamWriter(newOutputPath))
            {
                foreach (Device device in scannedDevices)
                {
                    writer.WriteLine(GetDeviceInformation(device));
                    writer.WriteLine(GetIpInformation(device.GlobalDeviceIp));
                    writer.WriteLine("-------------------------------------------");
                }
            }

            Console.WriteLine($"Scan results saved to: {newOutputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving scan results: {ex.Message}");
        }
    }

    private string GetDeviceInformation(Device device)
    {
        return
            $"Device Name: {device.Name}\nDevice Type: {device.Type}\nMAC Address: {device.MacAddress}";
    }

    private string GetIpInformation(IpConfiguration ipConfig)
    {
        return $"IP Address: {ipConfig.Address}\nSubnet Mask: {ipConfig.SubnetMask}";
    }
}