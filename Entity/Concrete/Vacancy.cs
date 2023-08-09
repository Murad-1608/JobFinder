using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Vacancy : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public int ExperienceId { get; set; }
        public int EducationId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Salary { get; set; }

        public Category Category { get; set; }
        public City City { get; set; }
        public Experience Experience { get; set; }
        public Education Education { get; set; }

    }
}
