using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Vacancy> Vacancies { get; set; }
    }
}
