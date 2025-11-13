using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdu.Shared.Services
{
    public static class ApiHelper
    {
        public static string GetBaseUrl()
        {
#if DEBUG
            // Jalankan otomatis sesuai konteks:
            // Jika app berjalan di port web (7130) → panggil backend 7194
            // Jika app berjalan langsung dari Windows → tetap ke 7194
            return "https://localhost:7194/";
#else
            // Saat nanti dipublish (production)
            // ubah ke URL server API sebenarnya
            return "https://localhost:7130/";
#endif
        }
    }

}
