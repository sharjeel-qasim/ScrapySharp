using ScrapySharp.Console.Data;
using ScrapySharp.Console.Data.Model;

namespace ScrapySharp.Console.Repo
{
    internal static class TripAdvisorRepo
    {
        public static int CreateLocation(string locationName)
        {
            using (var _context = new TripAdvisorDBContext())
            {
                var location = new Location();
                location.Name = locationName;
                
                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                _ = _context.Location.Add(location);
                #pragma warning restore CS8602 // Dereference of a possibly null reference.
                
                return location.Id;
            }
        }

        public static void CreateLocationComments(int locationId, List<string> comments)
        {
            using (var _context = new TripAdvisorDBContext())
            {
                var locationComments = new List<LocationComment>();
                foreach (var comment in comments)
                {
                    locationComments.Add(new LocationComment
                    {
                        LocationId = locationId,
                        Comment = comment
                    });
                }

                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                _context.LocationComment.AddRange(locationComments);
                #pragma warning restore CS8602 // Dereference of a possibly null reference.
                
                _context.SaveChanges();
            }
        }
    }
}
