using Yarp.ReverseProxy.Configuration;

namespace YarpSample.Proxy.Configuration;

public class ProxyConfigProvider : IProxyConfigProvider
{
    public IProxyConfig GetConfig() => new ProxyConfig();
}