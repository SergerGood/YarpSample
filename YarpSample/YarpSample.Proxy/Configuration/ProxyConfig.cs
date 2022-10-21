using Microsoft.Extensions.Primitives;
using Yarp.ReverseProxy.Configuration;

namespace YarpSample.Proxy.Configuration;

public class ProxyConfig : IProxyConfig
{
    private static readonly CancellationTokenSource cts = new();
    private static readonly string clusterId = "CustomerCluster";

    public IReadOnlyList<RouteConfig> Routes { get; } = GenerateRoutes();
    public IReadOnlyList<ClusterConfig> Clusters { get; } = GenerateClusters();
    public IChangeToken ChangeToken { get; } = new CancellationChangeToken(cts.Token);

    private static List<RouteConfig> GenerateRoutes() =>
        new()
        {
            new RouteConfig
            {
                RouteId = "CustomerRoute",
                ClusterId = clusterId,
                Match = new RouteMatch
                {
                    Path = "/api/customers/{**catch-all}"
                }
            }
        };

    private static List<ClusterConfig> GenerateClusters() =>
        new()
        {
            new ClusterConfig
            {
                ClusterId = clusterId,
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    {
                        "server", new DestinationConfig
                        {
                            Address = "https://ya.ru"
                        }
                    }
                }
            }
        };
}