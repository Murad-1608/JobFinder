using Microsoft.AspNetCore.Identity;

namespace Entity.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public List<Tag> Tags { get; set; }
    }
}
