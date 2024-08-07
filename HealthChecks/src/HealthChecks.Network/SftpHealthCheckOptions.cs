namespace HealthChecks.Network;

public class SftpHealthCheckOptions
{
    internal Dictionary<string, SftpConfiguration> ConfiguredHosts { get; } = new();
    public SftpHealthCheckOptions AddHost(SftpConfiguration sftpConfiguration)
    {
        ConfiguredHosts.Add(sftpConfiguration.Host, sftpConfiguration);
        return this;
    }

    public SftpHealthCheckOptions WithCheckAllHosts()
    {
        CheckAllHosts = true;
        return this;
    }

    public bool CheckAllHosts { get; set; }
}
