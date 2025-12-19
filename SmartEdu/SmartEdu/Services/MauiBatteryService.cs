using SmartEdu.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Devices;

namespace SmartEdu.Services
{
    public class MauiBatteryService : IBatteryService
    {
        public double GetLevel()
        {
            return Microsoft.Maui.Devices.Battery.ChargeLevel;
        }
        public string GetState()
        {
            return Microsoft.Maui.Devices.Battery.State.ToString();
        }
        public string GetPowerSource()
        {
            return Microsoft.Maui.Devices.Battery.PowerSource.ToString();
        }
    }
}
