using System.Net;

namespace NetworkMapper.Models;

public class Device
{
    public Device()
    {
        Id = Guid.NewGuid();
        GlobalDeviceIp = new IpConfiguration();
        NetworkCredential = new NetworkCredential();
    }
    
    public Guid Id { get; set; }

    private string _type;
    public string Type
    {
        get => _type;
        set => _type = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("Type cannot be null or empty.");
    }

    private string _manufacturer;
    public string Manufacturer
    {
        get => _manufacturer;
        set => _manufacturer = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("Manufacturer cannot be null or empty.");
    }

    private string _model;
    public string Model
    {
        get => _model;
        set => _model = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("Model cannot be null or empty.");
    }

    private string _name;
    public string Name
    {
        get => _name;
        set => _name = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("Name cannot be null or empty.");
    }

    private string _location;
    public string Location
    {
        get => _location;
        set => _location = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("Location cannot be null or empty.");
    }

    private string _description;
    public string Description
    {
        get => _description;
        set => _description = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("Description cannot be null or empty.");
    }

    private string _notes;
    public string Notes
    {
        get => _notes;
        set => _notes = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("Notes cannot be null or empty.");
    }
    
    private string _macAddress;
    public string MacAddress
    {
        get => _macAddress;
        set => _macAddress = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("MacAddress cannot be null or empty.");
    }
    
    private long _speed;
    public long Speed
    {
        get => _speed;
        set => _speed = value > 0 ? value : throw new ArgumentException("Speed must be greater than zero.");
    }

    private string _operationalStatus;
    public string OperationalStatus
    {
        get => _operationalStatus;
        set => _operationalStatus = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("OperationalStatus cannot be null or empty.");
    }

    private bool _supportsMulticast;
    public bool SupportsMulticast
    {
        get => _supportsMulticast;
        set => _supportsMulticast = value;
    }

    public NetworkCredential NetworkCredential { get; set; }
    public IpConfiguration GlobalDeviceIp { get; set; }
}