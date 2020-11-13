using App2.Interfaces;
using App2.iOS;

[assembly: Xamarin.Forms.Dependency(
    typeof(PlatformDetails))]
namespace App2.iOS
{
    public class PlatformDetails : IMyInterface
    {
        public PlatformDetails()
        {
            
        }
        public string GetPlatformName()
        {
            return "You are running on IOS";
        }
    }
}