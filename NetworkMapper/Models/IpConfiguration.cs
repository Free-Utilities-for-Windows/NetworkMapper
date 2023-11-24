namespace NetworkMapper.Models;

public class IpConfiguration
{
    private List<string> _dnsHosts;

    public IpConfiguration()
    {
        _dnsHosts = new List<string>();
        VlanId = 1;
    }

    private string _address;

    public string Address
    {
        get => _address;
        set => _address = IsValidIpAddress(value) ? value : throw new ArgumentException("Invalid IP Address.");
    }

    private string _subnetMask;

    public string SubnetMask
    {
        get => _subnetMask;
        set => _subnetMask = IsValidIpAddress(value) ? value : throw new ArgumentException("Invalid Subnet Mask.");
    }

    private string _defaultGateway;

    public string DefaultGateway
    {
        get => _defaultGateway;
        set => _defaultGateway =
            IsValidIpAddress(value) ? value : throw new ArgumentException("Invalid Default Gateway.");
    }

    public IReadOnlyList<string> DnsHosts => _dnsHosts;

    private int _vlanId;

    public int VlanId
    {
        get => _vlanId;
        set => _vlanId = (value >= 1 && value <= 4094)
            ? value
            : throw new ArgumentException("Invalid VLAN ID. Valid range is 1-4094.");
    }

    public void AddDnsHost(string dnsHost)
    {
        _dnsHosts.Add(dnsHost);
    }

    public void RemoveDnsHost(string dnsHost)
    {
        _dnsHosts.Remove(dnsHost);
    }

    private bool IsValidIpAddress(string ipAddress)
    {
        System.Net.IPAddress ip;
        return System.Net.IPAddress.TryParse(ipAddress, out ip);
    }
}