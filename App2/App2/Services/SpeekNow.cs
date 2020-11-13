using System.Threading.Tasks;
using Xamarin.Essentials;

namespace App2.Services
{
    public class SpeekNow
    {
        public async Task Speek(string city)
        {
            await TextToSpeech.SpeakAsync($"You have searched for {city}");
        }
        
    }
}