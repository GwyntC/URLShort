using Microsoft.AspNetCore.Identity;

namespace URLShort.Models
{
    public class ApplicationUser:IdentityUser
    {
      
      // public bool IsAdmin {  get; set; }
        public ICollection<URLModel> UrlModels { get; } = new List<URLModel>();//List<URLModel> URLModels { get; set; }
    }
}
