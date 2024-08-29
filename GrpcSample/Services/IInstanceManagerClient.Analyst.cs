using Shared;

namespace GrpcSample
{
    public interface IInstanceManagerClient
    {
        Task<IDictionary<int, AttachableProcess>> GetProcessesAsync();
        void Connect(string filename, Action<Location> locationUpdatedByServer);
        void ReportLocation(Location location);
        Task SubscribeAsync(int processId);
        void Disconnect();
    }
}
