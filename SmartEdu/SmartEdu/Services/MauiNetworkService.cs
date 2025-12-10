using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartEdu.Shared.Services;
using Microsoft.Maui.Networking;

namespace SmartEdu.Services
{
    public class MauiNetworkService : INetworkService
    {
        public MauiNetworkService()
        {
            Connectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            ConnectivityChanged?.Invoke(e.NetworkAccess == NetworkAccess.Internet);
        }
        public bool IsConnected => Connectivity.Current.NetworkAccess == NetworkAccess.Internet;

        public event Action<bool>? ConnectivityChanged;
    }
}

