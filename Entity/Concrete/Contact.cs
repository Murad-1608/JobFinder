using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
