using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Business
{
    public static class Extensions
    {
        public static string HumanizeDateTime(this DateTime time)
        {
            DateTime today = DateTime.Now;

            if (time.Year == today.Year && time.Month == today.Month && time.Day == today.Day) return "today";

            if (time.DayOfYear - today.DayOfYear == 1) return "tomorrow";
            return time.ToString("dddd, dd. MMM");
        }
        public async static Task<Actor> GetActor(this ISecureStorage storage)
        {
            var actorString = await storage.GetAsync("Actor");

            if (string.IsNullOrEmpty(actorString))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<Actor>(actorString);
        }
        public static DateTime ToDateTime(this double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
 