using App2.Android;
using App2.Interfaces;

[assembly: Xamarin.Forms.Dependency(
    typeof(PlatformDetails))]

namespace App2.Android
{
    public class PlatformDetails : IMyInterface
    {
        public PlatformDetails()
        {
        }
        public string GetPlatformName()
        {
            return "You are running on Android";
        }
    }
}