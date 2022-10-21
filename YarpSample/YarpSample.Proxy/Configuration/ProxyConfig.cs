using Microsoft.Extensions.Primitives;
using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.LoadBalancing;
using Yarp.ReverseProxy.Transforms;

namespace YarpSample.Proxy.Configuration;

public class ProxyConfig : IProxyConfig
{
    private static readonly CancellationTokenSource cts = new();
    private static readonly string clusterId = "customerCluster";

    public IReadOnlyList<RouteConfig> Routes { get; } = GenerateRoutes();
    public IReadOnlyList<ClusterConfig> Clusters { get; } = GenerateClusters();
    public IChangeToken ChangeToken { get; } = new CancellationChangeToken(cts.Token);

    private static List<RouteConfig> GenerateRoutes()
    {
        var routeConfig = new RouteConfig
        {
            RouteId = "customerRoute",
            ClusterId = clusterId,
            Match = new RouteMatch {Path = "{**catch-all}"}
        };
        
        routeConfig.WithTransformPathSet("/help");

        return new List<RouteConfig> {routeConfig};
    }

    private static List<ClusterConfig> GenerateClusters()
    {
        var clusterConfig = new ClusterConfig
        {
            ClusterId = clusterId,
            Destinations = new Dictionary<string, DestinationConfig>
            {
                {"customerServer1", new DestinationConfig {Address = "https://ya.ru"}},
                {"customerServer2", new DestinationConfig {Address = "https://google.ru"}}
            },
            LoadBalancingPolicy = LoadBalancingPolicies.RoundRobin
        };

        return new List<ClusterConfig> {clusterConfig};
    }
}