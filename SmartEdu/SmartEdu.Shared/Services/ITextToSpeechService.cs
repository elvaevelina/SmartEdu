using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace SmartEdu.Shared.Services
{
    public  interface ITextToSpeechService
    {
        Task SpeakAsync(string text);
        Task CancelAsync();
    }
}
