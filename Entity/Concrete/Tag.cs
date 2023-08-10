using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Tag : IEntity
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
