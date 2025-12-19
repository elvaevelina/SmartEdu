using SmartEdu.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Media;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using System.IO;
using Microsoft.Maui.Storage;

namespace SmartEdu.Services
{
    public class MauiScreenshotService : IScreenshotService
    {
        public async Task CaptureandShareAsync()
        {
            if (Screenshot.Default.IsCaptureSupported)
            {
                try
                {
                    // 1. Ambil Gambar Layar
                    IScreenshotResult screen = await Screenshot.Default.CaptureAsync();

                    // 2. Ubah jadi Stream
                    Stream stream = await screen.OpenReadAsync();

                    // 3. Simpan Stream ke File Sementara (Cache)
                    // Kita harus menyimpan file dulu karena ShareFile butuh Path, bukan Stream
                    string fileName = "smartedu_screenshot.png";
                    string filePath = Path.Combine(FileSystem.CacheDirectory, fileName);

                    using (FileStream fileStream = File.Create(filePath))
                    {
                        await stream.CopyToAsync(fileStream);
                    }

                    // 4. Panggil Fitur Share dengan Path File yang sudah disimpan
                    await Share.Default.RequestAsync(new ShareFileRequest
                    {
                        Title = "SmartEdu Screenshot",
                        File = new ShareFile(filePath)
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Screenshot Error: {ex.Message}");
                }
            }
        }
    }
}
