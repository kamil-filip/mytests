using System;
using System.Threading.Tasks;

namespace Client
{
    public interface IARP
    {
        Task Load(string username, Action<bool, string> output);
        Task<string> HasAccess(string userName, string where);
        event EventHandler OnPermissionChanged;
        event EventHandler OnError;
    }
}
