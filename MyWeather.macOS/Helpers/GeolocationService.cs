using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyWeather.Services
{
    public static class GeolocationService
    {
        public static async Task<Location> GetCurrentPositionAsync()
        {
            Position position = null;
            try
            {

                position = await CrossGeolocator.Current.GetLastKnownLocationAsync();

                if (position != null)
                {
                    //got a cahched position, so let's use it.
                    return new Location(position.Latitude, position.Longitude);
                }



                position = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(10));

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to get location: " + ex);
            }

            if (position == null)
                return null;

            Debug.WriteLine($"Location = {position.Latitude}, {position.Longitude} | Time: {position.Timestamp} | Accuracty {position.Accuracy}");

            return new Location(position.Latitude, position.Longitude);
        }

        public static async Task<Placemark> GetAddressAsync(Location position)
        {
            try
            {
                var addresses = await Geocoding.GetPlacemarksAsync(position);

                var address = addresses.FirstOrDefault();

                if (address == null)
                    Debug.WriteLine("No address found for position.");
                else
                    Debug.WriteLine("Addresss: {0} {1} {2}", address.Thoroughfare, address.Locality, address.CountryCode);

                return address;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to get address: " + ex);
            }

            return null;
        }
    }
}
