using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdu.Shared.Services
{
    public interface INetworkService
    {
        bool IsConnected { get; }
        event Action<bool> ConnectivityChanged;
    }
}
