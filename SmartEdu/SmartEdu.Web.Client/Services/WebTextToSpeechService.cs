using SmartEdu.Shared.Services;

namespace SmartEdu.Web.Client.Services
{
    public class WebTextToSpeechService : ITextToSpeechService
    {
        public Task SpeakAsync(string text)
        {
            Console.WriteLine("Text-to-Speech not implemented for Web version yet.");
            return Task.CompletedTask;
        }

        public Task CancelAsync()
        {
            return Task.CompletedTask;
        }
    }
}
