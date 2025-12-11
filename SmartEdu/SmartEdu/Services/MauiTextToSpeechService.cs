using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmartEdu.Shared.Services;
using Microsoft.Maui.Media;

namespace SmartEdu.Services
{
    public class MauiTextToSpeechService: ITextToSpeechService
    {
        private CancellationTokenSource? cts;

        public async Task SpeakAsync(string text)
        {
            try
            {
                await CancelAsync();

                cts = new CancellationTokenSource();

                var options = new SpeechOptions
                {
                    Volume = 1.0f,
                    Pitch = 1.0f
                };

                await TextToSpeech.Default.SpeakAsync(text, options, cts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("TTS dibatalkan oleh user.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TTS Error: {ex.Message}");
            }
        }

        public async Task CancelAsync()
        {
            try
            {
                if (cts != null && !cts.IsCancellationRequested)
                {
                    cts.Cancel();
                    cts.Dispose();
                    cts = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TTS Cancel Error: {ex.Message}");
            }
            await Task.CompletedTask;
        }
    }
}
